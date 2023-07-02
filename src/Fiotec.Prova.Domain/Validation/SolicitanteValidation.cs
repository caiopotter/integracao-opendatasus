using Fiotec.Prova.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Domain.Validation
{
    public class SolicitanteValidation : AbstractValidator<Solicitante>
    {
        public SolicitanteValidation() {
            RuleFor(x => x.Cpf).NotEmpty().WithMessage("O CPF não pode ser vazio!");
            RuleFor(x => x.Cpf).MinimumLength(11).WithMessage("O CPF não pode ser ter menos que 11 números!");
            RuleFor(x => x.Cpf).MaximumLength(11).WithMessage("O CPF não pode ser ter mais que 11 números!");            

            RuleFor(x => x.Nome).NotEmpty().WithMessage("O Nome não pode ser vazio!");
            RuleFor(x => x.Nome).MinimumLength(3).WithMessage("O Nome não pode ter menos que 3 caracteres!");
            RuleFor(x => x.Nome).MaximumLength(50).WithMessage("O Nome não pode ter mais que 50 caracteres!");
        }
    }
}
