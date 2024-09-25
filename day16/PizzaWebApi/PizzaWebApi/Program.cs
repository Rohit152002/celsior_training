using PizzaWebApi.Interfaces;
using PizzaWebApi.Models;
using PizzaWebApi.Repository;
using PizzaWebApi.Services;

namespace PizzaWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region RepositoryInjection
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            builder.Services.AddScoped<IRepository<int, Customer>, CustomerRepository>();
            builder.Services.AddScoped<IRepository<int, Order>, OrderRepository>();
            builder.Services.AddScoped<IRepository<int, OrderDetails>, OrderDetailsRepository>();
            builder.Services.AddScoped<IRepository<int,Cart>, CartRepository>();
            #endregion

            #region ServiceInjection
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
