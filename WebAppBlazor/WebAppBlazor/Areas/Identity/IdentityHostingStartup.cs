using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppBlazor.Data;

[assembly: HostingStartup(typeof(WebAppBlazor.Areas.Identity.IdentityHostingStartup))]
namespace WebAppBlazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebAppBlazorContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebAppBlazorContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebAppBlazorContext>();
            });
        }
    }
}