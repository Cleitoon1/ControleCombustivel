using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleCombustivel.Dominio.Servicos
{
    public class BaseService<T> : Notifiable, IBaseService<T> where T : EntityBase
    {
        private readonly IBaseRep<T> _rep;

        public BaseService(IBaseRep<T> rep)
        {
            this._rep = rep;
        }
        

        public bool Add(T obj)
        {
            bool ok = obj.Notifications.Any();
            if(!ok)
                _rep.Insert(obj);
            return !ok;
        }

        public IEnumerable<T> GetAll()
        {
            return _rep.GetAll();
        }

        public bool Update(T obj)
        {
            bool ok = obj.Notifications.Any();
            if (!ok)
                _rep.Update(obj);
            return !ok;
        }

        public T Get(int id)
        {
            return _rep.Get(id);
        }

        public bool Remove(T obj)
        {
            bool ok = obj.Notifications.Any();
            if(!ok)
                _rep.Remove(obj);
            return !ok;
        }

        public void Remove(int id)
        {
            T obj = this.Get(id);
            if (obj == null)
                throw new Exception();
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
