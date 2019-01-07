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
            new AddNotifications<TipoCombustivel>(this).IfNotNullOrEmpty(x => x.Nome, "Informe o Nome").IfLengthGreaterThan
                 (x => x.Nome, Configurations.ShortStringLength, "O Nome deve ter no máximo 30 caracteres");

            new AddNotifications<TipoCombustivel>(this).IfNotNullOrEmpty(x => x.NomeMedida, "Informe o Nome da Medida").IfLengthGreaterThan
                 (x => x.NomeMedida, Configurations.ShortStringLength, "O Nome da Medida deve ter no máximo 30 caracteres");

            new AddNotifications<TipoCombustivel>(this).IfNotNullOrEmpty(x => x.NomeMedidaPlural, "Informe o Nome da Medida no plural").IfLengthGreaterThan
                 (x => x.NomeMedidaPlural, Configurations.ShortStringLength, "O Nome da Medida deve ter no máximo 30 caracteres");
        }
    }
}