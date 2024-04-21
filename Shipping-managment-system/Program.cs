
using Shipping_managment_system.Application;
using Shipping_managment_system.Infrastructure;

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
