namespace CSSPDesktopInstallPostBuildServices.Services;

public partial class CSSPDesktopInstallPostBuildService : ICSSPDesktopInstallPostBuildService
{
    private IConfiguration Configuration { get; }
    private ICSSPCultureService CSSPCultureService { get; }
    private ICSSPScrambleService CSSPScrambleService { get; }
    private Contact contact { get; set; }

    public CSSPDesktopInstallPostBuildService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ICSSPScrambleService CSSPScrambleService)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
        if (CSSPScrambleService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPScrambleService") }");

        if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPWebAPIsLocalPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPWebAPIsLocalPath", "CSSPDesktopInstallPostBuildService") }");
        if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CSSPDesktopInstallPostBuildService") }");
        if (string.IsNullOrEmpty(Configuration["LoginEmail"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "LoginEmail", "CSSPDesktopInstallPostBuildService") }");
        if (string.IsNullOrEmpty(Configuration["Password"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "Password", "CSSPDesktopInstallPostBuildService") }");

        this.Configuration = Configuration;
        this.CSSPCultureService = CSSPCultureService;
        this.CSSPScrambleService = CSSPScrambleService;
    }
}

