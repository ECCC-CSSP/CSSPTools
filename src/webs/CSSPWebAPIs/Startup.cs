using CSSPEnums;
using CSSPDBModels;
using CSSPDBServices;
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
using LoggedInServices;
using CreateGzFileServices;
using CSSPScrambleServices;
using CSSPHelperServices;

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

            string DBConnStr = Configuration.GetValue<string>("AzureCSSPDB");

            services.AddDbContext<CSSPDBContext>(options =>
                options.UseSqlServer(DBConnStr));


            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(DBConnStr));

            //services.AddIdentityCore<ApplicationUser>()
            //.AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ICSSPCultureService, CSSPCultureService>();
            services.AddScoped<IEnums, Enums>();
            services.AddScoped<IScrambleService, ScrambleService>();
            services.AddScoped<ILoggedInService, LoggedInService>();

            services.AddScoped<ILoginModelService, LoginModelService>();
            services.AddScoped<IRegisterModelService, RegisterModelService>();

            LoadAllDBServices(services);
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
        }
        #endregion Functions public
    }
}
