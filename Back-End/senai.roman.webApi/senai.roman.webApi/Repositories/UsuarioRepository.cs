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
    public class UsuarioRepository : IUsuarioRepository
    {
        RomanContext ctx = new RomanContext();

        public Usuario Logar(string email, string senha)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation)
                                .Include(u => u.IdEquipeNavigation).FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
