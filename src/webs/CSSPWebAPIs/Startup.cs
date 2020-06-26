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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.IO;
using System.Text;
using UserServices.Models;
using UserServices.Services;
using ValidateAppSettingsServices.Services;

namespace CSSPCodeGenWebAPI
{
    public partial class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
        .       AddJsonOptions(options => {
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
             * using CSSPDB 
             * ---------------------------------------------------------------------------------      
             */

            //services.AddDbContext<CSSPDBContext>(options =>
            //        options.UseSqlServer(connectionStrings.CSSPDB));

            //services.AddDbContext<InMemoryDBContext>(options =>
            //        options.UseInMemoryDatabase(connectionStrings.CSSPDB));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionStrings.CSSPDB));



            /* ---------------------------------------------------------------------------------
             * using CSSPDB2 
             * ---------------------------------------------------------------------------------      
             */

            services.AddDbContext<CSSPDBContext>(options =>
                    options.UseSqlServer(connectionStrings.CSSPDB2));

            services.AddDbContext<InMemoryDBContext>(options =>
                    options.UseInMemoryDatabase(connectionStrings.CSSPDB2));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrings.CSSPDB2));



            /* ---------------------------------------------------------------------------------
             * using TestDB 
             * ---------------------------------------------------------------------------------      
             */

            //services.AddDbContext<CSSPDBContext>(options =>
            //        options.UseSqlServer(connectionStrings.TestDB));

            //services.AddDbContext<InMemoryDBContext>(options =>
            //        options.UseInMemoryDatabase(connectionStrings.TestDB));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(connectionStrings.TestDB));


            /* ---------------------------------------------------------------------------------
             * ApplicationUser 
             * ---------------------------------------------------------------------------------      
             */

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

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

            //services.AddResponseCompression();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseResponseCompression();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


}
