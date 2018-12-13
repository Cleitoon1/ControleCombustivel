namespace ControleCombustivel.Dominio.Entities
{
    public class Abastecimento : Base
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

        public Abastecimento(string nome, string descricao, decimal quantidade, decimal valorUnitario, decimal valorTotal, int idVeiculo, int idPosto, int idCompetencia, int idTipoCombustivel) : base()
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Quantidade = quantidade;
            this.ValorUnitario = this.ValorUnitario;
            this.ValorTotal = valorTotal;
            this.IdVeiculo = IdVeiculo;
            this.IdPosto = idPosto;
            this.IdCompetencia = IdCompetencia;
            this.IdTipoCombustivel = IdTipoCombustivel;
            Validar();
        }

        public Abastecimento(int id, string nome, string descricao, decimal quantidade, decimal valorUnitario, decimal valorTotal, int idVeiculo, int idPosto, int idCompetencia, int idTipoCombustivel, bool ativo = true) : base(id, ativo)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Quantidade = quantidade;
            this.ValorUnitario = this.ValorUnitario;
            this.ValorTotal = valorTotal;
            this.IdVeiculo = IdVeiculo;
            this.IdPosto = idPosto;
            this.IdCompetencia = IdCompetencia;
            this.IdTipoCombustivel = IdTipoCombustivel;
            Validar();
        }

        public override void Validar()
        {

        }
    }
}