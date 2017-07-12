using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Adminpanel.Startup))]
namespace Adminpanel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
