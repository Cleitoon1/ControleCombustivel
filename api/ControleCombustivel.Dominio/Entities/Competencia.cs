using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dominio.Entities
{
    public class Competencia : Base
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Usuario Usuario { get; set; }

        public int IdUsuario { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public ICollection<Abastatecimento> Abastatecimentos { get; set; }
    }
}
