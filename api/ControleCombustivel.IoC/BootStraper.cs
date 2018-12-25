using ControleCombustivel.Dados.Repositorios;
using ControleCombustivel.Dados.Transactions;
using ControleCombustivel.Dominio.Entities;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using ControleCombustivel.Dominio.Servicos;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.IoC
{
    public class BootStraper
    {
        public static void Register(Container container)
        {
            container.Register<Abastecimento>(Lifestyle.Scoped);
            container.Register<Competencia>(Lifestyle.Scoped);
            container.Register<Posto>(Lifestyle.Scoped);
            container.Register<TipoCombustivel>(Lifestyle.Scoped);
            container.Register<TipoUsuario>(Lifestyle.Scoped);
            container.Register<Usuario>(Lifestyle.Scoped);
            container.Register<Veiculo>(Lifestyle.Scoped);

            container.Register<IAbastecimentoService, AbastecimentoService>(Lifestyle.Scoped);
            container.Register<ICompetenciaService, CompetenciaService>(Lifestyle.Scoped);
            container.Register<IPostoService, PostoService>(Lifestyle.Scoped);
            container.Register<ITipoCombustivelService, TipoCombustivelService>(Lifestyle.Scoped);
            container.Register<ITipoUsuarioService, TipoUsuarioService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IVeiculoService, VeiculoService>(Lifestyle.Scoped);

            container.Register<IAbastecimentoRep, AbastecimentoRep>(Lifestyle.Scoped);
            container.Register<ICompetenciaRep, CompetenciaRep>(Lifestyle.Scoped);
            container.Register<IPostoRep, PostoRep>(Lifestyle.Scoped);
            container.Register<ITipoCombustivelRep, TipoCombustivelRep>(Lifestyle.Scoped);
            container.Register<ITipoUsuarioRep, TipoUsuarioRep>(Lifestyle.Scoped);
            container.Register<IUsuarioRep, UsuarioRep>(Lifestyle.Scoped);
            container.Register<IVeiculoRep, VeiculoRep>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

        }
    }
}