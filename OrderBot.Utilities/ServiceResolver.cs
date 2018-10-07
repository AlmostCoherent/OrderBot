using Unity;

namespace OrderBot.Utilities
{
    public static class ServiceResolver
    {
        public static IUnityContainer Container;
        public static T GetService<T>()
        {
            using(var scope = Container.CreateChildContainer())
            {
                return scope.Resolve<T>();
            }
        }
    }
}
