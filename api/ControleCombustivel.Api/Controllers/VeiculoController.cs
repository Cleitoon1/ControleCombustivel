using ControleCombustivel.Api.Controllers.Base;
using ControleCombustivel.Dados.Transactions;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControleCombustivel.Api.Controllers
{
    public class VeiculoController : ApiController
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IUnitOfWork _unitOfWork;

        public VeiculoController(IUnitOfWork unitOfWork, IVeiculoService veiculoService)
        {
            this._veiculoService = veiculoService;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            try
            {
                Veiculo data = _veiculoService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(Veiculo model)
        {
            try
            {
                _veiculoService.Add(model);
                if (_veiculoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _veiculoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public HttpResponseMessage Atualizar(Veiculo model)
        {
            try
            {
                _veiculoService.Update(model);
                if (_veiculoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _veiculoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Remover(Veiculo model)
        {
            try
            {
                _veiculoService.Remove(model);
                if (_veiculoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _veiculoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Remover(int id)
        {
            try
            {
                _veiculoService.Remove(id);
                if (_veiculoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _veiculoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            //Realiza o dispose no serviço para que possa ser zerada as notificações
            if (_veiculoService != null)
            {
                _veiculoService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
