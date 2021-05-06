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
using CSSPWebModels;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoFillCSSPDBSearch()
        {
            WebAllTVItems webAllTVItems = null;
            WebAllTVItemLanguages webAllTVItemLanguages = null;
            int skip = 0;
            int take = 50000;

            TVItem tvItem = await (from c in dbSearch.TVItems
                                   select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                try
                {
                    #region doing WebAllTVItems1980_2020 and WebAllTVItems2021_2060
                    var actionWebAllTVItems = await ReadGzFileService.ReadJSON<WebAllTVItems>(WebTypeEnum.WebAllTVItems1980_2020, 0);
                    if (((ObjectResult)actionWebAllTVItems.Result).StatusCode == 200)
                    {
                        webAllTVItems = (WebAllTVItems)((OkObjectResult)actionWebAllTVItems.Result).Value;
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                        return await Task.FromResult(false);
                    }

                    actionWebAllTVItems = await ReadGzFileService.ReadJSON<WebAllTVItems>(WebTypeEnum.WebAllTVItems2021_2060, 0);
                    if (((ObjectResult)actionWebAllTVItems.Result).StatusCode == 200)
                    {
                        var webAllTVItems2 = (WebAllTVItems)((OkObjectResult)actionWebAllTVItems.Result).Value;

                        webAllTVItems.TVItemList.AddRange(webAllTVItems2.TVItemList);
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                        return await Task.FromResult(false);
                    }

                    int count = 1;
                    int total = webAllTVItems.TVItemList.Count;

                    while (count > 0)
                    {
                        List<TVItem> tvItemList = webAllTVItems.TVItemList.Skip(skip).Take(take).ToList();

                        count = tvItemList.Count;

                        if (tvItemList.Count == 0)
                        {
                            break;
                        }

                        skip += take;

                        await dbSearch.TVItems.AddRangeAsync(tvItemList);

                        try
                        {
                            await dbSearch.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "WebTVItem.TVItems", ex.Message)));
                            return await Task.FromResult(false);
                        }

                        if (count < take)
                        {
                            AppendStatus(new AppendEventArgs($"{ string.Format(CSSPCultureDesktopRes.Done) } TVItems ({ total }/{ total })"));
                        }
                        else
                        {
                            AppendStatus(new AppendEventArgs($"{ string.Format(CSSPCultureDesktopRes.Done) } TVItems ({ skip }/{ total })"));
                        }

                        InstallingStatus(new InstallingEventArgs(25 + (30 * skip/ total)));

                    }
                    #endregion Doing WebAllTVItems1980_2020 and WebAllTVItems2021_2060

                    #region doing WebAllTVItemLanguage1980_2020 and WebAllTVItemLanguage2021_2060
                    var actionWebAllTVItemLanguages = await ReadGzFileService.ReadJSON<WebAllTVItemLanguages>(WebTypeEnum.WebAllTVItemLanguages1980_2020, 0);
                    if (((ObjectResult)actionWebAllTVItemLanguages.Result).StatusCode == 200)
                    {
                        webAllTVItemLanguages = (WebAllTVItemLanguages)((OkObjectResult)actionWebAllTVItemLanguages.Result).Value;
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                        return await Task.FromResult(false);
                    }

                    actionWebAllTVItemLanguages = await ReadGzFileService.ReadJSON<WebAllTVItemLanguages>(WebTypeEnum.WebAllTVItemLanguages2021_2060, 0);
                    if (((ObjectResult)actionWebAllTVItemLanguages.Result).StatusCode == 200)
                    {
                        var webAllTVItemLanguages2 = (WebAllTVItemLanguages)((OkObjectResult)actionWebAllTVItemLanguages.Result).Value;
                        webAllTVItemLanguages.TVItemLanguageList.AddRange(webAllTVItemLanguages2.TVItemLanguageList);
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                        return await Task.FromResult(false);
                    }


                    skip = 0;
                    count = 1;
                    total = webAllTVItemLanguages.TVItemLanguageList.Count;
                    while (count > 0)
                    {
                        List<TVItemLanguage> tvItemLanguageList = webAllTVItemLanguages.TVItemLanguageList.Skip(skip).Take(take).ToList();

                        count = tvItemLanguageList.Count;

                        if (tvItemLanguageList.Count == 0)
                        {
                            break;
                        }

                        skip += take;

                        await dbSearch.TVItemLanguages.AddRangeAsync(tvItemLanguageList);

                        try
                        {
                            await dbSearch.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.CouldNotAdd_Error_, "WebTVItem.TVItemLanguages", ex.Message)));
                            return await Task.FromResult(false);
                        }

                        if (count < take)
                        {
                            AppendStatus(new AppendEventArgs($"{ string.Format(CSSPCultureDesktopRes.Done) } TVItemLanguages ({ total }/{ total })"));
                        }
                        else
                        {
                            AppendStatus(new AppendEventArgs($"{ string.Format(CSSPCultureDesktopRes.Done) } TVItemLanguages ({ skip }/{ total })"));
                        }

                        InstallingStatus(new InstallingEventArgs(50 + (40 * skip / total)));
                    }
                    #endregion doing WebAllTVItemLanguage1980_2020 and WebAllTVItemLanguage2021_2060
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.UnmanagedServerError_, ex.Message)));
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
    }
}
