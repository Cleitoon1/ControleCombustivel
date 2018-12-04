namespace ControleCombustivel.Dominio.Entities
{
    public class Abastatecimento : Base
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal { get; set; }

        public Veiculo Veiculo { get; set; }

        public int IdVeiculo { get; set; }

        public Posto Posto { get; set; }

        public int IdPosto { get; set; }

        public Competencia Competencia { get; set; }

        public int IdCompetencia { get; set; }

        public TipoCombustivel TipoCombustivel { get; set; }

        public int IdTipoCombustivel { get; set; }
    }
}