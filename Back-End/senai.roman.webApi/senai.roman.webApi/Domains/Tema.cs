﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai.roman.webApi.Domains
{
    public partial class Tema
    {
        public Tema()
        {
            Projetos = new HashSet<Projeto>();
        }

        public int IdTema { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Projeto> Projetos { get; set; }
    }
}
