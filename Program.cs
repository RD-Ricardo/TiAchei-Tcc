using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Controllers;
using TiAchei_Tcc.Db;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository;
using TiAchei_Tcc.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnetion");

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContextMysql>(x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddIdentity<User, IdentityRole>(x => 
        {
            x.Password.RequiredLength = 5;
            x.Password.RequireLowercase = false;
            x.Password.RequireUppercase = false;
            x.Password.RequireNonAlphanumeric = false;
            x.Password.RequireDigit = false;
        })
                .AddEntityFrameworkStores<AppDbContextMysql>()
                .AddDefaultTokenProviders();
                
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// app.UseSession();
app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoit =>
{
    endpoit.MapDefaultControllerRoute();

    endpoit.MapControllerRoute(
        name: "cardfiltro",
        pattern: "Card/{userId?}",
        defaults: new { Controller = "Card", Action = "Index"}
    );
    endpoit.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
}

);


app.Run();
