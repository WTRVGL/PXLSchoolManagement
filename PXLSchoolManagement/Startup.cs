using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PXLSchoolManagement.Data;
using PXLSchoolManagement.Models;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace PXLSchoolManagement
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
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.Filters.Add(new AuthorizeFilter("RequiresVerification"));
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequiresVerification",
                    policyBuilder => policyBuilder.RequireRole(new string[] { "Admin", "Lector", "Student" }));
            });

            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultSqlServer"));
            });

            services.AddDefaultIdentity<Gebruiker>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context, UserManager<Gebruiker> userManager)
        {

            //context.Database.EnsureDeleted();
            context.Database.Migrate();
            DatabaseInitializer.InitializeDb(context, userManager);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages().RequireAuthorization();
                endpoints.MapAreaControllerRoute(
                    "Home",
                    "Home",
                    "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    "Admin",
                    "Admin",
                    "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "Student",
                    areaName: "Student",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}