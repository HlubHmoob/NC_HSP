using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NC_HSP.Startup))]
namespace NC_HSP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
