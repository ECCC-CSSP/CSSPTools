﻿namespace CSSPAzureLoginServices.Services;

public partial class CSSPAzureLoginService : ICSSPAzureLoginService
{
    private async Task<bool> AzureLoginTVTypeUserAuthorizationAsync()
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

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.Token);
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVTypeUserAuthorization/GetWithContactTVItemID/{ CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID }").Result;
            if ((int)response.StatusCode != 200)
            {
                if ((int)response.StatusCode == 401)
                {
                    CSSPLogService.AppendError(CSSPCultureServicesRes.NeedToBeLoggedIn);
                    return await Task.FromResult(false);
                }
                else
                {
                    CSSPLogService.AppendError(CSSPCultureServicesRes.ServerNotRespondingDoYouHaveInternetConnection);
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
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVTypeUserAuthorizationList", ex.Message));
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
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVTypeUserAuthorizationList", ex.Message));
                return await Task.FromResult(false);
            }

        }
        return await Task.FromResult(true);
    }
}

