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
using CSSPDBFilesManagementServices;
using DownloadFileServices;
using ReadGzFileServices;
using CSSPDBSearchServices;
using CSSPDBPreferenceServices;
using Microsoft.AspNetCore.Http.Features;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using CSSPDBCommandLogModels;
using CSSPDBSearchModels;
using LoggedInServices;
using CSSPDBServices;
using CSSPScrambleServices;
using WebAppLoadedServices;

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
             * using CSSPDBLocal 
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            /* ---------------------------------------------------------------------------------
            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreferenceFileName);

            services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBFileManagement
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");

            FileInfo fiCSSPDBFilesManagement = new FileInfo(CSSPDBFilesManagementFileName);

            services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagement.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBCommandLog
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBCommandLogFileName = Configuration.GetValue<string>("CSSPDBCommandLog");

            FileInfo fiCSSPDBCommandLog = new FileInfo(CSSPDBCommandLogFileName);

            services.AddDbContext<CSSPDBCommandLogContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBCommandLog.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBSearch
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBSearchFileName = Configuration.GetValue<string>("CSSPDBSearch");

            FileInfo fiCSSPDBSearch = new FileInfo(CSSPDBSearchFileName);

            services.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });


            services.AddScoped<ICSSPCultureService, CSSPCultureService>();
            services.AddScoped<IEnums, Enums>();
            services.AddScoped<IScrambleService, ScrambleService>();
            services.AddScoped<ILoggedInService, LoggedInService>();
            services.AddScoped<ILoginModelService, LoginModelService>();

            //LoadAllDBServices(services);

            services.AddScoped<ICSSPDBFilesManagementService, CSSPDBFilesManagementService>();
            services.AddScoped<IDownloadFileService, DownloadFileService>();
            services.AddScoped<IReadGzFileService, ReadGzFileService>();
            services.AddScoped<IPreferenceService, PreferenceService>();
            services.AddScoped<ICSSPDBSearchService, CSSPDBSearchService>();

            services.AddScoped<IWebAppLoadedService, WebAppLoadedService>();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "csspclient";
            });

            //services.Configure<FormOptions>(options =>
            //{
            //    options.MultipartBodyLengthLimit = (5L * 1024L * 1024L * 1024L);

            //});

            services.Configure<FormOptions>(o => {
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();

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
