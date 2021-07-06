using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileServices;
using ReadGzFileServices;
using Microsoft.AspNetCore.Http.Features;
using LoggedInServices;
using CSSPDBLocalServices;
using CreateGzFileServices;
using CSSPWebAPIsLocal.Controllers;
using ManageServices;

namespace CSSPWebAPIsLocal
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        #endregion Properties

        #region Constructors
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion Constructors

        #region Functions public
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            /* ---------------------------------------------------------------------------------
             * CSSPDBLocalContext 
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");

            FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);

            services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });


            services.AddScoped<ICSSPCultureService, CSSPCultureService>();
            services.AddScoped<IEnums, Enums>();
            services.AddScoped<ILoggedInService, LoggedInService>();

            //LoadAllDBServices(services);

            services.AddScoped<IManageFileService, ManageFileService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IReadGzFileService, ReadGzFileService>();
            services.AddScoped<ICreateGzFileService, CreateGzFileService>();
            services.AddScoped<ITVItemLocalService, TVItemLocalService>();
            services.AddScoped<IFileService, FileService>();

            //services.AddScoped<IWebAppLoadedService, WebAppLoadedService>();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "csspclient";
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
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
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "csspclient";
            });
        }
        #endregion Functions public
    }
}
