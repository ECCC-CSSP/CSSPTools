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
        //private async Task CheckChildTVItemAndChildTVItemLanguageForTVTypeList(int TVItemID, int ParentTVItemID, int GrandParentTVItemID, WebTypeEnum webTypeGrandParent, TVTypeEnum tvTypeParent, TVTypeEnum tvType, DBCommandEnum dbCommand, string tvTextEN, string tvTextFR)
        //{
        //    await LoadWebType(GrandParentTVItemID, webTypeGrandParent);

        //    List<WebBase> tvItemParentList = await GetWebBaseParentList(webTypeGrandParent);
        //    Assert.NotNull(tvItemParentList);

        //    TVItem tvItemParent = new TVItem();
        //    WebBase webBaseFile = new WebBase();

        //    if (tvTypeParent == TVTypeEnum.Infrastructure)
        //    {
        //        WebBase webBaseInfrastructure = ReadGzFileService.webAppLoaded.WebInfrastructures.TVItemInfrastructureList.Where(c => c.TVItemModel.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
        //        Assert.NotNull(webBaseInfrastructure);

        //        tvItemParentList.Add(webBaseInfrastructure);

        //        InfrastructureModel infrastructureModel = ReadGzFileService.webAppLoaded.WebInfrastructures.InfrastructureModelList.Where(c => c.Infrastructure.InfrastructureTVItemID == ParentTVItemID).FirstOrDefault();
        //        Assert.NotNull(infrastructureModel);

        //        webBaseFile = infrastructureModel.TVItemFileList.Where(c => c.TVItemModel.TVItem.TVItemID == TVItemID).FirstOrDefault();
        //        Assert.NotNull(webBaseFile);

        //        tvItemParentList.Add(webBaseFile);

        //        tvItemParent = webBaseInfrastructure.TVItemModel.TVItem;
        //    }
        //    else if (tvTypeParent == TVTypeEnum.MWQMSite)
        //    {
        //        WebBase webBaseMWQMSite = ReadGzFileService.webAppLoaded.WebMWQMSites.TVItemMWQMSiteList.Where(c => c.TVItemModel.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
        //        Assert.NotNull(webBaseMWQMSite);

        //        tvItemParentList.Add(webBaseMWQMSite);

        //        MWQMSiteModel mwqmSiteModel = ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList.Where(c => c.MWQMSite.MWQMSiteTVItemID == ParentTVItemID).FirstOrDefault();
        //        Assert.NotNull(mwqmSiteModel);

        //        webBaseFile = mwqmSiteModel.TVItemFileList.Where(c => c.TVItemModel.TVItem.TVItemID == TVItemID).FirstOrDefault();
        //        Assert.NotNull(webBaseFile);

        //        tvItemParentList.Add(webBaseFile);

        //        tvItemParent = mwqmSiteModel.TVItemModel.TVItem;
        //    }
        //    else if (tvTypeParent == TVTypeEnum.PolSourceSite)
        //    {
        //        WebBase webBasePolSourceSite = ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == ParentTVItemID).FirstOrDefault();
        //        Assert.NotNull(webBasePolSourceSite);

        //        tvItemParentList.Add(webBasePolSourceSite);

        //        PolSourceSiteModel polSourceSiteModel = ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList.Where(c => c.PolSourceSite.PolSourceSiteTVItemID == ParentTVItemID).FirstOrDefault();
        //        Assert.NotNull(polSourceSiteModel);

        //        webBaseFile = polSourceSiteModel.TVItemFileList.Where(c => c.TVItemModel.TVItem.TVItemID == TVItemID).FirstOrDefault();
        //        Assert.NotNull(webBaseFile);

        //        tvItemParentList.Add(webBaseFile);

        //        tvItemParent = polSourceSiteModel.TVItemModel.TVItem;
        //    }
        //    else
        //    {
        //        Assert.True(false, $"{tvTypeParent} is not implemented in CheckChildTVItemAndChildTVItemLanguageForTVTypeList");
        //    }


        //    TVItem tvItemNew = new TVItem()
        //    {
        //        DBCommand = dbCommand,
        //        IsActive = tvItemParent.IsActive,
        //        ParentID = tvItemParent.TVItemID,
        //        TVItemID = TVItemID,
        //        TVLevel = tvItemParent.TVLevel + 1,
        //        TVPath = $"{ tvItemParent.TVPath}p{TVItemID}",
        //        TVType = tvType,
        //        LastUpdateDate_UTC = webBaseFile.TVItemModel.TVItem.LastUpdateDate_UTC,
        //        LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        //    };

        //    CompareTVItems(webBaseFile.TVItemModel.TVItem, tvItemNew);

        //    List<TVItemLanguage> tvItemLanguageListNew = new List<TVItemLanguage>()
        //    {
        //        new TVItemLanguage()
        //        {
        //             DBCommand = dbCommand,
        //             Language = LanguageEnum.en,
        //             TVItemID = TVItemID,
        //             TVItemLanguageID = TVItemID,
        //             TranslationStatus = TranslationStatusEnum.Translated,
        //             TVText = tvTextEN,
        //             LastUpdateDate_UTC = webBaseFile.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].LastUpdateDate_UTC,
        //             LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        //        },
        //        new TVItemLanguage()
        //        {
        //             DBCommand = dbCommand,
        //             Language = LanguageEnum.en,
        //             TVItemID = TVItemID,
        //             TVItemLanguageID = TVItemID,
        //             TranslationStatus = TranslationStatusEnum.Translated,
        //             TVText = tvTextEN,
        //             LastUpdateDate_UTC = webBaseFile.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].LastUpdateDate_UTC,
        //             LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        //        },
        //        new TVItemLanguage()
        //        {
        //             DBCommand = dbCommand,
        //             Language = LanguageEnum.fr,
        //             TVItemID = TVItemID,
        //             TVItemLanguageID = TVItemID - 1,
        //             TranslationStatus = TranslationStatusEnum.Translated,
        //             TVText = tvTextFR,
        //             LastUpdateDate_UTC = webBaseFile.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].LastUpdateDate_UTC,
        //             LastUpdateContactTVItemID = LoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
        //        }
        //    };

        //    CompareTVItemLanguage(webBaseFile.TVItemModel.TVItemLanguageList, tvItemLanguageListNew);
        //}
    }
}
