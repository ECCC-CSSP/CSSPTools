namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<List<string>> GetZipFileNameListAsync()
    {
        return await Task.FromResult(new List<string>()
        {
            "csspwebapislocal.zip",
            "csspclient.zip",
            "csspotherfiles.zip",
        });
    }
}

