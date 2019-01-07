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
    public class CompetenciaController : ApiController
    {
        private readonly ICompetenciaService _competenciaService;
        private readonly IUnitOfWork _unitOfWork;

        public CompetenciaController(IUnitOfWork unitOfWork, ICompetenciaService competenciaService)
        {
            this._competenciaService = competenciaService;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            try
            {
                Competencia data = _competenciaService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(Competencia model)
        {
            try
            {
                _competenciaService.Add(model);
                if (_competenciaService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _competenciaService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public HttpResponseMessage Atualizar(Competencia model)
        {
            try
            {
                _competenciaService.Update(model);
                if (_competenciaService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _competenciaService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Remover(Competencia model)
        {
            try
            {
                _competenciaService.Remove(model);
                if (_competenciaService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _competenciaService.GetNotifications() });
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
                _competenciaService.Remove(id);
                if (_competenciaService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _competenciaService.GetNotifications() });
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
            if (_competenciaService != null)
            {
                _competenciaService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
