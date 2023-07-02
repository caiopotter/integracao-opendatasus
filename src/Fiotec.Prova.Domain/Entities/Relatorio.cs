using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Domain.Entities
{
    public class Relatorio : BaseEntity
    {
        public Guid SolicitanteId { get; private set; }
        public DateTime DataSolicitacao { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataAplicacaoVacina { get; private set; }
        public long QuantidadeVacinados { get; private set; }
        public virtual Solicitante Solicitante { get; private set; }
        
        private Relatorio() { }

        public Relatorio(Guid solicitanteId, DateTime dataSolicitacao, string descricao, DateTime dataAplicacaoVacina, long quantidadeVacinados)
        {
            SolicitanteId = solicitanteId;
            DataSolicitacao = dataSolicitacao;
            Descricao = descricao;
            DataAplicacaoVacina = dataAplicacaoVacina;
            QuantidadeVacinados = quantidadeVacinados;            
        }
    }
}
