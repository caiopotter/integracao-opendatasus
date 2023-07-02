using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.Rest.DataSus.ViewModels
{
    public class Hits
    {
        public string _index { get; set; }
        public string _type { get; set; }
        public string _id { get; set; }
        public double _score { get; set; }
        public Source _source { get; set; }
        public Total total { get; set; }
        public double max_score { get; set; }
        public List<Hits> hits { get; set; }
    }
}
