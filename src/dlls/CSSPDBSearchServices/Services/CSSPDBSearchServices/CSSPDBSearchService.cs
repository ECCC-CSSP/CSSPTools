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
using Microsoft.Extensions.Configuration;
using LocalServices;

namespace CSSPDBSearchServices
{
    public partial interface ICSSPDBSearchService
    {
        Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID);
    }
    public partial class CSSPDBSearchService : ControllerBase, ICSSPDBSearchService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private CSSPDBSearchContext dbSearch { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        #endregion Properties

        #region Constructors
        public CSSPDBSearchService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, ILocalService LocalService, IEnums enums,
            CSSPDBSearchContext dbSearch)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.dbSearch = dbSearch;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVItemLanguage>>> Search(string SearchTerm, int TVItemID)
        {
            return await DoSearch(SearchTerm, TVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
