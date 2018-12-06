using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Domain.Services
{
    public class FornecedorService : ServiceBase<Fornecedores> , IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IUnitOfWork _uow;

        public FornecedorService(IFornecedorRepository fornecedorRepository , IUnitOfWork uok) : base(fornecedorRepository , uok)
        {
            _fornecedorRepository = fornecedorRepository;
            _uow = uok;
        }
    }
}
