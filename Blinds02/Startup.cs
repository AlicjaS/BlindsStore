using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blinds02.Startup))]
namespace Blinds02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
