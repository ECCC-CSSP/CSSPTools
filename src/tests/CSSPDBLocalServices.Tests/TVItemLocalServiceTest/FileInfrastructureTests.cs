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
//        public async Task File_Infrastructure_AddTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));
       
//                await LoadWebType(27764, WebTypeEnum.WebMunicipality);
//                Assert.NotNull(webMunicipality);

//                InfrastructureModel infrastructureModel = (from c in webMunicipality.InfrastructureModelList
//                                                       select c).Skip(skip).Take(1).FirstOrDefault();
//                Assert.NotNull(infrastructureModel);

//                List<TVItemModel> tvItemModelParentList = infrastructureModel.TVItemModelParentList;
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
//                Assert.Equal(WebTypeEnum.WebMunicipality, toRecreateList[0].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Single(fiList);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebMunicipality }_{ 27764 }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(27764, WebTypeEnum.WebMunicipality);

//                infrastructureModel = (from c in webMunicipality.InfrastructureModelList
//                                       where c.TVItemModel.TVItem.TVItemID == infrastructureModel.TVItemModel.TVItem.TVItemID
//                                     select c).Skip(skip).Take(1).FirstOrDefault();

//                Assert.True(infrastructureModel.TVFileModelList.Where(c => c.TVItem.TVItemID == -1
//                && c.TVItem.TVType == TVTypeEnum.File).Any());

//                TVFileModel tvFileModel = infrastructureModel.TVFileModelList.Where(c => c.TVItem.TVItemID == -1
//                        && c.TVItem.TVType == TVTypeEnum.File).FirstOrDefault();
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
//        public async Task File_Infrastructure_DeleteTVItemLocal_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            Assert.True(false, "To Do");
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task File_Infrastructure_ModifyTVItemLocal_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            Assert.True(false, "To Do");
//        }
//    }
//}
