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
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPLogServices.Models;
using CSSPHelperModels;

namespace CSSPDBServices
{
    public partial interface ITVItemDBService
    {
        Task<ActionResult<List<TVItem>>> GetTVItemStartDateList(int Year, int Month, int Day);
        Task<ActionResult<TVItem>> GetTVItemRoot();
    }
    public partial class TVItemDBService : ControllerBase, ITVItemDBService
    {
        #region Variables
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResultList { get; set; }
        #endregion Variables

        #region Properties
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public TVItemDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums,
           ILoggedInService LoggedInService,
           CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;

            ValidationResultList = new List<ValidationResult>();
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVItem>>> GetTVItemStartDateList(int Year, int Month, int Day)
        {
            DateTime StartDate = new DateTime(Year, Month, Day);

            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            List<TVItem> tvItemList = await (from c in db.TVItems.AsNoTracking()
                                             where c.LastUpdateDate_UTC >= StartDate
                                             select c).ToListAsync();

            return await Task.FromResult(Ok(tvItemList));
        }
        public async Task<ActionResult<TVItem>> GetTVItemRoot()
        {
            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            TVItem tvItem = await (from c in db.TVItems.AsNoTracking()
                                   where c.TVLevel == 0
                                   select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.CouldNotFindRoot);
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(tvItem));
        }
        #endregion Functions private

    }
}
