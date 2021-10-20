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
        private async Task<TVItemLanguage> AddAddressTVItemLanguageLocal(TVItem tvItem, LanguageEnum language, string TVText)
        {
            int TVItemLanguageIDNew = (from c in dbLocal.TVItemLanguages
                                       where c.TVItemLanguageID < 0
                                       orderby c.TVItemLanguageID descending
                                       select c.TVItemLanguageID).FirstOrDefault() - 1;

            TVItemLanguage tvItemLanguageNew = new TVItemLanguage()
            {
                DBCommand = DBCommandEnum.Created,
                Language = language,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                TranslationStatus = TranslationStatusEnum.Translated,
                TVItemID = tvItem.TVItemID,
                TVItemLanguageID = TVItemLanguageIDNew,
                TVText = TVText,
            };

            try
            {
                dbLocal.TVItemLanguages.Add(tvItemLanguageNew);
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotAdd_Error_, "TVItemLanguageEN_Address", ex.Message));
                return null;
            }

            return await Task.FromResult(tvItemLanguageNew);
        }
    }
}

