using ControleCombustivel.Dominio.Entities.Base;
using ControleCombustivel.Utilidades.Validacoes;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class TipoUsuario : EntityBase
    {
        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

        private TipoUsuario()
        {

        }

        public TipoUsuario(string nome)
        {
            this.Nome = nome;
            Validar();
        }

        public TipoUsuario(int id, string nome, bool ativo = true) : base(id, ativo)
        {
            this.Nome = nome;
            Validar();

        }

        public override void Validar()
        {
            new AddNotifications<TipoUsuario>(this)
                .IfNullOrInvalidLength(x => x.Nome, 3, Configurations.ShortStringLength, "O Nome deve ter entre 3 e 30 caracteres");
        }
    }
}
