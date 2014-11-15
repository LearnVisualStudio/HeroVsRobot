using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HeroVsRobot.Startup))]
namespace HeroVsRobot
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
