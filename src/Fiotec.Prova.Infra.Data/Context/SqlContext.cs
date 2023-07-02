using Fiotec.Prova.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SolicitanteMapping());
            modelBuilder.ApplyConfiguration(new RelatorioMapping());
        }
    }
}
