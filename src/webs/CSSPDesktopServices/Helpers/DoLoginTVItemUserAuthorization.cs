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
        private async Task<bool> DoLoginTVItemUserAuthorization()
        {
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            using (HttpClient httpClient = new HttpClient())
            {

                // Getting TVItemUserAuthorization for the Contact
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorization/GetWithContactTVItemID/{ contact.ContactTVItemID }").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.NeedToBeLoggedIn));
                        return await Task.FromResult(false);
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection));
                        return await Task.FromResult(false);
                    }

                }

                List<TVItemUserAuthorization> tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVItemUserAuthorization>>(response.Content.ReadAsStringAsync().Result);

                List<TVItemUserAuthorization> tvItemUserAuthorizationToDeleteList = (from c in dbManage.TVItemUserAuthorizations
                                                                                     select c).ToList();

                if (tvItemUserAuthorizationToDeleteList.Count > 0)
                {
                    try
                    {
                        dbManage.TVItemUserAuthorizations.RemoveRange(tvItemUserAuthorizationToDeleteList);
                        dbManage.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDelete_Error_, "TVItemUserAuthorizationList", ex.Message)));
                        return await Task.FromResult(false);
                    }
                }

                try
                {
                    dbManage.TVItemUserAuthorizations.AddRange(tvItemUserAuthorizationList);
                    dbManage.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "TVItemUserAuthorizationList", ex.Message)));
                    return await Task.FromResult(false);
                }

            }
            return await Task.FromResult(true);
        }
    }
}
