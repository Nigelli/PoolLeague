using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIS.Pool.Startup))]
namespace UIS.Pool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
