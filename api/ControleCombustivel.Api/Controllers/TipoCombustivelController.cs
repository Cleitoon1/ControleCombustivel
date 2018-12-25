using ControleCombustivel.Api.Controllers.Base;
using ControleCombustivel.Dados.Transactions;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControleCombustivel.Api.Controllers
{
    public class TipoCombustivelController : BaseController
    {
        private readonly ITipoCombustivelService _tipoCombustivelService;

        public TipoCombustivelController(IUnitOfWork unitOfWork, ITipoCombustivelService tipoCombustivelService) :base(unitOfWork)
        {
            this._tipoCombustivelService = tipoCombustivelService;
        }

    }
}
