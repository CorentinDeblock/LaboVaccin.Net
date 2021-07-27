using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using ServiceASP.template;
using System;
using VaccineCenter.DAL.Model;
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

            services.AddSession((session) =>
            {
                session.IdleTimeout = TimeSpan.FromMinutes(10);
                session.Cookie.MaxAge = TimeSpan.FromDays(3);
                session.Cookie.Name = "VaccineCenter";
                session.Cookie.HttpOnly = true;
            });

            services.AddScoped<IIntService<Account,AccountModel,AccountForm>, AccountService>();
            services.AddScoped<IIntService<AccountType,AccountTypeModel, AccountTypeForm>, AccountTypeService>();
            services.AddScoped<IIntService<Staff,StaffModel, StaffForm>, StaffService>();
            services.AddScoped<IIntService<InActivity, InActivityModel, InActivityForm>, InActivityService>();
            services.AddScoped<IIntService<Center, CenterModel, CenterForm>, CenterService>();
            services.AddScoped<IIntService<Log, LogModel, LogForm>, LogService>();
            services.AddScoped<IIntService<Lot, LotModel, LotForm>, LotService>();
            services.AddScoped<IIntService<Workspace, WorkspaceModel, WorkspaceForm>, WorkspaceService>();
            services.AddScoped<IIntService<VaccinInfo, VaccinInfoModel, VaccinInfoForm>, VaccinInfoService>();
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
