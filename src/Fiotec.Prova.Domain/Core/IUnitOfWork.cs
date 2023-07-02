using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        bool Commit();
        void Rollback();
    }
}
