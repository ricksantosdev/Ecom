using System.Collections.Generic;
using ECOM.Application.Interfaces;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Application.Entities
{
    public class MenuApp : AppBase<Menu> , IMenuApp 
    {
        private IServiceBase<Menu> _service;

        public MenuApp(IServiceBase<Menu> service ): base(service)
        {
            _service = service;
        }


    }
}
