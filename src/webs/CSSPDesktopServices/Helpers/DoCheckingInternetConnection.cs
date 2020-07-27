using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task DoCheckingInternetConnection()
        {
            HttpClient httpClient = new HttpClient();
            foreach (string url in new List<string>() { "https://www.google.com/", "https://www.bing.com/" })
            {
                string ret = await httpClient.GetStringAsync(url);
                if (!string.IsNullOrWhiteSpace(ret))
                {
                    HasInternetConnection = true;
                }
                else
                {
                    HasInternetConnection = false;
                }
            }
        }
    }
}
