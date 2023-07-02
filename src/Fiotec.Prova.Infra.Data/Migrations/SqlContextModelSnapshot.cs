﻿// <auto-generated />
using System;
using Fiotec.Prova.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiotec.Prova.Infra.Data.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiotec.Prova.Domain.Entities.Relatorio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAplicacaoVacina")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<long>("QuantidadeVacinados")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SolicitanteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SolicitanteId");

                    b.ToTable("Relatorio", (string)null);
                });

            modelBuilder.Entity("Fiotec.Prova.Domain.Entities.Solicitante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Solicitante", (string)null);
                });

            modelBuilder.Entity("Fiotec.Prova.Domain.Entities.Relatorio", b =>
                {
                    b.HasOne("Fiotec.Prova.Domain.Entities.Solicitante", "Solicitante")
                        .WithMany("Relatorios")
                        .HasForeignKey("SolicitanteId")
                        .IsRequired();

                    b.Navigation("Solicitante");
                });

            modelBuilder.Entity("Fiotec.Prova.Domain.Entities.Solicitante", b =>
                {
                    b.Navigation("Relatorios");
                });
#pragma warning restore 612, 618
        }
    }
}