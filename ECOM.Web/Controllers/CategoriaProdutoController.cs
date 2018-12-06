using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ECOM.Web.Controllers
{
    public class CategoriaProdutoController : Controller
    {
        private readonly CategoriaProdutoApp _catApp;
        private readonly ProdutoApp _produtoApp;
        public CategoriaProdutoController( CategoriaProdutoApp categoriaApp , ProdutoApp produtoApp)
        {
            _catApp = categoriaApp;
            _produtoApp = produtoApp;
        }

        public ActionResult Index()
        {
            List<CategoriaProdutoViewModel> categorias = Mapper.Map<IEnumerable<CategoriaProduto>, IEnumerable<CategoriaProdutoViewModel>>(_catApp.GetAll()).ToList();

            if (Request.IsAjaxRequest())
                return PartialView(categorias);

            return View(categorias);
        }

        public ActionResult CreateEdit(int? id)
        {
            CategoriaProdutoViewModel categoriaVW;
            if (id != null)
            {
                categoriaVW = Mapper.Map<CategoriaProduto, CategoriaProdutoViewModel>(_catApp.GetEntityById(id.Value));
                categoriaVW.Produtos =_produtoApp.GetAll().Where(x => x.CategoriaProdutoId == categoriaVW.Id).ToList();
                IEnumerable<SelectListItem> produtosList = categoriaVW.Produtos.Select(x =>
                                                    new SelectListItem()
                                                    {
                                                        Text = x.Nome.ToString(),
                                                        Value = x.Id.ToString()
                                                        
                                                    });

                ViewBag.Produtos = produtosList;
            }
            else
            {
                categoriaVW = new CategoriaProdutoViewModel();
            }


            if (Request.IsAjaxRequest())
                return PartialView(categoriaVW);

            return View(categoriaVW);
        }

        [HttpPost]
        public ActionResult CreateEdit(CategoriaProdutoViewModel catVW)
        {
           if(ModelState.IsValid)
            {
                var cat = Mapper.Map<CategoriaProdutoViewModel, CategoriaProduto>(catVW);

                if (catVW.Id == 0)
                    _catApp.AddEntity(cat);
                else
                    _catApp.UpdateEntity(cat);

                return RedirectToAction("Index");
            }

            return View(catVW);

        }


        public ActionResult Delete(int id)
        {
            _catApp.DeleteEntity(_catApp.GetEntityById(id));

            return Json(new { status = "deletado com sucesso" }, JsonRequestBehavior.AllowGet);
        }


    }
}