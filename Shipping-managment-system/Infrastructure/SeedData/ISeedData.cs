namespace Shipping_managment_system.Infrastructure.SeedData
{
    public interface ISeedData
    {
        Task InitializeAsync(IServiceProvider service);
    }
}
