/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial class AddressLocalService : ControllerBase, IAddressLocalService
    {
        private async Task<TVItem> AddAddressTVItemLocal(TVItem tvItemParent)
        {
            int TVItemIDNew = (from c in dbLocal.TVItems
                               where c.TVItemID < 0
                               orderby c.TVItemID descending
                               select c.TVItemID).FirstOrDefault() - 1;

            TVItem tvItemNew = new TVItem()
            {
                DBCommand = DBCommandEnum.Created,
                IsActive = true,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                ParentID = tvItemParent.TVItemID,
                TVItemID = TVItemIDNew,
                TVLevel = tvItemParent.TVLevel + 1,
                TVPath = $"{ tvItemParent.TVPath }p{ TVItemIDNew }",
                TVType = TVTypeEnum.Address
            };

            try
            {
                dbLocal.TVItems.Add(tvItemNew);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItem_Address", ex.Message));
                return null;
            }

            return await Task.FromResult(tvItemNew);
        }
    }
}

