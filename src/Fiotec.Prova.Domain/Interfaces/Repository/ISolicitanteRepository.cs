using Fiotec.Prova.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiotec.Prova.Domain.Interfaces.Repository
{
    public interface ISolicitanteRepository
    {
        Task<Solicitante> ObterPorCpf(string cpf);
        void Adicionar(Solicitante solicitante);
    }
}
