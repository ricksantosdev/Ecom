using ECOM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ECOM.Infra.Data.EntityConfig
{
    public class ItensPedidoConfiguration : EntityTypeConfiguration<ItensPedido> , IMapping
    {
        public ItensPedidoConfiguration()
        {
            ToTable("ItensPedido");
        }
    }
}
