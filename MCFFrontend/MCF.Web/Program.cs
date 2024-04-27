using MCF.Web.Services.IServices;
using MCF.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using MCF.Web.Utility;

namespace MCF.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();

            builder.Services.AddHttpClient<IAuthService, AuthService>();
            builder.Services.AddHttpClient<IStorageLocationService, StorageLocationService>();
            builder.Services.AddHttpClient<IBpkbService, BpkbService>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IStorageLocationService, StorageLocationService>();
            builder.Services.AddScoped<IBpkbService, BpkbService>();
            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<ITokenProvider, TokenProvider>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                    options.LoginPath = "/Auth/Login";
                });

            var app = builder.Build();

            SD.MCFAPIBase = builder.Configuration["ServiceUrls:MCFAPI"];

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