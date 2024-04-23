using Microsoft.AspNetCore.Authentication;

namespace Shipping_managment_system.Application
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication( this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssemblies(typeof(DependancyInjection).Assembly);

            });

            services.AddSignalR();


            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
