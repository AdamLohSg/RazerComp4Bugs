using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4Bugs.Areas.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace _4Bugs
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
            services.AddDbContext<DBContext>(options => options.UseMySql(Configuration.GetConnectionString("DBContextConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => 
                options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DBContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();
           /* services.AddDbContextPool<DBContext>(
            options => options.UseMySql("server=database-1.cdnxwix1v5ty.ap-southeast-1.rds.amazonaws.com;user=FourBugs;password=PHRINrjufd0neP2fsr6Q;database=database-1;",
                mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(8, 0, 17), ServerType.MySql); // replace with your Server Version and Type
                }
        ));*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
