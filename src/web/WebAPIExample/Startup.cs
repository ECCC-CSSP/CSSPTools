using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using WebAPIExample.Models;

namespace WebAPIExample
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
            services.AddDbContext<CSSPDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddControllers(mvcOptions =>
            //  mvcOptions.EnableEndpointRouting = false);

            //services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            //app.UseMvc(routeBuilder =>
            //{
            //    routeBuilder.Select().Filter();
            //    routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //IEdmModel GetEdmModel()
        //{
        //    var odataBuilder = new ODataConventionModelBuilder();
        //    odataBuilder.EntitySet<Addresses>("Addresses");

        //    return odataBuilder.GetEdmModel();
        //}
    }
}
