using ControleCombustivel.Dados.Contexto;

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
