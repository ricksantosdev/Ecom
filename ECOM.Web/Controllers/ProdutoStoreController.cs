using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;
using ECOM.Web.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECOM.Web.Controllers
{
    public class ProdutoStoreController : Controller
    {
        private  ProdutoApp _produtoApp;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _uow;

        public ProdutoStoreController(ProdutoApp produtoApp , IProdutoRepository repository , IUnitOfWork unitOfWork)
        {
            _produtoApp = produtoApp;

            _uow = unitOfWork;
            _produtoRepository = repository;
        }

        //public ActionResult Index()
        //{
        //    List<Produto> produtos = _produtoApp.GetAll().ToList();

        //    if (Request.IsAjaxRequest())
        //        return PartialView(produtos);
        //    return View(produtos);

        //}

        public ActionResult Index(string nome)
        {
            List<Produto> produtos;
            if(! string.IsNullOrEmpty(nome))
                produtos = _produtoApp.GetAll("CategoriaProduto", "Fornecedor").Where(x => x.Nome.Contains(nome)).ToList();
            else
                produtos = _produtoApp.GetAll("CategoriaProduto", "Fornecedor").ToList();

            //if (_produtoApp != null)
            //{
            //    produtos = _produtoApp.GetAll("CategoriaProduto", "Fornecedor").Where(x => x.Nome.Contains(nome)).ToList();
            //}
            //else
            //{
            //    IServiceBase<Produto> service = ServiceLocator.Current.GetInstance<IProdutoService>();
            //    _produtoApp = new ProdutoApp(service);
            //    produtos = _produtoApp.GetAll("CategoriaProduto", "Fornecedor").Where(x => x.Nome.Contains(nome)).ToList();
            //}

            List<ProdutoViewModel> produtosVW =  Mapper.Map<List<Produto>, List<ProdutoViewModel>>(produtos);

            foreach (var item in produtosVW)
            {
                item.ImgVisual1 = Helpers.UtilHelper.RetornaFromByteToImageString(item.Imagem1);
            }

            if (Request.IsAjaxRequest())
                return PartialView(produtosVW);

            return View(produtosVW);
        }

        public ActionResult Detalhe()
        {
            return View();
        }
    }
}