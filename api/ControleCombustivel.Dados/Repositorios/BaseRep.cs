using ControleCombustivel.Dados.Contexto;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ControleCombustivel.Dados.Repositorios
{
    public class BaseRep<T> : IDisposable, IBaseRep<T> where T : class
    {
        protected ControleCombustivelContexto Db = new ControleCombustivelContexto();

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
