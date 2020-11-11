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
            WebAllTVItem webAllTVItem = null;
            WebAllTVItemLanguage webAllTVItemLanguage = null;
            int skip = 0;
            int take = 50000;

            TVItem tvItem = await (from c in dbSearch.TVItems
                                   select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                try
                {
                    #region doing WebAllTVItem
                    var actionWebAllTVItem = await ReadGzFileService.ReadJSON<WebAllTVItem>(WebTypeEnum.WebAllTVItem, 0, WebTypeYearEnum.Year1980);
                    if (((ObjectResult)actionWebAllTVItem.Result).StatusCode == 200)
                    {
                        webAllTVItem = (WebAllTVItem)((OkObjectResult)actionWebAllTVItem.Result).Value;
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                        return await Task.FromResult(false);
                    }

                    int count = 1;
                    int total = webAllTVItem.TVItemList.Count;

                    while (count > 0)
                    {
                        List<TVItem> tvItemList = webAllTVItem.TVItemList.Skip(skip).Take(take).ToList();

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
                    #endregion Doing WebAllTVItem

                    #region doing WebAllTVItemLanguage
                    var actionWebAllTVItemLanguage = await ReadGzFileService.ReadJSON<WebAllTVItemLanguage>(WebTypeEnum.WebAllTVItemLanguage, 0, WebTypeYearEnum.Year1980);
                    if (((ObjectResult)actionWebAllTVItemLanguage.Result).StatusCode == 200)
                    {
                        webAllTVItemLanguage = (WebAllTVItemLanguage)((OkObjectResult)actionWebAllTVItemLanguage.Result).Value;
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                        return await Task.FromResult(false);
                    }

                    skip = 0;
                    count = 1;
                    total = webAllTVItemLanguage.TVItemLanguageList.Count;
                    while (count > 0)
                    {
                        List<TVItemLanguage> tvItemLanguageList = webAllTVItemLanguage.TVItemLanguageList.Skip(skip).Take(take).ToList();

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
                    #endregion doing WebAllTVItemLanguage
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
