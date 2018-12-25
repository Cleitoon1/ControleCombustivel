using ControleCombustivel.Utilidades.Validacoes;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class Veiculo : EntityBase
    {
        public string Modelo { get; private set; }

        public string Placa { get; private set; }

        public string Fabricante { get; private set; }

        public int AnoFabricacao { get; private set; }

        public Usuario Usuario { get; private set; }

        public int IdUsuario { get; private set; }

        public bool Principal { get; private set; }

        public ICollection<TipoCombustivel> TiposCombustiveis { get; set; }

        public Veiculo(string modelo, string placa, string fabricante, int anoFabricacao, int idUsuario, bool principal) : base()
        {
            this.Modelo = modelo;
            this.Placa = placa;
            this.Fabricante = fabricante;
            this.AnoFabricacao = anoFabricacao;
            this.IdUsuario = idUsuario;
            this.Principal = principal;

            Validar();
        }

        public Veiculo(int id, string modelo, string placa, string fabricante, int anoFabricacao, int idUsuario, bool principal, bool ativo = true): base(id, ativo)
        {
            this.Modelo = modelo;
            this.Placa = placa;
            this.Fabricante = fabricante;
            this.AnoFabricacao = anoFabricacao;
            this.IdUsuario = idUsuario;
            this.Principal = principal;
            Validar();
        }

        public override void Validar()
        {

            new AddNotifications<Veiculo>(this).IfNotNullOrEmpty(x => x.Modelo, "Informe o Modelo")
                .IfLengthGreaterThan(x => x.Modelo, Configurations.MediumStringLength, "O Modelo deve ter no máximo 60 caracteres");

            new AddNotifications<Veiculo>(this).IfNotNullOrEmpty(x => x.Modelo, "Informe a Placa")
                .IfLengthGreaterThan(x => x.Modelo, 8, "A Placa deve ter no máximo 8 caracteres");

            new AddNotifications<Veiculo>(this).IfNotNullOrEmpty(x => x.Modelo, "Informe o Modelo")
                .IfLengthGreaterThan(x => x.Modelo, Configurations.MediumStringLength, "O Modelo deve ter no máximo 60 caracteres");

            new AddNotifications<Veiculo>(this).IfNotNullOrEmpty(x => x.Modelo, "Informe o Fabricante")
                .IfLengthGreaterThan(x => x.Modelo, Configurations.MediumStringLength, "O Fabricante deve ter no máximo 60 caracteres");

            new AddNotifications<Veiculo>(this).IfLowerOrEqualsThan(x => x.AnoFabricacao, 1950, "Informe um ano válido");

            new AddNotifications<Veiculo>(this).IfEqualsZero(x => x.IdUsuario, "Informe o Id do Usuário");
        }

    }
}