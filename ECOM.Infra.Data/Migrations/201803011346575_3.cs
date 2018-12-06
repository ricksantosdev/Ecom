namespace ECOM.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Imagem1", c => c.Binary());
            AddColumn("dbo.Produto", "Imagem2", c => c.Binary());
            AddColumn("dbo.Produto", "Imagem3", c => c.Binary());
            AddColumn("dbo.Produto", "Imagem4", c => c.Binary());
            DropColumn("dbo.Produto", "Imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Imagem", c => c.Binary());
            DropColumn("dbo.Produto", "Imagem4");
            DropColumn("dbo.Produto", "Imagem3");
            DropColumn("dbo.Produto", "Imagem2");
            DropColumn("dbo.Produto", "Imagem1");
        }
    }
}
