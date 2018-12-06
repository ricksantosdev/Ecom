using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ECOM.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuApp _menuApp;
        private readonly IMenuRepository _menuRepository;
        public MenuController(MenuApp menuApp, IMenuRepository repository)
        {
            _menuApp = menuApp;
            _menuRepository = repository;
        }



        public ActionResult Index()
        {

            var menus = Mapper.Map<IEnumerable<Menu>, IEnumerable<MenuViewModels>>(_menuApp.GetAll());

            if (Request.IsAjaxRequest())
                return PartialView(menus);

            return View(menus);
        }

        public ActionResult CreateEdit(int? id)
        {
            MenuViewModels menuModel = null;
            if (id != null)
                menuModel = Mapper.Map<Menu, MenuViewModels>(_menuApp.GetEntityById(id.Value));
            else
                menuModel = new MenuViewModels { Id = 0 };

            if (Request.IsAjaxRequest())
                return PartialView(menuModel);


            return View(menuModel);


        }

        [HttpPost]
        public ActionResult CreateEdit(MenuViewModels menu)
        {
            if (ModelState.IsValid)
            {
                var m = Mapper.Map<MenuViewModels, Menu>(menu);
                if (menu.Id == 0)
                    _menuApp.AddEntity(m);
                else
                    _menuApp.UpdateEntity(m);

                return RedirectToAction("Index");
            }

            return View(menu);
        }

        public ActionResult Delete(int id)
        {
            _menuApp.DeleteEntity(_menuApp.GetEntityById(id));

            return Json(new { status = "deletado com sucesso" }, JsonRequestBehavior.AllowGet);
        }
    }
}