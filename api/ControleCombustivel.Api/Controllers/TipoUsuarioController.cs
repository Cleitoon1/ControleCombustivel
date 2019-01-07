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
    public class TipoUsuarioController : ApiController
    {
        private readonly ITipoUsuarioService _tipoUsuarioService;
        private readonly IUnitOfWork _unitOfWork;

        public TipoUsuarioController(IUnitOfWork unitOfWork,ITipoUsuarioService tipoUsuarioService) 
        {
            this._tipoUsuarioService = tipoUsuarioService;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            try
            {
                TipoUsuario data = _tipoUsuarioService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(TipoUsuario model)
        {
            try
            {
                _tipoUsuarioService.Add(model);
                if (_tipoUsuarioService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _tipoUsuarioService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public HttpResponseMessage Atualizar(TipoUsuario model)
        {
            try
            {
                _tipoUsuarioService.Update(model);
                if (_tipoUsuarioService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _tipoUsuarioService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Remover(TipoUsuario model)
        {
            try
            {
                _tipoUsuarioService.Remove(model);
                if (_tipoUsuarioService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _tipoUsuarioService.GetNotifications() });
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
                _tipoUsuarioService.Remove(id);
                if (_tipoUsuarioService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _tipoUsuarioService.GetNotifications() });
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
            if (_tipoUsuarioService != null)
            {
                _tipoUsuarioService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
