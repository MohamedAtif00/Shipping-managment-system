namespace Shipping_managment_system.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication( this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(typeof(DependancyInjection).Assembly);

            });

            return services;
        }
    }
}
