using UnderstandingLayeredStructure.Interfaces;
using UnderstandingLayeredStructure.Repository;
using UnderstandingLayeredStructure.Service;

namespace UnderstandingLayeredStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ILoginServices, LoginService>();
            builder.Services.AddScoped<IRepository, LoginRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}