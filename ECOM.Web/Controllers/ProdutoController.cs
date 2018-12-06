using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECOM.Web.Helpers;

namespace ECOM.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoApp _produtoApp;
        private readonly FornecedorApp _fornecedorApp;
        private readonly CategoriaProdutoApp _categoriaApp;


        public ProdutoController(ProdutoApp produtoApp , FornecedorApp fornecedorApp , CategoriaProdutoApp categoriaProdutoApp)
        {
            _produtoApp = produtoApp;
            _fornecedorApp = fornecedorApp;
            _categoriaApp = categoriaProdutoApp;
        }

        public ActionResult Index()
        {
            //IEnumerable<Produto> products = _produtoApp.GetAll("CategoriaProduto", "Fornecedor");
            //List<ProdutoViewModel> produtos = new List<ProdutoViewModel>();
            //foreach (var item in products)
            //{
            //    produtos.Add(Mapper.Map<Produto, ProdutoViewModel>(item));
            //}

            List<ProdutoViewModel> produtos = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll("CategoriaProduto", "Fornecedor")).ToList();


            if (Request.IsAjaxRequest())
                return PartialView(produtos);
            return View(produtos);
        }

        public ActionResult CreateEdit(int? id)
        {
            ProdutoViewModel produtoVW = new ProdutoViewModel();
           
            if (id != null)
            {
                produtoVW = Mapper.Map<Produto, ProdutoViewModel>(_produtoApp.GetEntityById(id.Value));
                produtoVW.ImgVisual1 = UtilHelper.RetornaFromByteToImageString(produtoVW.Imagem1);
                produtoVW.ImgVisual2 = UtilHelper.RetornaFromByteToImageString(produtoVW.Imagem2);
                produtoVW.ImgVisual3 = UtilHelper.RetornaFromByteToImageString(produtoVW.Imagem3);
                produtoVW.ImgVisual4 = UtilHelper.RetornaFromByteToImageString(produtoVW.Imagem4);
            }
            produtoVW.Categorias = _categoriaApp.GetAll().Select(x =>
                                                       new SelectListItem()
                                                       {
                                                           Text = x.Nome,
                                                           Value = x.Id.ToString()
                                                       });

            produtoVW.Fornecedores = _fornecedorApp.GetAll().Select(x =>
                                                    new SelectListItem()
                                                    {
                                                        Text = x.Nomefantasia,
                                                        Value = x.Id.ToString()
                                                    });
            if (Request.IsAjaxRequest())
                return PartialView(produtoVW);
            return View(produtoVW);
        }
        [HttpPost]
        public ActionResult CreateEdit(ProdutoViewModel produtoView )
        {
            HttpPostedFileBase image1 = Request.Files["image1"];
            HttpPostedFileBase image2 = Request.Files["image2"];
            HttpPostedFileBase image3 = Request.Files["image3"];
            HttpPostedFileBase image4 = Request.Files["image4"];
            if (ModelState.IsValid)
            {
                Produto produto;
                if (produtoView.Id == 0)
                {
                    produto = Mapper.Map<ProdutoViewModel, Produto>(produtoView);
                }
                else
                {
                    produto = _produtoApp.GetEntityById(produtoView.Id);
                    produto.CategoriaProdutoId = produtoView.CategoriaProdutoId;
                    produto.Descricao = produtoView.Descricao;
                    produto.Disponivel = produtoView.Disponivel;
                    produto.FornecedorId = produtoView.FornecedorId;

                }

                if (!string.IsNullOrEmpty(image1.FileName))
                {
                    produto.Imagem1 = new byte[image1.ContentLength];
                    image1.InputStream.Read(produto.Imagem1, 0, image1.ContentLength);
                }


                if (!string.IsNullOrEmpty(image2.FileName))
                {
                    produto.Imagem2 = new byte[image2.ContentLength];
                    image2.InputStream.Read(produto.Imagem2, 0, image2.ContentLength);
                }


                if (!string.IsNullOrEmpty(image3.FileName))
                {
                    produto.Imagem3 = new byte[image3.ContentLength];
                    image3.InputStream.Read(produto.Imagem3, 0, image3.ContentLength);
                }


                if (!string.IsNullOrEmpty(image4.FileName))
                {
                    produto.Imagem4 = new byte[image4.ContentLength];
                    image4.InputStream.Read(produto.Imagem4, 0, image4.ContentLength);
                }


                if (produtoView.Id == 0)
                {
                    _produtoApp.AddEntity(produto);
                }
                else
                {
                    _produtoApp.UpdateEntity(produto);
                }

                return RedirectToAction("Index");
            }
            return View(produtoView);
        }

        public ActionResult Delete(int id)
        {
            _produtoApp.DeleteEntity(_produtoApp.GetEntityById(id));
            return Json(new { status = "deletado", JsonRequestBehavior.AllowGet });
        }
    }
}