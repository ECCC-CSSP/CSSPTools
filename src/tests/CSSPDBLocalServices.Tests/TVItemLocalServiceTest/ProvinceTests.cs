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
//        public async Task Province_AddTVItemLocal_Good_Test(string culture)
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

//            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.Province, TVTextEN, TVTextFR);

//            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
//            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//            Assert.True(boolRet);

//            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//            Assert.NotNull(toRecreateList);
//            Assert.NotEmpty(toRecreateList);
//            Assert.Equal(4, toRecreateList.Count);
//            Assert.Equal(0, toRecreateList[0].TVItemID);
//            Assert.Equal(WebTypeEnum.WebAllProvinces, toRecreateList[0].WebType);
//            Assert.Equal(5, toRecreateList[1].TVItemID);
//            Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[1].WebType);
//            Assert.Equal(-1, toRecreateList[2].TVItemID);
//            Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[2].WebType);
//            Assert.Equal(-1, toRecreateList[3].TVItemID);
//            Assert.Equal(WebTypeEnum.WebDrogueRuns, toRecreateList[3].WebType);

//            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//            Assert.True(di.Exists);
//            List<FileInfo> fiList = di.GetFiles().ToList();
//            Assert.Equal(4, fiList.Count);

//            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllProvinces }.gz");
//            Assert.True(fi.Exists);

//            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
//            Assert.True(fi.Exists);

//            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ -1 }.gz");
//            Assert.True(fi.Exists);

//            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebDrogueRuns }_{ -1 }.gz");
//            Assert.True(fi.Exists);

//            await LoadWebType(0, WebTypeEnum.WebAllProvinces);

//            Assert.True(webAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == -1
//            && c.TVItem.TVType == TVTypeEnum.Province).Any());

//            TVItemModel tvItemModel = webAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == -1
//            && c.TVItem.TVType == TVTypeEnum.Province).FirstOrDefault();
//            Assert.NotNull(tvItemModel);

//            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
//            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

//            await LoadWebType(5, WebTypeEnum.WebCountry);

//            Assert.True(webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == -1
//            && c.TVItem.TVType == TVTypeEnum.Province).Any());

//            tvItemModel = webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == -1
//            && c.TVItem.TVType == TVTypeEnum.Province).FirstOrDefault();
//            Assert.NotNull(tvItemModel);

//            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
//            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

//            await LoadWebType(-1, WebTypeEnum.WebProvince);

//            Assert.True(webProvince.TVItemModel.TVItem.TVItemID == -1
//            && webProvince.TVItemModel.TVItem.TVType == TVTypeEnum.Province);

//            tvItemModel = webProvince.TVItemModel;
//            Assert.NotNull(tvItemModel);
//            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
//            Assert.Equal(TVTypeEnum.Province, tvItemModel.TVItem.TVType);

//            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
//            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

//            await LoadWebType(-1, WebTypeEnum.WebDrogueRuns);

//            Assert.True(webDrogueRuns.TVItemModel.TVItem.TVItemID == -1
//            && webDrogueRuns.TVItemModel.TVItem.TVType == TVTypeEnum.Province);

//            tvItemModel = webDrogueRuns.TVItemModel;
//            Assert.NotNull(tvItemModel);
//            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
//            Assert.Equal(TVTypeEnum.Province, tvItemModel.TVItem.TVType);

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
//        public async Task Province_DeleteTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(5, WebTypeEnum.WebCountry);
//                Assert.NotNull(webCountry);

//                List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(webCountry.TVItemModelProvinceList.Count > 3);

//                TVItemModel tvItemModelProvince = (from c in webCountry.TVItemModelProvinceList
//                                                   select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelProvince.TVItem,
//                    TVItemLanguageList = tvItemModelProvince.TVItemLanguageList,
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
//                Assert.Equal(4, toRecreateList.Count);
//                Assert.Equal(0, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebAllProvinces, toRecreateList[0].WebType);
//                Assert.Equal(5, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[1].WebType);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[2].TVItemID);
//                Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[2].WebType);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[3].TVItemID);
//                Assert.Equal(WebTypeEnum.WebDrogueRuns, toRecreateList[3].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(4, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllProvinces }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ postTVItemModel.TVItem.TVItemID }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebDrogueRuns }_{ postTVItemModel.TVItem.TVItemID }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(0, WebTypeEnum.WebAllProvinces);

//                Assert.True(webAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Province).Any());

//                TVItemModel tvItemModel = webAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Province).FirstOrDefault();
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(5, WebTypeEnum.WebCountry);

//                Assert.True(webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Province).Any());

//                tvItemModel = webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Province).FirstOrDefault();
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebProvince);

//                Assert.True(webProvince.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && webProvince.TVItemModel.TVItem.TVType == TVTypeEnum.Province);

//                tvItemModel = webProvince.TVItemModel;
//                Assert.NotNull(tvItemModel);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(TVTypeEnum.Province, tvItemModel.TVItem.TVType);

//                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebDrogueRuns);

//                Assert.True(webDrogueRuns.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && webDrogueRuns.TVItemModel.TVItem.TVType == TVTypeEnum.Province);

//                tvItemModel = webDrogueRuns.TVItemModel;
//                Assert.NotNull(tvItemModel);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(TVTypeEnum.Province, tvItemModel.TVItem.TVType);

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
//        public async Task Province_ModifyTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(5, WebTypeEnum.WebCountry);
//                Assert.NotNull(webCountry);

//                List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(webCountry.TVItemModelProvinceList.Count > 3);

//                TVItemModel tvItemModelProvince = (from c in webCountry.TVItemModelProvinceList
//                                                   select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelProvince.TVItem,
//                    TVItemLanguageList = tvItemModelProvince.TVItemLanguageList,
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
//                Assert.Equal(4, toRecreateList.Count);
//                Assert.Equal(0, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebAllProvinces, toRecreateList[0].WebType);
//                Assert.Equal(5, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebCountry, toRecreateList[1].WebType);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[2].TVItemID);
//                Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[2].WebType);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[3].TVItemID);
//                Assert.Equal(WebTypeEnum.WebDrogueRuns, toRecreateList[3].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(4, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllProvinces }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebCountry }_{ 5 }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ postTVItemModel.TVItem.TVItemID }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebDrogueRuns }_{ postTVItemModel.TVItem.TVItemID }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(0, WebTypeEnum.WebAllProvinces);

//                Assert.True(webAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Province).Any());

//                TVItemModel tvItemModel = webAllProvinces.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Province).FirstOrDefault();
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(5, WebTypeEnum.WebCountry);

//                Assert.True(webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Province).Any());

//                tvItemModel = webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Province).FirstOrDefault();
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebProvince);

//                Assert.True(webProvince.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && webProvince.TVItemModel.TVItem.TVType == TVTypeEnum.Province);

//                tvItemModel = webProvince.TVItemModel;
//                Assert.NotNull(tvItemModel);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(TVTypeEnum.Province, tvItemModel.TVItem.TVType);

//                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebDrogueRuns);

//                Assert.True(webDrogueRuns.TVItemModel.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && webDrogueRuns.TVItemModel.TVItem.TVType == TVTypeEnum.Province);

//                tvItemModel = webDrogueRuns.TVItemModel;
//                Assert.NotNull(tvItemModel);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(TVTypeEnum.Province, tvItemModel.TVItem.TVType);

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
