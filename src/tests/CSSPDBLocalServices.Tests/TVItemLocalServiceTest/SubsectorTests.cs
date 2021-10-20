/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Subsector_AddTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            await LoadWebType(633, WebTypeEnum.WebSector);
            Assert.NotNull(webSector);

            List<TVItemModel> tvItemModelParentList = webSector.TVItemModelParentList;
            Assert.NotNull(tvItemModelParentList);

            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
            Assert.NotNull(tvItemModelParent);

            string TVTextEN = "New item";
            string TVTextFR = "Nouveau item";

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.Subsector, TVTextEN, TVTextFR);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Equal(7, toRecreateList.Count);
            Assert.Equal(633, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebSector, toRecreateList[0].WebType);
            Assert.Equal(-1, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[1].WebType);
            Assert.Equal(-1, toRecreateList[2].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMRuns, toRecreateList[2].WebType);
            Assert.Equal(-1, toRecreateList[3].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[3].WebType);
            Assert.Equal(-1, toRecreateList[4].TVItemID);
            Assert.Equal(WebTypeEnum.WebPolSourceSites, toRecreateList[4].WebType);
            Assert.Equal(-1, toRecreateList[5].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMSamples1980_2020, toRecreateList[5].WebType);
            Assert.Equal(-1, toRecreateList[6].TVItemID);
            Assert.Equal(WebTypeEnum.WebMWQMSamples2021_2060, toRecreateList[6].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(7, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSector }_{ 633 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMRuns }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebPolSourceSites }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ -1 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(633, WebTypeEnum.WebSector);

            Assert.True(webSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Subsector).Any());

            TVItemModel tvItemModel = webSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == -1
                && c.TVItem.TVType == TVTypeEnum.Subsector).FirstOrDefault();
            Assert.NotNull(tvItemModel);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

            await LoadWebType(-1, WebTypeEnum.WebSubsector);

            Assert.True(webSubsector.TVItemModel.TVItem.TVItemID == -1
            && webSubsector.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            tvItemModel = webSubsector.TVItemModel;
            Assert.NotNull(tvItemModel);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

            await LoadWebType(-1, WebTypeEnum.WebMWQMRuns);

            Assert.True(webMWQMRuns.TVItemModel.TVItem.TVItemID == -1
                && webMWQMRuns.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            tvItemModel = webMWQMRuns.TVItemModel;
            Assert.NotNull(tvItemModel);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

            await LoadWebType(-1, WebTypeEnum.WebMWQMSites);

            Assert.True(webMWQMSites.TVItemModel.TVItem.TVItemID == -1
                && webMWQMSites.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            tvItemModel = webMWQMSites.TVItemModel;
            Assert.NotNull(tvItemModel);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

            await LoadWebType(-1, WebTypeEnum.WebPolSourceSites);

            Assert.True(webPolSourceSites.TVItemModel.TVItem.TVItemID == -1
                && webPolSourceSites.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            tvItemModel = webPolSourceSites.TVItemModel;
            Assert.NotNull(tvItemModel);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

            await LoadWebType(-1, WebTypeEnum.WebMWQMSamples1980_2020);

            Assert.True(webMWQMSamples1980_2020.TVItemModel.TVItem.TVItemID == -1
                && webMWQMSamples1980_2020.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            tvItemModel = webMWQMSamples1980_2020.TVItemModel;
            Assert.NotNull(tvItemModel);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

            await LoadWebType(-1, WebTypeEnum.WebMWQMSamples2021_2060);

            Assert.True(webMWQMSamples2021_2060.TVItemModel.TVItem.TVItemID == -1
                && webMWQMSamples2021_2060.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

            tvItemModel = webMWQMSamples2021_2060.TVItemModel;
            Assert.NotNull(tvItemModel);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Subsector_DeleteTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 1 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(633, WebTypeEnum.WebSector);
                Assert.NotNull(webSector);

                List<TVItemModel> tvItemModelParentList = webSector.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webSector.TVItemModelSubsectorList.Count > 1);

                TVItemModel tvItemModelSubsector = (from c in webSector.TVItemModelSubsectorList
                                                   select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = tvItemModelSubsector.TVItem,
                    TVItemLanguageList = tvItemModelSubsector.TVItemLanguageList,
                    TVItemParent = tvItemModelParent.TVItem,
                };

                var actionPostTVItemModelRes = await TVItemLocalService.DeleteTVItemLocal(postTVItemModel);
                Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
                var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
                Assert.True(boolRet);

                List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
                Assert.NotNull(toRecreateList);
                Assert.NotEmpty(toRecreateList);
                Assert.Equal(7, toRecreateList.Count);
                Assert.Equal(633, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebSector, toRecreateList[0].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[1].TVItemID);
                Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[1].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[2].TVItemID);
                Assert.Equal(WebTypeEnum.WebMWQMRuns, toRecreateList[2].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[3].TVItemID);
                Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[3].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[4].TVItemID);
                Assert.Equal(WebTypeEnum.WebPolSourceSites, toRecreateList[4].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[5].TVItemID);
                Assert.Equal(WebTypeEnum.WebMWQMSamples1980_2020, toRecreateList[5].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[6].TVItemID);
                Assert.Equal(WebTypeEnum.WebMWQMSamples2021_2060, toRecreateList[6].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Equal(7, fiList.Count);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSector }_{ 633 }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMRuns }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebPolSourceSites }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(633, WebTypeEnum.WebSector);

                Assert.True(webSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Subsector).Any());

                TVItemModel tvItemModel = webSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && c.TVItem.TVType == TVTypeEnum.Subsector).FirstOrDefault();
                Assert.NotNull(tvItemModel);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebSubsector);

                Assert.True(webSubsector.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && webSubsector.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webSubsector.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMWQMRuns);

                Assert.True(webMWQMRuns.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webMWQMRuns.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webMWQMRuns.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMWQMSites);

                Assert.True(webMWQMSites.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webMWQMSites.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webMWQMSites.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebPolSourceSites);

                Assert.True(webPolSourceSites.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webPolSourceSites.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webPolSourceSites.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMWQMSamples1980_2020);

                Assert.True(webMWQMSamples1980_2020.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webMWQMSamples1980_2020.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webMWQMSamples1980_2020.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMWQMSamples2021_2060);

                Assert.True(webMWQMSamples2021_2060.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webMWQMSamples2021_2060.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webMWQMSamples2021_2060.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Subsector_ModifyTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 1 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(633, WebTypeEnum.WebSector);
                Assert.NotNull(webSector);

                List<TVItemModel> tvItemModelParentList = webSector.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webSector.TVItemModelSubsectorList.Count > 1);

                TVItemModel tvItemModelSubsector = (from c in webSector.TVItemModelSubsectorList
                                                    select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = tvItemModelSubsector.TVItem,
                    TVItemLanguageList = tvItemModelSubsector.TVItemLanguageList,
                    TVItemParent = tvItemModelParent.TVItem,
                };

                postTVItemModel.TVItemLanguageList[0].TVText = postTVItemModel.TVItemLanguageList[0].TVText + "Modify";
                postTVItemModel.TVItemLanguageList[1].TVText = postTVItemModel.TVItemLanguageList[1].TVText + "Modify";

                var actionPostTVItemModelRes = await TVItemLocalService.ModifyTVItemLocal(postTVItemModel);
                Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
                var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
                Assert.True(boolRet);

                List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
                Assert.NotNull(toRecreateList);
                Assert.NotEmpty(toRecreateList);
                Assert.Equal(7, toRecreateList.Count);
                Assert.Equal(633, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebSector, toRecreateList[0].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[1].TVItemID);
                Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[1].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[2].TVItemID);
                Assert.Equal(WebTypeEnum.WebMWQMRuns, toRecreateList[2].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[3].TVItemID);
                Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[3].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[4].TVItemID);
                Assert.Equal(WebTypeEnum.WebPolSourceSites, toRecreateList[4].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[5].TVItemID);
                Assert.Equal(WebTypeEnum.WebMWQMSamples1980_2020, toRecreateList[5].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[6].TVItemID);
                Assert.Equal(WebTypeEnum.WebMWQMSamples2021_2060, toRecreateList[6].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Equal(7, fiList.Count);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSector }_{ 633 }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMRuns }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebPolSourceSites }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(633, WebTypeEnum.WebSector);

                Assert.True(webSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Subsector).Any());

                TVItemModel tvItemModel = webSector.TVItemModelSubsectorList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && c.TVItem.TVType == TVTypeEnum.Subsector).FirstOrDefault();
                Assert.NotNull(tvItemModel);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebSubsector);

                Assert.True(webSubsector.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && webSubsector.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webSubsector.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMWQMRuns);

                Assert.True(webMWQMRuns.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webMWQMRuns.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webMWQMRuns.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMWQMSites);

                Assert.True(webMWQMSites.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webMWQMSites.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webMWQMSites.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebPolSourceSites);

                Assert.True(webPolSourceSites.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webPolSourceSites.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webPolSourceSites.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMWQMSamples1980_2020);

                Assert.True(webMWQMSamples1980_2020.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webMWQMSamples1980_2020.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webMWQMSamples1980_2020.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMWQMSamples2021_2060);

                Assert.True(webMWQMSamples2021_2060.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                    && webMWQMSamples2021_2060.TVItemModel.TVItem.TVType == TVTypeEnum.Subsector);

                tvItemModel = webMWQMSamples2021_2060.TVItemModel;
                Assert.NotNull(tvItemModel);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(TVTypeEnum.Subsector, tvItemModel.TVItem.TVType);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);
            }
        }
    }
}
