using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Model;

namespace Projeto.Controllers
{
    public class ClienteController : ControllerBase
    {
        [HttpGet, Authorize]
        [Route("clientes")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var clientes = await contexto.clientes.AsNoTracking().ToListAsync();
            return clientes == null ? NotFound() : Ok(clientes);
        }

        [HttpGet, Authorize]
        [Route("clientes/{id}")]
        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            var clientes = await contexto.clientes.AsNoTracking().FirstOrDefaultAsync(c => c.ID == id);
            return clientes == null ? NotFound() : Ok(clientes);
        }

        [HttpPost, Authorize]
        [Route("clientes")]
        public async Task<IActionResult> postAsync([FromServices] Contexto contexto, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await contexto.clientes.AddAsync(cliente);
                await contexto.SaveChangesAsync();
                return Created($"api/clientes/{cliente.ID}", cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Authorize]
        [Route("clientes/{id}")]
        public async Task<IActionResult> putAsync([FromServices] Contexto contexto, [FromBody] Cliente cliente, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var c = await contexto.clientes.FirstOrDefaultAsync(c => c.ID == id);

            if (c == null)
            {
                return NotFound();
            }

            try
            {
                c.nome = cliente.nome;
                c.cpf = cliente.cpf;
                contexto.clientes.Update(c);
                await contexto.SaveChangesAsync();
                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("clientes/{id}")]
        public async Task<IActionResult> deleteAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var c = await contexto.clientes.FirstOrDefaultAsync(c => c.ID == id);

            if (c == null)
            {
                return NotFound();
            }

            try
            {
                c.ativo = false;
                contexto.clientes.Update(c);
                await contexto.SaveChangesAsync();
                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
