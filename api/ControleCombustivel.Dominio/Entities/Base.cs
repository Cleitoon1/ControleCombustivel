﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dominio.Entities
{
    public class Base
    {
        public int Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataModificacao { get; set; }

        public bool Ativo { get; set; }
    }
}
