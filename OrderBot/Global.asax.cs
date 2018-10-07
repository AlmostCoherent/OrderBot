using OrderBot.App_Start;
using System.Web.Http;

namespace OrderBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            ServiceResolverConfig.RegisterServices();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
