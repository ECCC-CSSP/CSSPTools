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
    public partial interface ITVItemService
    {
        Task<ActionResult<List<TVItem>>> GetTVItemStartDateList(int Year, int Month, int Day);
        Task<ActionResult<TVItem>> GetTVItemRoot();
    }
    public partial class TVItemService : ControllerBase, ITVItemService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<TVItem>>> GetTVItemStartDateList(int Year, int Month, int Day)
        {
            DateTime StartDate = new DateTime(Year, Month, Day);

            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            List<TVItem> tvItemList = await (from c in db.TVItems.AsNoTracking()
                                             where c.LastUpdateDate_UTC >= StartDate
                                             select c).ToListAsync();

            return await Task.FromResult(Ok(tvItemList));
        }
        public async Task<ActionResult<TVItem>> GetTVItemRoot()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            TVItem tvItem = await (from c in db.TVItems.AsNoTracking()
                                   where c.TVLevel == 0
                                   select c).FirstOrDefaultAsync();

            if (tvItem == null)
            {
                return await Task.FromResult(BadRequest(CSSPCultureServicesRes.CouldNotFindRoot));
            }

            return await Task.FromResult(Ok(tvItem));
        }
        #endregion Functions private

    }
}
