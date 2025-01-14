using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoLavacar.Startup))]
namespace ProyectoLavacar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
