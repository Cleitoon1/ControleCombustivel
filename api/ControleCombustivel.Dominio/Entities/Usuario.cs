using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class Usuario : Base
    {
        public string NomeCompleto { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public ICollection<Competencia> Competencias { get; set; }

        public ICollection<Veiculo> Veiculos { get; set; }
    }
}