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
    public partial interface ITVTypeUserAuthorizationService
    {
        Task<ActionResult<List<TVTypeUserAuthorization>>> GetTVTypeUserAuthorizationWithContactTVItemID(int ContactTVItemID);
    }
    public partial class TVTypeUserAuthorizationService : ControllerBase, ITVTypeUserAuthorizationService
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

            if (LoggedInService.DBLocation == DBLocationEnum.InMemory)
            {
                List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = (from c in dbIM.TVTypeUserAuthorizations.AsNoTracking()
                                                                             where c.ContactTVItemID == ContactTVItemID
                                                                             select c).ToList();

                return await Task.FromResult(Ok(TVTypeUserAuthorizationList));
            }
            else if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = (from c in dbLocal.TVTypeUserAuthorizations.AsNoTracking()
                                                                             where c.ContactTVItemID == ContactTVItemID
                                                                             select c).ToList();

                return await Task.FromResult(Ok(TVTypeUserAuthorizationList));
            }
            else
            {
                List<TVTypeUserAuthorization> TVTypeUserAuthorizationList = (from c in db.TVTypeUserAuthorizations.AsNoTracking()
                                                                             where c.ContactTVItemID == ContactTVItemID
                                                                             select c).ToList();

                return await Task.FromResult(Ok(TVTypeUserAuthorizationList));
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
