namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<List<string>> GetDirectoryToCreateListAsync()
    {
        return await Task.FromResult(new List<string>()
        {
            Configuration["CSSPDesktopPath"],
            Configuration["CSSPDatabasesPath"],
            Configuration["CSSPWebAPIsLocalPath"],
            Configuration["CSSPJSONPath"],
            Configuration["CSSPJSONPathLocal"],
            Configuration["CSSPFilesPath"],
            Configuration["CSSPOtherFilesPath"],
            Configuration["CSSPTempFilesPath"]
        });
    }
}

