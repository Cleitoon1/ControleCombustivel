using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dominio.Entities
{
    public abstract class Base : Notifiable
    {
        public int Id { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime DataModificacao { get; private set; }

        public bool Ativo { get; private set; }

        public Base(int id, bool ativo)
        {
            this.Id = id;
            this.Ativo = ativo;
            
        }

        public Base()
        {
            this.Ativo = true;
        }

        public abstract void Validar();
    }
}
