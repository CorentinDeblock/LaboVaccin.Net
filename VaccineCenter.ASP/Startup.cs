using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceASP.Bases;
using ServiceASP.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineCenter.Models;
using VaccineCenter.Models.Form;
using VaccineCenter.Services;

namespace VaccineCenter.ASP
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

            services.AddScoped<DataContext>();

            services.AddSession((c) =>
            {
                c.Cookie.MaxAge = new TimeSpan(1000 * 60);
                c.Cookie.Name = "VaccineCenter";
            });

            services.AddScoped<IIntService<AccountModel,AccountForm>, AccountService>();
            services.AddScoped<IIntService<AccountTypeModel, AccountTypeForm>, AccountTypeService>();
            services.AddScoped<IIntService<StaffModel, StaffForm>, StaffService>();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
