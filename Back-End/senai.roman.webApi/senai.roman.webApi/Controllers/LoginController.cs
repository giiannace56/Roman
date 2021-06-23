using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.roman.webApi.Domains;
using senai.roman.webApi.Interfaces;
using senai.roman.webApi.Repositories;
using senai.roman.webApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.roman.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _habilidadeRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]

        public IActionResult Logar(LoginViewModel login)
        {
            try
            {



                Usuario usuarioBuscado = _usuarioRepository.Logar(login.email, login.senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha invalidos!");
                }

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email) ,
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome)
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "Roman.webApi",
                        audience: "Roman.webApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: creds
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro); ;
            }
        }
    }
}