using System.Collections.Generic;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;

namespace ECOM.Domain.Services
{
    public class MenuService : ServiceBase<Menu>, IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MenuService(IMenuRepository repository , IUnitOfWork unitOfWork) : base(repository , unitOfWork)
        {
            _menuRepository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
