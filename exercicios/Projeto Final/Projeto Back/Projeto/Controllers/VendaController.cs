using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Model;

namespace Projeto.Controllers
{
    public class VendaController : ControllerBase
    {
        [HttpGet, Authorize(Roles = "Admin,Vendas")]
        [Route("vendas")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var vendas = await contexto.vendas.AsTracking().ToListAsync();
            return vendas == null ? NotFound() : Ok(vendas);
        }

        [HttpPost, Authorize(Roles = "Admin,Vendas")]
        [Route("vendas")]
        public async Task<IActionResult> postAsync([FromServices] Contexto contexto, [FromBody] Venda venda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {

                venda.valor = venda.preco * venda.quantidade;
                await contexto.vendas.AddAsync(venda);
                await contexto.SaveChangesAsync();
                return Created($"api/vendas/{venda.ID}", venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
