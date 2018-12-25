using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;

namespace ControleCombustivel.Dominio.Servicos
{
    public class VeiculoService : BaseService<Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRep _rep;

        public VeiculoService(IVeiculoRep rep) : base(rep)
        {
            this._rep = rep;
        }
    }
}
