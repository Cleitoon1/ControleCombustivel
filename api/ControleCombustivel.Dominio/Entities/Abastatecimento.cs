using ControleCombustivel.Utilidades.Validacoes;
using prmToolkit.NotificationPattern;

namespace ControleCombustivel.Dominio.Entities
{
    public class Abastecimento : EntityBase
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

        private Abastecimento()
        {

        }

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
            this.ValorTotal = this.Quantidade * this.ValorUnitario;
            this.IdVeiculo = IdVeiculo;
            this.IdPosto = idPosto;
            this.IdCompetencia = IdCompetencia;
            this.IdTipoCombustivel = IdTipoCombustivel;
            Validar();
        }

        public override void Validar()
        {
            new AddNotifications<Abastecimento>(this).IfNotNullOrEmpty(x => x.Nome, "Informe o Nome")
                 .IfLengthGreaterThan(x => x.Nome, Configurations.ShortStringLength, "O Nome deve ter no máximo 30 caracteres");

            new AddNotifications<Abastecimento>(this).IfNotNullOrEmpty(x => x.Descricao, "Informe a Descrição")
                 .IfLengthGreaterThan(x => x.Descricao, Configurations.BigStringLength, "O Descrição deve ter no máximo 150 caracteres");

            new AddNotifications<Abastecimento>(this).IfLowerOrEqualsThan(x => x.Quantidade, 0M, "Informe a Quantidade");

            new AddNotifications<Abastecimento>(this).IfEqualsZero(x => x.IdVeiculo, "Informe o Id do Veículo");

            new AddNotifications<Abastecimento>(this).IfEqualsZero(x => x.IdCompetencia, "Informe o Id da Competência");

            new AddNotifications<Abastecimento>(this).IfEqualsZero(x => x.IdTipoCombustivel, "Informe o Id do Tipo de Combustível");         
        }
    }
}