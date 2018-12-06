using ECOM.Domain.Entities;
using System.Collections.Generic;

namespace ECOM.Web.ViewModels
{
    public class MenuStoreViewModels
    {
        public MenuStoreViewModels()
        {
            Produtos = new List<string>();
        }
        public string Categoria { get; set; }
        public int QtdeProdutoPorCategoria { get; set; }
        public int ProdutoId { get; set; }
        public List<string> Produtos { get; set; }
    }
}