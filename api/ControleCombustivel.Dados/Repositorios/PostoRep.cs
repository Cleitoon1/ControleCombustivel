using ControleCombustivel.Dados.Contexto;
using ControleCombustivel.Dados.Repositorios.Base;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;

namespace ControleCombustivel.Dados.Repositorios
{
    public class PostoRep : BaseRep<Posto>, IPostoRep
    {
        protected readonly ControleCombustivelContexto _context;

        public PostoRep(ControleCombustivelContexto contexto) : base(contexto)
        {
            _context = contexto;
        }
    }
}
