using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPDesktopServices.Models;
using CSSPModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CSSPCultureServices.Resources;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoCheckingInternetConnection()
        {
            AppendStatus(new AppendEventArgs(appTextModel.CheckingInternetConnection));

            try
            {
                AppendStatus(new AppendEventArgs(string.Format(appTextModel.TryingToDownload_, "https://www.google.com/")));

                if (await LocalService.CheckInternetConnection())
                {
                    AppendStatus(new AppendEventArgs(appTextModel.InternetConnectionDetected));
                    preference.HasInternetConnection = true;
                }
            }
            catch (Exception)
            {
                AppendStatus(new AppendEventArgs(appTextModel.InternetConnectionNotDetected));
                preference.HasInternetConnection = false;
            }

            Preference preferenceInDB = (from c in dbLogin.Preferences
                                         select c).FirstOrDefault();

            if (preferenceInDB == null)
            {
                preferenceInDB = new Preference()
                {
                    PreferenceID = 1,
                    AzureStore = "",
                    LoginEmail = "",
                    Password = "",
                    HasInternetConnection = preference.HasInternetConnection,
                    LoggedIn = false,
                    Token = "",
                };

                dbLogin.Preferences.Add(preferenceInDB);
            }
            else
            {
                preferenceInDB.HasInternetConnection = preference.HasInternetConnection;               
            }

            try
            {
                dbLogin.SaveChanges();

                AppendStatus(new AppendEventArgs(string.Format(appTextModel._StoredInTable_AndDatabase_, "Preference", "Preferences", "CSSPDBLogin.db")));
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference", ex.Message)));
                return await Task.FromResult(false);
            }

            preference.PreferenceID = preferenceInDB.PreferenceID;
            preference.AzureStore = await Descramble(preferenceInDB.AzureStore);
            preference.LoginEmail = await Descramble(preferenceInDB.LoginEmail);
            preference.Password = await Descramble(preferenceInDB.Password);
            preference.HasInternetConnection = preferenceInDB.HasInternetConnection;
            preference.LoggedIn = preferenceInDB.LoggedIn;
            preference.Token = await Descramble(preferenceInDB.Token);

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
