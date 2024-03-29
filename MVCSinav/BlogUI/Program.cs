using DATA.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using REPO.Abstract;
using REPO.Concrete;
using REPO.Context;
using SERVICE.KonuService;
using SERVICE.KullaniciKonuSERVICE;
using SERVICE.MakaleKonuService;
using SERVICE.MakaleService;
using SERVICE.UserService;

namespace BlogUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IKonuSERVICE, KonuSERVICE>();
            builder.Services.AddScoped<IMakaleSERVICE, MakaleSERVICE>();
            builder.Services.AddScoped<IKonuREPO, KonuREPO>();
            builder.Services.AddScoped<IMakaleREPO, MakaleREPO>();
            builder.Services.AddScoped<IKullaniciKonuSERVICE,KullaniciKonuSERVICE>();
            builder.Services.AddScoped<KullaniciKonuREPO>();
            builder.Services.AddScoped<IUserSERVICE,UserSERVICE>();
            builder.Services.AddScoped<UserREPO>();
            builder.Services.AddScoped<IMakaleKonuREPO,MakaleKonuREPO>();
            builder.Services.AddScoped<IMakaleKonuSERVICE,MakaleKonuSERVICE>();



            var conn = builder.Configuration.GetConnectionString("DefaultConn");
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(conn));

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_@.";
            }).AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();
            


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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}