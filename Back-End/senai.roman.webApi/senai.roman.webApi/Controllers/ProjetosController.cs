using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.roman.webApi.Domains;
using senai.roman.webApi.Interfaces;
using senai.roman.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.roman.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "1")]
    public class ProjetosController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }


        /// <summary>
        /// Instancia o objeto _projetoRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public ProjetosController()
        {
            _projetoRepository = new ProjetoRepository();
        }

        /// <summary>
        /// Lista todos os Projetos
        /// </summary>
        /// <returns>Uma lista de projetos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_projetoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }


        /// <summary>
        /// Cadastra um novo projeto
        /// </summary>
        /// <param name="novoProjeto"> objeto com o projeto a ser cadastrado</param>
        /// <returns> status code 201 </returns>
        [HttpPost]
        public IActionResult Cadastro(Projeto novoProjeto)
        {
            try
            {
                _projetoRepository.Cadastrar(novoProjeto);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
            
        }
    }
}
