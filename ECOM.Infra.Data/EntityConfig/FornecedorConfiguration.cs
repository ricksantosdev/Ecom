using ECOM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ECOM.Infra.Data.EntityConfig
{
    public class FornecedorConfiguration : EntityTypeConfiguration<Fornecedores> , IMapping
    {
        public FornecedorConfiguration()
        {
            ToTable("Fornecedor");
        }
    }
}
