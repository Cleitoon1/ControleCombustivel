using ControleCombustivel.Dados.Contexto;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Respositorios.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dados.Repositorios.Base
{
    public class BaseRep<T> : IDisposable, IBaseRep<T> where T : class
    {
        protected DbContext Db;

        public BaseRep(DbContext db)
        {
            this.Db = db;
        }

        public void Insert(T obj)
        {
            Db.Set<T>().Add(obj);
        }

        public void Dispose()
        {
            if (Db != null)
                Db.Dispose();
            else
                GC.SuppressFinalize(this);
        }

        public T Get(int id)
        {
            return Db.Set<T>().Find(id);

        }

        public IEnumerable<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(T obj)
        {
            Db.Set<T>().Remove(obj);
        }

        public void Remove(int id)
        {
            Db.Set<T>().Remove(this.Get(id));
        }
    }
}
