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
        public async Task Country_AddTVItemLocal_Good_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            await LoadWebType(1, WebTypeEnum.WebRoot);
            Assert.NotNull(webRoot);

            List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
            Assert.NotNull(tvItemModelParentList);

            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
            Assert.NotNull(tvItemModelParent);

            string TVTextEN = "New item";
            string TVTextFR = "Nouveau item";

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.Country, TVTextEN, TVTextFR);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Equal(3, toRecreateList.Count);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllCountries, toRecreateList[0].WebType);
            Assert.Equal(-1, toRecreateList[1].TVItemID);
            Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[1].WebType);
            Assert.Equal(0, toRecreateList[2].TVItemID);
            Assert.Equal(WebTypeEnum.WebRoot, toRecreateList[2].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Equal(3, fiList.Count);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllCountries }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ -1 }.gz");
            Assert.True(fi.Exists);

            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebRoot }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(0, WebTypeEnum.WebAllCountries);

            Assert.True(webAllCountries.TVItemModelList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Country).Any());

            TVItemModel tvItemModel = webAllCountries.TVItemModelList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Country).FirstOrDefault();
            Assert.NotNull(tvItemModel);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

            await LoadWebType(-1, WebTypeEnum.WebCountry);

            Assert.True(webCountry.TVItemModel.TVItem.TVItemID == -1);

            tvItemModel = webCountry.TVItemModel;
            Assert.NotNull(tvItemModel);

            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

            await LoadWebType(0, WebTypeEnum.WebRoot);

            Assert.True(webRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Country).Any());

            tvItemModel = webRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == -1
            && c.TVItem.TVType == TVTypeEnum.Country).FirstOrDefault();
            Assert.NotNull(tvItemModel);

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
        public async Task Country_DeleteTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 1 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(1, WebTypeEnum.WebRoot);
                Assert.NotNull(webRoot);

                List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webRoot.TVItemModelCountryList.Count > 1);

                TVItemModel tvItemModelCountry = (from c in webRoot.TVItemModelCountryList
                                                  select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = tvItemModelCountry.TVItem,
                    TVItemLanguageList = tvItemModelCountry.TVItemLanguageList,
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
                Assert.Equal(3, toRecreateList.Count);
                Assert.Equal(0, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebAllCountries, toRecreateList[0].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[1].TVItemID);
                Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[1].WebType);
                Assert.Equal(0, toRecreateList[2].TVItemID);
                Assert.Equal(WebTypeEnum.WebRoot, toRecreateList[2].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Equal(3, fiList.Count);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllCountries }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebRoot }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(0, WebTypeEnum.WebAllCountries);

                Assert.True(webAllCountries.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Country).Any());

                TVItemModel tvItemModel = webAllCountries.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Country).FirstOrDefault();
                Assert.NotNull(tvItemModel);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebCountry);

                Assert.True(webCountry.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID);

                tvItemModel = webCountry.TVItemModel;
                Assert.NotNull(tvItemModel);

                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(0, WebTypeEnum.WebRoot);

                Assert.True(webRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Country).Any());

                tvItemModel = webRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Country).FirstOrDefault();
                Assert.NotNull(tvItemModel);

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
        public async Task Country_ModifyTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 1 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(1, WebTypeEnum.WebRoot);
                Assert.NotNull(webRoot);

                List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webRoot.TVItemModelCountryList.Count > 1);

                TVItemModel tvItemModelCountry = (from c in webRoot.TVItemModelCountryList
                                                  select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = tvItemModelCountry.TVItem,
                    TVItemLanguageList = tvItemModelCountry.TVItemLanguageList,
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
                Assert.Equal(3, toRecreateList.Count);
                Assert.Equal(0, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebAllCountries, toRecreateList[0].WebType);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[1].TVItemID);
                Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[1].WebType);
                Assert.Equal(0, toRecreateList[2].TVItemID);
                Assert.Equal(WebTypeEnum.WebRoot, toRecreateList[2].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Equal(3, fiList.Count);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllCountries }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ postTVItemModel.TVItem.TVItemID }.gz");
                Assert.True(fi.Exists);

                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebRoot }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(0, WebTypeEnum.WebAllCountries);

                Assert.True(webAllCountries.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Country).Any());

                TVItemModel tvItemModel = webAllCountries.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Country).FirstOrDefault();
                Assert.NotNull(tvItemModel);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebCountry);

                Assert.True(webCountry.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID);

                tvItemModel = webCountry.TVItemModel;
                Assert.NotNull(tvItemModel);

                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

                await LoadWebType(0, WebTypeEnum.WebRoot);

                Assert.True(webRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Country).Any());

                tvItemModel = webRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                && c.TVItem.TVType == TVTypeEnum.Country).FirstOrDefault();
                Assert.NotNull(tvItemModel);

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
