using ControleCombustivel.Dados.Contexto;
using ControleCombustivel.Dados.Repositorios.Base;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;

namespace ControleCombustivel.Dados.Repositorios
{
    public class VeiculoRep : BaseRep<Veiculo>, IVeiculoRep
    {
        protected readonly ControleCombustivelContexto _context;

        public VeiculoRep(ControleCombustivelContexto contexto) : base(contexto)
        {
            _context = contexto;
        }
    }
}
