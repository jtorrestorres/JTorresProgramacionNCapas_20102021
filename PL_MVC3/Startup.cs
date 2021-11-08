using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PL_MVC3.Startup))]
namespace PL_MVC3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
