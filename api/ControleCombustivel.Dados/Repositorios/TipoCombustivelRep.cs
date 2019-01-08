using ControleCombustivel.Dados.Contexto;
using ControleCombustivel.Dados.Repositorios.Base;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;

namespace ControleCombustivel.Dados.Repositorios
{
    public class TipoCombustivelRep : BaseRep<TipoCombustivel>, ITipoCombustivelRep
    {
        protected readonly ControleCombustivelContexto _context;

        public TipoCombustivelRep(ControleCombustivelContexto contexto) : base(contexto)
        {
            _context = contexto;
        }
    }
}
