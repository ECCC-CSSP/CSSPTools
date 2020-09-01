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
                        AppendStatus(new AppendEventArgs(CSSPCultureServicesRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages));
                        return await Task.FromResult(false);
                    }

                    await dbSearch.TVItems.AddRangeAsync(webTVItem.TVItemList);

                    try
                    {
                        await dbSearch.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "WebTVItem.TVItems", ex.Message)));
                        return await Task.FromResult(false);
                    }

                    await dbSearch.TVItemLanguages.AddRangeAsync(webTVItem.TVItemLanguageList);

                    try
                    {
                        await dbSearch.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "WebTVItem.TVItemLanguages", ex.Message)));
                        return await Task.FromResult(false);
                    }
                }
                catch (Exception ex)
                {
                    AppendStatus(new AppendEventArgs(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
                    return await Task.FromResult(false);
                }
            }

            return await Task.FromResult(true);
        }
    }
}
