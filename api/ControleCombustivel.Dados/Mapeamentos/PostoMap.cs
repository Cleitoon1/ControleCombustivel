using ControleCombustivel.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleCombustivel.Dados.Mapeamentos
{
    public class PostoMap : EntityTypeConfiguration<Posto>
    {
        public PostoMap()
        {
            HasKey(x => x.Id);
            Property(x => x.DataCriacao).IsRequired();
            Property(x => x.DataModificacao).IsRequired();
            Property(x => x.Ativo).IsRequired();

            Property(x => x.Nome).IsRequired();
            Property(x => x.Cnpj);
            Property(x => x.Lat);
            Property(x => x.Long);
            Property(x => x.Cep);
            Property(x => x.Rua);
            Property(x => x.Numero);
            Property(x => x.Bairro);
            Property(x => x.Cidade);
            Property(x => x.Estado);
            HasMany(x => x.Abastecimentos).WithRequired(x => x.Posto).HasForeignKey(x => x.IdPosto);
        }
    }
}