namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    public async Task<bool> CreateAllRequiredDirectoriesAsync()
    {
        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CreatingAllRequiredDirectories));

        foreach (string dirStr in await GetDirectoryToCreateListAsync())
        {
            DirectoryInfo di = new DirectoryInfo(dirStr);
            if (!di.Exists)
            {
                try
                {
                    di.Create();
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.DirectoryCreated_, di.FullName)));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotCreateDirectory_Error_, di.FullName, ex.Message)));
                    return await Task.FromResult(false);
                }
            }
        }

        AppendStatus(new AppendEventArgs(""));

        return await Task.FromResult(true);
    }
}

