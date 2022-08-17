using AutoMapper;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nexus_loT.DataAccess;
using Nexus_loT.DataAccess.Repository;
using Nexus_loT.DataAccess.Repository.IRepository;
using Nexus_loT.Models;
using Nexus_loT_Web.Services;
using System;
using System.Reflection;

namespace Nexus_loT_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfire(config =>
                config.UsePostgreSqlStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<IClusterRepository, ClusterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IMeasurementUnitRepository, MeasurementUnitRepository>();
            services.AddScoped<ISensorTypeRepository, SensorTypeRepository>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IReadingRepository, ReadingRepository>();
            services.AddScoped<SensorReadingService>();
            //services.AddScoped<SeedingService>();
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IRecurringJobManager recurringJobManager, UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            recurringJobManager.AddOrUpdate("Send Request to API", () => serviceProvider.GetService<SensorReadingService>().ReadFromSensorAsync(DateTime.Now.ToLongTimeString()), Cron.Minutely);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthentication();
            
            app.UseAuthorization();

            SeedingService.SeedData(_userManager, _roleManager);

            app.UseStaticFiles();
            //app.UseSession();
            //app.MapRazorPages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=BasicUser}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
       
            });
        }
    }
}
