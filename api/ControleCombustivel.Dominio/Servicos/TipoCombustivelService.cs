using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;

namespace ControleCombustivel.Dominio.Servicos
{
    public class TipoCombustivelService : BaseService<TipoCombustivel>, ITipoCombustivelService
    {
        private readonly ITipoCombustivelRep _rep;

        public TipoCombustivelService(ITipoCombustivelRep rep) : base(rep)
        {
            this._rep = rep;
        }

    }
}