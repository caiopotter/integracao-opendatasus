using Fiotec.Prova.Application.Middlewares.AutoMapper;
using Fiotec.Prova.Application.Services;
using Fiotec.Prova.Application.Services.Interfaces;
using Fiotec.Prova.Domain.Core;
using Fiotec.Prova.Domain.Interfaces.Repository;
using Fiotec.Prova.Infra.Data.Context;
using Fiotec.Prova.Infra.Data.Repositories;
using Fiotec.Prova.Infra.Data.Rest.DataSus;
using Fiotec.Prova.Infra.Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IRelatorioService, RelatorioService>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<ISolicitanteRepository, SolicitanteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDataSusService, DataSusService>();
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));            
        }
    }
}
