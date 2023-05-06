using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using BusinessTrips.Business;
using BusinessTrips.Business.Interfaces;
using BusinessTrips.Business.Interfaces.Services;
using BusinessTrips.Business.Services;
using BusinessTrips.DataAccess;
using BusinessTrips.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });


builder.Services.AddDbContext<BusinessTripsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BusinessTripsDb")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BusinessTripsContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IBaseRepository<CompanyHQ, int>, BaseRepository<CompanyHQ, int>>();
builder.Services.AddScoped<IBaseRepository<ClientLocation, int>, BaseRepository<ClientLocation, int>>();
builder.Services.AddScoped<IBaseRepository<User, string>, BaseRepository<User, string>>();
builder.Services.AddScoped<IBaseRepository<Client, int>, BaseRepository<Client, int>>();
builder.Services.AddScoped<IBaseRepository<Project, int>, BaseRepository<Project, int>>();
builder.Services.AddScoped<IBaseRepository<ProjectTask, int>, BaseRepository<ProjectTask, int>>();
builder.Services.AddScoped<IBaseRepository<BusinessTrip, int>, BaseRepository<BusinessTrip, int>>();

builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();


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

app.UseNotyf();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Admin",
    pattern: "{Controller=Home}/{action=Index}");

app.Run();
