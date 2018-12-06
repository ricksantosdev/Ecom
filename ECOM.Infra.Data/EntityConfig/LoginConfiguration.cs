using ECOM.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ECOM.Infra.Data.EntityConfig
{
    public class LoginConfiguration : EntityTypeConfiguration<Login> , IMapping
    {
        public LoginConfiguration()
        {
            ToTable("Login");
        }
    }
}
