using CSSPCultureServices.Services;
using CSSPDesktopServices.Models;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        public async Task<bool> FillContactHasInternetConnectionAsync()
        {
            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CheckingInternetConnection));

            bool HasInternetConnection = false;

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.TryingToDownload_, "https://www.google.com/")));

                if (await TryToAccessGoogleAsync())
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
    }
}
