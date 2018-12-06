using ECOM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ECOM.Infra.Data.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<CategoriaProduto> , IMapping
    {
        public CategoriaConfiguration()
        {
            ToTable("CategoriaProduto");

        }
        
    }
}
