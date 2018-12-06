using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM.Domain.Entities
{
    public class Fornecedores
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Nomefantasia { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string EnderecoComercial { get; set; }
       

    }
}
