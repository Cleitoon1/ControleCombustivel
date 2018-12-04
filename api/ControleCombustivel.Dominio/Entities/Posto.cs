namespace ControleCombustivel.Dominio.Entities
{
    public class Posto : Base
    {
        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public long Lat { get; set; }

        public long Long { get; set; }

        public string Cep { get; set; }

        public string Rua { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}