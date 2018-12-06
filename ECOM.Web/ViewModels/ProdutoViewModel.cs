using ECOM.Domain.Entities;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace ECOM.Web.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Categorias = new List<SelectListItem>();
            Fornecedores = new List<SelectListItem>();

            Imagem1 = new byte[0];
            Imagem2 = new byte[0];
            Imagem3 = new byte[0];
            Imagem4 = new byte[0];

            
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Disponivel { get; set; }
        public byte[] Imagem1 { get; set; }
        public byte[] Imagem2 { get; set; }
        public byte[] Imagem3 { get; set; }
        public byte[] Imagem4 { get; set; }
        public string ImgVisual1 { get; set; }
        public string ImgVisual2 { get; set; }
        public string ImgVisual3 { get; set; }
        public string ImgVisual4 { get; set; }
        public int CategoriaProdutoId { get; set; }
        public virtual CategoriaProduto CategoriaProduto { get; set; }
        public int FornecedorId { get; set; }
        public virtual Fornecedores Fornecedor { get; set; }
        public IEnumerable<SelectListItem> Categorias { get; set; }
        public IEnumerable<SelectListItem> Fornecedores { get; set; }

        public decimal Preco { get; set; }
        
    }
}