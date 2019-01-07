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
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork, IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            try
            {
                Usuario data = _usuarioService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(Usuario model)
        {
            try
            {
                _usuarioService.Add(model);
                if (_usuarioService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _usuarioService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public HttpResponseMessage Atualizar(Usuario model)
        {
            try
            {
                _usuarioService.Update(model);
                if (_usuarioService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _usuarioService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Remover(Usuario model)
        {
            try
            {
                _usuarioService.Remove(model);
                if (_usuarioService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _usuarioService.GetNotifications() });
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
                _usuarioService.Remove(id);
                if (_usuarioService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _usuarioService.GetNotifications() });
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
            if (_usuarioService != null)
            {
                _usuarioService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
