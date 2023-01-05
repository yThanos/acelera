using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Projeto.Data;
using Projeto.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user, [FromServices] Contexto contexto)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            var funcionario = await contexto.funcionarios.AsNoTracking().FirstOrDefaultAsync(c => c.Username == user.UserName);
            if (funcionario == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.Password == funcionario.Senha)
            {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>{};
                claims.Add(new Claim("nome", funcionario.Nome));

                if (funcionario.Permissao == "Admin")
                {
                    claims.Add(new Claim("login", user.UserName));
                    claims.Add(new Claim("role", "Admin"));
                } else if (funcionario.Permissao == "Estoque")
                {
                    claims.Add(new Claim("name", user.UserName));
                    claims.Add(new Claim("role", "Estoque"));
                } else if (funcionario.Permissao == "Vendas")
                {
                    claims.Add(new Claim("name", user.UserName));
                    claims.Add(new Claim("role", "Vendas"));
                } else if (funcionario.Permissao == "RH")
                {
                    claims.Add(new Claim("name", user.UserName));
                    claims.Add(new Claim("role", "RH"));
                }

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7087",
                    audience: "https://localhost:7087",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
