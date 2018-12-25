using ControleCombustivel.Api.Controllers.Base;
using ControleCombustivel.Dados.Transactions;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ControleCombustivel.Api.Controllers
{
    public class AbastecimentoController : BaseController
    {
        private readonly IAbastecimentoService _abastecimentoService;

        public AbastecimentoController(IUnitOfWork unitOfWork, IAbastecimentoService abastecimentoService) :base(unitOfWork)
        {
            this._abastecimentoService = abastecimentoService;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Buscar(int id)
        {
            _abastecimentoService.Get(id);
            return await ResponseAsync(Ok(), _abastecimentoService);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar (Abastecimento model)
        {
            _abastecimentoService.Add(model);
            return await ResponseAsync(Ok(), _abastecimentoService);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Atualizar(Abastecimento model)
        {
            _abastecimentoService.Update(model);
            return await ResponseAsync(Ok(), _abastecimentoService);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Remover(Abastecimento model)
        {
            _abastecimentoService.Remove(model);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> BuscarPorUsuario(int id)
        {
            _abastecimentoService.BuscarPorUsuario(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> BuscarPorVeiculo(int id)
        {
            _abastecimentoService.BuscarPorVeiculo(id, 0);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> BuscarPorPosto(int id)
        {
            _abastecimentoService.BuscarPorPosto(id, 0);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> BuscarPorCompetencia(int mes, int ano)
        {
            _abastecimentoService.BuscarPorCompetencia(mes, ano, 0);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> BuscarPorTipoCombustivel(int id)
        {
            _abastecimentoService.BuscarPorTipoCombustivel(id, 0);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}