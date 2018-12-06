using ECOM.Application.Interfaces;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Application.Entities
{
    public class CategoriaProdutoApp : AppBase<CategoriaProduto> , ICategoriaProdutoApp
    {
        private IServiceBase<CategoriaProduto> _service;

        public CategoriaProdutoApp(IServiceBase<CategoriaProduto> service ) : base(service)
        {
            _service = service;
        }


    }
}
