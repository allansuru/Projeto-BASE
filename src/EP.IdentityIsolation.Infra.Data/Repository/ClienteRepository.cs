using EP.IdentityIsolation.Domain.Entities;
using EP.IdentityIsolation.Domain.Interface.Repository;
using System.Collections;
using System.Collections.Generic;

namespace EP.IdentityIsolation.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        //ja faco tudo no crud, mas se eu quiser refinar uma busca por exemplo eu faço aqui.
    

    }
}

