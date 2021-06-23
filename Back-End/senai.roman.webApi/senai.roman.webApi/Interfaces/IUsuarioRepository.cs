using senai.roman.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.roman.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Logar(string email, string senha);
    }
}
