using System.Data.Entity;
using EP.IdentityIsolation.Domain.Entities;
using EP.IdentityIsolation.Infra.Data.EntityConfig;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System;

namespace EP.IdentityIsolation.Infra.Data.Context
{
    public class IdentityIsolationContext : DbContext //Man, Instalar o EntityFramework no projeto(Infra.Data) via Nuget[console](Install-Package EntityFramework) --> Migrations(Enable-Migrations)(Update-Database)
    {
        public IdentityIsolationContext()
            : base("DefaultConnection")
        {}

        public DbSet<Usuario> Usuarios { get; set; } //mapeie aqui no contexto minha classe de usuario 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ImagensProduto> ImagensProduto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // toda propriedade com o nome + Id é um primary Key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());


            //tudo que for string ele vai ser um varchar e nao um nvarchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //add minha config da classe cliente
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}