using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;
using ECOM.Web.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Linq;

namespace ECOM.Web.Helpers
{
    public static class MenuHelper
    {
        public static List<MenuViewModels> GetMenu()
        {
            IServiceBase<Menu> service = ServiceLocator.Current.GetInstance<IServiceBase<Menu>>();
            MenuApp menuApp = new MenuApp(service);
            IEnumerable<MenuViewModels> menus =  Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModels>>(menuApp.GetAll());
            return menus.OrderBy(x => x.Titulo).ToList();

        }
    }
}