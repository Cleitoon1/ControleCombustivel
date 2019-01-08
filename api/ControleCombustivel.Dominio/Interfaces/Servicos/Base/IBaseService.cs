using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Entities.Base;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Interfaces.Servicos.Base
{
    public interface IBaseService<T> where T : EntityBase, INotifiable
    {
        void Add(T obj);

        T Get(int id);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Remove(T obj);

        void Remove(int id);

        void Dispose();

        bool HasNotifications();

        IEnumerable<Notification> GetNotifications();

    }
}
