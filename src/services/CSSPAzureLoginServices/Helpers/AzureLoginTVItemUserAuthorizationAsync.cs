using CSSPCultureServices.Resources;
using CSSPDBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPAzureLoginServices.Services
{
    public partial class CSSPAzureLoginService : ICSSPAzureLoginService
    {
        private async Task<bool> AzureLoginTVItemUserAuthorizationAsync()
        {
            string culture = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? "fr-CA" : "en-CA";

            if (CSSPLocalLoggedInService.LoggedInContactInfo == null
                || CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                CSSPLogService.AppendError(CSSPCultureServicesRes.NeedToBeLoggedIn);
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.Token))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._IsRequired, "Token"));
                return await Task.FromResult(false);
            }

            using (HttpClient httpClient = new HttpClient())
            {

                // Getting TVItemUserAuthorization for the Contact
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorization/GetWithContactTVItemID/{ CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID }").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        CSSPLogService.AppendError(CSSPCultureServicesRes.NeedToBeLoggedIn);
                        return await Task.FromResult(false);
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        CSSPLogService.AppendError(CSSPCultureServicesRes.ServerNotRespondingDoYouHaveInternetConnection);
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
                        CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVItemUserAuthorizationList", ex.Message));
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
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemUserAuthorizationList", ex.Message));
                    return await Task.FromResult(false);
                }

            }
            return await Task.FromResult(true);
        }
    }
}
