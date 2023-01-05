using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Model;
using System.Data;

namespace Projeto.Controllers
{
    public class FuncionarioController : ControllerBase
    {
        [HttpGet]
        [Route("funcionarios")]
        public async Task<IActionResult> getAllAsync([FromServices] Contexto contexto)
        {
            var funcionarios = await contexto.funcionarios.AsNoTracking().ToListAsync();
            return funcionarios == null ? NotFound() : Ok(funcionarios);
        }

        [HttpGet, Authorize(Roles = "Admin,RH")]
        [Route("funcionarios/{id}")]
        public async Task<IActionResult> getByIdAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            var funcionarios = await contexto.funcionarios.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return funcionarios == null ? NotFound() : Ok(funcionarios);
        }

        [HttpPost]
        [Route("funcionarios")]
        public async Task<IActionResult> postAsync([FromServices] Contexto contexto, [FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await contexto.funcionarios.AddAsync(funcionario);
                await contexto.SaveChangesAsync();
                return Created($"api/funcionarios/{funcionario.Id}", funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("funcionarios/{id}")]
        public async Task<IActionResult> putAsync([FromServices] Contexto contexto, [FromBody] Funcionario funcionario, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var c = await contexto.funcionarios.FirstOrDefaultAsync(c => c.Id == id);

            if (c == null)
            {
                return NotFound();
            }

            try
            {
                c.Nome = funcionario.Nome;
                c.Username = funcionario.Username;
                c.Telefone = funcionario.Telefone;
                c.Permissao = funcionario.Permissao;
                contexto.funcionarios.Update(c);
                await contexto.SaveChangesAsync();
                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Authorize(Roles = "Admin,RH")]
        [Route("funcionarios/{id}")]
        public async Task<IActionResult> deleteAsync([FromServices] Contexto contexto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var c = await contexto.funcionarios.FirstOrDefaultAsync(c => c.Id == id);

            if (c == null)
            {
                return NotFound();
            }

            try
            {
                c.Ativo = false;
                contexto.funcionarios.Update(c);
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
