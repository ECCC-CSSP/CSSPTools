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
        public async Task RainExceedance_AddTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            await LoadWebType(5, WebTypeEnum.WebCountry);
            Assert.NotNull(webCountry);

            List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;
            Assert.NotNull(tvItemModelParentList);

            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
            Assert.NotNull(tvItemModelParent);

            string TVTextEN = "New item";
            string TVTextFR = "Nouveau item";

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.RainExceedance, TVTextEN, TVTextFR);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(5, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(5, WebTypeEnum.WebCountry);

            Assert.True(webCountry.RainExceedanceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.RainExceedance).Any());

            RainExceedanceModel rainExceedanceModel = webCountry.RainExceedanceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
                    && c.TVItemModel.TVItem.TVType == TVTypeEnum.RainExceedance).FirstOrDefault();
            Assert.NotNull(rainExceedanceModel);

            Assert.Equal(DBCommandEnum.Created, rainExceedanceModel.TVItemModel.TVItem.DBCommand);
            Assert.Equal(-1, rainExceedanceModel.TVItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, rainExceedanceModel.TVItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, rainExceedanceModel.TVItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, rainExceedanceModel.TVItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, rainExceedanceModel.TVItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, rainExceedanceModel.TVItemModel.TVItemLanguageList[1].TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RainExceedance_DeleteTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(5, WebTypeEnum.WebCountry);
                Assert.NotNull(webCountry);

                List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webCountry.TVItemModelProvinceList.Count > 3);

                RainExceedanceModel rainExceedanceModelRand = (from c in webCountry.RainExceedanceModelList
                                                           select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = rainExceedanceModelRand.TVItemModel.TVItem,
                    TVItemLanguageList = rainExceedanceModelRand.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(5, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(5, WebTypeEnum.WebCountry);

                Assert.True(webCountry.RainExceedanceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.RainExceedance).Any());

                RainExceedanceModel rainExceedanceModel = webCountry.RainExceedanceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                        && c.TVItemModel.TVItem.TVType == TVTypeEnum.RainExceedance).FirstOrDefault();
                Assert.NotNull(rainExceedanceModel);

                TVItemModel tvItemModel = rainExceedanceModel.TVItemModel;
                Assert.Equal(postTVItemModel.TVItem.TVItemID, rainExceedanceModel.TVItemModel.TVItem.TVItemID);
                Assert.Equal(postTVItemModel.TVItem.TVType, rainExceedanceModel.TVItemModel.TVItem.TVType);

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
        public async Task RainExceedance_ModifyTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(5, WebTypeEnum.WebCountry);
                Assert.NotNull(webCountry);

                List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webCountry.TVItemModelProvinceList.Count > 3);

                RainExceedanceModel rainExceedanceModelRand = (from c in webCountry.RainExceedanceModelList
                                                               select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = rainExceedanceModelRand.TVItemModel.TVItem,
                    TVItemLanguageList = rainExceedanceModelRand.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(5, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(5, WebTypeEnum.WebCountry);

                Assert.True(webCountry.RainExceedanceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItemModel.TVItem.TVType == TVTypeEnum.RainExceedance).Any());

                RainExceedanceModel rainExceedanceModel = webCountry.RainExceedanceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                        && c.TVItemModel.TVItem.TVType == TVTypeEnum.RainExceedance).FirstOrDefault();
                Assert.NotNull(rainExceedanceModel);

                TVItemModel tvItemModel = rainExceedanceModel.TVItemModel;
                Assert.Equal(postTVItemModel.TVItem.TVItemID, rainExceedanceModel.TVItemModel.TVItem.TVItemID);
                Assert.Equal(postTVItemModel.TVItem.TVType, rainExceedanceModel.TVItemModel.TVItem.TVType);

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
