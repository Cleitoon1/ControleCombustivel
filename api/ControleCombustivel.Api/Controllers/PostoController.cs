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
    public class PostoController : BaseController
    {
        private readonly IPostoService _postoService;

        public PostoController(IUnitOfWork unitOfWork, IPostoService postoService) :base(unitOfWork)
        {
            this._postoService = postoService;
        }

    }
}
