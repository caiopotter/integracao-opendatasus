using Fiotec.Prova.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.Mappings
{
    public class SolicitanteMapping : IEntityTypeConfiguration<Solicitante>
    {
        public void Configure(EntityTypeBuilder<Solicitante> builder)
        {
            builder.HasKey(s => s.Id);
            builder.ToTable("Solicitante");
            
            builder.Property(s => s.Nome).HasColumnType("varchar(50)").IsRequired();
            builder.Property(s => s.Cpf).HasColumnType("varchar(11)").IsRequired();

            builder
                .HasMany(x => x.Relatorios)
                .WithOne(x => x.Solicitante)
                .HasForeignKey(x => x.SolicitanteId)
                .OnDelete(DeleteBehavior.ClientSetNull);                
        }
    }
}
