using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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

            contact = (from c in dbManage.Contacts
                       select c).FirstOrDefault();

            if (contact == null)
            {
                return await Task.FromResult(false);
            }

            contact.HasInternetConnection = HasInternetConnection;

            try
            {
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnmanagedServerError_, ex.Message)));
                return await Task.FromResult(true);
            }

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
