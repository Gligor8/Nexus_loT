using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nexus_loT.Models;
using Nexus_loT_Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexus_loT_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            //var seed = args.Contains("/seed");
            //if (seed)
            //{
            //    args = args.Except(new[] { "/seed" }).ToArray();
            //}

            //var host = CreateHostBuilder(args).Build();
            //if (seed)
            //{

            //}

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var _userManager = serviceProvider.
                        GetRequiredService<UserManager<User>>();

                    var _roleManager = serviceProvider.
                        GetRequiredService<RoleManager<IdentityRole>>();

                    SeedingService.SeedData
                        (_userManager, _roleManager);
                }
                catch
                {

                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                });
                
    }
}
