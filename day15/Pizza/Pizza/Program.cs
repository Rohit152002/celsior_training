using PizzaApplication.Interfaces;
using PizzaApplication.Models;
using PizzaApplication.Services;
using PizzaApplication.Repository;

namespace PizzaApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPizzaService, PizzaService>();//Service will be used in controller
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();//Repo will be used in service
            builder.Services.AddScoped<IRepository<int, PizzaImages>, PizzaImageRepository>();//Repo will be used in service


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}