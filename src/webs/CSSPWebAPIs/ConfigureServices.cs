namespace CSSPWebAPIs;

public partial class Startup
{
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

        string IsTesting = Configuration.GetValue<string>("IsTesting");
        if (string.IsNullOrWhiteSpace(IsTesting)) // then we are not testing use normal DB
        {
            string DBConnStr = Configuration.GetValue<string>("AzureCSSPDB");

            services.AddDbContext<CSSPDBContext>(options =>
                options.UseSqlServer(DBConnStr));
        }
        else
        {
            string DBConnStr = Configuration.GetValue<string>("AzureCSSPDBTest");

            services.AddDbContext<CSSPDBContext>(options =>
                options.UseSqlServer(DBConnStr));
        }

        services.AddScoped<ICSSPCultureService, CSSPCultureService>();
        services.AddScoped<IEnums, Enums>();
        services.AddScoped<ICSSPScrambleService, CSSPScrambleService>();
        services.AddScoped<ICSSPServerLoggedInService, CSSPServerLoggedInService>();

        //services.AddScoped<ILoginModelService, LoginModelService>();
        //services.AddScoped<IRegisterModelService, RegisterModelService>();

        services.AddScoped<IAppTaskDBService, AppTaskDBService>();
        services.AddScoped<IAppTaskLanguageDBService, AppTaskLanguageDBService>();
        services.AddScoped<IContactDBService, ContactDBService>();
        services.AddScoped<ITVItemUserAuthorizationDBService, TVItemUserAuthorizationDBService>();
        services.AddScoped<ITVTypeUserAuthorizationDBService, TVTypeUserAuthorizationDBService>();

        services.AddScoped<IAzureAppTaskService, AzureAppTaskService>();
    }
}

