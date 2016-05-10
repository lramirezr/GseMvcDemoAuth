using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gse.Erp.Auth.Mvc.Startup))]
namespace Gse.Erp.Auth.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
