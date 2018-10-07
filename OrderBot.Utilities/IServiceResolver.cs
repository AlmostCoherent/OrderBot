namespace OrderBot.Utilities
{
    public interface IServiceResolver
    {
        T GetService<T>();
    }
}
