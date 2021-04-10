using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllMixedUp.WebMVC.Startup))]
namespace AllMixedUp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
