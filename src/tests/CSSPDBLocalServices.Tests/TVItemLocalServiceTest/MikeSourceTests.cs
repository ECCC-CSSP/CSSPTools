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
//        public async Task MikeSource_AddTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
//                Assert.NotNull(webMikeScenarios);

//                Assert.True(webMikeScenarios.MikeScenarioModelList.Count > 3);

//                List<TVItemModel> tvItemModelParentList = webMikeScenarios.MikeScenarioModelList.Skip(skip).Take(1).First().TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                string TVTextEN = "New item";
//                string TVTextFR = "Nouveau item";

//                TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.MikeSource, TVTextEN, TVTextFR);

//                var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
//                Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//                Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//                var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//                Assert.True(boolRet);

//                List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//                Assert.NotNull(toRecreateList);
//                Assert.NotEmpty(toRecreateList);
//                Assert.Equal(2, toRecreateList.Count);
//                Assert.Equal(27764, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[0].WebType);
//                Assert.Equal(27764, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[1].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(2, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMunicipality);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

//                foreach (MikeScenarioModel mikeScenarioModel in webMikeScenarios.MikeScenarioModelList)
//                {
//                    if (mikeScenarioModel.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID)
//                    {
//                        Assert.True(mikeScenarioModel.MikeSourceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
//                        && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeSource).Any());

//                        MikeSourceModel mikeSourceModel = mikeScenarioModel.MikeSourceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
//                            && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeSource).FirstOrDefault();
//                        Assert.NotNull(mikeSourceModel);

//                        Assert.Equal(DBCommandEnum.Created, mikeSourceModel.TVItemModel.TVItem.DBCommand);
//                        Assert.Equal(-1, mikeSourceModel.TVItemModel.TVItem.TVItemID);
//                        Assert.Equal(tvItemModelParent.TVItem.TVItemID, mikeSourceModel.TVItemModel.TVItem.ParentID);

//                        Assert.Equal(TVTextEN, mikeSourceModel.TVItemModel.TVItemLanguageList[0].TVText);
//                        Assert.Equal(TVTextFR, mikeSourceModel.TVItemModel.TVItemLanguageList[1].TVText);
//                        Assert.Equal(-1, mikeSourceModel.TVItemModel.TVItemLanguageList[0].TVItemID);
//                        Assert.Equal(-1, mikeSourceModel.TVItemModel.TVItemLanguageList[1].TVItemID);
//                    }
//                }
//            }
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task MikeSource_DeleteTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
//                Assert.NotNull(webMikeScenarios);

//                Assert.True(webMikeScenarios.MikeScenarioModelList.Count > 3);

//                MikeScenarioModel mikeScenarioModelRand = webMikeScenarios.MikeScenarioModelList.Skip(skip).Take(1).FirstOrDefault();
//                Assert.NotNull(mikeScenarioModelRand);

//                List<TVItemModel> tvItemModelParentList = mikeScenarioModelRand.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(mikeScenarioModelRand.MikeSourceModelList.Count > 0);

//                MikeSourceModel mikeSourceModelRand = (from c in mikeScenarioModelRand.MikeSourceModelList
//                                                                             where c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeSource
//                                                                             select c).Skip(skip).Take(1).FirstOrDefault();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = mikeSourceModelRand.TVItemModel.TVItem,
//                    TVItemLanguageList = mikeSourceModelRand.TVItemModel.TVItemLanguageList,
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
//                Assert.Equal(27764, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[0].WebType);
//                Assert.Equal(27764, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[1].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(2, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMunicipality);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

//                foreach (MikeScenarioModel mikeScenarioModel in webMikeScenarios.MikeScenarioModelList)
//                {
//                    if (mikeScenarioModel.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID)
//                    {
//                        Assert.True(mikeScenarioModel.MikeSourceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                        && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeSource).Any());

//                        MikeSourceModel mikeSourceModel = mikeScenarioModel.MikeSourceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                         && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeSource).FirstOrDefault();
//                        Assert.NotNull(mikeSourceModel);

//                        Assert.Equal(DBCommandEnum.Deleted, mikeSourceModel.TVItemModel.TVItem.DBCommand);
//                        Assert.Equal(postTVItemModel.TVItem.TVItemID, mikeSourceModel.TVItemModel.TVItem.TVItemID);
//                        Assert.Equal(tvItemModelParent.TVItem.TVItemID, mikeSourceModel.TVItemModel.TVItem.ParentID);

//                        Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, mikeSourceModel.TVItemModel.TVItemLanguageList[0].TVText);
//                        Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, mikeSourceModel.TVItemModel.TVItemLanguageList[1].TVText);
//                    }
//                }
//            }
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task MikeSource_ModifyTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
//                Assert.NotNull(webMikeScenarios);

//                Assert.True(webMikeScenarios.MikeScenarioModelList.Count > 3);

//                MikeScenarioModel mikeScenarioModelRand = webMikeScenarios.MikeScenarioModelList.Skip(skip).Take(1).FirstOrDefault();
//                Assert.NotNull(mikeScenarioModelRand);

//                List<TVItemModel> tvItemModelParentList = mikeScenarioModelRand.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(mikeScenarioModelRand.MikeSourceModelList.Count > 0);

//                MikeSourceModel mikeSourceModelRand = (from c in mikeScenarioModelRand.MikeSourceModelList
//                                                       where c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeSource
//                                                       select c).Skip(skip).Take(1).FirstOrDefault();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = mikeSourceModelRand.TVItemModel.TVItem,
//                    TVItemLanguageList = mikeSourceModelRand.TVItemModel.TVItemLanguageList,
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
//                Assert.Equal(27764, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[0].WebType);
//                Assert.Equal(27764, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[1].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(2, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMunicipality);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

//                foreach (MikeScenarioModel mikeScenarioModel in webMikeScenarios.MikeScenarioModelList)
//                {
//                    if (mikeScenarioModel.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID)
//                    {
//                        Assert.True(mikeScenarioModel.MikeSourceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                        && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeSource).Any());

//                        MikeSourceModel mikeSourceModel = mikeScenarioModel.MikeSourceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                         && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeSource).FirstOrDefault();
//                        Assert.NotNull(mikeSourceModel);

//                        Assert.Equal(DBCommandEnum.Modified, mikeSourceModel.TVItemModel.TVItem.DBCommand);
//                        Assert.Equal(postTVItemModel.TVItem.TVItemID, mikeSourceModel.TVItemModel.TVItem.TVItemID);
//                        Assert.Equal(tvItemModelParent.TVItem.TVItemID, mikeSourceModel.TVItemModel.TVItem.ParentID);

//                        Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, mikeSourceModel.TVItemModel.TVItemLanguageList[0].TVText);
//                        Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, mikeSourceModel.TVItemModel.TVItemLanguageList[1].TVText);
//                    }
//                }
//            }
//        }
//    }
//}
