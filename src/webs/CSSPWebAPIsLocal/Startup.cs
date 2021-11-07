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
using CSSPFileServices;
using CSSPReadGzFileServices;
using Microsoft.AspNetCore.Http.Features;
using CSSPLocalLoggedInServices;
using CSSPDBLocalServices;
using CSSPCreateGzFileServices;
using CSSPWebAPIsLocal.Controllers;
using ManageServices;
using CSSPLogServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;

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

            if (string.IsNullOrEmpty(Configuration["AzureStore"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStore", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CreateGzFileService") }");
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
            services.AddScoped<ICSSPScrambleService, CSSPScrambleService>();
            services.AddScoped<ICSSPLogService, CSSPLogService>();
            services.AddScoped<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();

            //LoadAllDBServices(services);

            services.AddScoped<IManageFileService, ManageFileService>();
            services.AddScoped<ICSSPFileService, CSSPFileService>();
            services.AddScoped<ICSSPReadGzFileService, CSSPReadGzFileService>();
            services.AddScoped<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
            //services.AddScoped<ITVItemLocalService, TVItemLocalService>();
            services.AddScoped<ICSSPFileService, CSSPFileService>();

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
