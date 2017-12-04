using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using MCQsDesigner.DAL;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(MCQsDesigner.Web.App_Start.Startup))]

namespace MCQsDesigner.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           


            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
           
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions {

                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/login")

            });
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
