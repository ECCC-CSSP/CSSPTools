namespace CSSPLocalLoggedInServices;

public partial class CSSPLocalLoggedInService : ICSSPLocalLoggedInService
{
    public LoggedInContactInfo LoggedInContactInfo { get; set; }

    private CSSPDBManageContext dbManage { get; }

    public CSSPLocalLoggedInService(IConfiguration Configuration, CSSPDBManageContext dbManage)
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "LoggedInService") }");

        this.dbManage = dbManage;

        LoggedInContactInfo = new LoggedInContactInfo();
    }
}

