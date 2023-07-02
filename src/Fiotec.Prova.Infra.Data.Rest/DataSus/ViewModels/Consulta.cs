using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Fiotec.Prova.Infra.Data.Rest.DataSus.ViewModels.Consulta;

namespace Fiotec.Prova.Infra.Data.Rest.DataSus.ViewModels
{
    public class Consulta
    {
        public int took { get; set; }
        public bool timed_out { get; set; }
        public Shards _shards { get; set; }
        public Hits hits { get; set; }
    }
}
