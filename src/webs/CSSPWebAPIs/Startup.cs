using CSSPEnums;
using CSSPModels;
using CSSPServices;
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

namespace CSSPWebAPIs
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private string RunningOn { get; set; }
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

            string APISecret = Configuration.GetValue<string>("APISecret");
            byte[] key = Encoding.ASCII.GetBytes(APISecret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            RunningOn = Configuration.GetValue<string>("RunningOn"); // either "Local", "Azure"

            string DBConnStr = "";

            if (RunningOn == "Azure")
            {
                DBConnStr = Configuration.GetValue<string>("AzureCSSPDB");

            }
            else
            {
                string DBToUse = Configuration.GetValue<string>("DBToUse");

                if (DBToUse == "CSSPDB")
                {
                    DBConnStr = Configuration.GetValue<string>("CSSPDB");
                }

                if (DBToUse == "CSSPDB2")
                {
                    DBConnStr = Configuration.GetValue<string>("CSSPDB2");
                }

                if (DBToUse == "TestDB")
                {
                    DBConnStr = Configuration.GetValue<string>("TestDB");

                }
            }

            /* ---------------------------------------------------------------------------------
             * Setting up the required CSSPDB, CSSPDB2, TestDB or AzureCSSPDB with ApplicationUser
             * ---------------------------------------------------------------------------------      
             */

            services.AddDbContext<CSSPDBContext>(options =>
                    options.UseSqlServer(DBConnStr));

            services.AddDbContext<CSSPDBInMemoryContext>(options =>
                    options.UseInMemoryDatabase(DBConnStr));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(DBConnStr));

            services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

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
             * using CSSPDBLogin
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLoginFileName = Configuration.GetValue<string>("CSSPDBLogin");

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
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

            services.AddScoped<ICSSPCultureService, CSSPCultureService>();
            services.AddScoped<IEnums, Enums>();
            services.AddScoped<ILoginModelService, LoginModelService>();
            services.AddScoped<IRegisterModelService, RegisterModelService>();
            services.AddScoped<ILoggedInService, LoggedInService>();
            services.AddScoped<IContactService, ContactService>();

            LoadAllDBServices(services);

            services.AddScoped<ICreateGzFileService, CreateGzFileService>();
            services.AddScoped<ICSSPFileService, CSSPFileService>();
            services.AddScoped<IDownloadGzFileService, DownloadGzFileService>();
            services.AddScoped<IReadGzFileService, ReadGzFileService>();

            if (RunningOn == "Local")
            {
                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "csspclient";
                });
            }
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

            if (RunningOn == "Local")
            {
                app.UseStaticFiles();

                if (!env.IsDevelopment())
                {
                    app.UseSpaStaticFiles();
                }
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (RunningOn == "Local")
            {
                app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "csspclient";
                });
            }
        }
        #endregion Functions public
    }
}
