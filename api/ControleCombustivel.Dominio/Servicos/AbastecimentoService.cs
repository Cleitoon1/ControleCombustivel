using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleCombustivel.Dominio.Servicos
{
    public class AbastecimentoService : BaseService<Abastecimento>, IAbastecimentoService
    {
        private readonly IAbastecimentoRep _rep;

        public AbastecimentoService(IAbastecimentoRep rep) : base(rep)
        {
            this._rep = rep;
        }

        public IEnumerable<Abastecimento> BuscarPorCompetencia(int mes, int ano, int idUsuario)
        {
            return _rep.GetAll().Where(x => x.Competencia.Mes.Equals(mes) && x.Competencia.Ano.Equals(ano) && x.Competencia.IdUsuario.Equals(idUsuario)).ToList();
        }

        public IEnumerable<Abastecimento> BuscarPorPosto(int idPosto, int idUsuario)
        {
            return _rep.GetAll().Where(x => x.IdPosto == idPosto && x.Competencia.IdUsuario.Equals(idUsuario)).ToList();

        }

        public IEnumerable<Abastecimento> BuscarPorTipoCombustivel(int idTipo, int idUsuario)
        {
            return _rep.GetAll().Where(x => x.IdTipoCombustivel == idTipo && x.Competencia.IdUsuario.Equals(idUsuario)).ToList();

        }

        public IEnumerable<Abastecimento> BuscarPorUsuario(int idUsuario)
        {
            return _rep.GetAll().Where(x => x.Competencia.IdUsuario.Equals(idUsuario)).ToList();

        }

        public IEnumerable<Abastecimento> BuscarPorVeiculo(int idVeiculo, int idUsuario)
        {
            return _rep.GetAll().Where(x => x.IdVeiculo == idVeiculo && x.Competencia.IdUsuario.Equals(idUsuario)).ToList();

        }
    }
}
