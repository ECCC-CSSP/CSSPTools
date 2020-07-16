using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebServices;
using CSSPWebServices.Services;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UserServices.Models;
using UserServices.Services;
using ValidateAppSettingsServices.Services;

namespace CSSPWebAPIs
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
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string DBFromArgs = "TestDB";

            List<string> ArgsOptionsList = new List<string>()
            {
                "TestDB", "CSSPDB", "CSSPDB2", "AzureDB"
            };

            string[] args = Environment.GetCommandLineArgs();

            foreach (string arg in args)
            {
                if (ArgsOptionsList.Contains(arg))
                {
                    DBFromArgs = arg;
                    break;
                }
            }

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


            /* ---------------------------------------------------------------------------------
             * using AzureCSSPDB 
             * ---------------------------------------------------------------------------------      
             */

            if (DBFromArgs == "AzureDB")
            {
                string AzureConnStr = Configuration.GetValue<string>("AzureCSSPDB");

                services.AddDbContext<CSSPDBContext>(options =>
                        options.UseSqlServer(AzureConnStr));

                services.AddDbContext<InMemoryDBContext>(options =>
                        options.UseInMemoryDatabase(AzureConnStr));

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(AzureConnStr));
            }


            /* ---------------------------------------------------------------------------------
             * using CSSPDB 
             * ---------------------------------------------------------------------------------      
             */

            if (DBFromArgs == "CSSPDB")
            {
                string CSSPDB = Configuration.GetValue<string>("CSSPDB");

                services.AddDbContext<CSSPDBContext>(options =>
                        options.UseSqlServer(CSSPDB));

                services.AddDbContext<InMemoryDBContext>(options =>
                        options.UseInMemoryDatabase(CSSPDB));

                string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

                FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

                services.AddDbContext<CSSPDBLocalContext>(options =>
                {
                    options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
                });

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(CSSPDB));
            }

            /* ---------------------------------------------------------------------------------
             * using CSSPDB2 
             * ---------------------------------------------------------------------------------      
             */

            if (DBFromArgs == "CSSPDB2")
            {
                string CSSPDB2 = Configuration.GetValue<string>("CSSPDB2");

                services.AddDbContext<CSSPDBContext>(options =>
                options.UseSqlServer(CSSPDB2));

                services.AddDbContext<InMemoryDBContext>(options =>
                        options.UseInMemoryDatabase(CSSPDB2));

                string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

                FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

                services.AddDbContext<CSSPDBLocalContext>(options =>
                {
                    options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
                });

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(CSSPDB2));
            }

            /* ---------------------------------------------------------------------------------
             * using TestDB 
             * ---------------------------------------------------------------------------------      
             */
            if (DBFromArgs == "TestDB")
            {
                string TestDB = Configuration.GetValue<string>("TestDB");

                services.AddDbContext<CSSPDBContext>(options =>
                        options.UseSqlServer(TestDB));

                services.AddDbContext<InMemoryDBContext>(options =>
                        options.UseInMemoryDatabase(TestDB));

                string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

                FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

                services.AddDbContext<CSSPDBLocalContext>(options =>
                {
                    options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
                });

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(TestDB));
            }

            /* ---------------------------------------------------------------------------------
             * ApplicationUser 
             * ---------------------------------------------------------------------------------      
             */

            services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            FileInfo fiDB = new FileInfo(Configuration.GetValue<string>("CSSPDBLocal").Replace("{AppDataPath}", appDataPath));

            services.AddDbContext<ActionCommandContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            services.AddScoped<ICultureService, CultureService>();
            services.AddScoped<IEnums, Enums>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoggedInService, LoggedInService>();
            services.AddScoped<IActionCommandDBService, ActionCommandDBService>();
            services.AddScoped<IValidateAppSettingsService, ValidateAppSettingsService>();
            services.AddScoped<IPolSourceGroupingExcelFileReadService, PolSourceGroupingExcelFileReadService>();

            LoadAllDBServices(services);
            services.AddScoped<IWebService, WebService>();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app";
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";
            });
        }
        #endregion Functions public
    }
}
