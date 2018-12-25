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
    public class CompetenciaController : BaseController
    {
        private readonly ICompetenciaService _competenciaService;

        public CompetenciaController(IUnitOfWork unitOfWork, ICompetenciaService competenciaService) :base(unitOfWork)
        {
            this._competenciaService = competenciaService;
        }

    }
}
