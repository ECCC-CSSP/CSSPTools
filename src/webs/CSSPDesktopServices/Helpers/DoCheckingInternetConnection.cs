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
            string url = "https://www.google.com/";

            AppendStatus(new AppendEventArgs(appTextModel.CheckingInternetConnection));

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.TryingToDownload_, url)));

                HttpClient httpClient = new HttpClient();
                string ret = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
                if (!string.IsNullOrWhiteSpace(ret))
                {
                    AppendStatus(new AppendEventArgs(appTextModel.InternetConnectionDetected));
                    HasInternetConnection = true;
                }
            }
            catch (Exception)
            {
                AppendStatus(new AppendEventArgs(appTextModel.InternetConnectionNotDetected));
                HasInternetConnection = false;
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
