using BankSystem.Core.Entities.Auth;
using BankSystem.Data.Persistence;
using Microsoft.AspNetCore.Identity;
using BankSystem.Service;
using BankSystem.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentity<AppUser, IdentityRole>(
        option =>
        {
            option.Password.RequiredUniqueChars = 0;
            option.Password.RequireUppercase = false;
            option.Password.RequireLowercase = false;
            option.Password.RequiredLength = 8;
            option.Password.RequireNonAlphanumeric = false;

        }

        ).AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
//builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ApplicationConfiguration(builder.Configuration);
builder.Services.InfrastructureConfiguration(builder.Configuration);

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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();