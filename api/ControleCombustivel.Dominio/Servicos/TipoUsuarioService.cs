using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;

namespace ControleCombustivel.Dominio.Servicos
{
    public class TipoUsuarioService : BaseService<TipoUsuario>, ITipoUsuarioService
    {
        private readonly ITipoUsuarioRep _rep;

        public TipoUsuarioService(ITipoUsuarioRep rep) : base(rep)
        {
            this._rep = rep;
        }
    }
}
