

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECOM.Web.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Preencha o nome")]
        [MaxLength(150 , ErrorMessage ="Máximo {0} caracteres")]
        [MinLength(2 , ErrorMessage ="Minimo {0} caracteres")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo cpf")]
        public decimal Cpf { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]    //informando que field nao aparecera no scaffoding
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        [Range(18, 30)]
        public int Idade { get; set; }

        [ReadOnly(true)]
        public string Password { get; set; }
    }
}