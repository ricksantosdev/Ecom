

using ECOM.Domain.Entities;
using System.Collections.Generic;

namespace ECOM.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> FindByName(string name);
    }
}
