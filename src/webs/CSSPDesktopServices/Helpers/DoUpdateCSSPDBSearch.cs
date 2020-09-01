/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSSPDesktopServices.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoUpdateCSSPDBSearch()
        {
            if (!await DoGetTVItems()) return await Task.FromResult(false);
            if (!await DoGetTVItemLanguages()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }

        private async Task<bool> DoGetTVItems()
        {
            TVItem tvItem = await(from c in dbSearch.TVItems
                                  select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                if (!await FillCSSPDBSearch()) return await Task.FromResult(false);
            }

            tvItem = await(from c in dbSearch.TVItems
                           orderby c.LastUpdateDate_UTC descending
                           select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                AppendStatus(new AppendEventArgs(CSSPCultureServicesRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                return await Task.FromResult(false);
            }

            HttpResponseMessage response = null;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                response = await httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/TVItem/GetTVItemStartDateList/{ tvItem.LastUpdateDate_UTC.Year }/{ tvItem.LastUpdateDate_UTC.Month }/{ tvItem.LastUpdateDate_UTC.Day }");
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

            }

            List<TVItem> tvItemList = JsonSerializer.Deserialize<List<TVItem>>(response.Content.ReadAsStringAsync().Result);

            foreach (TVItem tvItemChanged in tvItemList)
            {
                TVItem TVItem2 = await(from c in dbSearch.TVItems
                                       where c.TVItemID == tvItemChanged.TVItemID
                                       select c).FirstOrDefaultAsync();

                if (TVItem2 == null)
                {
                    dbSearch.Add(TVItem2);
                }
                else
                {
                    if (TVItem2 != tvItemChanged)
                    {
                        dbSearch.Update(TVItem2);
                    }
                }
            }

            try
            {
                await dbSearch.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItems", ex.Message)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);

        }

        private async Task<bool> DoGetTVItemLanguages()
        {
            TVItemLanguage tvItemLanguage = await(from c in dbSearch.TVItemLanguages
                                                  orderby c.LastUpdateDate_UTC descending
                                                  select c).FirstOrDefaultAsync();

            if (tvItemLanguage == null)
            {
                AppendStatus(new AppendEventArgs(CSSPCultureServicesRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                return await Task.FromResult(false);
            }

            HttpResponseMessage response = null;
            using (HttpClient httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                response = await httpClient.GetAsync($"{ CSSPAzureUrl }api/en-CA/TVItemLanguage/GetTVItemLanguageStartDateList/{ tvItemLanguage.LastUpdateDate_UTC.Year }/{ tvItemLanguage.LastUpdateDate_UTC.Month }/{ tvItemLanguage.LastUpdateDate_UTC.Day }");
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
            }

            List<TVItemLanguage> tvItemLanguageList = JsonSerializer.Deserialize<List<TVItemLanguage>>(response.Content.ReadAsStringAsync().Result);


            foreach (TVItemLanguage tvItemLanguageChanged in tvItemLanguageList)
            {
                TVItemLanguage TVItemLanguage2 = await(from c in dbSearch.TVItemLanguages
                                                       where c.TVItemLanguageID == tvItemLanguageChanged.TVItemLanguageID
                                                       select c).FirstOrDefaultAsync();

                if (TVItemLanguage2 == null)
                {
                    dbSearch.Add(TVItemLanguage2);
                }
                else
                {
                    dbSearch.Update(TVItemLanguage2);
                }
            }

            try
            {
                await dbSearch.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguages", ex.Message)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
