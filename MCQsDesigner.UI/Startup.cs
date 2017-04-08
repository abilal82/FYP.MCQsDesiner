using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCQsDesigner.UI.Startup))]
namespace MCQsDesigner.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
