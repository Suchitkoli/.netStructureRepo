using DataService.Abstract.UserPersonalDetails;
using DataService.Abstract.Users;
using DataService.EntityData;
using DataService.Services.UserPersonalDetails;
using DataService.Services.Users;
using Employee.Manager.Managers.UserPersonalDetails;
using Employee.Manager.Managers.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5
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

            //Data Services

            services.AddTransient<IUserDataService, UsersDataService>();
            services.AddTransient<IUserPersonalDetailsServices, UserPersonalDetailsService>();

            //Users Manager

            services.AddTransient<UsersManager>();
            services.AddTransient<UserPersonalDetailsManager>();

            // database connection
            string connection = @"Server=LAPTOP-G42KIK4M\SQLEXPRESS;Database=EmployeeUser; Integrated Security=True";

            // Database Context
            services.AddDbContext<EmployeeUserContext>(options => options.UseSqlServer(connection));

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
