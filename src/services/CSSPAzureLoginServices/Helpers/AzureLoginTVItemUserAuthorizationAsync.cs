namespace CSSPAzureLoginServices.Services;

public partial class CSSPAzureLoginService : ICSSPAzureLoginService
{
    private async Task<bool> AzureLoginTVItemUserAuthorizationAsync()
    {
        using (HttpClient httpClient = new HttpClient())
        {

            // Getting TVItemUserAuthorization for the Contact
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.Token);
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/TVItemUserAuthorizationAzure/{ CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID }").Result;
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

