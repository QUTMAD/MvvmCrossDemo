using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(QutMadSem22016Wednesday3Service.Startup))]

namespace QutMadSem22016Wednesday3Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}