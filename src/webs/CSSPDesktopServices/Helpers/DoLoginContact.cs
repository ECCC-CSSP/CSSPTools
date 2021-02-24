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
using CSSPHelperModels;
using CSSPDBPreferenceModels;
using Microsoft.AspNetCore.Mvc;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Properties
        #endregion Properties

        #region Functions private
        private async Task<bool> DoLoginContact(LoginModel loginModel)
        {
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.Login));

            if (string.IsNullOrWhiteSpace(loginModel.LoginEmail))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._IsRequired, "LoginEmail")));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(loginModel.Password))
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._IsRequired, "Password")));
                return await Task.FromResult(false);
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.PostRequestLoginEmailAndPasswordTo_, $"{ CSSPAzureUrl }api/{ culture }/auth/token")));

                try
                {
                    // trying to login
                    string stringData = JsonSerializer.Serialize(loginModel);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync($"{ CSSPAzureUrl }api/{ culture }/auth/token", contentData).Result;
                    if ((int)response.StatusCode != 200)
                    {
                        if ((int)response.StatusCode == 400)
                        {
                            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail)));
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
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail)));
                        return await Task.FromResult(false);
                    }
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(ex.Message));
                    return await Task.FromResult(false);
                }

                // Addgin Contact item in dbPreference
                List<Contact> contactToDeleteList = (from c in dbPreference.Contacts
                                                     select c).ToList();

                if (contactToDeleteList.Count > 0)
                {
                    try
                    {
                        dbPreference.Contacts.RemoveRange(contactToDeleteList);
                        dbPreference.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotDelete_Error_, "Contacts", ex.Message)));
                        return await Task.FromResult(false);
                    }
                }

                try
                {
                    dbPreference.Contacts.Add(contact);
                    dbPreference.SaveChanges();

                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._StoredInTable_AndDatabase_, "Contact", "Contacts", "CSSPDBPreference.db")));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "Contact", ex.Message)));
                    return await Task.FromResult(false);
                }

                string LoginEmail = "";
                var actionPreference = await PreferenceService.GetPreferenceWithVariableName("LoginEmail");
                if (await DoStatusActionPreference(actionPreference, "LoginEmail"))
                {
                    Preference preference = (Preference)((OkObjectResult)actionPreference.Result).Value;
                    LoginEmail = preference.VariableValue;
                }

                if (!await LoggedInService.SetLoggedInContactInfo(LoginEmail)) return await Task.FromResult(false);
                //await LocalService.SetLoggedInContactInfo();
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
