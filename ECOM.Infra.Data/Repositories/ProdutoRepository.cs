
using System.Collections.Generic;
using System.Linq;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;

namespace ECOM.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> FindByName(string name)
        {
            return Context.Produtos.Where(x => x.Nome == name);
        }
    }
}
