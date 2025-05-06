using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyGamesLibrary.Models;
using MyGamesLibrary.Repository;

namespace MyGamesLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("constr")));

            //Registers//
            builder.Services.AddScoped<IPlayedRepo, PlayedRepo>();
            builder.Services.AddScoped<IWantedRepo, WantedRepo>();
            builder.Services.AddScoped<IFavouriteRepo, FavouriteRepo>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 4;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireDigit = false;
                option.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
