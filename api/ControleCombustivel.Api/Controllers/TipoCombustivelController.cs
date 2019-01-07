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
    public class TipoCombustivelController : ApiController
    {
        private readonly ITipoCombustivelService _tipoCombustivelService;
        private readonly IUnitOfWork _unitOfWork;

        public TipoCombustivelController(IUnitOfWork unitOfWork, ITipoCombustivelService tipoCombustivelService)
        {
            this._tipoCombustivelService = tipoCombustivelService;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            try
            {
                TipoCombustivel data = _tipoCombustivelService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(TipoCombustivel model)
        {
            try
            {
                _tipoCombustivelService.Add(model);
                if (_tipoCombustivelService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _tipoCombustivelService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public HttpResponseMessage Atualizar(TipoCombustivel model)
        {
            try
            {
                _tipoCombustivelService.Update(model);
                if (_tipoCombustivelService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _tipoCombustivelService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Remover(TipoCombustivel model)
        {
            try
            {
                _tipoCombustivelService.Remove(model);
                if (_tipoCombustivelService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _tipoCombustivelService.GetNotifications() });
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
                _tipoCombustivelService.Remove(id);
                if (_tipoCombustivelService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _tipoCombustivelService.GetNotifications() });
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
            if (_tipoCombustivelService != null)
            {
                _tipoCombustivelService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
