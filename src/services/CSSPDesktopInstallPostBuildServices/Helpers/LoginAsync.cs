namespace CSSPDesktopInstallPostBuildServices.Services;

public partial class CSSPDesktopInstallPostBuildService : ICSSPDesktopInstallPostBuildService
{
    public async Task<Contact> LoginAsync()
    {
        contact = null;
        Console.WriteLine($"Logging in ...");

        using (HttpClient httpClient = new HttpClient())
        {
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);

            LoginModel loginModel = new LoginModel()
            {
                LoginEmail = Configuration["LoginEmail"],
                Password = Configuration["Password"],
            };

            try
            {
                // trying to login
                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/auth/token", contentData).Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 400)
                    {
                        Console.WriteLine(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                        return await Task.FromResult(contact);
                    }
                    else
                    {
                        Console.WriteLine(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection);
                        return await Task.FromResult(contact);
                    }
                }

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);

                if (contact == null)
                {
                    Console.WriteLine(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                    return await Task.FromResult(contact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(contact);
            }
        }

        using (HttpClient httpClient = new HttpClient())
        {
            // Getting googleMapKeyHash
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
            HttpResponseMessage response = httpClient.GetAsync($"{ Configuration["CSSPAzureUrl"] }api/en-CA/Auth/AzureStoreHash").Result;
            if ((int)response.StatusCode != 200)
            {
                if ((int)response.StatusCode == 401)
                {
                    Console.WriteLine(CSSPCultureDesktopRes.NeedToBeLoggedIn);
                    return await Task.FromResult(contact);
                }
                else
                {
                    Console.WriteLine(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection);
                    return await Task.FromResult(contact);
                }
            }

            try
            {
                contact.AzureStoreHash = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                Console.WriteLine(string.Format(CSSPCultureDesktopRes.CouldNotGet_, "AzureStoreHash"));
                return await Task.FromResult(contact);
            }
        }

        Console.WriteLine($"Logged in ...");

        return await Task.FromResult(contact);
    }
}

