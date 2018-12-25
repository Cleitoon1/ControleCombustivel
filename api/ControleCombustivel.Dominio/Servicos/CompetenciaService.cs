using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Servicos
{
    public class CompetenciaService : BaseService<Competencia>, ICompetenciaService
    {
        private readonly ICompetenciaRep _rep;

        public CompetenciaService(ICompetenciaRep rep) : base(rep)
        {
            this._rep = rep;
        }

        public IEnumerable<Competencia> BuscarPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public decimal BuscarQuantidadeAnual(int ano, int idTipoCombustivel)
        {
            throw new NotImplementedException();
        }

        public decimal BuscarQuantidadeMensal(int mes, int ano, int idTipoCombustivel)
        {
            throw new NotImplementedException();
        }

        public decimal BuscarValorTotalAnual(int ano)
        {
            throw new NotImplementedException();
        }

        public decimal BuscarValorTotalMensal(int mes, int ano)
        {
            throw new NotImplementedException();
        }
    }
}
