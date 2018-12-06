using ECOM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ECOM.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto> , IMapping
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(250);

            //HasRequired(p => p.Cliente)
            //    .WithMany()
            //    .HasForeignKey(p => p.CLienteId);

        }
    }
}
