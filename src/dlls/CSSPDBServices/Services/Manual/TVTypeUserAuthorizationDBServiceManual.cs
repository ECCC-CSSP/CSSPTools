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
    public partial interface ITVTypeUserAuthorizationDBService
    {
        Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationWithContactTVItemID(int ContactTVItemID);
    }
    public partial class TVTypeUserAuthorizationDBService : ControllerBase, ITVTypeUserAuthorizationDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationWithContactTVItemID(int ContactTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
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
