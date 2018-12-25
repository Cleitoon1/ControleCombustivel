using ControleCombustivel.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleCombustivel.Dados.Mapeamentos
{
    public class AbastecimentoMap : EntityTypeConfiguration<Abastecimento>
    {
        public AbastecimentoMap()
        {
            HasKey(x => x.Id);
            Property(x => x.DataCriacao).IsRequired();
            Property(x => x.DataModificacao).IsRequired();
            Property(x => x.Ativo).IsRequired();

            Property(x => x.Nome).IsRequired();
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Quantidade).IsRequired();
            Property(x => x.ValorUnitario).IsRequired();
            Property(x => x.ValorTotal);
            HasRequired(x => x.Veiculo).WithMany().HasForeignKey(x => x.IdVeiculo);
            HasRequired(x => x.Posto).WithMany().HasForeignKey(x => x.IdPosto);
            HasRequired(x => x.Competencia).WithMany().HasForeignKey(x => x.IdCompetencia);
            HasRequired(x => x.TipoCombustivel).WithMany().HasForeignKey(x => x.IdTipoCombustivel);
        }
    }
}
