using AutoMapper;
using Fiotec.Prova.Application.ViewModels;
using Fiotec.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Application.Middlewares.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RelatorioVM, Relatorio>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<SolicitanteVM, Solicitante>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
