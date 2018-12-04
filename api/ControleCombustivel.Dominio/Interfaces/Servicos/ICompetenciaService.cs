using ControleCombustivel.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dominio.Interfaces.Servicos
{
    public interface ICompetenciaService : IBaseService<Competencia>
    {
        IEnumerable<Competencia> BuscarPorUsuario(int idUsuario);

        decimal BuscarValorTotalMensal(int mes, int ano);

        decimal BuscarValorTotalAnual(int ano);

        decimal BuscarQuantidadeMensal(int mes, int ano, int idTipoCombustivel);

        decimal BuscarQuantidadeAnual(int ano, int idTipoCombustivel);
    }
}
