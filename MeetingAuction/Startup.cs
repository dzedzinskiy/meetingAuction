using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingAuction.Startup))]
namespace MeetingAuction
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
