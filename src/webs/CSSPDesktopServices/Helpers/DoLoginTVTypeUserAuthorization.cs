using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPDBModels;
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
        private async Task<bool> DoLoginTVTypeUserAuthorization()
        {
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            using (HttpClient httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/TVTypeUserAuthorization/GetWithContactTVItemID/{ contact.ContactTVItemID }").Result;
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

                // Adding TVTypeUserAuthorization item in dbPreference
                List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(response.Content.ReadAsStringAsync().Result);

                List<TVTypeUserAuthorization> TVTypeUserAuthorizationToDeleteList = (from c in dbPreference.TVTypeUserAuthorizations
                                                                                     select c).ToList();

                if (TVTypeUserAuthorizationToDeleteList.Count > 0)
                {
                    try
                    {
                        dbPreference.TVTypeUserAuthorizations.RemoveRange(TVTypeUserAuthorizationToDeleteList);
                        dbPreference.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDelete_Error_, "TVTypeUserAuthorizationList", ex.Message)));
                        return await Task.FromResult(false);
                    }
                }

                try
                {
                    dbPreference.TVTypeUserAuthorizations.AddRange(TVTypeUserAuthorizationList);
                    dbPreference.SaveChanges();

                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._StoredInTable_AndDatabase_, "TVTypeUserAuthorization", "TVTypeUserAuthorizations", "CSSPDBPreference.db")));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "TVTypeUserAuthorizationList", ex.Message)));
                    return await Task.FromResult(false);
                }

            }
            return await Task.FromResult(true);
        }
    }
}
