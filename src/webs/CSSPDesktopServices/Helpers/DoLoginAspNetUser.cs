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
        private async Task<bool> DoLoginAspNetUser()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                // Getting AspNetUser for the Contact
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/aspnetuser/{ contact.Id }").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureServicesRes.NeedToBeLoggedIn));
                        return await Task.FromResult(false);
                    }
                    else if ((int)response.StatusCode == 500)
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureServicesRes.ServerNotRespondingDoYouHaveInternetConnection));
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
                    dbLogin.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AspNetUsers", ex.Message)));
                    return await Task.FromResult(false);
                }

                try
                {
                    dbLogin.AspNetUsers.Add(aspNetUser);
                    dbLogin.SaveChanges();

                    AppendStatus(new AppendEventArgs(string.Format(appTextModel._StoredInTable_AndDatabase_, "AspNetUser", "AspNetUsers", "CSSPDBLogin.db")));
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "AspNetUser", ex.Message)));
                    return await Task.FromResult(false);
                }
            }
            return await Task.FromResult(true);
        }
    }
}
