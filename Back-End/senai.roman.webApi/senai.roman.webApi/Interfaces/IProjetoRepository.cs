using senai.roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.roman.webApi.Interfaces
{
    interface IProjetoRepository
    {
        /// <summary>
        /// Cadastra um novo projeto
        /// </summary>
        /// <param name="novoProjeto">objeto com os dados do novo projeto</param>
        void Cadastrar(Projeto novoProjeto);

        List<Projeto> Listar();
    }
}
