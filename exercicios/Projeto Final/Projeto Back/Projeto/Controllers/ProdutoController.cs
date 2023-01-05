using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Model;

namespace Projeto.Controllers
{
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("produtos")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var produtos = await contexto.produtos.AsNoTracking().ToListAsync();
            return produtos == null ? NotFound() : Ok(produtos);
        }

        [HttpGet]
        [Route("produtos/{id}")]
        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            var produtos = await contexto.produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ID == id);
            return produtos == null ? NotFound() : Ok(produtos);
        }

        [HttpPost, Authorize(Roles = "Admin,Estoque")]
        [Route("produtos")]
        public async Task<IActionResult> postAsync([FromServices] Contexto contexto, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await contexto.produtos.AddAsync(produto);
                await contexto.SaveChangesAsync();
                return Created($"api/produtos/{produto.ID}", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Authorize(Roles = "Admin,Estoque")]
        [Route("produtos/{id}")]
        public async Task<IActionResult> putAsync([FromServices] Contexto contexto, [FromBody] Produto produto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var p = await contexto.produtos.FirstOrDefaultAsync(p => p.ID == id);

            if (p == null)
            {
                return NotFound();
            }

            try
            {
                p.nome = produto.nome;
                p.preco = produto.preco;
                contexto.produtos.Update(p);
                await contexto.SaveChangesAsync();
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Authorize(Roles = "Admin,Estoque")]
        [Route("produtos/{id}")]
        public async Task<IActionResult> deleteAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var p = await contexto.produtos.FirstOrDefaultAsync(p => p.ID == id);

            if (p == null)
            {
                return NotFound();
            }

            try
            {
                p.ativo = false;
                contexto.produtos.Update(p);
                await contexto.SaveChangesAsync();
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
