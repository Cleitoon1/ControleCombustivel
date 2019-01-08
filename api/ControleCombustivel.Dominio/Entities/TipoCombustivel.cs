using ControleCombustivel.Dominio.Entities.Base;
using ControleCombustivel.Utilidades.Validacoes;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class TipoCombustivel : EntityBase
    {
        public string Nome { get; private set; }

        public string NomeMedida { get; private set; }

        public string NomeMedidaPlural { get; private set; }

        public ICollection<Veiculo> Veiculos { get; private set; }

        public ICollection<Abastecimento> Abastecimentos { get; private set; }

        private TipoCombustivel()
        {

        }

        public TipoCombustivel(string nome, string nomeMedida, string nomeMedidaPlural) : base()
        {
            this.Nome = nome;
            this.NomeMedida = nomeMedida;
            this.NomeMedidaPlural = nomeMedidaPlural;
            Validar();
        }

        public TipoCombustivel(int id, string nome, string nomeMedida, string nomeMedidaPlural, bool ativo = true) : base(id, ativo)
        {
            this.Nome = nome;
            this.NomeMedida = nomeMedida;
            this.NomeMedidaPlural = nomeMedidaPlural;
            Validar();
        }

        public override void Validar()
        {
            new AddNotifications<TipoCombustivel>(this).IfNotNullOrEmpty(x => x.Nome, "Informe o Nome")
                .IfNullOrInvalidLength(x => x.Nome, Configurations.MinStringLength,  Configurations.ShortStringLength, "O Nome deve ter entre 3 e 30 caracteres");

            new AddNotifications<TipoCombustivel>(this).IfNotNullOrEmpty(x => x.NomeMedida, "Informe o Nome da Medida")
                .IfNullOrInvalidLength(x => x.NomeMedida, 2, Configurations.ShortStringLength, "O Nome da Medida deve ter entre 2 e 30 caracteres");

            new AddNotifications<TipoCombustivel>(this).IfNotNullOrEmpty(x => x.NomeMedidaPlural, "Informe o Nome da Medida no plural")
                .IfNullOrInvalidLength(x => x.NomeMedidaPlural, 2, Configurations.ShortStringLength, "O Nome da Medida no plural deve ter entre 2 e 30 caracteres");
        }
    }
}