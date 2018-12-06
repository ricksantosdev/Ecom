using ECOM.Application.Interfaces;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Application.Entities
{
    public class FornecedorApp : AppBase<Fornecedores>  , IFornecedorApp
    {
        private IServiceBase<Fornecedores> _service;
        public FornecedorApp(IServiceBase<Fornecedores> service) : base(service)
        {
            _service = service;
        }
    }
}
