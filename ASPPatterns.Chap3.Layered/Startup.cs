using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPPatterns.Chap3.Layered.Startup))]
namespace ASPPatterns.Chap3.Layered
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
