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
        [Theory(Skip = "TideSite does not have item in the DB yet. So this test would fail.")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TideSite_AddTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            await LoadWebType(7, WebTypeEnum.WebTideSites);
            Assert.NotNull(webTideSites);

            List<TVItemModel> tvItemModelParentList = webTideSites.TVItemModelParentList;
            Assert.NotNull(tvItemModelParentList);

            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
            Assert.NotNull(tvItemModelParent);

            string TVTextEN = "New item";
            string TVTextFR = "Nouveau item";

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.TideSite, TVTextEN, TVTextFR);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(7, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebTideSites, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebTideSites }_{ 7 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(7, WebTypeEnum.WebTideSites);

            Assert.True(webTideSites.TideSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.TideSite).Any());

            TideSiteModel tideSiteModel = webTideSites.TideSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.TideSite).FirstOrDefault();
            Assert.NotNull(tideSiteModel);

            Assert.Equal(DBCommandEnum.Created, tideSiteModel.TVItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tideSiteModel.TVItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tideSiteModel.TVItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tideSiteModel.TVItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tideSiteModel.TVItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tideSiteModel.TVItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tideSiteModel.TVItemModel.TVItemLanguageList[1].TVItemID);
        }
        [Theory(Skip = "TideSite does not have item in the DB yet. So this test would fail.")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TideSite_DeleteTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {

                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(7, WebTypeEnum.WebTideSites);
                Assert.NotNull(webTideSites);

                List<TVItemModel> tvItemModelParentList = webTideSites.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                TideSiteModel tideSiteModelToDelete = (from c in webTideSites.TideSiteModelList
                                                             select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = tideSiteModelToDelete.TVItemModel.TVItem,
                    TVItemLanguageList = tideSiteModelToDelete.TVItemModel.TVItemLanguageList,
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
                Assert.Single(toRecreateList);
                Assert.Equal(7, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebTideSites, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebTideSites }_{ 7 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(7, WebTypeEnum.WebTideSites);

                Assert.True(webTideSites.TideSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.TideSite).Any());

                TideSiteModel tideSiteModel = webTideSites.TideSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.TideSite).FirstOrDefault();
                Assert.NotNull(tideSiteModelToDelete);

                Assert.Equal(DBCommandEnum.Deleted, tideSiteModelToDelete.TVItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tideSiteModelToDelete.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tideSiteModelToDelete.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tideSiteModelToDelete.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tideSiteModelToDelete.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tideSiteModelToDelete.TVItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tideSiteModelToDelete.TVItemModel.TVItemLanguageList[1].TVText);
            }
        }
        [Theory(Skip = "TideSite does not have item in the DB yet. So this test would fail.")]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TideSite_ModifyTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {

                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(7, WebTypeEnum.WebTideSites);
                Assert.NotNull(webTideSites);

                List<TVItemModel> tvItemModelParentList = webTideSites.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                TideSiteModel tideSiteModelToDelete = (from c in webTideSites.TideSiteModelList
                                                             select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = tideSiteModelToDelete.TVItemModel.TVItem,
                    TVItemLanguageList = tideSiteModelToDelete.TVItemModel.TVItemLanguageList,
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
                Assert.Single(toRecreateList);
                Assert.Equal(7, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebTideSites, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebTideSites }_{ 7 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(7, WebTypeEnum.WebTideSites);

                Assert.True(webTideSites.TideSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.TideSite).Any());

                TideSiteModel tideSiteModel = webTideSites.TideSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.TideSite).FirstOrDefault();
                Assert.NotNull(tideSiteModelToDelete);

                Assert.Equal(DBCommandEnum.Modified, tideSiteModelToDelete.TVItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tideSiteModelToDelete.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tideSiteModelToDelete.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tideSiteModelToDelete.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tideSiteModelToDelete.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tideSiteModelToDelete.TVItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tideSiteModelToDelete.TVItemModel.TVItemLanguageList[1].TVText);
            }
        }
    }
}
