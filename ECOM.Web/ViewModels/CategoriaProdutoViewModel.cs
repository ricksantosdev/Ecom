
using ECOM.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ECOM.Web.ViewModels
{
    public class CategoriaProdutoViewModel
    {
        public CategoriaProdutoViewModel()
        {
            this.Produtos = new List<Produto>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha a categoria")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }

    }
}