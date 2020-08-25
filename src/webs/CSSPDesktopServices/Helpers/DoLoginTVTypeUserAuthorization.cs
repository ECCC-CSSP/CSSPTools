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
        private async Task<bool> DoLoginTVTypeUserAuthorization()
        {
            using (HttpClient httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/TVTypeUserAuthorization/GetWithContactTVItemID?ContactTVItemID={ contact.ContactTVItemID }").Result;
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

                // Adding TVTypeUserAuthorization item in dbLogin
                List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(response.Content.ReadAsStringAsync().Result);

                List<TVTypeUserAuthorization> TVTypeUserAuthorizationToDeleteList = (from c in dbLogin.TVTypeUserAuthorizations
                                                                                     select c).ToList();

                if (TVTypeUserAuthorizationToDeleteList.Count > 0)
                {
                    try
                    {
                        dbLogin.TVTypeUserAuthorizations.RemoveRange(TVTypeUserAuthorizationToDeleteList);
                        dbLogin.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVTypeUserAuthorizationList", ex.Message)));
                        return await Task.FromResult(false);
                    }
                }

                try
                {
                    dbLogin.TVTypeUserAuthorizations.AddRange(TVTypeUserAuthorizationList);
                    dbLogin.SaveChanges();

                    AppendStatus(new AppendEventArgs(string.Format(appTextModel._StoredInTable_AndDatabase_, "TVTypeUserAuthorization", "TVTypeUserAuthorizations", "CSSPDBLogin.db")));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVTypeUserAuthorizationList", ex.Message)));
                    return await Task.FromResult(false);
                }

            }
            return await Task.FromResult(true);
        }
    }
}
