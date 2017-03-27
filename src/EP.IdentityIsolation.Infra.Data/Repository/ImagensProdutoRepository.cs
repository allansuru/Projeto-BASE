using EP.IdentityIsolation.Domain.Entities;
using EP.IdentityIsolation.Domain.Interface.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EP.IdentityIsolation.Infra.Data.Repository
{
    public class ImagensProdutoRepository : RepositoryBase<ImagensProduto>, IImagensProdutoRepository
    {
        public IEnumerable<ImagensProduto> BuscaPorNome(string nome)
        {
            return _db.ImagensProduto.Where(p => p.ImagemTitulo == nome);

        }


    }
}
