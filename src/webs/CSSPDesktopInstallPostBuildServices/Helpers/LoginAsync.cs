using Azure.Storage.Blobs;
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPHelperModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPDesktopInstallPostBuildServices.Services
{
    public partial class CSSPDesktopInstallPostBuildService : ICSSPDesktopInstallPostBuildService
    {
        public async Task<bool> LoginAsync()
        {
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
                            return await Task.FromResult(false);
                        }
                        else
                        {
                            Console.WriteLine(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection);
                            return await Task.FromResult(false);
                        }
                    }

                    contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);

                    if (contact == null)
                    {
                        Console.WriteLine(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                        return await Task.FromResult(false);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return await Task.FromResult(false);
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
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        Console.WriteLine(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection);
                        return await Task.FromResult(false);
                    }
                }

                try
                {
                    AzureStoreHash = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                    Console.WriteLine(string.Format(CSSPCultureDesktopRes.CouldNotGet_, "AzureStoreHash"));
                    return await Task.FromResult(false);
                }
            }

            Console.WriteLine($"Logged in ...");

            return await Task.FromResult(true);
        }
    }
}
