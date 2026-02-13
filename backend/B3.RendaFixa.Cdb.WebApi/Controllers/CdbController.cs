using Asp.Versioning;
using B3.RendaFixa.Cdb.Aplicacao.DTOs;
using B3.RendaFixa.Cdb.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B3.RendaFixa.Cdb.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CdbController : ControllerBase
    {
        private readonly ICalcularCdb _servico;

        public CdbController(ICalcularCdb servico)
        {
            _servico = servico;
        }

        [HttpPost]
        public async Task<ActionResult<CdbResposta>> Calcular([FromBody] CdbRequisicao request, CancellationToken ct)
        {
            var resultado = await _servico.CalcularAsync(request, ct);

            if (resultado.EhFalha)
                return BadRequest(new { erro = resultado.Erro });

            return Ok(resultado.Valor);
        }
    }
}
