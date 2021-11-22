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
    public partial interface ITVTypeUserAuthorizationDBService
    {
        Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationWithContactTVItemID(int ContactTVItemID);
    }
    public partial class TVTypeUserAuthorizationDBService : ControllerBase, ITVTypeUserAuthorizationDBService
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
        public TVTypeUserAuthorizationDBService(ICSSPCultureService CSSPCultureService, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.enums = enums;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationWithContactTVItemID(int ContactTVItemID)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations.AsNoTracking()
                                                                         where c.ContactTVItemID == ContactTVItemID
                                                                         select c).ToList();

            return await Task.FromResult(Ok(TVTypeUserAuthorizationList));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}