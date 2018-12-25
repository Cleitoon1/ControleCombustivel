using ControleCombustivel.Utilidades.Validacoes;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Entities
{
    public class TipoUsuario : EntityBase
    {
        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

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
            new AddNotifications<TipoUsuario>(this).IfNotNullOrEmpty(x => x.Nome, "Informe o Nome").IfLengthGreaterThan
                (x => x.Nome, Configurations.ShortStringLength, "O Nome deve ter no máximo 30 caracteres");
        }
    }
}
