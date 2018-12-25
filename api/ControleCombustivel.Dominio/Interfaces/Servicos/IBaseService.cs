using prmToolkit.NotificationPattern;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Interfaces.Servicos
{
    public interface IBaseService<T> where T : class, INotifiable
    {
        bool Add(T obj);

        T Get(int id);

        IEnumerable<T> GetAll();

        bool Update(T obj);

        bool Remove(T obj);

        void Remove(int id);

        void Dispose();

        bool HasNotifications();

        IEnumerable<Notification> GetNotifications();

    }
}
