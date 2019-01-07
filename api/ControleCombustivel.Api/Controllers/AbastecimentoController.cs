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
    public class AbastecimentoController : ApiController
    {
        private readonly IAbastecimentoService _abastecimentoService;
        private readonly IUnitOfWork _unitOfWork;


        public AbastecimentoController(IUnitOfWork unitOfWork, IAbastecimentoService abastecimentoService)
        {
            this._abastecimentoService = abastecimentoService;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage Buscar(int id)
        {
            try
            {
                Abastecimento data =_abastecimentoService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        public HttpResponseMessage Adicionar(Abastecimento model)
        {
            try
            {
                _abastecimentoService.Add(model);
                if(_abastecimentoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _abastecimentoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpPut]
        public HttpResponseMessage Atualizar(Abastecimento model)
        {
            try
            {
                _abastecimentoService.Update(model);
                if (_abastecimentoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _abastecimentoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Remover(Abastecimento model)
        {
            try
            {
                _abastecimentoService.Remove(model);
                if (_abastecimentoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _abastecimentoService.GetNotifications() });
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
                _abastecimentoService.Remove(id);
                if (_abastecimentoService.HasNotifications())
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = _abastecimentoService.GetNotifications() });
                _unitOfWork.Commit();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        public HttpResponseMessage BuscarPorUsuario(int id)
        {
            try
            {
                IEnumerable<Abastecimento> data = _abastecimentoService.BuscarPorUsuario(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        public HttpResponseMessage BuscarPorVeiculo(int id)
        {
            try
            {
                IEnumerable<Abastecimento> data = _abastecimentoService.BuscarPorVeiculo(id, 0);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        public HttpResponseMessage BuscarPorPosto(int id)
        {
            try
            {
                IEnumerable<Abastecimento> data = _abastecimentoService.BuscarPorPosto(id, 0);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        public HttpResponseMessage BuscarPorCompetencia(int mes, int ano)
        {
            try
            {
                IEnumerable<Abastecimento> data = _abastecimentoService.BuscarPorCompetencia(mes, ano, 0);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        [HttpGet]
        public HttpResponseMessage BuscarPorTipoCombustivel(int id)
        {
            try
            {
                IEnumerable<Abastecimento> data = _abastecimentoService.BuscarPorTipoCombustivel(id, 0);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict, $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            //Realiza o dispose no serviço para que possa ser zerada as notificações
            if (_abastecimentoService != null)
            {
                _abastecimentoService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}