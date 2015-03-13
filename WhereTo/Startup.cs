using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhereTo.Startup))]
namespace WhereTo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
