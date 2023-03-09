using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CRMSSystem.StartupOwin))]

namespace CRMSSystem
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
