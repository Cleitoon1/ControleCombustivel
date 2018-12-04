using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class Veiculo : Base
    {
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Placa { get; set; }

        public string Fabricante { get; set; }

        public int AnoFabricacao { get; set; }

        public Usuario Usuario { get; set; }

        public int IdUsuario { get; set; }

        public ICollection<TipoCombustivel> TiposCombustiveis { get; set; }

    }
}