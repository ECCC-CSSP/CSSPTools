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
using Microsoft.AspNetCore.Mvc;

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

                List<string> VariableNameList = new List<string>()
                {
                    "AzureStore",
                    "LoginEmail",
                    "Password",
                    "Token",
                    "HasInternetConnection",
                    "LoggedIn"
                };

                List<string> VariableValueList = new List<string>()
                {
                    await LocalService.Scramble(AzureStore),
                    await LocalService.Scramble(loginModel.LoginEmail),
                    await LocalService.Scramble(loginModel.Password),
                    await LocalService.Scramble(contact.Token),
                    await LocalService.Scramble("true"),
                    await LocalService.Scramble("true"),
                };

                for (int i = 0; i < VariableNameList.Count; i++)
                {
                    var actionPreference = await PreferenceService.AddOrChange(VariableNameList[i], VariableValueList[i]);
                    if (!await DoStatusActionPreference(actionPreference, VariableNameList[i])) return await Task.FromResult(false);
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }

        private async Task<bool> DoStatusActionPreference(ActionResult<Preference> actionPreference, string VariableName)
        {
            if (((ObjectResult)actionPreference.Result).StatusCode == 200)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._StoredInTable_AndDatabase_, VariableName, "Preferences", "CSSPDBLogin.db")));
            }
            else
            {
                if (((ObjectResult)actionPreference.Result).StatusCode == 401)
                {
                    AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.Unauthorized));
                    return await Task.FromResult(false);
                }
                else if (((ObjectResult)actionPreference.Result).StatusCode == 404)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.BadRequest_, ((ObjectResult)actionPreference.Result).Value)));
                    return await Task.FromResult(false);
                }
                else
                {
                    AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ServerError));
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
    }
}
