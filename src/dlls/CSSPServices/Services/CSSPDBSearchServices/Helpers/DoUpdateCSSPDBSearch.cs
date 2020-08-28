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
        private async Task<ActionResult<bool>> DoUpdateCSSDBSearch(DateTime fromDate)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.RunningOn != RunningOnEnum.Local)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._OnlyAvailableWhenRunningOnLocal, "UpdateCSSPDBSearch")));
            }

            TVItem tvItem = await (from c in dbSearch.TVItems
                                   select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                var actionFillCSSPDBSearch = await FillCSSDBSearch();
                if (((ObjectResult)actionFillCSSPDBSearch.Result).StatusCode != 200)
                {
                    return await Task.FromResult(actionFillCSSPDBSearch);
                }
            }

            // doing the update for TVItems
            tvItem = await (from c in dbSearch.TVItems
                            orderby c.LastUpdateDate_UTC descending
                            select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages)));
            }

            var actionTVItem = await TVItemService.GetTVItemStartDateList(tvItem.LastUpdateDate_UTC);
            if (((ObjectResult)actionTVItem.Result).StatusCode != 200)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_, "TVItem")));
            }

            List<TVItem> tvItemList = (List<TVItem>)((OkObjectResult)actionTVItem.Result).Value;

            foreach (TVItem tvItemChanged in tvItemList)
            {
                TVItem TVItem2 = await (from c in dbSearch.TVItems
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
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItems", ex.Message)));
            }

            // doing the update for TVItemLanguages
            TVItemLanguage tvItemLanguage = await (from c in dbSearch.TVItemLanguages
                                                   orderby c.LastUpdateDate_UTC descending
                                                   select c).FirstOrDefaultAsync();

            if (tvItemLanguage == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotUpdateCSSPDBSearchWithTVItemsAndTVItemLanguages)));
            }

            var actionTVItemLanguage = await TVItemLanguageService.GetTVItemLanguageStartDateList(tvItem.LastUpdateDate_UTC);
            if (((ObjectResult)actionTVItemLanguage.Result).StatusCode != 200)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_, "TVItemLanguage")));
            }

            List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguage.Result).Value;

            foreach (TVItemLanguage tvItemLanguageChanged in tvItemLanguageList)
            {
                TVItemLanguage TVItemLanguage2 = await (from c in dbSearch.TVItemLanguages
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
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguages", ex.Message)));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
