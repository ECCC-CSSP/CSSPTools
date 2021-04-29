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
        //private async Task DoAddFileUnderChildItemTest(int ParentTVItemID, WebTypeEnum webType, int ChildTVItemID, TVTypeEnum tvTypeChild, TVTypeEnum tvType, WebTypeYearEnum webTypeYear, string postTVText)
        //{
        //    await LoadWebType(ParentTVItemID, webType, WebTypeYearEnum.Year1980);

        //    List<WebBase> tvItemParentList = await GetWebBaseParentList(webType, webTypeYear);
        //    Assert.NotNull(tvItemParentList);
        //    int StartCount = 0;

        //    switch (tvTypeChild)
        //    {
        //        case TVTypeEnum.MWQMSite:
        //            {
        //                await LoadWebType(ParentTVItemID, WebTypeEnum.WebMWQMSite, WebTypeYearEnum.Year1980);

        //                MWQMSiteModel mwqmSiteModel = ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList.Where(c => c.MWQMSite.MWQMSiteTVItemID == ChildTVItemID).FirstOrDefault();
        //                Assert.NotNull(mwqmSiteModel);

        //                StartCount = mwqmSiteModel.TVItemFileList.Count;

        //                tvItemParentList.Add(mwqmSiteModel);
        //            }
        //            break;
        //        case TVTypeEnum.PolSourceSite:
        //            {
        //                await LoadWebType(ParentTVItemID, WebTypeEnum.WebPolSourceSite, WebTypeYearEnum.Year1980);

        //                PolSourceSiteModel polSourceSiteModel = ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList.Where(c => c.PolSourceSite.PolSourceSiteTVItemID == ChildTVItemID).FirstOrDefault();
        //                Assert.NotNull(polSourceSiteModel);

        //                StartCount = polSourceSiteModel.TVItemFileList.Count;

        //                tvItemParentList.Add(polSourceSiteModel);
        //            }
        //            break;
        //        case TVTypeEnum.Infrastructure:
        //            {
        //                await LoadWebType(ParentTVItemID, WebTypeEnum.WebInfrastructure, WebTypeYearEnum.Year1980);

        //                InfrastructureModel infrastructureModel = ReadGzFileService.webAppLoaded.WebInfrastructures.InfrastructureModelList.Where(c => c.Infrastructure.InfrastructureTVItemID == ChildTVItemID).FirstOrDefault();
        //                Assert.NotNull(infrastructureModel);

        //                StartCount = infrastructureModel.TVItemFileList.Count;

        //                tvItemParentList.Add(infrastructureModel);
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    string TVTextEN = $"New item {postTVText}";
        //    string TVTextFR = $"Nouveau item {postTVText}";
        //    PostTVItemModel postTVItemModel = FillPostTVItemModelForAdd(tvItemParentList, TVTextEN, TVTextFR, tvType);

        //    await TestAddOrModify(postTVItemModel);

        //    await LoadWebType(ParentTVItemID, webType, WebTypeYearEnum.Year1980);

        //    tvItemParentList = await GetWebBaseParentList(webType, webTypeYear);
        //    Assert.NotNull(tvItemParentList);

        //    switch (tvTypeChild)
        //    {
        //        case TVTypeEnum.MWQMSite:
        //            {
        //                await LoadWebType(ParentTVItemID, WebTypeEnum.WebMWQMSite, WebTypeYearEnum.Year1980);

        //                MWQMSiteModel mwqmSiteModel = ReadGzFileService.webAppLoaded.WebMWQMSites.MWQMSiteModelList.Where(c => c.MWQMSite.MWQMSiteTVItemID == ChildTVItemID).FirstOrDefault();
        //                Assert.NotNull(mwqmSiteModel);

        //                int EndCount = mwqmSiteModel.TVItemFileList.Count;
        //                Assert.Equal(StartCount + 1, EndCount);

        //                tvItemParentList.Add(mwqmSiteModel);

        //                CompareWebItem(postTVItemModel, mwqmSiteModel.TVItemFileList[EndCount - 1]);
        //            }
        //            break;
        //        case TVTypeEnum.PolSourceSite:
        //            {
        //                await LoadWebType(ParentTVItemID, WebTypeEnum.WebPolSourceSite, WebTypeYearEnum.Year1980);

        //                PolSourceSiteModel polSourceSiteModel = ReadGzFileService.webAppLoaded.WebPolSourceSites.PolSourceSiteModelList.Where(c => c.PolSourceSite.PolSourceSiteTVItemID == ChildTVItemID).FirstOrDefault();
        //                Assert.NotNull(polSourceSiteModel);

        //                int EndCount = polSourceSiteModel.TVItemFileList.Count;
        //                Assert.Equal(StartCount + 1, EndCount);

        //                tvItemParentList.Add(polSourceSiteModel);

        //                CompareWebItem(postTVItemModel, polSourceSiteModel.TVItemFileList[EndCount - 1]);
        //            }
        //            break;
        //        case TVTypeEnum.Infrastructure:
        //            {
        //                await LoadWebType(ParentTVItemID, WebTypeEnum.WebMunicipality, WebTypeYearEnum.Year1980);

        //                InfrastructureModel infrastructureModel = ReadGzFileService.webAppLoaded.WebInfrastructures.InfrastructureModelList.Where(c => c.Infrastructure.InfrastructureTVItemID == ChildTVItemID).FirstOrDefault();
        //                Assert.NotNull(infrastructureModel);

        //                int EndCount = infrastructureModel.TVItemFileList.Count;
        //                Assert.Equal(StartCount + 1, EndCount);

        //                tvItemParentList.Add(infrastructureModel);

        //                CompareWebItem(postTVItemModel, infrastructureModel.TVItemFileList[EndCount - 1]);
        //            }
        //            break;
        //        default:
        //            break;
        //    }

        //    CompareTVItemParentListInDB(tvItemParentList);

        //    string ParentTVPath = tvItemParentList[tvItemParentList.Count - 1].TVItemModel.TVItem.TVPath;
        //    bool ParentIsActive = tvItemParentList[tvItemParentList.Count - 1].TVItemModel.TVItem.IsActive;

        //    int TVLevelNew = tvItemParentList[tvItemParentList.Count - 1].TVItemModel.TVItem.TVLevel + 1;

        //    CompareTVItemAddInDB(-1, DBCommandEnum.Created, TVLevelNew, $"{ ParentTVPath }p-1", tvType, ChildTVItemID, ParentIsActive);
        //    CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, TVTextEN, TranslationStatusEnum.Translated);
        //    CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, TVTextFR, TranslationStatusEnum.Translated);
        //}
    }
}
