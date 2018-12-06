using ECOM.Domain.Entities;
using System.Collections.Generic;


namespace ECOM.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> FindByName(string name);
    }
}
