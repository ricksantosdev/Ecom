

namespace ECOM.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Disponivel { get; set; }
        public byte[] Imagem1 { get; set; }
        public byte[] Imagem2 { get; set; }
        public byte[] Imagem3 { get; set; }
        public byte[] Imagem4 { get; set; }
        public int CategoriaProdutoId { get; set; }
        public virtual CategoriaProduto CategoriaProduto { get; set; }
        public int FornecedorId { get; set; }
        public virtual Fornecedores Fornecedor { get; set; }
        public decimal Preco { get; set; }

    }
}
