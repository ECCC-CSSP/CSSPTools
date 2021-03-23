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
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationWithContactTVItemID(int ContactTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
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
