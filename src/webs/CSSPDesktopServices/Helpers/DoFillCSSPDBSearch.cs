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

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        private async Task<bool> DoFillCSSPDBSearch()
        {
            WebTVItem webTVItem = null;
            int skip = 0;
            int take = 50000;

            TVItem tvItem = await (from c in dbSearch.TVItems
                                   select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                try
                {
                    var actionWebTVItem = await ReadGzFileService.ReadJSON<WebTVItem>(WebTypeEnum.WebTVItem, 0, WebTypeYearEnum.Year1980);
                    if (((ObjectResult)actionWebTVItem.Result).StatusCode == 200)
                    {
                        webTVItem = (WebTVItem)((OkObjectResult)actionWebTVItem.Result).Value;
                    }
                    else
                    {
                        AppendStatus(new AppendEventArgs(CSSPCultureDesktopRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                        return await Task.FromResult(false);
                    }

                    int count = 1;
                    int total = webTVItem.TVItemList.Count;

                    while (count > 0)
                    {
                        List<TVItem> tvItemList = webTVItem.TVItemList.Skip(skip).Take(take).ToList();

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
                    }

                    skip = 0;
                    count = 1;
                    total = webTVItem.TVItemLanguageList.Count;
                    while (count > 0)
                    {
                        List<TVItemLanguage> tvItemLanguageList = webTVItem.TVItemLanguageList.Skip(skip).Take(take).ToList();

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
                    }
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
