/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBPreferenceModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task CheckTVItemAndTVItemLanguageForAll(int TVItemID, int ParentTVItemID, WebTypeEnum webType, WebTypeEnum webTypeParent, TVTypeEnum tvType, DBCommandEnum dbCommand, string tvTextEN, string tvTextFR)
        {
            await LoadWebType(ParentTVItemID, webTypeParent);

            List<TVItemStatModel> tvItemParentList = await GetWebBaseParentList(webTypeParent);
            Assert.NotNull(tvItemParentList);

            TVItem tvItemParent = tvItemParentList[tvItemParentList.Count - 1].TVItem;
            Assert.NotNull(tvItemParent);

            await LoadWebType(TVItemID, webType);

            List<TVItemStatModel> webBaseList = await GetWebBaseList(webType, tvType, ParentTVItemID);
            Assert.True(webBaseList.Count > 0);

            TVItemModel webBaseNew = webBaseList.Where(c => c.TVItem.TVItemID == TVItemID).First();
            Assert.NotNull(webBaseNew);

            TVItem tvItem = webBaseNew.TVItem;
            List<TVItemLanguage> tvItemLanguageList = webBaseNew.TVItemLanguageList;

            TVItem tvItemNew = new TVItem()
            {
                DBCommand = dbCommand,
                IsActive = tvItemParent.IsActive,
                ParentID = tvItemParent.TVItemID,
                TVItemID = TVItemID,
                TVLevel = tvItemParent.TVLevel + 1,
                TVPath = $"{ tvItemParent.TVPath}p{TVItemID}",
                TVType = tvType,
                LastUpdateDate_UTC = tvItem.LastUpdateDate_UTC,
                LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            };

            CompareTVItems(tvItem, tvItemNew);

            List<TVItemLanguage> tvItemLanguageListNew = new List<TVItemLanguage>()
            {
                new TVItemLanguage()
                {
                     DBCommand = dbCommand,
                     Language = LanguageEnum.en,
                     TVItemID = TVItemID,
                     TVItemLanguageID = TVItemID,
                     TranslationStatus = TranslationStatusEnum.Translated,
                     TVText = tvTextEN,
                     LastUpdateDate_UTC = tvItemLanguageList[(int)LanguageEnum.en].LastUpdateDate_UTC,
                     LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                },
                new TVItemLanguage()
                {
                     DBCommand = dbCommand,
                     Language = LanguageEnum.en,
                     TVItemID = TVItemID,
                     TVItemLanguageID = TVItemID,
                     TranslationStatus = TranslationStatusEnum.Translated,
                     TVText = tvTextEN,
                     LastUpdateDate_UTC = tvItemLanguageList[(int)LanguageEnum.en].LastUpdateDate_UTC,
                     LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                },
                new TVItemLanguage()
                {
                     DBCommand = dbCommand,
                     Language = LanguageEnum.en,
                     TVItemID = TVItemID,
                     TVItemLanguageID = TVItemID,
                     TranslationStatus = TranslationStatusEnum.Translated,
                     TVText = tvTextEN,
                     LastUpdateDate_UTC = tvItemLanguageList[(int)LanguageEnum.fr].LastUpdateDate_UTC,
                     LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                },
            };

            CompareTVItemLanguage(tvItemLanguageList, tvItemLanguageListNew);
        }
    }
}
