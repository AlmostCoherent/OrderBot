using OrderBot.Entity.Models.Support;
using OrderBot.Utilities;
using Unity;

namespace OrderBot.App_Start
{
    public class ServiceResolverConfig
    {
        public static void RegisterServices()
        {
            var container = new UnityContainer();

            container.RegisterType<ISupportRequestRepository, SupportRequestRepository>();

            ServiceResolver.Container = container;
        }
    }
}