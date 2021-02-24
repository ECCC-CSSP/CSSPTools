using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPDesktopServices.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CSSPCultureServices.Resources;
using CSSPDBModels;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckingInternetConnection()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckingInternetConnection));

            bool HasInternetConnection = false;

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.TryingToDownload_, "https://www.google.com/")));

                if (await CheckInternetConnection())
                {
                    AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.InternetConnectionDetected));
                    HasInternetConnection = true;
                }
                else
                {
                    AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.InternetConnectionNotDetected));
                    HasInternetConnection = false;
                }
            }
            catch (Exception)
            {
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.InternetConnectionNotDetected));
                HasInternetConnection = false;
            }

            var actionPreference = await PreferenceService.AddOrChange("HasInternetConnection", HasInternetConnection.ToString());
            if (!await DoStatusActionPreference(actionPreference, "HasInternetConnection")) return await Task.FromResult(false);

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }

        private async Task<bool> CheckInternetConnection()
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
}
