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
        #endregion Properties

        #region Constructors
        public CSSPDBSearchService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, 
            CSSPDBSearchContext dbSearch, IReadGzFileService ReadGzFileService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.dbSearch = dbSearch;
            this.ReadGzFileService = ReadGzFileService;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<bool>> FillCSSDBSearch()
        {
            WebTVItem webTVItem = null;

            var actionWebTVItem = await ReadGzFileService.ReadJSON<WebTVItem>(WebTypeEnum.WebTVItem, 0, WebTypeYearEnum.Year1980);
            if (((ObjectResult)actionWebTVItem.Result).StatusCode == 200)
            {
                webTVItem = (WebTVItem)((OkObjectResult)actionWebTVItem.Result).Value;
            }
            else
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFillCSSPDBSearchWithTVItemsAndTVItemLanguages)));
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
            WebTVItem webTVItem = null;

            var actionWebTVItem = await ReadGzFileService.ReadJSON<WebTVItem>(WebTypeEnum.WebTVItem, 0, WebTypeYearEnum.Year1980);
            if (((ObjectResult)actionWebTVItem.Result).StatusCode == 200)
            {
                webTVItem = (WebTVItem)((OkObjectResult)actionWebTVItem.Result).Value;
            }
            else
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFillCSSPDBSearchWithTVItemsAndTVItemLanguages)));
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
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
