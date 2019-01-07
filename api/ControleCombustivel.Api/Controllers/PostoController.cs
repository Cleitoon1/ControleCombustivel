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
    public class PostoController : ApiController
    {
        private readonly IPostoService _postoService;
        private readonly IUnitOfWork _unitOfWork;

        public PostoController(IUnitOfWork unitOfWork, IPostoService postoService)
        {
            this._postoService = postoService;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            try
            {
                Posto data = _postoService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(Posto model)
        {
            try
            {
                _postoService.Add(model);
                if (_postoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _postoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public HttpResponseMessage Atualizar(Posto model)
        {
            try
            {
                _postoService.Update(model);
                if (_postoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _postoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Remover(Posto model)
        {
            try
            {
                _postoService.Remove(model);
                if (_postoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _postoService.GetNotifications() });
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
                _postoService.Remove(id);
                if (_postoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _postoService.GetNotifications() });
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
            if (_postoService != null)
            {
                _postoService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
