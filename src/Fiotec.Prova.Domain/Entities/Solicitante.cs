using Fiotec.Prova.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Fiotec.Prova.Domain.Entities
{
    public class Solicitante : BaseEntity
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }       

        public virtual ICollection<Relatorio> Relatorios { get; private set; }

        private Solicitante() { }

        public Solicitante(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;            
        }        
    }
}
