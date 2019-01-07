using ControleCombustivel.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dados.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ControleCombustivelContexto _context;

        public UnitOfWork(ControleCombustivelContexto context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
