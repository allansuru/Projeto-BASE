using EP.IdentityIsolation.Domain.Entities;
using System.Collections.Generic;

namespace EP.IdentityIsolation.Domain.Interface.Repository
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscaPorNome(string nome);

    
    }
}
