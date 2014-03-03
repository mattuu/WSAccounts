using System;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using WS.Accounts.Site.App_Start;

namespace WS.Accounts.Site
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            UnityConfig.RegisterComponents();

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}