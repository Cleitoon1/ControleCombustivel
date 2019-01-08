using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using ControleCombustivel.Dominio.Servicos.Base;

namespace ControleCombustivel.Dominio.Servicos
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRep _rep;

        public UsuarioService(IUsuarioRep rep) : base(rep)
        {
            this._rep = rep;
        }
    }
}
