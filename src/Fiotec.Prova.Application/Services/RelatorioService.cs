using AutoMapper;
using Azure.Core;
using Fiotec.Prova.Application.InputModel;
using Fiotec.Prova.Application.Services.Interfaces;
using Fiotec.Prova.Application.ViewModels;
using Fiotec.Prova.Domain.Core;
using Fiotec.Prova.Domain.Core.Notification;
using Fiotec.Prova.Domain.Entities;
using Fiotec.Prova.Domain.Interfaces.Repository;
using Fiotec.Prova.Infra.Data.Rest.DataSus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Application.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly ISolicitanteRepository _solicitanteRepository;
        public readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IDataSusService _dataSusService;

        public RelatorioService(IUnitOfWork unitOfWork, IRelatorioRepository relatorioRepository, ISolicitanteRepository solicitanteRepository, IConfiguration configuration, IMapper mapper, IDataSusService dataSusService)
        {
            _unitOfWork = unitOfWork;
            _relatorioRepository = relatorioRepository;
            _solicitanteRepository = solicitanteRepository;
            _configuration = configuration;
            _mapper = mapper;
            _dataSusService = dataSusService;
        }

        public async Task<IEnumerable<RelatorioVM>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<RelatorioVM>>(await _relatorioRepository.ObterTodos());
        }

        public async Task<RelatorioVM> SolicitaRelatorio(RelatorioIM relatorio)
        {
            var solicitante = _solicitanteRepository.ObterPorCpf(relatorio.Cpf);
            var registros = _dataSusService.ObtemRegistros();

            if (registros != null)
            {
                var dataConsulta = relatorio.DataAplicacao;

                var vacinados = registros.hits.hits
                    .Where(x => x._source.estabelecimento_uf.Equals("RJ") &&
                            x._source.vacina_fabricante_nome.Equals("PFIZER") &&
                            x._source.vacina_dataAplicacao == dataConsulta.ToDateTime(TimeOnly.Parse("00:00")))
                    .ToList();

                if (vacinados.Count == 0)
                    return null;

                if (solicitante.Result != null)
                {
                    _unitOfWork.BeginTransaction();
                    var novoRelatorio = new Relatorio(solicitante.Result.Id, DateTime.Now, $"Relatório Vacinas Pfizer aplicadas no RJ_{string.Format("{0}-{1}-{2}", dataConsulta.Year, dataConsulta.Month, dataConsulta.Day)}", DateTime.Now, vacinados.Count());
                    _relatorioRepository.Adicionar(novoRelatorio);
                    if (_unitOfWork.Commit())
                        return _mapper.Map<RelatorioVM>(await _relatorioRepository.ObterPorId(novoRelatorio.Id));
                }
                else
                {
                    _unitOfWork.BeginTransaction();
                    var novoSolicitante = new Solicitante(relatorio.Nome, relatorio.Cpf);
                    _solicitanteRepository.Adicionar(novoSolicitante);

                    var novoRelatorio = new Relatorio(novoSolicitante.Id, DateTime.Now, $"Relatório Vacinas Pfizer aplicadas no RJ_{string.Format("{0}-{1}-{2}", dataConsulta.Year, dataConsulta.Month, dataConsulta.Day)}", DateTime.Now, vacinados.Count());
                    _relatorioRepository.Adicionar(novoRelatorio);
                    if (_unitOfWork.Commit())
                        return _mapper.Map<RelatorioVM>(await _relatorioRepository.ObterPorId(novoRelatorio.Id));
                }
            }

            return null;
        }
    }
}
