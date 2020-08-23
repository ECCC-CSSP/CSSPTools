using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPModels;
using CSSPServices;
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
        private async Task<bool> DoLoginPreference(string LoginEmail, string Password)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Getting AzureStore
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/Auth/AzureStore").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureServicesRes.NeedToBeLoggedIn));
                        return await Task.FromResult(false);
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureServicesRes.ServerNotRespondingDoYouHaveInternetConnection));
                        return await Task.FromResult(false);
                    }
                }

                string AzureStore = "";
                try
                {
                    AzureStore = response.Content.ReadAsStringAsync().Result;

                }
                catch (Exception ex)
                {

                    throw;
                }

                List<Preference> preferenceToDeleteList = (from c in dbLogin.Preferences
                                                           select c).ToList();

                try
                {
                    dbLogin.Preferences.RemoveRange(preferenceToDeleteList);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "PreferenceToDeleteList", ex.Message)));
                    return await Task.FromResult(false);
                }

                Preference preference = new Preference()
                {
                    PreferenceID = 1,
                    AzureStore = await Scramble(AzureStore),
                    LoginEmail = await Scramble(LoginEmail),
                    Password = await Scramble(Password),
                    HasInternetConnection = true,
                    AzureLoggedIn = true,
                    AzureToken = await Scramble(contact.Token),
                    LocalLoggedIn = false,
                    LocalToken = "",
                };

                try
                {
                    dbLogin.Preferences.Add(preference);
                    dbLogin.SaveChanges();

                    AppendStatus(new AppendEventArgs(string.Format(appTextModel._StoredInTable_AndDatabase_, "Preference", "Preferences", "CSSPDBLogin.db")));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference", ex.Message)));
                    return await Task.FromResult(false);
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }
    }
}
