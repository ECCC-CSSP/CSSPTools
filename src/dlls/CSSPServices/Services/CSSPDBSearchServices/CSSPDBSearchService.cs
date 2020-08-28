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
        Task<ActionResult<bool>> FillCSSDBSearch();
        Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID);
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
            return await DoFillCSSDBSearch();
        }
        public async Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID)
        {
            return await DoSearch(SearchTerm, TVItemID);
        }
        public async Task<ActionResult<bool>> UpdateCSSDBSearch(DateTime fromDate)
        {
            return await DoUpdateCSSDBSearch(fromDate);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
