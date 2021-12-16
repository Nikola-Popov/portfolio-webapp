using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(portfolio.Startup))]
namespace portfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
