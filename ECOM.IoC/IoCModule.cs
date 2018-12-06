using ECOM.Application.Entities;
using ECOM.Application.Interfaces;
using ECOM.Domain.Interfaces.Repositories;
using ECOM.Domain.Interfaces.Services;
using ECOM.Domain.Services;
using ECOM.Infra.Data.Contexto;
using ECOM.Infra.Data.Repositories;
using Ninject.Modules;

namespace ECOM.Infra.IoC
{
    public class IoCModule : NinjectModule
    {
        public override void Load()
        {
            //APPLICATION
           // Bind<IBaseApp<T>>().To<AppBase<T>>();
            Bind(typeof(IBaseApp<>)).To(typeof(AppBase<>));
            Bind<IAppCliente>().To<ClienteApplication>();
            Bind<IMenuApp>().To<MenuApp>();
            Bind<ICategoriaProdutoApp>().To<CategoriaProdutoApp>();
            Bind<IFornecedorApp>().To<FornecedorApp>();
            Bind<IFormaPagtoApp>().To<FormaPagtoApp>();
            Bind<IProdutoApp>().To<ProdutoApp>();

            //SERVICE
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<ICLienteService>().To<ClienteService>();
            Bind<IMenuService>().To<MenuService>();
            Bind<ICategoriaProdutoService>().To<CategoriaProdutoService>();
            Bind<IFornecedorService>().To<FornecedorService>();
            Bind<IFormaPagtoService>().To<FormaPagtoService>();
            Bind<IProdutoService>().To<ProdutoService>();

            //REPOSITORY
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<ICLienteRepository>().To<ClienteRepository>();
            Bind<IProdutoRepository>().To<ProdutoRepository>();
            Bind<IMenuRepository>().To<MenuRepository>();
            Bind<ICategoriaProdutoRepository>().To<CategoriaProdutoRepository>();
            Bind<IFornecedorRepository>().To<FornecedorRepository>();
            Bind<IFormaPagtoService>().To<FormaPagtoService>();

            //BIND UNIT OF WORK
            Bind<ContextManager>().ToSelf();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
