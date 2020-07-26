using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoCheckingInternetConnection()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                foreach (string url in new List<string>() { "https://www.google.com/", "https://www.bing.com/" })
                {
                    string ret = await httpClient.GetStringAsync(url);
                    if (!string.IsNullOrWhiteSpace(ret))
                    {
                        return await Task.FromResult(true);
                    }
                }
            }
            catch (Exception ex)
            {
                // nothing for now
            }
            
            return await Task.FromResult(false);
        }
    }
}
