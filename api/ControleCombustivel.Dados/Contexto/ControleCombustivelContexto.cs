using ControleCombustivel.Dados.Mapeamentos;
using ControleCombustivel.Dominio.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControleCombustivel.Dados.Contexto
{
    public class ControleCombustivelContexto : DbContext
    {
        public ControleCombustivelContexto() : base("ControleCombustivel")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Abastecimento> Abastecimentos { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Posto> Postos { get; set; }
        public DbSet<TipoCombustivel> TipoCombustiveis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(120));

            modelBuilder.Configurations.Add(new AbastecimentoMap());
            modelBuilder.Configurations.Add(new CompetenciaMap());
            modelBuilder.Configurations.Add(new PostoMap());
            modelBuilder.Configurations.Add(new TipoCombustivelMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new TipoUsuarioMap());
            modelBuilder.Configurations.Add(new VeiculoMap());
        }

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property("DataCriacao") != null)
                        entry.Property("DataCriacao").CurrentValue = DateTime.Now;
                    if (entry.Property("DataModificacao") != null)
                        entry.Property("DataModificacao").CurrentValue = DateTime.Now;
                    if (entry.Property("Ativo") != null)
                        entry.Property("Ativo").CurrentValue = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Property("DataCriacao") != null)
                        entry.Property("DataCriacao").IsModified = false;
                    if (entry.Property("DataMotificacao") != null)
                        entry.Property("DataMotificacao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}
