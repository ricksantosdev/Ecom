using ECOM.Domain.Entities;
using System.Collections.Generic;

namespace ECOM.Web.ViewModels
{
    public class FornecedorViewModels
    {
        public FornecedorViewModels()
        {
            this.Produtos = new List<Produto>();
        }
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Nomefantasia { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string EnderecoComercial { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
        
    }
}