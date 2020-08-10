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
        List<int> skip { get; set; } = new List<int>()
        {
            3, 1, -3, 2, 2, 0, 4, 1, -2, 2, -1, 3, -2, 0, 1, 3, 1, 2, -4, -1, 1, 2, 0, 2, 1,
            -1, 4, -4, 2, 3, 1, 2, 3, 1, 2, 3, 1, 3, 1, -2, -1, -1, 4, -2, 2, -3, 2, 2, 0, 4,
            3, 1, 1, -2, -1, 3, -2, 0, 3, 2, 0, 1, 4, 1, 1, -4, -1, 2, 0, 2, 1, -3, 2, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, 2, 1,
            -2, 3, 1, -3, 2, 3, -2, -1, 4, 1, -2, 2, 2, -1, 0, 4, 1, -2, -1, 3, -2, 0, 3, -1, 1, -4, -1, 2, 0, 2, 1,
            -1, 2, 3, 2, 1, -3, 2, 3, 2, 0, 4, 1, 2, -2, -1, 0, 3, -2, 0, 3, 1, -4, -1, 3, 2, 0, 2, 1,
            -4, 3, 1, -3, 1, 2, 2, 0, 1, 2, 4, 1, -1, 3, -1, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, -1, 2, 1,
            1, 3, 4, 1, -3, -2, 2, 2, 0, -1, 4, 1, -2, -1, 3, 2, -2, 0, 1, 3, 1, -2, -4, -1, -1, 2, 0, 2, 1,
        };
        #endregion Properties

        #region Functions private
        private bool DoLogin(string LoginEmail, string Password)
        {
            if (string.IsNullOrWhiteSpace(LoginEmail))
            {
                AppendTempStatus(new AppendTempEventArgs("LoginEmail is required"));
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                AppendTempStatus(new AppendTempEventArgs("Password is required"));
                return false;
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
                        return false;
                    }
                    else
                    {
                        AppendTempStatus(new AppendTempEventArgs("Looks like the server is not responding. Do you have internet connection."));
                        return false;
                    }
                }

                Contact contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);

                if (contact == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnableToLoginAs_WithProvidedPassword, LoginEmail)));
                    return false;
                }

                //AppendStatus(new AppendEventArgs(contact.Token));

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
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "Contacts", ex.Message)));
                    return false;
                }

                try
                {
                    dbLogin.Contacts.Add(contact);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Contact", ex.Message)));
                    return false;
                }

                // Getting AspNetUser for the Contact
                //stringData = JsonSerializer.Serialize(contact.Id);
                //contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/aspnetuser/{ contact.Id }").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendTempStatus(new AppendTempEventArgs(CSSPCultureServicesRes.NeedToBeLoggedIn));
                        return false;
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        AppendTempStatus(new AppendTempEventArgs("Looks like the server is not responding. Do you have internet connection."));
                        return false;
                    }

                }

                // Adding ASPNetUser item in dbLogin
                AspNetUser aspNetUser = JsonSerializer.Deserialize<AspNetUser>(response.Content.ReadAsStringAsync().Result);

                if (aspNetUser == null)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AspNetUser", "Id", contact.Id.ToString())));
                    return false;
                }

                List<AspNetUser> aspNetUserToDeleteList = (from c in dbLogin.AspNetUsers
                                                           select c).ToList();

                try
                {
                    dbLogin.AspNetUsers.RemoveRange(aspNetUserToDeleteList);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AspNetUsers", ex.Message)));
                    return false;
                }

                try
                {
                    dbLogin.AspNetUsers.Add(aspNetUser);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AspNetUser", ex.Message)));
                    return false;
                }

                // Getting TVItemUserAuthorization for the Contact
                //stringData = JsonSerializer.Serialize(contact.ContactTVItemID);
                //contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/TVItemUserAuthorization/GetWithContactTVItemID?ContactTVItemID={ contact.ContactTVItemID }").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendTempStatus(new AppendTempEventArgs(CSSPCultureServicesRes.NeedToBeLoggedIn));
                        return false;
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        AppendTempStatus(new AppendTempEventArgs("Looks like the server is not responding. Do you have internet connection."));
                        return false;
                    }

                }

                // Adding TVItemUserAuthorization item in dbLogin
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = JsonSerializer.Deserialize<List<TVItemUserAuthorization>>(response.Content.ReadAsStringAsync().Result);

                List<TVItemUserAuthorization> tvItemUserAuthorizationToDeleteList = (from c in dbLogin.TVItemUserAuthorizations
                                                                                     select c).ToList();

                try
                {
                    dbLogin.TVItemUserAuthorizations.RemoveRange(tvItemUserAuthorizationToDeleteList);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVItemUserAuthorizationList", ex.Message)));
                    return false;
                }

                try
                {
                    dbLogin.TVItemUserAuthorizations.AddRange(tvItemUserAuthorizationList);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemUserAuthorizationList", ex.Message)));
                    return false;
                }

                // Getting TVTypeUserAuthorization for the Contact
                //stringData = JsonSerializer.Serialize(contact.ContactTVItemID);
                //contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/TVTypeUserAuthorization/GetWithContactTVItemID?ContactTVItemID={ contact.ContactTVItemID }").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendTempStatus(new AppendTempEventArgs(CSSPCultureServicesRes.NeedToBeLoggedIn));
                        return false;
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        AppendTempStatus(new AppendTempEventArgs("Looks like the server is not responding. Do you have internet connection."));
                        return false;
                    }

                }

                // Adding TVTypeUserAuthorization item in dbLogin
                List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = JsonSerializer.Deserialize<List<TVTypeUserAuthorization>>(response.Content.ReadAsStringAsync().Result);

                List<TVTypeUserAuthorization> TVTypeUserAuthorizationToDeleteList = (from c in dbLogin.TVTypeUserAuthorizations
                                                                                     select c).ToList();

                try
                {
                    dbLogin.TVTypeUserAuthorizations.RemoveRange(TVTypeUserAuthorizationToDeleteList);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "TVTypeUserAuthorizationList", ex.Message)));
                    return false;
                }

                try
                {
                    dbLogin.TVTypeUserAuthorizations.AddRange(TVTypeUserAuthorizationList);
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVTypeUserAuthorizationList", ex.Message)));
                    return false;
                }

                // Getting AzureStore
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/Auth/AzureStore").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendTempStatus(new AppendTempEventArgs(CSSPCultureServicesRes.NeedToBeLoggedIn));
                        return false;
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        AppendTempStatus(new AppendTempEventArgs("Looks like the server is not responding. Do you have internet connection."));
                        return false;
                    }

                }

                // Adding AzureStore
                string AzureStore = JsonSerializer.Deserialize<string>(response.Content.ReadAsStringAsync().Result);

                // Adding Preference AzureStore item in dbLogin
                Preference preference = (from c in dbLogin.Preferences
                                         where c.PreferenceName == "AzureStore"
                                         select c).FirstOrDefault();

                if (preference == null)
                {
                    int lastPreferenceID = (from c in dbLogin.Preferences
                                            orderby c.PreferenceID descending
                                            select c.PreferenceID).FirstOrDefault();

                    preference = new Preference()
                    {
                        PreferenceID = lastPreferenceID + 1,
                        PreferenceName = "AzureStore",
                        PreferenceText = Scramble(AzureStore)
                    };

                    dbLogin.Preferences.Add(preference);
                }
                else
                {
                    preference.PreferenceText = Scramble(AzureStore);
                }

                try
                {
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference AzureStore Item", ex.Message)));
                    return false;
                }


                // Adding Preference LoginEmail item in dbLogin
                preference = (from c in dbLogin.Preferences
                              where c.PreferenceName == "LoginEmail"
                              select c).FirstOrDefault();

                if (preference == null)
                {
                    int lastPreferenceID = (from c in dbLogin.Preferences
                                            orderby c.PreferenceID descending
                                            select c.PreferenceID).FirstOrDefault();

                    preference = new Preference()
                    {
                        PreferenceID = lastPreferenceID + 1,
                        PreferenceName = "LoginEmail",
                        PreferenceText = Scramble(LoginEmail)
                    };

                    dbLogin.Preferences.Add(preference);
                }
                else
                {
                    preference.PreferenceText = Scramble(LoginEmail);
                }

                try
                {
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference LoginEmail Item", ex.Message)));
                    return false;
                }

                // Adding Preference Password item in dbLogin
                preference = (from c in dbLogin.Preferences
                              where c.PreferenceName == "Password"
                              select c).FirstOrDefault();

                if (preference == null)
                {
                    int lastPreferenceID = (from c in dbLogin.Preferences
                                            orderby c.PreferenceID descending
                                            select c.PreferenceID).FirstOrDefault();

                    preference = new Preference()
                    {
                        PreferenceID = lastPreferenceID + 1,
                        PreferenceName = "Password",
                        PreferenceText = Scramble(Password)
                    };

                    dbLogin.Preferences.Add(preference);
                }
                else
                {
                    preference.PreferenceText = Scramble(Password);
                }

                try
                {
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference Password Item", ex.Message)));
                    return false;
                }

                // Adding Preference Password item in dbLogin
                preference = (from c in dbLogin.Preferences
                              where c.PreferenceName == "Password"
                              select c).FirstOrDefault();

                if (preference == null)
                {
                    int lastPreferenceID = (from c in dbLogin.Preferences
                                            orderby c.PreferenceID descending
                                            select c.PreferenceID).FirstOrDefault();

                    preference = new Preference()
                    {
                        PreferenceID = lastPreferenceID + 1,
                        PreferenceName = "Password",
                        PreferenceText = Scramble(Password)
                    };

                    dbLogin.Preferences.Add(preference);
                }
                else
                {
                    preference.PreferenceText = Scramble(Password);
                }

                try
                {
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference Password Item", ex.Message)));
                    return false;
                }

                // Adding Preference LoggedIn item in dbLogin
                preference = (from c in dbLogin.Preferences
                              where c.PreferenceName == "LoggedIn"
                              select c).FirstOrDefault();

                if (preference == null)
                {
                    int lastPreferenceID = (from c in dbLogin.Preferences
                                            orderby c.PreferenceID descending
                                            select c.PreferenceID).FirstOrDefault();

                    preference = new Preference()
                    {
                        PreferenceID = lastPreferenceID + 1,
                        PreferenceName = "LoggedIn",
                        PreferenceText = Scramble("true")
                    };

                    dbLogin.Preferences.Add(preference);
                }
                else
                {
                    preference.PreferenceText = Scramble("true");
                }

                try
                {
                    dbLogin.SaveChanges();
                    IsLoggedIn = true;
                }
                catch (Exception ex)
                {
                    AppendTempStatus(new AppendTempEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "Preference LoggedIn Item", ex.Message)));
                }
            }

            return true;
        }
        private string Scramble(string Text)
        {
            Random r = new Random();
            int Start = r.Next(1, 9);

            if (string.IsNullOrWhiteSpace(Text)) return "";

            string retStr = Start.ToString();
            int i = 0;
            foreach (char c in Text)
            {
                retStr += (char)((int)c + skip[i + Start]);
                i += 1;
            }

            string retStr2 = "";
            int length = retStr.Length - 1;
            for (int j = length; j > -1; j--)
            {
                retStr2 += retStr[j].ToString();
            }

            return retStr2;
        }
        #endregion Functions private
    }
}
