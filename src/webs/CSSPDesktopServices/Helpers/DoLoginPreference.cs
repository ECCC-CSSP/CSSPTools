using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.SignalR;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoLoginPreference(LoginModel loginModel)
        {
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            using (HttpClient httpClient = new HttpClient())
            {
                // Getting AzureStore
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/Auth/AzureStore").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.NeedToBeLoggedIn));
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection));
                        return await Task.FromResult(false);
                    }
                }

                string AzureStore = "";
                try
                {
                    AzureStore = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotReadAzureStoreFrom_, $"{ CSSPAzureUrl }api/{ culture }/Auth/AzureStore")));
                    return await Task.FromResult(false);
                }

                List<Preference> preferenceToDeleteList = (from c in dbLogin.Preferences
                                                           select c).ToList();

                if (preferenceToDeleteList.Count > 0)
                {
                    try
                    {
                        dbLogin.Preferences.RemoveRange(preferenceToDeleteList);
                        dbLogin.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDelete_Error_, "PreferenceToDeleteList", ex.Message)));
                        return await Task.FromResult(false);
                    }
                }

                Preference preference = new Preference()
                {
                    PreferenceID = 1,
                    AzureStore = await LocalService.Scramble(AzureStore),
                    LoginEmail = await LocalService.Scramble(loginModel.LoginEmail),
                    Password = await LocalService.Scramble(loginModel.Password),
                    HasInternetConnection = true,
                    LoggedIn = true,
                    Token = await LocalService.Scramble(contact.Token),
                };

                try
                {
                    dbLogin.Preferences.Add(preference);
                    dbLogin.SaveChanges();

                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._StoredInTable_AndDatabase_, "Preference", "Preferences", "CSSPDBLogin.db")));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "Preference", ex.Message)));
                    return await Task.FromResult(false);
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
