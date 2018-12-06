using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECOM.Web.Startup))]
namespace ECOM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


    }
}
