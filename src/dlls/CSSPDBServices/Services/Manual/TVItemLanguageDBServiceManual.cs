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
using CSSPServerLoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPHelperModels;

namespace CSSPDBServices
{
    public partial interface ITVItemLanguageDBService
    {
        Task<ActionResult<List<TVItemLanguage>>> GetTVItemLanguageStartDateList(int Year, int Month, int Day);
    }
    public partial class TVItemLanguageDBService : ControllerBase, ITVItemLanguageDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
        private CSSPDBContext db { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public TVItemLanguageDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVItemLanguage>>> GetTVItemLanguageStartDateList(int Year, int Month, int Day)
        {
            DateTime StartDate = new DateTime(Year, Month, Day);

            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            List<TVItemLanguage> tvItemLanguageList = (from c in db.TVItemLanguages.AsNoTracking()
                                                       where c.LastUpdateDate_UTC >= StartDate
                                                       select c).ToList();

            return await Task.FromResult(Ok(tvItemLanguageList));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
