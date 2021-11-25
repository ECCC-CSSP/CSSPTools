namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<bool> FillHasCSSPOtherFilesAsync()
    {
        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfCSSPOtherFilesExist));

        HasCSSPOtherFiles = true;

        foreach (string CSSPOtherFile in await GetCSSPOtherFileListAsync())
        {
            FileInfo fi = new FileInfo(CSSPOtherFile);
            if (fi.Exists)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPOtherFileFound_, CSSPOtherFile)));
            }
            else
            {
                HasCSSPOtherFiles = false;
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CSSPOtherFileNotFound_, CSSPOtherFile)));
            }

        }

        AppendStatus(new AppendEventArgs(""));

        return await Task.FromResult(true);
    }
}

