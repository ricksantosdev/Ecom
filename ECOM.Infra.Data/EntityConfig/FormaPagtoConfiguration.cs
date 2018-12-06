using ECOM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ECOM.Infra.Data.EntityConfig
{
    public class FormaPagtoConfiguration : EntityTypeConfiguration<FormaPagto> , IMapping
    {
        public FormaPagtoConfiguration()
        {
            ToTable("FormaPagto");
        }
    }
}
