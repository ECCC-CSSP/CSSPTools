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
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckingInternetConnection()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string ret = await httpClient.GetStringAsync("https://www.google.com/");
                if (!string.IsNullOrWhiteSpace(ret))
                {
                    HasInternetConnection = true;
                }
            }
            catch (Exception)
            {
                HasInternetConnection = false;
            }

            return await Task.FromResult(true);
        }
    }
}
