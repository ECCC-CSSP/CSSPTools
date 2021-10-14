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
        public async Task MikeBoundaryConditionWebTide_AddTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
                Assert.NotNull(webMikeScenarios);

                Assert.True(webMikeScenarios.MikeScenarioModelList.Count > 3);

                List<TVItemModel> tvItemModelParentList = webMikeScenarios.MikeScenarioModelList.Skip(skip).Take(1).First().TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                string TVTextEN = "New item";
                string TVTextFR = "Nouveau item";

                TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.MikeBoundaryConditionWebTide, TVTextEN, TVTextFR);

                var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
                Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
                var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
                Assert.True(boolRet);

                List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
                Assert.NotNull(toRecreateList);
                Assert.NotEmpty(toRecreateList);
                Assert.Single(toRecreateList);
                Assert.Equal(27764, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

                foreach (MikeScenarioModel mikeScenarioModel in webMikeScenarios.MikeScenarioModelList)
                {
                    if (mikeScenarioModel.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID)
                    {
                        Assert.True(mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
                        && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide).Any());

                        MikeBoundaryConditionModel mikeBoundaryConditionModel = mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
                            && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide).FirstOrDefault();
                        Assert.NotNull(mikeBoundaryConditionModel);

                        Assert.Equal(DBCommandEnum.Created, mikeBoundaryConditionModel.TVItemModel.TVItem.DBCommand);
                        Assert.Equal(-1, mikeBoundaryConditionModel.TVItemModel.TVItem.TVItemID);
                        Assert.Equal(tvItemModelParent.TVItem.TVItemID, mikeBoundaryConditionModel.TVItemModel.TVItem.ParentID);

                        Assert.Equal(TVTextEN, mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList[0].TVText);
                        Assert.Equal(TVTextFR, mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList[1].TVText);
                        Assert.Equal(-1, mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList[0].TVItemID);
                        Assert.Equal(-1, mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList[1].TVItemID);
                    }
                }
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeBoundaryConditionWebTide_DeleteTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
                Assert.NotNull(webMikeScenarios);

                Assert.True(webMikeScenarios.MikeScenarioModelList.Count > 3);

                MikeScenarioModel mikeScenarioModelRand = webMikeScenarios.MikeScenarioModelList.Skip(skip).Take(1).FirstOrDefault();
                Assert.NotNull(mikeScenarioModelRand);

                List<TVItemModel> tvItemModelParentList = mikeScenarioModelRand.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(mikeScenarioModelRand.MikeBoundaryConditionModelList.Count > 0);

                MikeBoundaryConditionModel mikeBoundaryConditionModelRand = (from c in mikeScenarioModelRand.MikeBoundaryConditionModelList
                                                                             where c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide
                                                                             select c).Skip(skip).Take(1).FirstOrDefault();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = mikeBoundaryConditionModelRand.TVItemModel.TVItem,
                    TVItemLanguageList = mikeBoundaryConditionModelRand.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(27764, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

                foreach (MikeScenarioModel mikeScenarioModel in webMikeScenarios.MikeScenarioModelList)
                {
                    if (mikeScenarioModel.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID)
                    {
                        Assert.True(mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                        && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide).Any());

                        MikeBoundaryConditionModel mikeBoundaryConditionModel = mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                            && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide).FirstOrDefault();
                        Assert.NotNull(mikeBoundaryConditionModel);

                        Assert.Equal(DBCommandEnum.Deleted, mikeBoundaryConditionModel.TVItemModel.TVItem.DBCommand);
                        Assert.Equal(postTVItemModel.TVItem.TVItemID, mikeBoundaryConditionModel.TVItemModel.TVItem.TVItemID);
                        Assert.Equal(tvItemModelParent.TVItem.TVItemID, mikeBoundaryConditionModel.TVItemModel.TVItem.ParentID);

                        Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList[0].TVText);
                        Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList[1].TVText);
                    }
                }
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeBoundaryConditionWebTide_ModifyTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);
                Assert.NotNull(webMikeScenarios);

                Assert.True(webMikeScenarios.MikeScenarioModelList.Count > 3);

                MikeScenarioModel mikeScenarioModelRand = webMikeScenarios.MikeScenarioModelList.Skip(skip).Take(1).FirstOrDefault();
                Assert.NotNull(mikeScenarioModelRand);

                List<TVItemModel> tvItemModelParentList = mikeScenarioModelRand.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(mikeScenarioModelRand.MikeBoundaryConditionModelList.Count > 0);

                MikeBoundaryConditionModel mikeBoundaryConditionModelRand = (from c in mikeScenarioModelRand.MikeBoundaryConditionModelList
                                                                             where c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide
                                                                             select c).Skip(skip).Take(1).FirstOrDefault();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = mikeBoundaryConditionModelRand.TVItemModel.TVItem,
                    TVItemLanguageList = mikeBoundaryConditionModelRand.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(27764, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebMikeScenarios, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMikeScenarios }_{ 27764 }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(27764, WebTypeEnum.WebMikeScenarios);

                foreach (MikeScenarioModel mikeScenarioModel in webMikeScenarios.MikeScenarioModelList)
                {
                    if (mikeScenarioModel.MikeScenario.MikeScenarioTVItemID == postTVItemModel.TVItem.ParentID)
                    {
                        Assert.True(mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                        && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide).Any());

                        MikeBoundaryConditionModel mikeBoundaryConditionModel = mikeScenarioModel.MikeBoundaryConditionModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
                            && c.TVItemModel.TVItem.TVType == TVTypeEnum.MikeBoundaryConditionWebTide).FirstOrDefault();
                        Assert.NotNull(mikeBoundaryConditionModel);

                        Assert.Equal(DBCommandEnum.Modified, mikeBoundaryConditionModel.TVItemModel.TVItem.DBCommand);
                        Assert.Equal(postTVItemModel.TVItem.TVItemID, mikeBoundaryConditionModel.TVItemModel.TVItem.TVItemID);
                        Assert.Equal(tvItemModelParent.TVItem.TVItemID, mikeBoundaryConditionModel.TVItemModel.TVItem.ParentID);

                        Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList[0].TVText);
                        Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, mikeBoundaryConditionModel.TVItemModel.TVItemLanguageList[1].TVText);
                    }
                }
            }
        }
    }
}
