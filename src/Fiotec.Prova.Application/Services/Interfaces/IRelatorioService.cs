using Fiotec.Prova.Application.InputModel;
using Fiotec.Prova.Application.ViewModels;
using Fiotec.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Application.Services.Interfaces
{
    public interface IRelatorioService
    {
        Task<IEnumerable<RelatorioVM>> ObterTodos();
        Task<RelatorioVM> SolicitaRelatorio(RelatorioIM relatorio);
    }
}
