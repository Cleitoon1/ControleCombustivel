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
    public class TipoUsuarioController : BaseController
    {
        private readonly ITipoUsuarioService _tipoUsuarioService;

        public TipoUsuarioController(IUnitOfWork unitOfWork, ITipoUsuarioService tipoUsuarioServicee) :base(unitOfWork)
        {
            this._tipoUsuarioService = tipoUsuarioServicee;
        }

    }
}
