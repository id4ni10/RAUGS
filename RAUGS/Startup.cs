using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RAUGS.Startup))]
namespace RAUGS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
