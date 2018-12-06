using ECOM.Application.Interfaces;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Application.Entities
{
    public class FormaPagtoApp : AppBase<FormaPagto> , IFormaPagtoApp
    {
        private IServiceBase<FormaPagto> _service;

        public FormaPagtoApp(IServiceBase<FormaPagto> service) : base(service)
        {
            _service = service;
        }
    }
}
