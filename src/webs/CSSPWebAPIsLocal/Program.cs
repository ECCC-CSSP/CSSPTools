var builder = WebApplication.CreateBuilder(args);

string appSettings = "appsettings.json";

if (builder.Environment.IsDevelopment())
{
    //appSettings = "appsettingstests.json";
}

builder.WebHost.ConfigureAppConfiguration(configuration =>
{
    configuration.AddJsonFile(appSettings);
});

builder.WebHost.UseUrls("http://localhost:4446");

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

if (string.IsNullOrEmpty(builder.Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["azure_csspjson_backup"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["azure_csspjson_backup_uncompress"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup_uncompress", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPTempFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPTempFilesPath", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["LocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "LocalUrl", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPWebAPIsLocal") }");
if (string.IsNullOrEmpty(builder.Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CSSPWebAPIsLocal") }");

builder.Services.AddDbContext<CSSPDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration["CSSPDB"]);
});

builder.Services.AddDbContext<CSSPDBLocalContext>(options =>
{
    options.UseSqlite($"Data Source={ builder.Configuration["CSSPDBLocal"] }");
});

builder.Services.AddDbContext<CSSPDBManageContext>(options =>
{
    options.UseSqlite($"Data Source={ builder.Configuration["CSSPDBManage"] }");
});

builder.Services.AddScoped<ICSSPCultureService, CSSPCultureService>();
builder.Services.AddScoped<IEnums, Enums>();
builder.Services.AddScoped<ICSSPScrambleService, CSSPScrambleService>();
builder.Services.AddScoped<ICSSPLogService, CSSPLogService>();
builder.Services.AddScoped<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();

//LoadAllDBServices(services);

builder.Services.AddScoped<IManageFileService, ManageFileService>();
builder.Services.AddScoped<ICSSPFileService, CSSPFileService>();
builder.Services.AddScoped<ICSSPReadGzFileService, CSSPReadGzFileService>();
builder.Services.AddScoped<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
builder.Services.AddScoped<ICountryLocalService, CountryLocalService>();
builder.Services.AddScoped<IHelperLocalService, HelperLocalService>();
builder.Services.AddScoped<ITVItemLocalService, TVItemLocalService>();
builder.Services.AddScoped<IMapInfoLocalService, MapInfoLocalService>();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "csspclient";
});

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

//----------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    //app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}

app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//app.UseAuthentication();
//app.UseAuthorization();
//app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "csspclient";
});

app.Run();
