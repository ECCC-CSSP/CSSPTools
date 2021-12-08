var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//----------------------------------

//IConfiguration Configuration = new ConfigurationBuilder()
//        .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//        //.AddJsonFile("appsettings_csspwebapis.json")
//        //.AddUserSecrets("CSSPWebAPIs")
//        .Build();

builder.Services.AddCors();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

string APISecret = builder.Configuration["APISecret"];
byte[] key = Encoding.ASCII.GetBytes(APISecret);

builder.Services.AddAuthentication(x =>
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

builder.Services.AddDbContext<CSSPDBContext>(options =>
    options.UseSqlServer(builder.Configuration["CSSPDBAzure"]));

builder.Services.AddScoped<ICSSPCultureService, CSSPCultureService>();
builder.Services.AddScoped<IEnums, Enums>();
builder.Services.AddScoped<ICSSPScrambleService, CSSPScrambleService>();
builder.Services.AddScoped<ICSSPServerLoggedInService, CSSPServerLoggedInService>();
builder.Services.AddScoped<IAppTaskAzureService, AppTaskAzureService>();
builder.Services.AddScoped<IContactAzureService, ContactAzureService>();
builder.Services.AddScoped<ITVItemUserAuthorizationAzureService, TVItemUserAuthorizationAzureService>();
builder.Services.AddScoped<ITVTypeUserAuthorizationAzureService, TVTypeUserAuthorizationAzureService>();

//----------------------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
