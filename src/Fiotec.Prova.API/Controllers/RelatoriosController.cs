using Fiotec.Prova.Application.InputModel;
using Fiotec.Prova.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiotec.Prova.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatoriosController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        /// <summary>
        /// Obter todos os relatórios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("relatorios")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _relatorioService.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Solicita relatório
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("relatorios")]
        public async Task<IActionResult> Post(RelatorioIM relatorio)
        {
            if (string.IsNullOrEmpty(relatorio.Cpf) || relatorio.Cpf == "string")
                return BadRequest("Favor informar o CPF");

            if (string.IsNullOrEmpty(relatorio.Nome) || relatorio.Nome == "string")
                return BadRequest("Favor informar o Nome");

            if(relatorio.DataAplicacao == DateOnly.MinValue)
                return BadRequest("Favor informar a Data da Aplicação");

            try
            {
                var retorno = await _relatorioService.SolicitaRelatorio(relatorio);

                if(retorno == null)
                    return Ok("Nenhum registro encontrado para a dataAplicacao informada.");

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
