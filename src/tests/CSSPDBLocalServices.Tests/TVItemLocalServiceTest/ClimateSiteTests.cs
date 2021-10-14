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
        public async Task ClimateSite_AddTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            await LoadWebType(7, WebTypeEnum.WebClimateSites);
            Assert.NotNull(webClimateSites);

            List<TVItemModel> tvItemModelParentList = webClimateSites.TVItemModelParentList;
            Assert.NotNull(tvItemModelParentList);

            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
            Assert.NotNull(tvItemModelParent);

            string TVTextEN = "New item";
            string TVTextFR = "Nouveau item";

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.ClimateSite, TVTextEN, TVTextFR);

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
            Assert.Equal(WebTypeEnum.WebClimateSites, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebClimateSites }_{ 7 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(7, WebTypeEnum.WebClimateSites);

            Assert.True(webClimateSites.ClimateSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.ClimateSite).Any());

            ClimateSiteModel climateSiteModel = webClimateSites.ClimateSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.ClimateSite).FirstOrDefault();
            Assert.NotNull(climateSiteModel);

            Assert.Equal(DBCommandEnum.Created, climateSiteModel.TVItemModel.TVItem.DBCommand);
            Assert.Equal(-1, climateSiteModel.TVItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, climateSiteModel.TVItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, climateSiteModel.TVItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, climateSiteModel.TVItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, climateSiteModel.TVItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, climateSiteModel.TVItemModel.TVItemLanguageList[1].TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ClimateSite_DeleteTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {

                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(7, WebTypeEnum.WebClimateSites);
                Assert.NotNull(webClimateSites);

                List<TVItemModel> tvItemModelParentList = webClimateSites.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                ClimateSiteModel climateSiteModelToDelete = (from c in webClimateSites.ClimateSiteModelList
                                                             select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = climateSiteModelToDelete.TVItemModel.TVItem,
                    TVItemLanguageList = climateSiteModelToDelete.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(WebTypeEnum.WebClimateSites, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebClimateSites }_{ 7 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(7, WebTypeEnum.WebClimateSites);

                Assert.True(webClimateSites.ClimateSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.ClimateSite).Any());

                ClimateSiteModel climateSiteModel = webClimateSites.ClimateSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.ClimateSite).FirstOrDefault();
                Assert.NotNull(climateSiteModelToDelete);

                Assert.Equal(DBCommandEnum.Deleted, climateSiteModelToDelete.TVItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, climateSiteModelToDelete.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, climateSiteModelToDelete.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, climateSiteModelToDelete.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, climateSiteModelToDelete.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, climateSiteModelToDelete.TVItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, climateSiteModelToDelete.TVItemModel.TVItemLanguageList[1].TVText);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ClimateSite_ModifyTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {

                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(7, WebTypeEnum.WebClimateSites);
                Assert.NotNull(webClimateSites);

                List<TVItemModel> tvItemModelParentList = webClimateSites.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                ClimateSiteModel climateSiteModelToDelete = (from c in webClimateSites.ClimateSiteModelList
                                                             select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = climateSiteModelToDelete.TVItemModel.TVItem,
                    TVItemLanguageList = climateSiteModelToDelete.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(WebTypeEnum.WebClimateSites, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebClimateSites }_{ 7 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(7, WebTypeEnum.WebClimateSites);

                Assert.True(webClimateSites.ClimateSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.ClimateSite).Any());

                ClimateSiteModel climateSiteModel = webClimateSites.ClimateSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.ClimateSite).FirstOrDefault();
                Assert.NotNull(climateSiteModelToDelete);

                Assert.Equal(DBCommandEnum.Modified, climateSiteModelToDelete.TVItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, climateSiteModelToDelete.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, climateSiteModelToDelete.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, climateSiteModelToDelete.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, climateSiteModelToDelete.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, climateSiteModelToDelete.TVItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, climateSiteModelToDelete.TVItemModel.TVItemLanguageList[1].TVText);
            }
        }
    }
}
