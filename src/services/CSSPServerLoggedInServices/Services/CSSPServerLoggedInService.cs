
namespace CSSPServerLoggedInServices;

public partial class CSSPServerLoggedInService : ICSSPServerLoggedInService
{
    public LoggedInContactInfo LoggedInContactInfo { get; set; }

    private IConfiguration Configuration { get; }
    private CSSPDBContext dbAzure { get; }

    public CSSPServerLoggedInService(IConfiguration Configuration, CSSPDBContext dbAzure)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (dbAzure == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbAzure") }");

        this.Configuration = Configuration;
        this.dbAzure = dbAzure;

        LoggedInContactInfo = new LoggedInContactInfo();
    }
}

