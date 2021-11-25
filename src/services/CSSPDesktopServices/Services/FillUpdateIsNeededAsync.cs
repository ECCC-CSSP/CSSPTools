namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<bool> FillUpdateIsNeededAsync()
    {
        if (!await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync()) return await Task.FromResult(false);

        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckIfUpdateIsNeeded));

        UpdateIsNeeded = false;

        if (contact.HasInternetConnection == null || !(bool)contact.HasInternetConnection)
        {
            return await Task.FromResult(true);
        }

        if (!await CheckIfZipFileAreUpToDateAsync()) return await Task.FromResult(true);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(false);

        if (!await CheckIfJsonFileAreUpToDateAsync()) return await Task.FromResult(true);

        if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(false);

        AppendStatus(new AppendEventArgs(""));

        return await Task.FromResult(true);
    }
}

