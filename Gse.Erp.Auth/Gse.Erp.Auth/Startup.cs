using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gse.Erp.MvcAuth.Startup))]
namespace Gse.Erp.MvcAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
