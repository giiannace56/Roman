using Microsoft.EntityFrameworkCore;
using senai.roman.webApi.Contexts;
using senai.roman.webApi.Domains;
using senai.roman.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.roman.webApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        RomanContext ctx = new RomanContext();

        /// <summary>
        /// Cadastra um novo projeto
        /// </summary>
        /// <param name="novoProjeto">novo projeto a ser criado</param>
        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }


        /// <summary>
        /// Lista todos os projetos
        /// </summary>
        /// <returns>Uma lista de projetos</returns>
        public List<Projeto> Listar()
        {
            return ctx.Projetos.Include(p => p.IdTemaNavigation).ToList();
        }

        
    }
}
