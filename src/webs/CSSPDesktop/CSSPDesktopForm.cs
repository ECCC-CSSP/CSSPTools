namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private IConfiguration Configuration { get; set; }
    private IServiceProvider Provider { get; set; }
    private IServiceCollection Services { get; set; }
    private IManageFileService ManageFileService { get; set; }
    private ICSSPCultureService CSSPCultureService { get; set; }
    private ICSSPDesktopService CSSPDesktopService { get; set; }
    private ICSSPSQLiteService CSSPSQLiteService { get; set; }
    private ICSSPScrambleService CSSPScrambleService { get; set; }
    private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
    private ICSSPAzureLoginService CSSPAzureLoginService { get; set; }
    bool IsEnglish { get; set; } = true;

    public CSSPDesktopForm()
    {
        InitializeComponent();
        string Version = "1.0.1.9";
        lblVersionValue.Text = Version;
        lblVersionTop.Text = Version;

        SetupAsync().GetAwaiter().GetResult();
    }
}

