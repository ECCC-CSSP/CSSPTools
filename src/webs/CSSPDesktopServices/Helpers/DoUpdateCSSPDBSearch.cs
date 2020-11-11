/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
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
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            TVItem tvItem = await (from c in dbSearch.TVItems
                                   select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                if (!await FillCSSPDBSearch()) return await Task.FromResult(false);
            }

            tvItem = await (from c in dbSearch.TVItems
                            orderby c.LastUpdateDate_UTC descending
                            select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                return await Task.FromResult(false);
            }

            List<TVItem> tvItemList = new List<TVItem>();

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/TVItem/GetTVItemStartDateList/{ tvItem.LastUpdateDate_UTC.Year }/{ tvItem.LastUpdateDate_UTC.Month }/{ tvItem.LastUpdateDate_UTC.Day }").Result;
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

                tvItemList = JsonSerializer.Deserialize<List<TVItem>>(response.Content.ReadAsStringAsync().Result);
            }

            int total = tvItemList.Count;
            int count = 0;
            foreach (TVItem tvItemChanged in tvItemList)
            {
                count += 1;
                InstallingStatus(new InstallingEventArgs(90 + (9 * count / total)));

                TVItem TVItem2 = await (from c in dbSearch.TVItems
                                        where c.TVItemID == tvItemChanged.TVItemID
                                        select c).FirstOrDefaultAsync();

                if (TVItem2 == null)
                {
                    dbSearch.Add(tvItemChanged);
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
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "TVItems", ex.Message)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);

        }

        private async Task<bool> DoGetTVItemLanguages()
        {
            string culture = "fr-CA";
            if (IsEnglish)
            {
                culture = "en-CA";
            }

            TVItemLanguage tvItemLanguage = await (from c in dbSearch.TVItemLanguages
                                                   orderby c.LastUpdateDate_UTC descending
                                                   select c).FirstOrDefaultAsync();

            if (tvItemLanguage == null)
            {
                AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                return await Task.FromResult(false);
            }

            List<TVItemLanguage> tvItemLanguageList = new List<TVItemLanguage>();

            using (HttpClient httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", contact.Token);
                HttpResponseMessage response = httpClient.GetAsync($"{ CSSPAzureUrl }api/{ culture }/TVItemLanguage/GetTVItemLanguageStartDateList/{ tvItemLanguage.LastUpdateDate_UTC.Year }/{ tvItemLanguage.LastUpdateDate_UTC.Month }/{ tvItemLanguage.LastUpdateDate_UTC.Day }").Result;
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

                tvItemLanguageList = JsonSerializer.Deserialize<List<TVItemLanguage>>(response.Content.ReadAsStringAsync().Result);
            }



            foreach (TVItemLanguage tvItemLanguageChanged in tvItemLanguageList)
            {
                TVItemLanguage TVItemLanguage2 = await (from c in dbSearch.TVItemLanguages
                                                        where c.TVItemLanguageID == tvItemLanguageChanged.TVItemLanguageID
                                                        select c).FirstOrDefaultAsync();

                if (TVItemLanguage2 == null)
                {
                    dbSearch.Add(tvItemLanguageChanged);
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
                AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "TVItemLanguages", ex.Message)));
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
