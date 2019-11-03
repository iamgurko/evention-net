using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Evention.Startup))]
namespace Evention
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
