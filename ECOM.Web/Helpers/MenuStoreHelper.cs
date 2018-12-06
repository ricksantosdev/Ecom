using AutoMapper;
using ECOM.Application.Entities;
using ECOM.Domain.Entities;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;
using ECOM.Infra.Data.Repositories;
using ECOM.Web.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Linq;

namespace ECOM.Web.Helpers
{
    public static class MenuStoreHelper
    {
        //static CategoriaProdutoApp _categoria = new CategoriaProdutoApp();
        
        public static List<MenuStoreViewModels> GetMenuStore()
        {
            IServiceBase<CategoriaProduto> categoriaProdutoRepository = ServiceLocator.Current.GetInstance<IServiceBase<CategoriaProduto>>();
            IServiceBase<Produto> produtoApp = ServiceLocator.Current.GetInstance<IServiceBase<Produto>>();

            //CategoriaProdutoApp categoriaProdutoApp = new CategoriaProdutoApp(categoriaService);
            //ProdutoApp produtoApp = new ProdutoApp(produtoService);

            //ICategoriaProdutoRepository categoriaProdutoRepository = new CategoriaProdutoRepository();
            //IProdutoRepository produtoApp = new ProdutoRepository();

            List<CategoriaProdutoViewModel> categorias = Mapper.Map<IEnumerable<CategoriaProduto>, IEnumerable<CategoriaProdutoViewModel>>(categoriaProdutoRepository.GetAll()).ToList();
            //List<Produto> produtos = produtoApp.GetAll().ToList();

            //List<Produto> produtos = produtoApp.GetAll()
            //            .GroupBy(x => x.Nome.ToUpper())
            //            .Select(x => x.FirstOrDefault())
            //            .ToList();


            //var produtos = from x in produtoApp.GetAll()
            //            group x by x.Nome
            //            into y
            //            select y.First();


            List<Produto> produtos = (from q in produtoApp.GetAll()
                                      group q by new { q.Nome , q.CategoriaProdutoId } into newQuery
                                      select new Produto
                                      {
                                          Nome = newQuery.Key.Nome ,
                                          CategoriaProdutoId = newQuery.Key.CategoriaProdutoId
                                      }).Distinct().ToList();


            var prodDistinct = produtos.Select(x => x.Nome).Distinct();

            List<MenuStoreViewModels> menus = new List<MenuStoreViewModels>();



            foreach (var item in categorias)
            {
                item.Produtos = produtos.Where(x => x.CategoriaProdutoId == item.Id);
            }

            foreach (var item in categorias)
            {
                MenuStoreViewModels m = new MenuStoreViewModels();

                m.Categoria = item.Nome;
                if(item.Produtos.Count() > 0)
                {
                    m.QtdeProdutoPorCategoria = item.Produtos.Count();
                    m.Produtos = item.Produtos.Where(x => x.CategoriaProdutoId == item.Id).Select(x => x.Nome.Trim()).Distinct().ToList();
                }

                menus.Add(m);
            }

            return menus;
        }
    }
}