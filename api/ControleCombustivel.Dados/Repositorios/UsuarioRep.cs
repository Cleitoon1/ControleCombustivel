using ControleCombustivel.Dados.Contexto;
using ControleCombustivel.Dados.Repositorios.Base;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;

namespace ControleCombustivel.Dados.Repositorios
{
    public class UsuarioRep : BaseRep<Usuario>, IUsuarioRep
    {
        protected readonly ControleCombustivelContexto _context;

        public UsuarioRep(ControleCombustivelContexto contexto) : base(contexto)
        {
            _context = contexto;
        }
    }
}
