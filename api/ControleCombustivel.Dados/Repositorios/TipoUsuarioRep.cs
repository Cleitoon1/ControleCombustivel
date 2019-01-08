using ControleCombustivel.Dados.Contexto;
using ControleCombustivel.Dados.Repositorios.Base;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;

namespace ControleCombustivel.Dados.Repositorios
{
    public class TipoUsuarioRep : BaseRep<TipoUsuario>, ITipoUsuarioRep
    {
        protected readonly ControleCombustivelContexto _context;

        public TipoUsuarioRep(ControleCombustivelContexto contexto) : base(contexto)
        {
            _context = contexto;
        }
    }
}
