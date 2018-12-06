using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ECOM.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly FornecedorApp _fornecedorApp;
        private readonly ProdutoApp _produtoApp;
        public FornecedorController(FornecedorApp fornecedorApp , ProdutoApp produtoApp)
        {
            _fornecedorApp = fornecedorApp;
            _produtoApp = produtoApp;
        }
        public ActionResult Index()
        {
            List<FornecedorViewModels> fornecedorVW = Mapper.Map< IEnumerable<Fornecedores>, IEnumerable<FornecedorViewModels>>(_fornecedorApp.GetAll()).ToList();
            if (Request.IsAjaxRequest())
                return PartialView(fornecedorVW);
            return View(fornecedorVW);
        }

        public ActionResult CreateEdit(int?  id)
        {
            FornecedorViewModels fornecedor;
            if (id != null)
            {
                fornecedor = Mapper.Map<Fornecedores, FornecedorViewModels>(_fornecedorApp.GetEntityById(id.Value));
                fornecedor.Produtos = _produtoApp.GetAll().Where(x => x.CategoriaProdutoId == id.Value).ToList();
                IEnumerable<SelectListItem> produtoList = fornecedor.Produtos.Select(x =>
                                                            new SelectListItem()
                                                            {
                                                                Text = x.Nome,
                                                                Value = x.Id.ToString()
                                                            });
                ViewBag.Produtos = produtoList;
            }
            else
            {
                fornecedor = new FornecedorViewModels();
            }
            if (Request.IsAjaxRequest())
                return PartialView(fornecedor);

            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult CreateEdit(FornecedorViewModels fornecedorViewModels)
        {
            if(ModelState.IsValid)
            {
                Fornecedores fornecedor = Mapper.Map<FornecedorViewModels, Fornecedores>(fornecedorViewModels);
                if (fornecedorViewModels.Id == 0)
                    _fornecedorApp.AddEntity(fornecedor);
                else
                    _fornecedorApp.UpdateEntity(fornecedor);

                return RedirectToAction("Index");
            }

            return View(fornecedorViewModels);
        }

        public ActionResult Delete(int id)
        {
            _fornecedorApp.DeleteEntity(_fornecedorApp.GetEntityById(id));

            return Json(new { status = "deletado com sucesso", JsonRequestBehavior.AllowGet });
        }
    }
}