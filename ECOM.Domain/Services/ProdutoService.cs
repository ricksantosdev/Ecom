using System.Collections.Generic;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;


namespace ECOM.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _uow;
        public ProdutoService(IProdutoRepository repository , IUnitOfWork unitOfWork) : base(repository , unitOfWork)
        {
            _produtoRepository = repository;
            _uow = unitOfWork;
        }

        public IEnumerable<Produto> FindByName(string name)
        {
            return _produtoRepository.FindByName(name);
        }
    }
}
