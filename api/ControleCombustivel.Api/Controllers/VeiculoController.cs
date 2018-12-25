﻿using ControleCombustivel.Api.Controllers.Base;
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
    public class VeiculoController : BaseController
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IUnitOfWork unitOfWork, IVeiculoService veiculoService) :base(unitOfWork)
        {
            this._veiculoService = veiculoService;
        }

    }
}