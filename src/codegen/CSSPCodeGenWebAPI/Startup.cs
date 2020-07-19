using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using CSSPModels;
using CSSPServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;

namespace CSSPCodeGenWebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
        .       AddJsonOptions(options => {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            string APISecret = Configuration.GetValue<string>("APISecret");
            if (string.IsNullOrWhiteSpace(APISecret))
            {
                Console.WriteLine("Could not find APISecret under User Secrets");
            }
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

            string CSSPDB2 = Configuration.GetValue<string>("CSSPDB2");
            if (string.IsNullOrWhiteSpace(CSSPDB2))
            {
                Console.WriteLine("Could not find CSSPDB2 in appsettings.json");
            }

            string ActionCommandDB = Configuration.GetValue<string>("ActionCommandDB");
            if (string.IsNullOrWhiteSpace(ActionCommandDB))
            {
                Console.WriteLine("Could not find CSSPDB2 in appsettings.json");
            }

            //// using CSSPDB
            //services.AddDbContext<CSSPDBContext>(options =>
            //        options.UseSqlServer(CSSPDB));

            // using CSSPDB2
            services.AddDbContext<CSSPDBContext>(options =>
                    options.UseSqlServer(CSSPDB2));

            //// using In Memory CSSPDB2
            //services.AddDbContext<CSSPDBContext>(options =>
            //        options.UseInMemoryDatabase(CSSPDB2));

            //// using TestDB
            //services.AddDbContext<CSSPDBContext>(options =>
            //        options.UseSqlServer(TestDB));

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(CSSPDB2));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiDB = new FileInfo(ActionCommandDB.Replace("{AppDataPath}", appDataPath));

            services.AddDbContext<ActionCommandContext>(options =>
            {
                options.UseSqlite($"DataSource={fiDB.FullName}");
            });

            services.AddScoped<ICSSPCultureService, CSSPCultureService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IActionCommandDBService, ActionCommandDBService>();
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
