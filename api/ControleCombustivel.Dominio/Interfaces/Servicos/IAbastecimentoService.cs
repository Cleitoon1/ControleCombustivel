using ControleCombustivel.Dominio.Entities;
using System.Collections.Generic;

namespace ControleCombustivel.Dominio.Interfaces.Servicos
{
    public interface IAbastecimentoService : IBaseService<Abastecimento>
    {
        IEnumerable<Abastecimento> BuscarPorCompetencia(int mes, int ano, int idUsuario);

        IEnumerable<Abastecimento> BuscarPorVeiculo(int idVeiculo, int idUsuario);

        IEnumerable<Abastecimento> BuscarPorUsuario(int idUsuario);

        IEnumerable<Abastecimento> BuscarPorTipoCombustivel(int idTipo, int idUsuario);

        IEnumerable<Abastecimento> BuscarPorPosto(int idPosto, int idUsuario);
    }
}
