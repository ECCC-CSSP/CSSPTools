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
        private void CheckCreatedTVItemAndTVItemLanguageList(TVItemModel tvItemModel, string TVTextEN, string TVTextFR)
        {
            Assert.Equal(1, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(2, (from c in dbLocal.TVItemLanguages select c).Count());

            TVItem tvItemDB = (from c in dbLocal.TVItems
                               where c.TVItemID == tvItemModel.TVItem.TVItemID
                               select c).FirstOrDefault();
            Assert.NotNull(tvItemDB);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(tvItemDB.IsActive, tvItemModel.TVItem.IsActive);
            Assert.Equal(tvItemDB.ParentID, tvItemModel.TVItem.ParentID);
            Assert.Equal(tvItemDB.TVItemID, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemDB.TVLevel, tvItemModel.TVItem.TVLevel);
            Assert.Equal(tvItemDB.TVPath, tvItemModel.TVItem.TVPath);
            Assert.Equal(tvItemDB.TVType, tvItemModel.TVItem.TVType);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, tvItemModel.TVItem.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddSeconds(-1) < tvItemModel.TVItem.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddSeconds(1) > tvItemModel.TVItem.LastUpdateDate_UTC);

            List<TVItemLanguage> tvItemLanguageListDB = (from c in dbLocal.TVItemLanguages
                                                         where c.TVItemID == tvItemModel.TVItem.TVItemID
                                                         orderby c.Language
                                                         select c).ToList();
            Assert.NotNull(tvItemLanguageListDB);
            Assert.NotEmpty(tvItemLanguageListDB);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItemLanguageList[0].DBCommand);
            Assert.Equal(LanguageEnum.en, tvItemModel.TVItemLanguageList[0].Language);
            Assert.Equal(TranslationStatusEnum.Translated, tvItemModel.TVItemLanguageList[0].TranslationStatus);
            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, tvItemModel.TVItemLanguageList[0].LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddSeconds(-1) < tvItemModel.TVItemLanguageList[0].LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddSeconds(1) > tvItemModel.TVItemLanguageList[0].LastUpdateDate_UTC);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItemLanguageList[1].DBCommand);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);
            Assert.Equal(LanguageEnum.fr, tvItemModel.TVItemLanguageList[1].Language);
            Assert.Equal(TranslationStatusEnum.Translated, tvItemModel.TVItemLanguageList[1].TranslationStatus);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, tvItemModel.TVItemLanguageList[1].LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddSeconds(-1) < tvItemModel.TVItemLanguageList[1].LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddSeconds(1) > tvItemModel.TVItemLanguageList[1].LastUpdateDate_UTC);
        }
    }
}
