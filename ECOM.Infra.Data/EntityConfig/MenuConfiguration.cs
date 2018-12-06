using ECOM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ECOM.Infra.Data.EntityConfig
{
    public class MenuConfiguration : EntityTypeConfiguration<Menu> , IMapping
    {
        public MenuConfiguration()
        {
            ToTable("Menu");
        }
    }
}
