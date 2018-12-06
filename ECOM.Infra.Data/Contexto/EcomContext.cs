using ECOM.Domain.Entities;
using ECOM.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace ECOM.Infra.Data.Contexto
{
    public class EcomContext : DbContext 
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItensPedido> ItensPedido { get; set; }
        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Fornecedores> Fornecedores { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<FormaPagto> FormaPagto { get; set; }

        public EcomContext() : base("ECom")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                            .Where(x => x.Name == x.ReflectedType.Name + "Id")
                            .Configure(x => x.IsKey());

            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(x => x.HasMaxLength(100));



            //modelBuilder.Configurations.Add(new ClienteConfiguration());
            //modelBuilder.Configurations.Add(new ProdutoConfiguration());
            //modelBuilder.Configurations.Add(new CategoriaConfiguration());
            //modelBuilder.Configurations.Add(new FormaPagtoConfiguration());
            //modelBuilder.Configurations.Add(new FornecedorConfiguration());
            //modelBuilder.Configurations.Add(new ItensPedidoConfiguration());
            //modelBuilder.Configurations.Add(new LoginConfiguration());
            //modelBuilder.Configurations.Add(new PedidoConfiguration());
            //modelBuilder.Configurations.Add(new MenuConfiguration());

            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();

            // Varrendo todos os tipos que são mapeamento 
            // Com ajuda do Reflection criamos as instancias 
            // e adicionamos no Entity Framework
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }
        }

       
    }


}
