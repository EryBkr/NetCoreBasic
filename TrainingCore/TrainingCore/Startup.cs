using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using TrainingCore.Models;
using TrainingCore.Services;

namespace TrainingCore
{
    public class Startup
    {

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<CustomerContext>(options => options.UseSqlServer(_configuration["DbConnection"]));
            services.AddScoped<ICalculator, Calculator18>();
            services.AddSession();
            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
           
            app.UseSession();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions() {FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"node_modules")),RequestPath=new PathString("/vendor")});
            app.UseMvc(ConfigureRoutes);
        }
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            routeBuilder.MapRoute("areas","{area:exists}/{controller=Home}/{Action=Index}/{id?}");
           
        }
    }
}
