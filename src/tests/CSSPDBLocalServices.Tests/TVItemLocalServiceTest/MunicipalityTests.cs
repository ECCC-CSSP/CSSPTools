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
//        public async Task Municipality_AddTVItemLocal_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            await LoadWebType(7, WebTypeEnum.WebProvince);
//            Assert.NotNull(webProvince);

//            List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;
//            Assert.NotNull(tvItemModelParentList);

//            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//            Assert.NotNull(tvItemModelParent);

//            string TVTextEN = "New item";
//            string TVTextFR = "Nouveau item";

//            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.Municipality, TVTextEN, TVTextFR);

//            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
//            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//            Assert.True(boolRet);

//            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//            Assert.NotNull(toRecreateList);
//            Assert.NotEmpty(toRecreateList);
//            Assert.Equal(3, toRecreateList.Count);
//            Assert.Equal(0, toRecreateList[0].TVItemID);
//            Assert.Equal(WebTypeEnum.WebAllMunicipalities, toRecreateList[0].WebType);
//            Assert.Equal(-1, toRecreateList[1].TVItemID);
//            Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[1].WebType);
//            Assert.Equal(7, toRecreateList[2].TVItemID);
//            Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[2].WebType);

//            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//            Assert.True(di.Exists);
//            List<FileInfo> fiList = di.GetFiles().ToList();
//            Assert.Equal(3, fiList.Count);

//            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllMunicipalities }.gz");
//            Assert.True(fi.Exists);

//            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ -1 }.gz");
//            Assert.True(fi.Exists);

//            fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ 7 }.gz");
//            Assert.True(fi.Exists);

//            await LoadWebType(7, WebTypeEnum.WebAllMunicipalities);

//            TVItemModel tvItemModel = webAllMunicipalities.TVItemModelList.Where(c => c.TVItem.TVItemID == -1
//            && c.TVItem.TVType == TVTypeEnum.Municipality).FirstOrDefault();
//            Assert.NotNull(tvItemModel);

//            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
//            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

//            await LoadWebType(-1, WebTypeEnum.WebMunicipality);

//            tvItemModel = webMunicipality.TVItemModel;
//            Assert.NotNull(tvItemModel);

//            Assert.Equal(DBCommandEnum.Created, tvItemModel.TVItem.DBCommand);
//            Assert.Equal(-1, tvItemModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, tvItemModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, tvItemModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, tvItemModel.TVItemLanguageList[1].TVItemID);

//            await LoadWebType(7, WebTypeEnum.WebProvince);

//            tvItemModel = webProvince.TVItemModelMunicipalityList.Where(c => c.TVItem.TVItemID == -1
//            && c.TVItem.TVType == TVTypeEnum.Municipality).FirstOrDefault();
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
//        public async Task Municipality_DeleteTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(7, WebTypeEnum.WebProvince);
//                Assert.NotNull(webProvince);

//                List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(webProvince.TVItemModelMunicipalityList.Count > 3);

//                TVItemModel tvItemModelMunicipality = (from c in webProvince.TVItemModelMunicipalityList
//                                               select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelMunicipality.TVItem,
//                    TVItemLanguageList = tvItemModelMunicipality.TVItemLanguageList,
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
//                Assert.Equal(3, toRecreateList.Count);
//                Assert.Equal(0, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebAllMunicipalities, toRecreateList[0].WebType);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[1].WebType);
//                Assert.Equal(7, toRecreateList[2].TVItemID);
//                Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[2].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(3, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllMunicipalities }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ postTVItemModel.TVItem.TVItemID }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ 7 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(7, WebTypeEnum.WebAllMunicipalities);

//                TVItemModel tvItemModel = webAllMunicipalities.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Municipality).FirstOrDefault();
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMunicipality);

//                tvItemModel = webMunicipality.TVItemModel;
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Deleted, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(7, WebTypeEnum.WebProvince);

//                tvItemModel = webProvince.TVItemModelMunicipalityList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Municipality).FirstOrDefault();
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
//        public async Task Municipality_ModifyTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(7, WebTypeEnum.WebProvince);
//                Assert.NotNull(webProvince);

//                List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(webProvince.TVItemModelMunicipalityList.Count > 3);

//                TVItemModel tvItemModelMunicipality = (from c in webProvince.TVItemModelMunicipalityList
//                                                       select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = tvItemModelMunicipality.TVItem,
//                    TVItemLanguageList = tvItemModelMunicipality.TVItemLanguageList,
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
//                Assert.Equal(3, toRecreateList.Count);
//                Assert.Equal(0, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebAllMunicipalities, toRecreateList[0].WebType);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, toRecreateList[1].TVItemID);
//                Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[1].WebType);
//                Assert.Equal(7, toRecreateList[2].TVItemID);
//                Assert.Equal(WebTypeEnum.WebProvince, toRecreateList[2].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Equal(3, fiList.Count);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllMunicipalities }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ postTVItemModel.TVItem.TVItemID }.gz");
//                Assert.True(fi.Exists);

//                fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebProvince }_{ 7 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(7, WebTypeEnum.WebAllMunicipalities);

//                TVItemModel tvItemModel = webAllMunicipalities.TVItemModelList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Municipality).FirstOrDefault();
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(postTVItemModel.TVItem.TVItemID, WebTypeEnum.WebMunicipality);

//                tvItemModel = webMunicipality.TVItemModel;
//                Assert.NotNull(tvItemModel);

//                Assert.Equal(DBCommandEnum.Modified, tvItemModel.TVItem.DBCommand);
//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, tvItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, tvItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, tvItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, tvItemModel.TVItemLanguageList[1].TVText);

//                await LoadWebType(7, WebTypeEnum.WebProvince);

//                tvItemModel = webProvince.TVItemModelMunicipalityList.Where(c => c.TVItem.TVItemID == postTVItemModel.TVItem.TVItemID
//                && c.TVItem.TVType == TVTypeEnum.Municipality).FirstOrDefault();
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
