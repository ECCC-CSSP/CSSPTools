namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<List<string>> GetCSSPOtherFileListAsync()
    {
        return await Task.FromResult(new List<string>()
        {
            $"{ Configuration["CSSPOtherFilesPath"] }CssFamilyMaterial.css",
            $"{ Configuration["CSSPOtherFilesPath"] }flUhRq6tzZclQEJ-Vdg-IuiaDsNc.woff2",
            $"{ Configuration["CSSPOtherFilesPath"] }GoogleMap.js",
            $"{ Configuration["CSSPOtherFilesPath"] }IconFamilyMaterial.css",
            $"{ Configuration["CSSPOtherFilesPath"] }HelpDocEN.rtf",
            $"{ Configuration["CSSPOtherFilesPath"] }HelpDocFR.rtf"
        });
    }
}

