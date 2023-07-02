using Fiotec.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fiotec.Prova.Application.ViewModels
{
    public class RelatorioVM
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public Guid SolicitanteId { get; set; }        
        public DateTime DataSolicitacao { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAplicacaoVacina { get; set; }
        public long QuantidadeVacinados { get; set; }
        public virtual SolicitanteVM Solicitante { get; set; }
    }
}
