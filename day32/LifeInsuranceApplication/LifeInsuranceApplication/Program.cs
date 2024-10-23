using AutoMapper;
using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
using Microsoft.EntityFrameworkCore;

namespace LifeInsuranceApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Context
            builder.Services.AddDbContext<InsuranceContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region  repositories
            builder.Services.AddScoped<IRepository<int, Policy>, PolicyRepository>();
            builder.Services.AddScoped<IRepository<int, ClaimType>, ClaimTypeRepository>();
            builder.Services.AddScoped<IRepository<int, Claim>, ClaimRepository>();
            #endregion

            #region  services
            builder.Services.AddScoped<IPolicyService, PolicyService>();
            builder.Services.AddScoped<IClaimTypeService, ClaimTypeService>();
            // builder.Services.AddScoped<IClaimService, ClaimService>();
            #endregion

            #region mapper
            builder.Services.AddAutoMapper(typeof(Policy));
            builder.Services.AddAutoMapper(typeof(ClaimTypeService));
            builder.Services.AddAutoMapper(typeof(Claim));
            #endregion

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

            // Register ClaimService with the upload folder as a parameter
            builder.Services.AddScoped<IClaimService>(
                provider =>
                    new ClaimService(
                        provider.GetRequiredService<IRepository<int, Claim>>(),
                        uploadFolder,
                        provider.GetRequiredService<IMapper>()
                        )
                );
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
