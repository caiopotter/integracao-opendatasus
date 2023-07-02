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
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Relatorio, RelatorioVM>().IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Solicitante, SolicitanteVM>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
