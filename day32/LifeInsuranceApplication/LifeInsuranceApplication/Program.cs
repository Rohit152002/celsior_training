using AutoMapper;
using LifeInsuranceApplication.Context;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Interfaces;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Repositories;
using LifeInsuranceApplication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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

            #region Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                // Check if the Authorization header is present
                var authorizationHeader = context.Request.Headers["Authorization"].ToString();

                if (string.IsNullOrEmpty(authorizationHeader))
                {
                    Console.WriteLine("No Authorization header found.");
                }
                else if (!authorizationHeader.StartsWith("Bearer "))
                {
                    Console.WriteLine("Authorization header is not a Bearer token.");
                }
                else
                {
                    // Token is present and valid
                    Console.WriteLine("Authorization header found: " + authorizationHeader);
                }

                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("Authentication failed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("Token validated.");
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                context.Response.Headers.Add("WWW-Authenticate", "Bearer");
                context.Response.StatusCode = 401; // Unauthorized
                return Task.CompletedTask;
            }
        };
    });

            #endregion

            #region  repositories
            builder.Services.AddScoped<IRepository<int, Policy>, PolicyRepository>();
            builder.Services.AddScoped<IRepository<int, ClaimType>, ClaimTypeRepository>();
            builder.Services.AddScoped<IRepository<int, CustomerClaim>, ClaimRepository>();
            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            #endregion

            #region  services
            builder.Services.AddScoped<IPolicyService, PolicyService>();
            builder.Services.AddScoped<IClaimTypeService, ClaimTypeService>();
            // builder.Services.AddScoped<IClaimService, ClaimService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            #endregion

            #region mapper
            builder.Services.AddAutoMapper(typeof(Policy));
            builder.Services.AddAutoMapper(typeof(ClaimType));
            builder.Services.AddAutoMapper(typeof(CustomerClaim));
           
            #endregion

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

            // Register ClaimService with the upload folder as a parameter
            builder.Services.AddScoped<IClaimService>(
                provider =>
                    new ClaimService(
                        provider.GetRequiredService<IRepository<int, CustomerClaim>>(),
                        uploadFolder,
                        provider.GetRequiredService<IMapper>()
                        )
                );

            var emailConfig=builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            builder.Services.AddSingleton(emailConfig);


            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });




            var app = builder.Build();

            app.UseAuthentication();

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
