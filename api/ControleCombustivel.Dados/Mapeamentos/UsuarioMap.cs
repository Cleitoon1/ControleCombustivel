using ControleCombustivel.Dominio.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleCombustivel.Dados.Mapeamentos
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            HasKey(x => x.Id);
            Property(x => x.DataCriacao).IsRequired();
            Property(x => x.DataModificacao).IsRequired();
            Property(x => x.Ativo).IsRequired();

            Property(x => x.NomeCompleto).IsRequired();
            Property(x => x.Cpf).IsRequired();
            Property(x => x.Email).IsRequired();
            Property(x => x.Senha).IsRequired();
            HasMany(x => x.Competencias).WithRequired(x => x.Usuario).HasForeignKey(x => x.IdUsuario);
            HasMany(x => x.Veiculos).WithRequired(x => x.Usuario).HasForeignKey(x => x.IdUsuario);
            HasRequired(x => x.TipoUsuario).WithMany().HasForeignKey(x => x.IdTipoUsuario);

        }
    }
}
