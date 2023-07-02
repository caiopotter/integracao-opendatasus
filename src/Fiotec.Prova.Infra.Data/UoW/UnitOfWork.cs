using Fiotec.Prova.Domain.Core;
using Fiotec.Prova.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlContext _context;

        public UnitOfWork(SqlContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public bool Commit()
        {
            try
            {
                _context.SaveChanges();
                _context.Database.CurrentTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Rollback();
                return false;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _context.Database.CurrentTransaction?.Dispose();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
            Dispose();
        }
    }
}
