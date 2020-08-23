using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPModels;
using CSSPServices;
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
        private async Task<bool> DoLoginContact(string LoginEmail, string Password)
        {
            AppendStatus(new AppendEventArgs(appTextModel.Login));

            if (string.IsNullOrWhiteSpace(LoginEmail))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes._IsRequired, "LoginEmail")));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes._IsRequired, "Password")));
                return await Task.FromResult(false);
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                LoginModel loginModel = new LoginModel()
                {
                    LoginEmail = LoginEmail,
                    Password = Password
                };

                AppendStatus(new AppendEventArgs(string.Format(appTextModel.PostRequestLoginEmailAndPasswordTo_, $"{ CSSPAzureUrl }api/en-CA/auth/token")));

                // trying to login
                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 400)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, LoginEmail)));
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureServicesRes.ServerNotRespondingDoYouHaveInternetConnection));
                        return await Task.FromResult(false);
                    }
                }

                contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);

                if (contact == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, LoginEmail)));
                    return await Task.FromResult(false);
                }

                // Addgin Contact item in dbLogin
                List<Contact> contactToDeleteList = (from c in dbLogin.Contacts
                                                     select c).ToList();

                try
                {
                    dbLogin.Contacts.RemoveRange(contactToDeleteList);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "Contacts", ex.Message)));
                    return await Task.FromResult(false);
                }

                try
                {
                    dbLogin.Contacts.Add(contact);
                    dbLogin.SaveChanges();

                    AppendStatus(new AppendEventArgs(string.Format(appTextModel._StoredInTable_AndDatabase_, "Contact", "Contacts", "CSSPDBLogin.db")));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Contact", ex.Message)));
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
