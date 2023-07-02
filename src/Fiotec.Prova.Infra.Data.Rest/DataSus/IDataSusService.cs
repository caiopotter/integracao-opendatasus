using Fiotec.Prova.Infra.Data.Rest.DataSus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.Rest.DataSus
{
    public interface IDataSusService
    {
        Consulta ObtemRegistros();
    }
}
