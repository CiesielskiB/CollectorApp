using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollectorApp.WebUI.Startup))]
namespace CollectorApp.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
