using EventBooking.Context;
using EventBooking.Interface;
using EventBooking.Migrations;
using EventBooking.Models;
using EventBooking.Repository;
using EventBooking.Services;
using Microsoft.EntityFrameworkCore;

namespace EventBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Contexts
            builder.Services.AddDbContext<EventContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Repository
            builder.Services.AddScoped<IRepository<int,User>,UserRepository>();
            builder.Services.AddScoped<IRepository<int, Event>, EventRepository>();
            builder.Services.AddScoped<IRepository<int, Booking>, BookingRepository>();

            #endregion

            #region Services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEventService, EventServices>();
            builder.Services.AddScoped<IBookService, BookingService>();
            #endregion

            #region Mapper
            builder.Services.AddAutoMapper(typeof(User));
            builder.Services.AddAutoMapper(typeof(Event));
            builder.Services.AddAutoMapper(typeof(Booking));
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
