using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QQQ.Mvc5WebUI.Startup))]
namespace QQQ.Mvc5WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
