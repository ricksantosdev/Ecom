using ECOM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ECOM.Infra.Data.EntityConfig
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido> , IMapping
    {
        public PedidoConfiguration()
        {
            ToTable("Pedido");
        }
    }
}
