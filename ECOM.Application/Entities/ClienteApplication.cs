using ECOM.Application.Interfaces;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Application.Entities
{

    public class ClienteApplication : AppBase<Cliente> , IAppCliente
    {
        private readonly IServiceBase<Cliente> _service;
        public ClienteApplication(IServiceBase<Cliente> service) : base(service)
        {
            _service = service;
        }


    }
}
