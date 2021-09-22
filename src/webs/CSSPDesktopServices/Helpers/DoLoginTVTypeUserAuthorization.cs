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
                HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorization/GetWithContactTVItemID/{ contact.ContactTVItemID }").Result;
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

                List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(response.Content.ReadAsStringAsync().Result);

                List<TVTypeUserAuthorization> TVTypeUserAuthorizationToDeleteList = (from c in dbManage.TVTypeUserAuthorizations
                                                                                     select c).ToList();

                if (TVTypeUserAuthorizationToDeleteList.Count > 0)
                {
                    try
                    {
                        dbManage.TVTypeUserAuthorizations.RemoveRange(TVTypeUserAuthorizationToDeleteList);
                        dbManage.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDelete_Error_, "TVTypeUserAuthorizationList", ex.Message)));
                        return await Task.FromResult(false);
                    }
                }

                try
                {
                    dbManage.TVTypeUserAuthorizations.AddRange(TVTypeUserAuthorizationList);
                    dbManage.SaveChanges();
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
