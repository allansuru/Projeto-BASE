using EP.IdentityIsolation.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EP.IdentityIsolation.Infra.Data.EntityConfig
{
    public class ProdutoImagemConfiguration : EntityTypeConfiguration<ImagensProduto>
    {
        public ProdutoImagemConfiguration()
        {
            HasKey(pi => pi.ImagemId);

            HasRequired(pi => pi.Produto)
              .WithMany()
             .HasForeignKey(pi => pi.ProdutoId);


        }

    }
}
