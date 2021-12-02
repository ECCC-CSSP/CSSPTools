namespace CSSPAzureLoginServices.Services;

public partial class CSSPAzureLoginService : ICSSPAzureLoginService
{
    private async Task<bool> AzureLoginManageAsync(LoginModel loginModel)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            // Getting googleMapKeyHash
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.Token);
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/Auth/GoogleMapKeyHash").Result;
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

            string GoogleMapKeyHash = "";
            try
            {
                GoogleMapKeyHash = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotGet_, "GoogleMapKeyHash"));
                return await Task.FromResult(false);
            }

            Contact contact = (from c in dbManage.Contacts
                               select c).FirstOrDefault();

            if (contact == null)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotFind_, "Contact"));
                return await Task.FromResult(false);
            }

            contact.HasInternetConnection = true;
            contact.IsLoggedIn = true;
            contact.GoogleMapKeyHash = GoogleMapKeyHash;

            try
            {
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message));
                return await Task.FromResult(true);
            }
        }

        using (HttpClient httpClient = new HttpClient())
        {
            // Getting googleMapKeyHash
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.Token);
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/Auth/AzureStoreHash").Result;
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

            string AzureStoreHash = "";
            try
            {
                AzureStoreHash = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotGet_, "AzureStoreHash"));
                return await Task.FromResult(false);
            }

            Contact contact = (from c in dbManage.Contacts
                               select c).FirstOrDefault();

            if (contact == null)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotFind_, "Contact"));
                return await Task.FromResult(false);
            }

            contact.HasInternetConnection = true;
            contact.IsLoggedIn = true;
            contact.AzureStoreHash = AzureStoreHash;

            try
            {
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message));
                return await Task.FromResult(true);
            }

        }

        return await Task.FromResult(true);
    }
}

