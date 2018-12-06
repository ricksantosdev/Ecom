namespace ECOM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Sobrenome = c.String(maxLength: 100, unicode: false),
                        Cpf = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CLienteId = c.Int(nullable: false),
                        DataPedido = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.CLienteId)
                .Index(t => t.CLienteId);
            
            CreateTable(
                "dbo.FormaPagto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(maxLength: 100, unicode: false),
                        Nomefantasia = c.String(maxLength: 100, unicode: false),
                        CNPJ = c.String(maxLength: 100, unicode: false),
                        Telefone = c.String(maxLength: 100, unicode: false),
                        Celular = c.String(maxLength: 100, unicode: false),
                        EnderecoComercial = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItensPedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.PedidoId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Disponivel = c.Boolean(nullable: false),
                        Imagem = c.Binary(),
                        CategoriaProdutoId = c.Int(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaProduto", t => t.CategoriaProdutoId)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId)
                .Index(t => t.CategoriaProdutoId)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Password = c.String(maxLength: 100, unicode: false),
                        IsAdm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(maxLength: 100, unicode: false),
                        Controller = c.String(maxLength: 100, unicode: false),
                        Action = c.String(maxLength: 100, unicode: false),
                        Area = c.String(maxLength: 100, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Login", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.ItensPedido", "ProdutoId", "dbo.Produto");
            DropForeignKey("dbo.Produto", "FornecedorId", "dbo.Fornecedor");
            DropForeignKey("dbo.Produto", "CategoriaProdutoId", "dbo.CategoriaProduto");
            DropForeignKey("dbo.ItensPedido", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "CLienteId", "dbo.Cliente");
            DropIndex("dbo.Login", new[] { "ClienteId" });
            DropIndex("dbo.Produto", new[] { "FornecedorId" });
            DropIndex("dbo.Produto", new[] { "CategoriaProdutoId" });
            DropIndex("dbo.ItensPedido", new[] { "ProdutoId" });
            DropIndex("dbo.ItensPedido", new[] { "PedidoId" });
            DropIndex("dbo.Pedido", new[] { "CLienteId" });
            DropTable("dbo.Menu");
            DropTable("dbo.Login");
            DropTable("dbo.Produto");
            DropTable("dbo.ItensPedido");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.FormaPagto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Cliente");
            DropTable("dbo.CategoriaProduto");
        }
    }
}
