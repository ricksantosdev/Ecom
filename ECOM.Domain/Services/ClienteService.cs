using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;


namespace ECOM.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente> , ICLienteService
    {
        private readonly ICLienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ClienteService(ICLienteRepository repository , IUnitOfWork unitOfWork) : base(repository , unitOfWork)
        {
            _clienteRepository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
