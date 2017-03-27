using EP.IdentityIsolation.Domain.Entities;
using System.Collections.Generic;

namespace EP.IdentityIsolation.Domain.Interface.Repository
{
    public interface IImagensProdutoRepository : IRepositoryBase<ImagensProduto>
    {
        IEnumerable<ImagensProduto> BuscaPorNome(string nome);

    }
}
