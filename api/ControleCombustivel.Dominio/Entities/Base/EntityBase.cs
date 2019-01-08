using prmToolkit.NotificationPattern;
using System;

namespace ControleCombustivel.Dominio.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public int Id { get; private set; }

        public DateTime DataCriacao { get; private set; }

        public DateTime DataModificacao { get; private set; }

        public bool Ativo { get; private set; }


        public EntityBase(int id, bool ativo)
        {
            this.Id = id;
            this.Ativo = ativo;
            
        }

        public EntityBase()
        {
            this.Ativo = true;
        }

        public abstract void Validar();
    }
}
