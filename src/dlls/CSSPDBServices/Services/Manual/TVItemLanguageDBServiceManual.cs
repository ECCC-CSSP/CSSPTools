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
   public partial interface ITVItemLanguageDBService
    {
       Task<ActionResult<List<TVItemLanguage>>> GetTVItemLanguageStartDateList(int Year, int Month, int Day);
    }
    public partial class TVItemLanguageDBService : ControllerBase, ITVItemLanguageDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVItemLanguage>>> GetTVItemLanguageStartDateList(int Year, int Month, int Day)
        {
            DateTime StartDate = new DateTime(Year, Month, Day);

            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
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
