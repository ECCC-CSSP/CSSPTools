using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPHelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPAzureLoginServices.Services
{
    public partial class CSSPAzureLoginService : ICSSPAzureLoginService
    {
        #region Properties
        #endregion Properties

        #region Functions private
        private async Task<bool> AzureLoginContactAsync(LoginModel loginModel)
        {
            if (string.IsNullOrWhiteSpace(loginModel.LoginEmail))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._IsRequired, "LoginEmail"));
                return await Task.FromResult(false);
            }

            if (string.IsNullOrWhiteSpace(loginModel.Password))
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes._IsRequired, "Password"));
                return await Task.FromResult(false);
            }

            using (HttpClient httpClient = new HttpClient())
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(contentType);

                try
                {
                    // trying to login
                    string stringData = JsonSerializer.Serialize(loginModel);
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync($"{ Configuration["CSSPAzureUrl"] }api/{ culture }/auth/token", contentData).Result;
                    if ((int)response.StatusCode != 200)
                    {
                        if ((int)response.StatusCode == 400)
                        {
                            CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
                            return await Task.FromResult(false);
                        }
                        else
                        {
                            CSSPLogService.AppendError(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection);
                            return await Task.FromResult(false);
                        }
                    }

                    contact = JsonSerializer.Deserialize<Contact>(response.Content.ReadAsStringAsync().Result);

                    if (contact == null)
                    {
                        CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes.UnableToLoginAs_WithProvidedPassword, loginModel.LoginEmail));
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
                        CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes.CouldNotDelete_Error_, "Contacts", ex.Message));
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
                    CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "Contact", ex.Message));
                    return await Task.FromResult(false);
                }

                if (!await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo()) return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
