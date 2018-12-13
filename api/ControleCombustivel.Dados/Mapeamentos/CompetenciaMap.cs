using ControleCombustivel.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCombustivel.Dados.Mapeamentos
{
    public class CompetenciaMap : EntityTypeConfiguration<Competencia>
    {
        public CompetenciaMap()
        {
            HasKey(x => x.Id);
            Property(x => x.DataCriacao).IsRequired();
            Property(x => x.DataModificacao).IsRequired();
            Property(x => x.Ativo).IsRequired();

            Property(x => x.Nome).IsRequired();
            Property(x => x.Descricao).IsRequired();
            Property(x => x.Ano).IsRequired();
            Property(x => x.Mes).IsRequired();
            HasRequired(x => x.Usuario).WithMany().HasForeignKey(x => x.IdUsuario);
            HasMany(x => x.Abastatecimentos).WithRequired(x => x.Competencia).HasForeignKey(x => x.IdCompetencia);
        }
    }
}
