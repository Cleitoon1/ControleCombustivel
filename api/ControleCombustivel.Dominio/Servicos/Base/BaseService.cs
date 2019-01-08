using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Entities.Base;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Respositorios.Base;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using ControleCombustivel.Dominio.Interfaces.Servicos.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleCombustivel.Dominio.Servicos.Base
{
    public class BaseService<T> : Notifiable, IBaseService<T> where T : EntityBase
    {
        private readonly IBaseRep<T> _rep;

        public BaseService(IBaseRep<T> rep)
        {
            this._rep = rep;
        }
        

        public void Add(T obj)
        {
            obj.Validar();
            AddNotifications(obj);
            _rep.Insert(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _rep.GetAll();
        }

        public void Update(T obj)
        {
            obj.Validar();
            AddNotifications(obj.Notifications);
            _rep.Update(obj);
        }

        public T Get(int id)
        {
            return _rep.Get(id);
        }

        public void Remove(T obj)
        {
            obj.Validar();
            AddNotifications(obj);
            _rep.Remove(obj);
        }

        public void Remove(int id)
        {
            T obj = this.Get(id);
            if (obj == null)
                throw new Exception("Inválid");
            this.Remove(obj);
        }

        public bool HasNotifications()
        {
            return this.Notifications.Any();
        }

        public IEnumerable<Notification> GetNotifications()
        {
            return this.Notifications;
        }
    }
}
