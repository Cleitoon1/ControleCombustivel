﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dominio.Interfaces.Servicos
{
    public interface IBaseService<T> where T : class
    {
        void Add(T obj);

        T Get(int id);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Remove(T obj);

        void Remove(int id);

        void Dispose();
    }
}
