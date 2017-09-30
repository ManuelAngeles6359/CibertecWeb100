using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cibertec.UnitOfWork;
using Cibertec.MVC.Models;
using Cibertec.Repositories.Dapper.Northwind;
using FluentValidation.AspNetCore;
using Cibertec.Models;
using FluentValidation;
using Cibertec.MVC.Validators;

namespace Cibertec.MVC
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


            services.AddTransient<IUnitOfWork>
                (

                option => new NorthwindUnitOfWork(
                    
                            Configuration.GetConnectionString("Northwind")
                       

                    )
                 );

            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Customer>, CustomerValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
