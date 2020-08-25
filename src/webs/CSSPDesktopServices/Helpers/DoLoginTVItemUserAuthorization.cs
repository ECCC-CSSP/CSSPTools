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
        private async Task<bool> DoLoginTVItemUserAuthorization()
        {
            using (HttpClient httpClient = new HttpClient())
            {

                // Getting TVItemUserAuthorization for the Contact
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/TVItemUserAuthorization/GetWithContactTVItemID?ContactTVItemID={ contact.ContactTVItemID }").Result;
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

                // Adding TVItemUserAuthorization item in dbLogin
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVItemUserAuthorization>>(response.Content.ReadAsStringAsync().Result);

                List<TVItemUserAuthorization> tvItemUserAuthorizationToDeleteList = (from c in dbLogin.TVItemUserAuthorizations
                                                                                     select c).ToList();

                if (tvItemUserAuthorizationToDeleteList.Count > 0)
                {
                    try
                    {
                        dbLogin.TVItemUserAuthorizations.RemoveRange(tvItemUserAuthorizationToDeleteList);
                        dbLogin.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVItemUserAuthorizationList", ex.Message)));
                        return await Task.FromResult(false);
                    }
                }

                try
                {
                    dbLogin.TVItemUserAuthorizations.AddRange(tvItemUserAuthorizationList);
                    dbLogin.SaveChanges();

                    AppendStatus(new AppendEventArgs(string.Format(appTextModel._StoredInTable_AndDatabase_, "TVItemUserAuthorization", "TVItemUserAuthorizations", "CSSPDBLogin.db")));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemUserAuthorizationList", ex.Message)));
                    return await Task.FromResult(false);
                }

            }
            return await Task.FromResult(true);
        }
    }
}
