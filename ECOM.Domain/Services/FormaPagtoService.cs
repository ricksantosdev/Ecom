using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Domain.Services
{
    public class FormaPagtoService : ServiceBase<FormaPagto> , IFormaPagtoService
    {
        private readonly IFormaPagtoRepository _formaPagtoRepository;
        private readonly IUnitOfWork _uow;

        public FormaPagtoService(IFormaPagtoRepository formaPagtoRepository , IUnitOfWork uow) : base(formaPagtoRepository , uow)
        {
            _formaPagtoRepository = formaPagtoRepository;
            _uow = uow;
        }
    }
}
