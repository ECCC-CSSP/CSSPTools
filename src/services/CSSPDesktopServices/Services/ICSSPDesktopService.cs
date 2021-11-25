namespace CSSPDesktopServices.Services;

public interface ICSSPDesktopService
{
    // Properties
    bool IsEnglish { get; set; }
    bool LoginRequired { get; set; }
    bool UpdateIsNeeded { get; set; }
    bool HasCSSPOtherFiles { get; set; }
    Contact contact { get; set; }

    // Functions
    Task<bool> CreateAllRequiredDirectoriesAsync();
    Task<bool> FillHasCSSPOtherFilesAsync();
    Task<bool> FillLoginRequiredAsync();
    Task<bool> FillUpdateIsNeededAsync();
    Task<bool> FillContactHasInternetConnectionAsync();
    Task<List<string>> GetCSSPOtherFileListAsync();
    Task<List<string>> GetDirectoryToCreateListAsync();
    Task<List<string>> GetJsonFileNameListAsync();
    Task<List<string>> GetZipFileNameListAsync();
    Task<bool> InstallUpdatesAsync();
    Task<bool> LoginAsync(LoginModel loginModel);
    Task<bool> LogoffAsync();
    Task<bool> StartAsync();
    Task<bool> StopAsync();

    // Events
    event EventHandler<ClearEventArgs> StatusClear;
    event EventHandler<AppendEventArgs> StatusAppend;
    event EventHandler<InstallingEventArgs> StatusInstalling;
}

