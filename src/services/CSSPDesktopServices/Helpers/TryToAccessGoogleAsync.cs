namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    private async Task<bool> TryToAccessGoogleAsync()
    {
        string url = "https://www.google.com/";

        try
        {
            HttpClient httpClient = new HttpClient();
            string ret = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
            if (!string.IsNullOrWhiteSpace(ret))
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }
        catch (Exception)
        {
            return await Task.FromResult(false);
        }
    }
}

