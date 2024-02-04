namespace KnockKnockApp.Helpers
{
    public interface IServiceHelper
    {
        TService GetService<TService>();
    }
}
