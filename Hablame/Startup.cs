using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hablame.Startup))]
namespace Hablame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
