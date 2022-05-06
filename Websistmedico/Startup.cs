using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Websistmedico.Startup))]
namespace Websistmedico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
