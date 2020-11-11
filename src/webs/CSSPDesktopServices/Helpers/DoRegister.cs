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
        #region Properties
        #endregion Properties

        #region Functions private
        private async Task<bool> DoRegister(RegisterModel registerModel)
        {
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.Register));

            if (string.IsNullOrWhiteSpace(registerModel.LoginEmail))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._IsRequired, "Login Email")));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(registerModel.FirstName))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._IsRequired, "First Name")));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(registerModel.LastName))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._IsRequired, "Last Name")));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(registerModel.Initial))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._IsRequired, "Initial")));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(registerModel.Password))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._IsRequired, "Password")));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(registerModel.ConfirmPassword))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._IsRequired, "Confirm Password")));
                return await Task.FromResult(false);
            }


            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.PostRequestLoginEmailAndPasswordTo_, $"{ CSSPAzureUrl }api/{ culture }/auth/register")));

                try
                {
                    // trying to login
                    string stringData = JsonSerializer.Serialize(registerModel);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/{ culture }/auth/register", contentData).Result;
                    if ((int)response.StatusCode != 200)
                    {
                        if ((int)response.StatusCode == 400)
                        {
                            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, registerModel.LoginEmail)));
                            return await Task.FromResult(false);
                        }
                        else
                        {
                            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection));
                            return await Task.FromResult(false);
                        }
                    }

                    contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);

                    if (contact == null)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, registerModel.LoginEmail)));
                        return await Task.FromResult(false);
                    }

                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(ex.Message));
                    return await Task.FromResult(false);
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }

        #endregion Functions private
    }
}
