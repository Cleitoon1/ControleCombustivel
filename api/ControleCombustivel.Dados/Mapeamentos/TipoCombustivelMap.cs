using ControleCombustivel.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleCombustivel.Dados.Mapeamentos
{
    public class TipoCombustivelMap : EntityTypeConfiguration<TipoCombustivel>
    {
        public TipoCombustivelMap()
        {
            HasKey(x => x.Id);
            Property(x => x.DataCriacao).IsRequired();
            Property(x => x.DataModificacao).IsRequired();
            Property(x => x.Ativo).IsRequired();

            Property(x => x.Nome).IsRequired();
            Property(x => x.NomeMedida).IsRequired();
            Property(x => x.NomeMedidaPlural).IsRequired();
            HasMany(x => x.Abastecimentos).WithRequired(x => x.TipoCombustivel).HasForeignKey(x => x.IdTipoCombustivel);
            HasMany(x => x.Veiculos).WithMany(x => x.TiposCombustiveis).Map(x =>
            {
                x.ToTable("VeiculosTiposCombustiveis");
                x.MapLeftKey("VeiculoId");
                x.MapRightKey("TipoCombustivelId");
            });

        }
    }
}
