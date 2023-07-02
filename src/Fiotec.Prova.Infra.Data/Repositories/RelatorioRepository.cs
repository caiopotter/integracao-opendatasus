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
    public class RelatorioRepository : RepositoryBase<Relatorio>, IRelatorioRepository
    {
        private readonly SqlContext _context;

        public RelatorioRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Relatorio>> ObterTodos()
        {
            return await _context.Set<Relatorio>().Include(x => x.Solicitante).AsNoTracking().OrderByDescending(x => x.DataSolicitacao).ToListAsync();
        }

        public async Task<Relatorio> ObterPorId(Guid id)
        {
            return await _context.Set<Relatorio>().Include(x => x.Solicitante).Where(x => x.Id == id).AsNoTracking().FirstAsync();
        }

        public void Adicionar(Relatorio relatorio)
        {
            _context.Set<Relatorio>().Add(relatorio);            
        }
    }
}
