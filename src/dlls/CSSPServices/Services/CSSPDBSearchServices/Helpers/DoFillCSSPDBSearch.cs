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

namespace CSSPServices
{
    public partial class CSSPDBSearchService : ControllerBase, ICSSPDBSearchService
    {
        private async Task<ActionResult<bool>> DoFillCSSDBSearch()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "FillCSSPDBSearch")));
            }

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
                        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages)));
                    }

                    await dbSearch.TVItems.AddRangeAsync(webTVItem.TVItemList);

                    try
                    {
                        await dbSearch.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "WebTVItem.TVItems", ex.Message)));
                    }

                    await dbSearch.TVItemLanguages.AddRangeAsync(webTVItem.TVItemLanguageList);

                    try
                    {
                        await dbSearch.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "WebTVItem.TVItemLanguages", ex.Message)));
                    }

                }
                catch (Exception ex)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
                }
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
