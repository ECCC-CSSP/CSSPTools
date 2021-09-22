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
using CSSPHelperModels;

namespace CSSPDBServices
{
    public partial interface ITVItemUserAuthorizationDBService
    {
        Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationWithContactTVItemID(int ContactTVItemID);
    }
    public partial class TVItemUserAuthorizationDBService : ControllerBase, ITVItemUserAuthorizationDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private IEnums enums { get; }
        private ILoggedInService LoggedInService { get; }
        private CSSPDBContext db { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationDBService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.LoggedInService = LoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationWithContactTVItemID(int ContactTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations.AsNoTracking()
                                                                         where c.ContactTVItemID == ContactTVItemID
                                                                         select c).ToList();

            return await Task.FromResult(Ok(tvItemUserAuthorizationList));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
