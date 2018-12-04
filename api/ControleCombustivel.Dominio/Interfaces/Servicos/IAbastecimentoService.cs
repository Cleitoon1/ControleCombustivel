using ControleCombustivel.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dominio.Interfaces.Servicos
{
    public interface IAbastecimentoService: IBaseService<Abastatecimento>
    {
        IEnumerable<Abastatecimento> BuscarPorCompetencia(int ano, int mes);

        IEnumerable<Abastatecimento> BuscarPorVeiculo(int idVeiculo);

        IEnumerable<Abastatecimento> BuscarPorUsuario(int idUsuario);

        IEnumerable<Abastatecimento> BuscarPorTipoCombustivel(int idTipo);

        IEnumerable<Abastatecimento> BuscarPorPosto(int idPosto);


    }
}
