/*
 * Name: Shivam Janda
 * Date: December 12, 2022
 * Description: Identity Hosting startup class and its properties to connect to db for auth db context
 */
using System;
using Lab5Workout.Areas.Identity.Data;
using Lab5Workout.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Lab5Workout.Areas.Identity.IdentityHostingStartup))]
namespace Lab5Workout.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            // configured the user database context over here instead of the startup.cs
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}