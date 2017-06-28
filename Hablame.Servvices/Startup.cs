using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hablame.Servvices.Startup))]
namespace Hablame.Servvices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
