
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shipping_managment_system.Application;
using Shipping_managment_system.Application.Service;
using Shipping_managment_system.Infrastructure;
using Shipping_managment_system.Infrastructure.Data;
using Shipping_managment_system.Infrastructure.SeedData;

namespace Shipping_managment_system
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();

            // Add services to the container.


            builder.Services.AddInfrastructure(configuration);
            builder.Services.AddApplication();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();

                context.Database.Migrate();

                var userMgr = services.GetRequiredService<UserManager<IdentityUser<Guid>>>();
                var roleMgr = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                SeedData.Initialize(context, userMgr, roleMgr).Wait();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();



            app.MapControllers();
            //app.MapHub<EventHub>("offers");

            app.UseCors("AllowOrigin");
            app.Run();
        }
    }
}
