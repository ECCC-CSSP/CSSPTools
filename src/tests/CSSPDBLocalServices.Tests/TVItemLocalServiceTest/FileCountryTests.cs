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
//        public async Task File_Country_AddTVItemLocal_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            await LoadWebType(5, WebTypeEnum.WebCountry);
//            Assert.NotNull(webCountry);

//            List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;
//            Assert.NotNull(tvItemModelParentList);

//            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//            Assert.NotNull(tvItemModelParent);

//            string TVTextEN = "New item";
//            string TVTextFR = "Nouveau item";

//            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.File, TVTextEN, TVTextFR);

//            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
//            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//            Assert.True(boolRet);

//            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//            Assert.NotNull(toRecreateList);
//            Assert.NotEmpty(toRecreateList);
//            Assert.Single(toRecreateList);
//            Assert.Equal(5, toRecreateList[0].TVItemID);
//            Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[0].WebType);

//            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//            Assert.True(di.Exists);
//            List<FileInfo> fiList = di.GetFiles().ToList();
//            Assert.Single(fiList);

//            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
//            Assert.True(fi.Exists);

//            await LoadWebType(5, WebTypeEnum.WebCountry);

//            Assert.True(webCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == -1
//            && c.TVItem.TVType == TVTypeEnum.File).Any());

//            TVFileModel tvFileModel = webCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == -1
//                && c.TVItem.TVType == TVTypeEnum.File).FirstOrDefault();
//            Assert.NotNull(tvFileModel);

//            Assert.Equal(DBCommandEnum.Created, tvFileModel.TVItem.DBCommand);
//            Assert.Equal(-1, tvFileModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvFileModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, tvFileModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, tvFileModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, tvFileModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, tvFileModel.TVItemLanguageList[1].TVItemID);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task File_Country_DeleteTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 1 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(5, WebTypeEnum.WebCountry);
//                Assert.NotNull(webCountry);

//                List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(webCountry.TVFileModelList.Count > 1);

//                TVFileModel tvItemModelNew = (from c in webCountry.TVFileModelList
//                                               select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelNew.TVItem,
//                    TVItemLanguageList = tvItemModelNew.TVItemLanguageList,
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
//                Assert.Single(toRecreateList);
//                Assert.Equal(5, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[0].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Single(fiList);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(5, WebTypeEnum.WebCountry);

//                Assert.True(webCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.File).Any());

//                TVFileModel tvFileModel = webCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.File).FirstOrDefault();
//                Assert.NotNull(tvFileModel);

//                Assert.Equal(DBCommandEnum.Deleted, tvFileModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvFileModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvFileModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvFileModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvFileModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvFileModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvFileModel.TVItemLanguageList[1].TVText);
//            }
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task File_Country_ModifyTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 1 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(5, WebTypeEnum.WebCountry);
//                Assert.NotNull(webCountry);

//                List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(webCountry.TVFileModelList.Count > 1);

//                TVFileModel tvItemModelNew = (from c in webCountry.TVFileModelList
//                                               select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelNew.TVItem,
//                    TVItemLanguageList = tvItemModelNew.TVItemLanguageList,
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
//                Assert.Single(toRecreateList);
//                Assert.Equal(5, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[0].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Single(fiList);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(5, WebTypeEnum.WebCountry);

//                Assert.True(webCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.File).Any());

//                TVFileModel tvFileModel = webCountry.TVFileModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.File).FirstOrDefault();
//                Assert.NotNull(tvFileModel);

//                Assert.Equal(DBCommandEnum.Modified, tvFileModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvFileModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvFileModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvFileModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvFileModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvFileModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvFileModel.TVItemLanguageList[1].TVText);
//            }
//        }
//    }
//}
