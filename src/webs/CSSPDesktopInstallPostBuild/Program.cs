namespace CSSPDesktopInstallPostBuild;

partial class Program
{
    static async Task<int> Main(string[] args)
    {
        IConfiguration Configuration;
        IServiceProvider Provider;
        IServiceCollection Services;
        ICSSPDesktopInstallPostBuildService CSSPDesktopInstallPostBuildService;

        Configuration = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                          .AddJsonFile("appsettings_csspdesktopinstallpostbuild.json")
                          .AddUserSecrets("CSSPDesktopInstallPostBuild")
                          .Build();

        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(Configuration);
        Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
        Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
        Services.AddSingleton<ICSSPDesktopInstallPostBuildService, CSSPDesktopInstallPostBuildService>();

        if (string.IsNullOrEmpty(Configuration["CSSPClientPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPClientPath", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["CSSPClientZipFile"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPClientZipFile", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesPath", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["CSSPOtherFilesZipFile"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPOtherFilesZipFile", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsLocalPath", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["CSSPWebAPIsLocalZipFile"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPWebAPIsLocalZipFile", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsLocalPath", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["LoginEmail"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "LoginEmail", "CSSPDesktopInstallPostBuild") }");
        if (string.IsNullOrEmpty(Configuration["Password"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "Password", "CSSPDesktopInstallPostBuild") }");

        Provider = Services.BuildServiceProvider();
        if (Provider == null) return await Task.FromResult(1);

        CSSPDesktopInstallPostBuildService = Provider.GetService<ICSSPDesktopInstallPostBuildService>();
        if (CSSPDesktopInstallPostBuildService == null) return await Task.FromResult(1);

        CSSPDesktopInstallPostBuildService.SetContact(await CSSPDesktopInstallPostBuildService.LoginAsync());
        if (!await CSSPDesktopInstallPostBuildService.CSSPClientCompressAndSendToAzureAsync()) return await Task.FromResult(1);
        if (!await CSSPDesktopInstallPostBuildService.CSSPOtherFilesCompressAndSendToAzureAsync()) return await Task.FromResult(1);
        if (!await CSSPDesktopInstallPostBuildService.CSSPWebAPIsLocalCompressAndSendToAzureAsync()) return await Task.FromResult(1);

        return await Task.FromResult(0);
    }
}

