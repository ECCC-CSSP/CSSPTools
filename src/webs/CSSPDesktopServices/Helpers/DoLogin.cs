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

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService
    {
        private async Task<bool> DoLogin(string LoginEmail, string Password)
        {
            if (string.IsNullOrWhiteSpace(LoginEmail))
            {
                AppendTempStatus(new AppendTempEventArgs("LoginEmail is required"));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                AppendTempStatus(new AppendTempEventArgs("Password is required"));
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

                // trying to login
                string stringData = JsonSerializer.Serialize(loginModel);
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/en-CA/auth/token", contentData).Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 400)
                    {
                        AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, LoginEmail)));
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        AppendTempStatus(new AppendTempEventArgs("Looks like the server is not responding. Do you have internet connection."));
                        return await Task.FromResult(false);
                    }
                }

                Contact contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);

                if (contact == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, LoginEmail)));
                    return await Task.FromResult(false);
                }

                //AppendStatus(new AppendEventArgs(contact.Token));

                // Addgin Contact item in dbLogin
                List<Contact> contactToDeleteList = (from c in dbLogin.Contacts
                                                     select c).ToList();

                try
                {
                    dbLogin.Contacts.RemoveRange(contactToDeleteList);
                    await dbLogin.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "Contacts", ex.Message)));
                    return await Task.FromResult(false);
                }

                try
                {
                    dbLogin.Contacts.Add(contact);
                    await dbLogin.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Contact", ex.Message)));
                    return await Task.FromResult(false);
                }

                stringData = JsonSerializer.Serialize(contact.Id);
                contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/aspnetuser/{ contact.Id }").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendTempStatus(new AppendTempEventArgs(CSSPCultureServicesRes.NeedToBeLoggedIn));
                        return await Task.FromResult(false);
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        AppendTempStatus(new AppendTempEventArgs("Looks like the server is not responding. Do you have internet connection."));
                        return await Task.FromResult(false);
                    }

                }

                // Adding ASPNetUser item in dbLogin
                AspNetUser aspNetUser = JsonSerializer.Deserialize<AspNetUser>(response.Content.ReadAsStringAsync().Result);

                if (aspNetUser == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AspNetUser", "Id", contact.Id.ToString())));
                    return await Task.FromResult(false);
                }

                List<AspNetUser> aspNetUserToDeleteList = (from c in dbLogin.AspNetUsers
                                                           select c).ToList();

                try
                {
                    dbLogin.AspNetUsers.RemoveRange(aspNetUserToDeleteList);
                    await dbLogin.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AspNetUsers", ex.Message)));
                    return await Task.FromResult(false);
                }

                try
                {
                    dbLogin.AspNetUsers.Add(aspNetUser);
                    await dbLogin.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AspNetUser", ex.Message)));
                    return await Task.FromResult(false);
                }

                // Adding Preference LoginEmail item in dbLogin
                Preference preference = (from c in dbLogin.Preferences
                                         where c.PreferenceName == "LoginEmail"
                                         select c).FirstOrDefault();

                if (preference == null)
                {
                    preference = new Preference()
                    {
                        PreferenceName = "LoginEmail",
                        PreferenceText = LoginEmail
                    };

                    dbLogin.Preferences.Add(preference);
                }
                else
                {
                    preference.PreferenceText = LoginEmail;
                }

                try
                {
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference LoginEmail Item", ex.Message)));
                    return await Task.FromResult(false);
                }

                // Adding Preference Password item in dbLogin
                preference = (from c in dbLogin.Preferences
                              where c.PreferenceName == "Password"
                              select c).FirstOrDefault();

                if (preference == null)
                {
                    preference = new Preference()
                    {
                        PreferenceName = "Password",
                        PreferenceText = Password
                    };

                    dbLogin.Preferences.Add(preference);
                }
                else
                {
                    preference.PreferenceText = Password;
                }

                try
                {
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference Password Item", ex.Message)));
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(false);
        }
    }
}
