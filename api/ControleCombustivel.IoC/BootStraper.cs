using ControleCombustivel.Dados.Contexto;
using ControleCombustivel.Dados.Repositorios;
using ControleCombustivel.Dados.Transactions;
using ControleCombustivel.Dominio.Interfaces.Respositorios;
using ControleCombustivel.Dominio.Interfaces.Servicos;
using ControleCombustivel.Dominio.Servicos;
using Unity;
using Unity.Lifetime;

namespace ControleCombustivel.IoC
{
    public class BootStraper
    {
        public static void Resolve(UnityContainer container)
        {
            //Contexto do Banco
            container.RegisterType<ControleCombustivelContexto, ControleCombustivelContexto>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            //Services
            container.RegisterType<IAbastecimentoService, AbastecimentoService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompetenciaService, CompetenciaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPostoService, PostoService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoCombustivelService, TipoCombustivelService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoUsuarioService, TipoUsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());
            container.RegisterType<IVeiculoService, VeiculoService>(new HierarchicalLifetimeManager());

            //Respositorios
            container.RegisterType<IAbastecimentoRep, AbastecimentoRep>(new HierarchicalLifetimeManager());
            container.RegisterType<ICompetenciaRep, CompetenciaRep>(new HierarchicalLifetimeManager());
            container.RegisterType<IPostoRep, PostoRep>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoCombustivelRep, TipoCombustivelRep>(new HierarchicalLifetimeManager());
            container.RegisterType<ITipoUsuarioRep, TipoUsuarioRep>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRep, UsuarioRep>(new HierarchicalLifetimeManager());
            container.RegisterType<IVeiculoRep, VeiculoRep>(new HierarchicalLifetimeManager());


        }
    }
}