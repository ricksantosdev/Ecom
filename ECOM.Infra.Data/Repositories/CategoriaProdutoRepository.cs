

using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace ECOM.Infra.Data.Repositories
{
    public class CategoriaProdutoRepository : RepositoryBase<CategoriaProduto>, ICategoriaProdutoRepository
    {
       
        public IEnumerable<CategoriaProduto> GetAllWithProducts()
        {
            return Context.CategoriaProdutos.Include("Produtos");
        }

         
    }
}
