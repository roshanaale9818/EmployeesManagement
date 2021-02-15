using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.modals;

namespace WebApplication1
{
    public class Startup
    {
        private IConfiguration config;

        public Startup(IConfiguration _config)
        {
            config = _config;

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // difference between addDbContextPool and adddbcontext is addDbcontextpool searches for instance before creating
            //if found any it uses that instance not creating another one.
            //we add our adddbcontext class for db contexting
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("EmployeeDBConnection")));
           // services.AddMvc(options => options.EnableEndpointRouting = false);
            //this is dependency injection when some class implements the iemployee repositoty .net automatically configures the mockEmployeeRepositiry which is th
            //the implementation of IEmployeeRepository it creates an instance of it
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          app.UseRouting();
    
            //app.UseEndpoints(endpoints =>
           // {
               // DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
                //defaultFilesOptions.DefaultFileNames.Clear();
               // defaultFilesOptions.DefaultFileNames.Add("foo.html");
                //defaultFilesOptions
                app.UseDefaultFiles();
                app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}");
            });
            //app.UseMvcWithDefaultRoute();
            // app.Use(async (context, next) => { await context.Response.WriteAsync("Middleware is received"); });
            //endpoints.MapGet("/", async context =>


            //  app.Run( async (context)=> {

            //"Hello World!"
            // throw new Exception("SOME EXCEPTIONS");
            //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //});
            //});
        }
    }
}
