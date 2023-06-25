using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ali_ECommerce.Startup))]
namespace Ali_ECommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
