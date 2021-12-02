namespace CSSPAzureLoginServices.Services;

public partial class CSSPAzureLoginService : ICSSPAzureLoginService
{
    private async Task<bool> AzureLoginContactAsync()
    {
        using (HttpClient httpClient = new HttpClient())
        {
            Contact contact = new Contact();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            try
            {
                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/auth/token", contentData).Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 400)
                    {
                        CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        CSSPLogService.AppendError(CSSPCultureServicesRes.ServerNotRespondingDoYouHaveInternetConnection);
                        return await Task.FromResult(false);
                    }
                }

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);

                if (contact == null)
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError(ex.Message);
                return await Task.FromResult(false);
            }

            List<Contact> contactToDeleteList = (from c in dbManage.Contacts
                                                 select c).ToList();

            if (contactToDeleteList.Count > 0)
            {
                try
                {
                    dbManage.Contacts.RemoveRange(contactToDeleteList);
                    dbManage.SaveChanges();
                }
                catch (Exception ex)
                {
                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "Contacts", ex.Message));
                    return await Task.FromResult(false);
                }
            }

            try
            {
                dbManage.Contacts.Add(contact);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Contact", ex.Message));
                return await Task.FromResult(false);
            }

            if (!await CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync()) return await Task.FromResult(false);
        }

        return await Task.FromResult(true);
    }
}

