using ControleCombustivel.Dominio.ObjetosValor;
using Flunt.Validations;
using System;

namespace ControleCombustivel.Dominio.Entities
{
    public class TipoCombustivel : Base
    {
        public string Nome { get; private set; }

        public string NomeMedida { get; private set; }

        public string NomeMedidaPlural { get; private set; }

        public TipoCombustivel(int id, string nome, string nomeMedida, string nomeMedidaPlural, bool ativo = true)
        {
            this.Id = id;
            this.Nome = nome;
            this.NomeMedida = nomeMedida;
            this.NomeMedidaPlural = nomeMedidaPlural;
            this.Ativo = ativo;
            Validar();
        }

        public TipoCombustivel(string nome, string nomeMedida, string nomeMedidaPlural, bool ativo = true)
        {
            this.Nome = nome;
            this.NomeMedida = nomeMedida;
            this.NomeMedidaPlural = nomeMedidaPlural;
            this.Ativo = ativo;
            Validar();
        }

        private void Validar()
        {
            AddNotifications(
                new Contract().Requires().IsNullOrEmpty(this.Nome, this.Nome, "Informe o Nome")
                .HasMaxLen(this.Nome, Configurations.ShortStringLength, this.Nome, "O Nome deve ter no máximo 30 caracteres"),

                new Contract().Requires().IsNullOrEmpty(this.NomeMedida, this.NomeMedida, "Informe o Nome da Medida")
                .HasMaxLen(this.NomeMedida, Configurations.ShortStringLength, this.NomeMedida, "O Nome da Medida deve ter no máximo 30 caracteres"),
                
                new Contract().Requires().IsNullOrEmpty(this.NomeMedidaPlural, this.NomeMedidaPlural, "Informe o Nome da Medida no plural")
                .HasMaxLen(this.NomeMedidaPlural, Configurations.ShortStringLength, this.NomeMedidaPlural, "O Nome da Medida deve ter no máximo 30 caracteres")
            );
        }
    }
}