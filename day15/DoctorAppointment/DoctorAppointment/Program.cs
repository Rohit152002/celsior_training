using DoctorAppointment.Interfaces;
using DoctorAppointment.Models;
using DoctorAppointment.Repositories;
using DoctorAppointment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Repositories
builder.Services.AddScoped<IRepository<string, Patient>, PatientRepository>();
builder.Services.AddScoped<IRepository<string, Doctor>, DoctorRepository>();
#endregion

#region Service Providers

builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
#endregion

#region Authentication
#endregion

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
    pattern: "{controller=Patient}/{action=Index}/{id?}");

app.Run();
