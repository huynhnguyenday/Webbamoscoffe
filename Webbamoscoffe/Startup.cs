using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Webbamoscoffe.Startup))]
namespace Webbamoscoffe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
