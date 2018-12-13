using ControleCombustivel.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dominio.Interfaces.Servicos
{
    public interface IAbastecimentoService: IBaseService<Abastecimento>
    {
        IEnumerable<Abastecimento> BuscarPorCompetencia(int ano, int mes);

        IEnumerable<Abastecimento> BuscarPorVeiculo(int idVeiculo);

        IEnumerable<Abastecimento> BuscarPorUsuario(int idUsuario);

        IEnumerable<Abastecimento> BuscarPorTipoCombustivel(int idTipo);

        IEnumerable<Abastecimento> BuscarPorPosto(int idPosto);


    }
}
