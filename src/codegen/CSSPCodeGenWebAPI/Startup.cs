using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CSSPModels;
using Microsoft.EntityFrameworkCore;
using CSSPCodeGenWebAPI.Model;
using CSSPCodeGenWebAPI.Services;
using StatusAndResultsDBService.Services;
using System.IO;
using StatusAndResultsDBService.Models;
using CSSPCodeGenWebAPI.Models;

namespace CSSPCodeGenWebAPI
{
    public class Startup
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

            //// using CSSPDB
            //services.AddDbContext<CSSPDBContext>(options =>
            //        options.UseSqlServer(connectionStrings.CSSPDB));

            // using CSSPDB2
            services.AddDbContext<CSSPDBContext>(options =>
                    options.UseSqlServer(connectionStrings.CSSPDB2));

            //// using In Memory CSSPDB2
            //services.AddDbContext<CSSPDBContext>(options =>
            //        options.UseInMemoryDatabase(connectionStrings.CSSPDB2));

            //// using TestDB
            //services.AddDbContext<CSSPDBContext>(options =>
            //        options.UseSqlServer(connectionStrings.TestDB));

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionStrings.CSSPDB2));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo(connectionStrings.GenerateCodeSatusDB.Replace("{appDataPath}", appDataPath));

            services.AddDbContext<GenerateCodeStatusContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGenerateEnumsService, GenerateEnumsService>();
            services.AddScoped<IStatusEnumsService, StatusEnumsService>();
            services.AddScoped<IStatusAndResultsService, StatusAndResultsService>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


}
