/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPReadGzFileServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ManageServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
    {
        private void CheckTVItemLanguage(TVItemModel tvItemModel, DBCommandEnum dbCommand, string TVText, LanguageEnum language)
        {
            TVItemLanguage tvItemLanguageDB = (from c in dbLocal.TVItemLanguages
                                               where c.TVItemID == tvItemModel.TVItem.TVItemID
                                               && c.Language == language
                                               select c).FirstOrDefault();
            Assert.NotNull(tvItemLanguageDB);

            int index = language == LanguageEnum.fr ? 1 : 0;

            Assert.Equal(dbCommand, tvItemModel.TVItemLanguageList[index].DBCommand);
            Assert.Equal(tvItemLanguageDB.DBCommand, tvItemModel.TVItemLanguageList[index].DBCommand);
            Assert.Equal(tvItemLanguageDB.Language, tvItemModel.TVItemLanguageList[index].Language);
            Assert.Equal(tvItemLanguageDB.TranslationStatus, tvItemModel.TVItemLanguageList[index].TranslationStatus);
            Assert.Equal(tvItemLanguageDB.TVText, tvItemModel.TVItemLanguageList[index].TVText);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, tvItemModel.TVItemLanguageList[index].LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddMinutes(-1) < tvItemModel.TVItemLanguageList[index].LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddMinutes(1) > tvItemModel.TVItemLanguageList[index].LastUpdateDate_UTC);
        }
    }
}
