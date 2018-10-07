using OrderBot.Dialogs;
using System.Web.Http;
using Unity;
using Unity.AspNet.WebApi;

namespace OrderBot.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IDialogFactory, DialogFactory>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

        }
    }
}