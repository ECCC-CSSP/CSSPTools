///* 
// *  Manually Edited
// *  
// */

//using CSSPCultureServices.Resources;
//using CSSPDBModels;
//using CSSPEnums;
//using CSSPHelperModels;
//using CSSPWebModels;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace CSSPDBLocalServices.Tests
//{
//    public partial class TVItemLocalServiceTest
//    {
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task MWQMSite_AddTVItemLocal_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            await LoadWebType(635, WebTypeEnum.WebSubsector);
//            Assert.NotNull(webSubsector);

//            List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;
//            Assert.NotNull(tvItemModelParentList);

//            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//            Assert.NotNull(tvItemModelParent);

//            string TVTextEN = "New item";
//            string TVTextFR = "Nouveau item";

//            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.MWQMSite, TVTextEN, TVTextFR);

//            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
//            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//            Assert.True(boolRet);

//            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//            Assert.NotNull(toRecreateList);
//            Assert.NotEmpty(toRecreateList);
//            Assert.Equal(2, toRecreateList.Count);
//            Assert.Equal(635, toRecreateList[0].TVItemID);
//            Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[0].WebType);
//            Assert.Equal(635, toRecreateList[1].TVItemID);
//            Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[1].WebType);

//            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//            Assert.True(di.Exists);
//            List<FileInfo> fiList = di.GetFiles().ToList();
//            Assert.Equal(2, fiList.Count);

//            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ 635 }.gz");
//            Assert.True(fi.Exists);

//            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ 635 }.gz");
//            Assert.True(fi.Exists);

//            await LoadWebType(635, WebTypeEnum.WebMWQMSites);

//            MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
//                && c.TVItemModel.TVItem.TVType == TVTypeEnum.MWQMSite).FirstOrDefault();
//            Assert.NotNull(mwqmSiteModel);

//            Assert.Equal(DBCommandEnum.Created, mwqmSiteModel.TVItemModel.TVItem.DBCommand);
//            Assert.Equal(-1, mwqmSiteModel.TVItemModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, mwqmSiteModel.TVItemModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, mwqmSiteModel.TVItemModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, mwqmSiteModel.TVItemModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, mwqmSiteModel.TVItemModel.TVItemLanguageList[1].TVItemID);

//            await LoadWebType(635, WebTypeEnum.WebSubsector);

//            TVItemModel tvItemModel = webSubsector.TVItemModelMWQMSiteList.Where(c => c.TVItem.TVItemID == -1
//            && c.TVItem.TVType == TVTypeEnum.MWQMSite).FirstOrDefault();
//            Assert.NotNull(tvItemModel);

//            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
//            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task MWQMSite_DeleteTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(635, WebTypeEnum.WebSubsector);
//                Assert.NotNull(webSubsector);

//                List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);


//                Assert.True(webSubsector.TVItemModelMWQMSiteList.Count > 3);

//                TVItemModel tvItemModelMWQMSite = (from c in webSubsector.TVItemModelMWQMSiteList
//                                                   select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelMWQMSite.TVItem,
//                    TVItemLanguageList = tvItemModelMWQMSite.TVItemLanguageList,
//                    TVItemParent = tvItemModelParent.TVItem,
//                };

//                var actionPostTVItemModelRes = await TVItemLocalService.DeleteTVItemLocal(postTVItemModel);
//                Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//                Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//                var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//                Assert.True(boolRet);

//                List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//                Assert.NotNull(toRecreateList);
//                Assert.NotEmpty(toRecreateList);
//                Assert.Equal(2, toRecreateList.Count);
//                Assert.Equal(635, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[0].WebType);
//                Assert.Equal(635, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[1].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(2, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ 635 }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ 635 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(635, WebTypeEnum.WebMWQMSites);

//                MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                    && c.TVItemModel.TVItem.TVType == TVTypeEnum.MWQMSite).FirstOrDefault();
//                Assert.NotNull(mwqmSiteModel);

//                Assert.Equal(DBCommandEnum.Deleted, mwqmSiteModel.TVItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, mwqmSiteModel.TVItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, mwqmSiteModel.TVItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(635, WebTypeEnum.WebSubsector);

//                TVItemModel tvItemModel = webSubsector.TVItemModelMWQMSiteList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.MWQMSite).FirstOrDefault();
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);
//            }
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task MWQMSite_ModifyTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(635, WebTypeEnum.WebSubsector);
//                Assert.NotNull(webSubsector);

//                List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);


//                Assert.True(webSubsector.TVItemModelMWQMSiteList.Count > 3);

//                TVItemModel tvItemModelMWQMSite = (from c in webSubsector.TVItemModelMWQMSiteList
//                                                   select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelMWQMSite.TVItem,
//                    TVItemLanguageList = tvItemModelMWQMSite.TVItemLanguageList,
//                    TVItemParent = tvItemModelParent.TVItem,
//                };

//                postTVItemModel.TVItemLanguageList[0].TVText = postTVItemModel.TVItemLanguageList[0].TVText + "Modify";
//                postTVItemModel.TVItemLanguageList[1].TVText = postTVItemModel.TVItemLanguageList[1].TVText + "Modify";

//                var actionPostTVItemModelRes = await TVItemLocalService.ModifyTVItemLocal(postTVItemModel);
//                Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//                Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//                var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//                Assert.True(boolRet);

//                List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//                Assert.NotNull(toRecreateList);
//                Assert.NotEmpty(toRecreateList);
//                Assert.Equal(2, toRecreateList.Count);
//                Assert.Equal(635, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMWQMSites, toRecreateList[0].WebType);
//                Assert.Equal(635, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebSubsector, toRecreateList[1].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(2, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMWQMSites }_{ 635 }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebSubsector }_{ 635 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(635, WebTypeEnum.WebMWQMSites);

//                MWQMSiteModel mwqmSiteModel = webMWQMSites.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                    && c.TVItemModel.TVItem.TVType == TVTypeEnum.MWQMSite).FirstOrDefault();
//                Assert.NotNull(mwqmSiteModel);

//                Assert.Equal(DBCommandEnum.Modified, mwqmSiteModel.TVItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, mwqmSiteModel.TVItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, mwqmSiteModel.TVItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, mwqmSiteModel.TVItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(635, WebTypeEnum.WebSubsector);

//                TVItemModel tvItemModel = webSubsector.TVItemModelMWQMSiteList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.MWQMSite).FirstOrDefault();
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);
//            }
//        }
//    }
//}
