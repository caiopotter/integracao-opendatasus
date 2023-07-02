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
    public class RelatorioMapping : IEntityTypeConfiguration<Relatorio>
    {
        public void Configure(EntityTypeBuilder<Relatorio> builder)
        {
            builder.HasKey(r => r.Id);
            builder.ToTable("Relatorio");

            builder.Property(r => r.Id).IsRequired();
            builder.Property(r => r.SolicitanteId).IsRequired();
            builder.Property(r => r.DataSolicitacao).HasColumnType("datetime").IsRequired();
            builder.Property(r => r.Descricao).HasColumnType("varchar(500)").IsRequired();
            builder.Property(r => r.DataAplicacaoVacina).HasColumnType("datetime").IsRequired();
            builder.Property(r => r.QuantidadeVacinados).IsRequired();

            builder
                .HasOne(x => x.Solicitante)
                .WithMany(x => x.Relatorios)
                .HasForeignKey(x => x.SolicitanteId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
