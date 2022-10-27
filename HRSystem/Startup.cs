using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRSystem.data;
using HRSystem.service;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Identity;
using HRSystem.Models;

namespace HRSystem
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
            services.AddDbContext<hrcontext>();
            services.AddScoped<Iemployeeservice, employeeservice>();

            services.AddScoped<Icityservice, cityservice>();
            services.AddScoped<Icountryservice, countryservice>();
            services.AddScoped<Idepartmentservice, departmentservice>();
            services.AddScoped<IAccountservice, Accountservice>();
            services.AddIdentity<Applicationuser, IdentityRole>().
                AddEntityFrameworkStores<hrcontext>();
            services.ConfigureApplicationCookie(config =>

            {
                config.LoginPath = "/Account/signin";


            });

            services.Configure<IdentityOptions>(options =>


           {

               options.Password.RequiredLength = 5;
               options.Password.RequireNonAlphanumeric = false;
               options.Password.RequireDigit = false;
               options.Password.RequireUppercase = false;
               options.Password.RequireLowercase = false;


           });
      
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

            app.UseStaticFiles(new StaticFileOptions()

            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), Configuration["ImageFolderName"])),
                RequestPath="/StaticFiles"

            });


            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=employee}/{action=empsearch}/{id?}");
            });
        }
    }
}
