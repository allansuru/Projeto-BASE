using EP.IdentityIsolation.Domain.Entities;
using EP.IdentityIsolation.Domain.Interface.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EP.IdentityIsolation.Infra.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscaPorNome(string nome)
        {
            return _db.Produtos.Where(p => p.Nome == nome);
           
        }


    }
}
