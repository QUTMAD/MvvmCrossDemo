using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WeatherMobileApp.Startup))]

namespace WeatherMobileApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}