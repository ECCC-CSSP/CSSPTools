namespace CSSPWebAPIsLocal;

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

        if (string.IsNullOrEmpty(Configuration["CSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDB", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBLocal", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup_uncompress"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup_uncompress", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["CSSPTempFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPTempFilesPath", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["LocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "LocalUrl", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPWebAPIsLocal") }");
        if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CSSPWebAPIsLocal") }");

        /* ---------------------------------------------------------------------------------
         * CSSPDBContext 
         * ---------------------------------------------------------------------------------      
         */
        string CSSPDBFileName = Configuration.GetValue<string>("CSSPDB");

        FileInfo fiCSSPDB = new FileInfo(CSSPDBFileName);

        services.AddDbContext<CSSPDBContext>(options =>
        {
            options.UseSqlServer(Configuration["CSSPDB"]);
        });

        /* ---------------------------------------------------------------------------------
         * CSSPDBLocalContext 
         * ---------------------------------------------------------------------------------      
         */
        string CSSPDBLocalFileName = Configuration.GetValue<string>("CSSPDBLocal");

        FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

        services.AddDbContext<CSSPDBLocalContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
        });

        /* ---------------------------------------------------------------------------------
         * CSSPDBManageContext
         * ---------------------------------------------------------------------------------      
         */
        string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");

        FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);

        services.AddDbContext<CSSPDBManageContext>(options =>
        {
            options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
        });


        services.AddScoped<ICSSPCultureService, CSSPCultureService>();
        services.AddScoped<IEnums, Enums>();
        services.AddScoped<ICSSPScrambleService, CSSPScrambleService>();
        services.AddScoped<ICSSPLogService, CSSPLogService>();
        services.AddScoped<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();

        //LoadAllDBServices(services);

        services.AddScoped<IManageFileService, ManageFileService>();
        services.AddScoped<ICSSPFileService, CSSPFileService>();
        services.AddScoped<ICSSPReadGzFileService, CSSPReadGzFileService>();
        services.AddScoped<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
        services.AddScoped<ICountryLocalService, CountryLocalService>();
        services.AddScoped<IHelperLocalService, HelperLocalService>();
        services.AddScoped<ITVItemLocalService, TVItemLocalService>();
        services.AddScoped<IMapInfoLocalService, MapInfoLocalService>();
        services.AddScoped<ICSSPFileService, CSSPFileService>();

        services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "csspclient";
        });

        services.Configure<FormOptions>(o =>
        {
            o.ValueLengthLimit = int.MaxValue;
            o.MultipartBodyLengthLimit = int.MaxValue;
            o.MemoryBufferThreshold = int.MaxValue;
        });
    }
}

