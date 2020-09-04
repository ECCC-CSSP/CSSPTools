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
        private RunningOnEnum RunningOn { get; set; }
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

            RunningOn = Configuration.GetValue<string>("RunningOn") == "Local" ? RunningOnEnum.Local : RunningOnEnum.Azure;

            string DBConnStr = "";

            if (RunningOn == RunningOnEnum.Azure)
            {
                DBConnStr = Configuration.GetValue<string>("AzureCSSPDB");
            }
            else if (RunningOn == RunningOnEnum.Local)
            {
            }
            else // this would automatically fall into RunningOnEnum.Test
            {
                string DBToUse = Configuration.GetValue<string>("DBToUse");

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
             * Setting up the required CSSPDB2, TestDB or AzureCSSPDB with ApplicationUser
             * ---------------------------------------------------------------------------------      
             */

            if (RunningOn == RunningOnEnum.Azure)
            {
                services.AddDbContext<CSSPDBContext>(options =>
                        options.UseSqlServer(DBConnStr));

                services.AddDbContext<CSSPDBInMemoryContext>(options =>
                    options.UseInMemoryDatabase(DBConnStr));

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(DBConnStr));

                services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            }

            if (RunningOn == RunningOnEnum.Local)
            {
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
                 * using CSSPDBLocalInMemory 
                 * ---------------------------------------------------------------------------------      
                 */

                DBConnStr = Configuration.GetValue<string>("AzureCSSPDB");

                services.AddDbContext<CSSPDBInMemoryContext>(options =>
                {
                    options.UseInMemoryDatabase(DBConnStr);
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
                 * using CSSPDBLoginInMemory
                 * ---------------------------------------------------------------------------------      
                 */

                services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
                {
                    options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLogin.FullName }");
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
                 * using CSSPDBFileManagementInMemmory
                 * ---------------------------------------------------------------------------------      
                 */
                services.AddDbContext<CSSPDBFilesManagementInMemoryContext>(options =>
                {
                    options.UseInMemoryDatabase($"Data Source={ fiCSSPDBFilesManagement.FullName }");
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

                /* ---------------------------------------------------------------------------------
                 * using CSSPDBSearchInMemory
                 * ---------------------------------------------------------------------------------      
                 */
                services.AddDbContext<CSSPDBSearchInMemoryContext>(options =>
                {
                    options.UseInMemoryDatabase($"Data Source={ fiCSSPDBSearch.FullName }");
                });

            }

            services.AddScoped<ICSSPCultureService, CSSPCultureService>();
            services.AddScoped<IEnums, Enums>();

            services.AddScoped<ILoginModelService, LoginModelService>();
            services.AddScoped<IRegisterModelService, RegisterModelService>();

            LoadAllDBServices(services);

            if (RunningOn == RunningOnEnum.Azure)
            {
                services.AddScoped<ILoggedInService, LoggedInService>();
                services.AddScoped<ICreateGzFileService, CreateGzFileService>();
            }

            if (RunningOn == RunningOnEnum.Local)
            {
                services.AddScoped<LocalService, LocalService>();
                services.AddScoped<ICSSPFileService, CSSPFileService>();
                services.AddScoped<IDownloadGzFileService, DownloadGzFileService>();
                services.AddScoped<IReadGzFileService, ReadGzFileService>();
                services.AddScoped<ICSSPDBSearchService, CSSPDBSearchService>();
            }

            if (RunningOn == RunningOnEnum.Local)
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

            if (RunningOn == RunningOnEnum.Local)
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

            if (RunningOn == RunningOnEnum.Local)
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
