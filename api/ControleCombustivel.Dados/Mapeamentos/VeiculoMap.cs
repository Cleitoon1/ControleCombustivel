using ControleCombustivel.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleCombustivel.Dados.Mapeamentos
{
    public class VeiculoMap : EntityTypeConfiguration<Veiculo>
    {
        public VeiculoMap()
        {
            HasKey(x => x.Id);
            Property(x => x.DataCriacao).IsRequired();
            Property(x => x.DataModificacao).IsRequired();
            Property(x => x.Ativo).IsRequired();

            Property(x => x.Modelo).IsRequired();
            Property(x => x.Placa).IsRequired();
            Property(x => x.Fabricante).IsRequired();
            Property(x => x.AnoFabricacao).IsRequired();
            Property(x => x.Principal).IsRequired();
            HasRequired(x => x.Usuario).WithMany().HasForeignKey(x => x.IdUsuario);
        }
    }
}
