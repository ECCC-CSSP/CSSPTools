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
        private string RootPath { get; set; }
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
            string DBFromArgs = "";

            List<string> ArgsOptionsList = new List<string>()
            {
                "TestDB", "CSSPDB", "CSSPDB2", "AzureDB"
            };

            string[] args = Environment.GetCommandLineArgs();

            if (args.Count() < 1)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"args should have one parameter. Choice of [{ string.Join(", ", ArgsOptionsList) }]");
                Console.WriteLine();
                Console.WriteLine();
                return;
            }

            foreach (string arg in args)
            {
                if (ArgsOptionsList.Contains(arg))
                {
                    DBFromArgs = arg;
                    break;
                }
            }

            if (string.IsNullOrWhiteSpace(DBFromArgs))
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"args should have one parameter. Choice of [{ string.Join(", ", ArgsOptionsList) }]");
                Console.WriteLine();
                Console.WriteLine();
                return;
            }

            services.AddCors();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            IConfigurationSection apiSettingsSection = Configuration.GetSection("ApiSettings");
            services.Configure<ApiSettingsModel>(apiSettingsSection);

            ApiSettingsModel apiSettings = apiSettingsSection.Get<ApiSettingsModel>();
            byte[] key = Encoding.ASCII.GetBytes(apiSettings.APISecret);

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


            IConfigurationSection connectionStringsSection = Configuration.GetSection("ConnectionStrings");
            services.Configure<ConnectionStringsModel>(connectionStringsSection);

            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();

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
                services.AddDbContext<CSSPDBContext>(options =>
                        options.UseSqlServer(connectionStrings.CSSPDB));

                services.AddDbContext<InMemoryDBContext>(options =>
                        options.UseInMemoryDatabase(connectionStrings.CSSPDB));

                string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

                FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

                services.AddDbContext<CSSPDBLocalContext>(options =>
                {
                    options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
                });

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionStrings.CSSPDB));
            }

            /* ---------------------------------------------------------------------------------
             * using CSSPDB2 
             * ---------------------------------------------------------------------------------      
             */

            if (DBFromArgs == "CSSPDB2")
            {
                services.AddDbContext<CSSPDBContext>(options =>
                options.UseSqlServer(connectionStrings.CSSPDB2));

                services.AddDbContext<InMemoryDBContext>(options =>
                        options.UseInMemoryDatabase(connectionStrings.CSSPDB2));

                string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

                FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

                services.AddDbContext<CSSPDBLocalContext>(options =>
                {
                    options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
                });

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionStrings.CSSPDB2));
            }

            /* ---------------------------------------------------------------------------------
             * using TestDB 
             * ---------------------------------------------------------------------------------      
             */
            if (DBFromArgs == "TestDB")
            {
                services.AddDbContext<CSSPDBContext>(options =>
                        options.UseSqlServer(connectionStrings.TestDB));

                services.AddDbContext<InMemoryDBContext>(options =>
                        options.UseInMemoryDatabase(connectionStrings.TestDB));

                string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

                FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

                services.AddDbContext<CSSPDBLocalContext>(options =>
                {
                    options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
                });

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionStrings.TestDB));
            }

            /* ---------------------------------------------------------------------------------
             * ApplicationUser 
             * ---------------------------------------------------------------------------------      
             */

            services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            FileInfo fiDB = new FileInfo(Configuration.GetValue<string>("DBFileName").Replace("{AppDataPath}", appDataPath));

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

            FileInfo fiClient = new FileInfo(Configuration.GetValue<string>("LocalClientPath").Replace("{AppDataPath}", appDataPath));

            RootPath = fiClient.Directory.FullName;

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = RootPath;
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
                spa.Options.SourcePath = RootPath;
            });
        }
        #endregion Functions public
    }
}
