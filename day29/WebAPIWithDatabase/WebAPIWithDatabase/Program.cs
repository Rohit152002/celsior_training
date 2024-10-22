using Microsoft.EntityFrameworkCore;
using WebAPIWithDatabase.Contexts;
using WebAPIWithDatabase.Interfaces;
using WebAPIWithDatabase.Models;
using WebAPIWithDatabase.Repositories;
using WebAPIWithDatabase.Services;
namespace WebAPIWithDatabase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Contexts
            builder.Services.AddDbContext<ShoppingContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Repositories
            builder.Services.AddScoped<IRepository<int, Customer>, CustomerRepository>();
            builder.Services.AddScoped<IRepository<int,Product>, ProductRepository>();
            builder.Services.AddScoped<IRepository<int,Image>,ImagesRepository>();
            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<ICustomerBasicServices, CustomerBasicServices>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IUserService, UserService>();
            #endregion

            #region OtherServices
            builder.Services.AddAutoMapper(typeof(Customer));
            builder.Services.AddAutoMapper(typeof(Product));
            builder.Services.AddAutoMapper(typeof(User));
            #endregion
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
