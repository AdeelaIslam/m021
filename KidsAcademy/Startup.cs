using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KidsAcademy.Startup))]
namespace KidsAcademy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
