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
    public partial interface ITVItemUserAuthorizationService
    {
        Task<ActionResult<List<TVItemUserAuthorization>>> GetTVItemUserAuthorizationWithContactTVItemID(int ContactTVItemID);
    }
    public partial class TVItemUserAuthorizationService : ControllerBase, ITVItemUserAuthorizationService
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
                return await Task.FromResult(Unauthorized());
            }

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in dbIM.TVItemUserAuthorizations.AsNoTracking()
                                                                             where c.ContactTVItemID == ContactTVItemID
                                                                             select c).ToList();

                return await Task.FromResult(Ok(tvItemUserAuthorizationList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in dbLocal.TVItemUserAuthorizations.AsNoTracking()
                                                                             where c.ContactTVItemID == ContactTVItemID
                                                                             select c).ToList();

                return await Task.FromResult(Ok(tvItemUserAuthorizationList));
            }
            else
            {
                List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations.AsNoTracking()
                                                                             where c.ContactTVItemID == ContactTVItemID
                                                                             select c).ToList();

                return await Task.FromResult(Ok(tvItemUserAuthorizationList));
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
