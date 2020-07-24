using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopUpdateServices.Services
{
    public partial class CSSPDesktopUpdateService
    {
        private bool DoCheckingInternetConnection()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                foreach (string url in new List<string>() { "https://www.google.com/", "https://www.bing.com/" })
                {
                    string ret = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
                    if (!string.IsNullOrWhiteSpace(ret))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // nothing for now
            }
            
            return false;
        }
    }
}
