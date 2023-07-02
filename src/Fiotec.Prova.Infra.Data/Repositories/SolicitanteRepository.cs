using Fiotec.Prova.Domain.Entities;
using Fiotec.Prova.Domain.Interfaces.Repository;
using Fiotec.Prova.Infra.Data.Base;
using Fiotec.Prova.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.Repositories
{
    public class SolicitanteRepository : RepositoryBase<Solicitante>, ISolicitanteRepository
    {
        private readonly SqlContext _context;

        public SolicitanteRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Solicitante> ObterPorCpf(string cpf)
        {
            return await _context.Set<Solicitante>().Where(x => x.Cpf == cpf).AsNoTracking().FirstOrDefaultAsync();
        }

        public void Adicionar(Solicitante solicitante)
        {
            _context.Set<Solicitante>().Add(solicitante);
        }
    }
}
