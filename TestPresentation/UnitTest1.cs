using System;
using System.Collections.Generic;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;
using ECOM.Domain.Services;
using ECOM.Infra.Data.Repositories;
using ECOM.Infra.IoC;
using ECOM.Web.Helpers;
using ECOM.Web.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using ServiceLocation;

namespace ECOM.Web.TestPresentation
{
   

    [TestClass]
    public class UnitTest1
    {
        private IServiceLocator locator;
        private ICategoriaProdutoService _categoria;
        private ICategoriaProdutoRepository _catRepository;
        private CategoriaProdutoApp cat;
        [TestInitialize]
        public void Initialize()
        {
            IoC.Init();
            cat = new CategoriaProdutoApp(_categoria);
        }

        [TestMethod]
        public void TestMethod1()
        {

            List<MenuStoreViewModels> m  = MenuStoreHelper.GetMenuStore();
        }
    }
}
