namespace ControleCombustivel.Dominio.Entities
{
    public class Abastatecimento : Base
    {
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public decimal Quantidade { get; private set; }

        public decimal ValorUnitario { get; private set; }

        public decimal ValorTotal { get; private set; }

        public Veiculo Veiculo { get; private set; }

        public int IdVeiculo { get; private set; }

        public Posto Posto { get; private set; }

        public int IdPosto { get; private set; }

        public Competencia Competencia { get; private set; }

        public int IdCompetencia { get; private set; }

        public TipoCombustivel TipoCombustivel { get; private set; }

        public int IdTipoCombustivel { get; private set; }

        public Abastatecimento(string nome, string descricao, decimal quantidade, decimal? valorTotal, int idVeiculo, int idPosto, int idCompetencia, int idTipoCombustivel)
        {

        }

        private void Validar(Abastatecimento abastatecimento)
        {

        }
    }
}