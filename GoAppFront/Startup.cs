using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoAppFront.Startup))]
namespace GoAppFront
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
