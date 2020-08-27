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
    public partial interface ICSSPDBSearchService
    {
        Task<ActionResult<List<TVItemLanguage>>> Search(int TVItemID, string SearchTerm);
        Task<ActionResult<bool>> FillCSSDBSearch();
        Task<ActionResult<bool>> UpdateCSSDBSearch(DateTime fromDate);
    }
    public partial class CSSPDBSearchService : ControllerBase, ICSSPDBSearchService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBSearchContext dbSearch { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IReadGzFileService ReadGzFileService { get; }
        private ITVItemService TVItemService { get; }
        private ITVItemLanguageService TVItemLanguageService { get; }
        #endregion Properties

        #region Constructors
        public CSSPDBSearchService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums,
            CSSPDBSearchContext dbSearch, IReadGzFileService ReadGzFileService, ITVItemService TVItemService, ITVItemLanguageService TVItemLanguageService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.dbSearch = dbSearch;
            this.ReadGzFileService = ReadGzFileService;
            this.TVItemService = TVItemService;
            this.TVItemLanguageService = TVItemLanguageService;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<bool>> FillCSSDBSearch()
        {
            WebTVItem webTVItem = null;

            TVItem tvItem = await (from c in dbSearch.TVItems
                                   select c).FirstOrDefaultAsync();

            if (tvItem != null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CSSPDBSearchAlreadyFilled)));
            }

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

            return await Task.FromResult(Ok(true));
        }

        public async Task<ActionResult<List<TVItemLanguage>>> Search(int TVItemID, string SearchTerm)
        {
            LanguageEnum LanguageRequest = LanguageEnum.en;
            if (CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr")
            {
                LanguageRequest = LanguageEnum.fr;
            }

            SearchTerm = SearchTerm.Trim();

            if (SearchTerm == "")
            {
                return await Task.FromResult(Ok(new List<TVItemLanguage>()));
            }

            List<string> TermList = SearchTerm.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToList();



            var tvItemLanguage = (from cl in dbSearch.TVItemLanguages
                                  where cl.TVText.Contains(TermList[0])
                                  && cl.Language == LanguageRequest
                                  select cl);

            for (int i = 1; i < TermList.Count; i++)
            {
                tvItemLanguage = (from ct in tvItemLanguage
                                  from cl in dbSearch.TVItemLanguages
                                  where cl.TVItemID == ct.TVItemID
                                  && cl.TVText.Contains(TermList[i])
                                  && cl.Language == LanguageRequest
                                  select cl);
            }

            if (tvItemLanguage == null)
            {
                return await Task.FromResult(Ok(new List<TVItemLanguage>()));
            }

            return await Task.FromResult(Ok(tvItemLanguage.Take(10).ToList()));
        }
        public async Task<ActionResult<bool>> UpdateCSSDBSearch(DateTime fromDate)
        {
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
                    dbSearch.Update(TVItem2);
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
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
