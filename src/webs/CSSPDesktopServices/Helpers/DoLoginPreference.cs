using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPHelperModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoLoginManage(LoginModel loginModel)
        {
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            using (HttpClient httpClient = new HttpClient())
            {
                // Getting googleMapKey
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/Auth/GoogleMapKey").Result;
                if ((int)response.StatusCode != 200)
                {
                    if ((int)response.StatusCode == 401)
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.NeedToBeLoggedIn));
                        return await Task.FromResult(false);
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ServerNotRespondingDoYouHaveInternetConnection));
                        return await Task.FromResult(false);
                    }
                }

                string GoogleMapKey = "";
                try
                {
                    GoogleMapKey = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotReadAzureStoreFrom_, $"{ CSSPAzureUrl }api/{ culture }/Auth/GoogleMapKey")));
                    return await Task.FromResult(false);
                }

                contact.HasInternetConnection = true;
                contact.IsLoggedIn = true;
                contact.GoogleMapKeyHash = ScrambleService.Scramble(GoogleMapKey);

                try
                {
                    dbManage.SaveChanges();
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnmanagedServerError_, ex.Message)));
                    return await Task.FromResult(true);
                }
            }

            AppendStatus(new AppendEventArgs(""));

            return await Task.FromResult(true);
        }

        //private async Task<bool> DoStatusActionPreference(ActionResult<Preference> actionPreference, string VariableName)
        //{
        //    if (((ObjectResult)actionPreference.Result).StatusCode == 200)
        //    {
        //        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes._StoredInTable_AndDatabase_, VariableName, "Preferences", "CSSPDBPreference.db")));
        //    }
        //    else
        //    {
        //        if (((ObjectResult)actionPreference.Result).StatusCode == 401)
        //        {
        //            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.Unauthorized));
        //            return await Task.FromResult(false);
        //        }
        //        else if (((ObjectResult)actionPreference.Result).StatusCode == 404)
        //        {
        //            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.BadRequest_, ((ObjectResult)actionPreference.Result).Value)));
        //            return await Task.FromResult(false);
        //        }
        //        else
        //        {
        //            AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.ServerError));
        //            return await Task.FromResult(false);
        //        }
        //    }

        //    return await Task.FromResult(true);
        //}
    }
}
