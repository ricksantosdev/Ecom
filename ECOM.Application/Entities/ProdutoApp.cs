using System.Collections.Generic;
using ECOM.Application.Interfaces;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Application.Entities
{
    public class ProdutoApp : AppBase<Produto> , IProdutoApp
    {
        private IServiceBase<Produto> _service;

        public ProdutoApp(IServiceBase<Produto> service) : base(service)
        {
            _service = service;
        }
    }
}
