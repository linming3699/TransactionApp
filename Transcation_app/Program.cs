using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Transcation_app.Interfaces;
using Transcation_app.Models;
using Transcation_app.Services;

namespace Transcation_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // 未登入會導向此頁
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TransactionDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("TransactionDb")));
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });
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
