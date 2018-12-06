using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Domain.Services
{
    public class CategoriaProdutoService  : ServiceBase<CategoriaProduto> , ICategoriaProdutoService
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly IUnitOfWork _uow;
        public CategoriaProdutoService(ICategoriaProdutoRepository repository , IUnitOfWork unitOfWork) : base(repository , unitOfWork)
        {
            _categoriaProdutoRepository = repository;
            _uow = unitOfWork;
        }
    }
}
