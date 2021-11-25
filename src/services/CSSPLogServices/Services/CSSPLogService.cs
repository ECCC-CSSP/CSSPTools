namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    private List<int> skip { get; set; } = new List<int>()
        {
            3, 1, -3, 2, 2, 0, 4, 1, -2, 2, -1, 3, -2, 0, 1, 3, 1, 2, -4, -1, 1, 2, 0, 2, 1,
            -1, 4, -4, 2, 3, 1, 2, 3, 1, 2, 3, 1, 3, 1, -2, -1, -1, 4, -2, 2, -3, 2, 2, 0, 4,
            3, 1, 1, -2, -1, 3, -2, 0, 3, 2, 0, 1, 4, 1, 1, -4, -1, 2, 0, 2, 1, -3, 2, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, 2, 1,
            -2, 3, 1, -3, 2, 3, -2, -1, 4, 1, -2, 2, 2, -1, 0, 4, 1, -2, -1, 3, -2, 0, 3, -1, 1, -4, -1, 2, 0, 2, 1,
            -1, 2, 3, 2, 1, -3, 2, 3, 2, 0, 4, 1, 2, -2, -1, 0, 3, -2, 0, 3, 1, -4, -1, 3, 2, 0, 2, 1,
            -4, 3, 1, -3, 1, 2, 2, 0, 1, 2, 4, 1, -1, 3, -1, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, -1, 2, 1,
            1, 3, 4, 1, -3, -2, 2, 2, 0, -1, 4, 1, -2, -1, 3, 2, -2, 0, 1, 3, 1, -2, -4, -1, -1, 2, 0, 2, 1,
            4, 3, -2, -1, 2, 0, 2, -1, 4, 2, 0, 1, -1, -1, -3, -2, 2, -4, 3, 2, 1, -3, 2, -1, 2, 4, 0, 0, 1,
            2, 1, -2, -4, 1, 3, -3, 1, -1, 2, 1, 0, 4, -1, 1, -1, -3, 1, 1, -3, -4, 1, -3, 1, -3, 1, -1, 0,
            4, 2, 1, -3, 1, -2, 1, -4, 1, -2, 0, 3, -1, 4, 1, -2, 1, 0, -4, -1, -3, 2, 1, 4, -1, 1, 2, 4, 2
        };

    public string CSSPAppName { get; set; } = "Unknown";
    public string CSSPCommandName { get; set; } = "Unknown";
    public StringBuilder sbError { get; set; } = new StringBuilder();
    public StringBuilder sbLog { get; set; } = new StringBuilder();
    public ErrRes ErrRes { get; set; } = new ErrRes();

    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
    private CSSPDBManageContext dbManage { get; }
    private int FunctionCount { get; set; } = 0;

    public CSSPLogService(IConfiguration Configuration, ICSSPLocalLoggedInService CSSPLocalLoggedInService, CSSPDBManageContext dbManage) : base()
    {
        if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
        if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService ") }");
        if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

        if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPLogService") }");

        this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
        this.dbManage = dbManage;
    }
}

