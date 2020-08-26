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
    public partial interface ISearchService
    {
        Task<ActionResult<List<TVItemLanguage>>> Search(int TVItemID, string SearchTerm);
    }
    public partial class SearchService : ControllerBase, ISearchService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBSearchContext dbSearch { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public SearchService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBSearchContext dbSearch)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.dbSearch = dbSearch;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVItemLanguage>>> Search(int TVItemID, string SearchTerm)
        {
            LanguageEnum LanguageRequest = LanguageEnum.en;
            if (CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr")
            {
                LanguageRequest = LanguageEnum.fr;
            }

            SearchTerm = SearchTerm.Trim();

            if (SearchTerm == "")
                return await Task.FromResult(new List<TVItemLanguage>());

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
                return await Task.FromResult(new List<TVItemLanguage>());

            return await Task.FromResult(tvItemLanguage.Take(10).ToList());
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
