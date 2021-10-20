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
//        public async Task File_MikeScenario_AddTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 1 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
//                Assert.NotNull(webMikeScenarios);

//                MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
//                                                       select c).Skip(skip).Take(1).FirstOrDefault();
//                Assert.NotNull(mikeScenarioModel);

//                List<TVItemModel> tvItemModelParentList = mikeScenarioModel.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                string TVTextEN = "New item";
//                string TVTextFR = "Nouveau item";

//                TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.File, TVTextEN, TVTextFR);

//                var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
//                Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//                Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//                var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//                Assert.True(boolRet);

//                List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//                Assert.NotNull(toRecreateList);
//                Assert.NotEmpty(toRecreateList);
//                Assert.Single(toRecreateList);
//                Assert.Equal(27764, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Single(fiList);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

//                mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
//                                     select c).Skip(skip).Take(1).FirstOrDefault();

//                Assert.True(mikeScenarioModel.TVFileModelList.Where(c => c.TVItem.TVItemID == -1
//                && c.TVItem.TVType == TVTypeEnum.File).Any());

//                TVFileModel tvFileModel = mikeScenarioModel.TVFileModelList.Where(c => c.TVItem.TVItemID == -1
//                          && c.TVItem.TVType == TVTypeEnum.File).FirstOrDefault();
//                Assert.NotNull(tvFileModel);

//                Assert.Equal(DBCommandEnum.Created, tvFileModel.TVItem.DBCommand);
//                Assert.Equal(-1, tvFileModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvFileModel.TVItem.ParentID);

//                Assert.Equal(TVTextEN, tvFileModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(TVTextFR, tvFileModel.TVItemLanguageList[1].TVText);
//                Assert.Equal(-1, tvFileModel.TVItemLanguageList[0].TVItemID);
//                Assert.Equal(-1, tvFileModel.TVItemLanguageList[1].TVItemID);
//            }
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task File_MikeScenario_DeleteTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 1 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
//                Assert.NotNull(webMikeScenarios);

//                MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
//                                                       select c).Skip(skip).Take(1).FirstOrDefault();
//                Assert.NotNull(mikeScenarioModel);

//                List<TVItemModel> tvItemModelParentList = mikeScenarioModel.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(mikeScenarioModel.TVFileModelList.Count > 1);

//                TVFileModel tvItemModelToDelete = (from c in mikeScenarioModel.TVFileModelList
//                                               select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelToDelete.TVItem,
//                    TVItemLanguageList = tvItemModelToDelete.TVItemLanguageList,
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
//                Assert.Equal(27764, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Single(fiList);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

//                mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
//                                     select c).Skip(skip).Take(1).FirstOrDefault();
//                Assert.NotNull(mikeScenarioModel);

//                Assert.True(mikeScenarioModel.TVFileModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.File).Any());

//                TVFileModel tvFileModel = mikeScenarioModel.TVFileModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                          && c.TVItem.TVType == TVTypeEnum.File).FirstOrDefault();
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
//        public async Task File_MikeScenario_ModifyTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 1 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
//                Assert.NotNull(webMikeScenarios);

//                MikeScenarioModel mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
//                                                       select c).Skip(skip).Take(1).FirstOrDefault();
//                Assert.NotNull(mikeScenarioModel);

//                List<TVItemModel> tvItemModelParentList = mikeScenarioModel.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(mikeScenarioModel.TVFileModelList.Count > 1);

//                TVFileModel tvItemModelToModify = (from c in mikeScenarioModel.TVFileModelList
//                                               select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelToModify.TVItem,
//                    TVItemLanguageList = tvItemModelToModify.TVItemLanguageList,
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
//                Assert.Equal(27764, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Single(fiList);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

//                mikeScenarioModel = (from c in webMikeScenarios.MikeScenarioModelList
//                                     select c).Skip(skip).Take(1).FirstOrDefault();
//                Assert.NotNull(mikeScenarioModel);

//                Assert.True(mikeScenarioModel.TVFileModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.File).Any());

//                TVFileModel tvFileModel = mikeScenarioModel.TVFileModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                          && c.TVItem.TVType == TVTypeEnum.File).FirstOrDefault();
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