using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using ControleCombustivel.Dominio.Servicos.Base;

namespace ControleCombustivel.Dominio.Servicos
{
    public class PostoService : BaseService<Posto>, IPostoService
    {
        private readonly IPostoRep _rep;

        public PostoService(IPostoRep rep) : base(rep)
        {
            this._rep = rep;
        }

    }
}
