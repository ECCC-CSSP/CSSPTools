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
//        public async Task Email_AddTVItemLocal_Good_Test(string culture)
//        {
//            Assert.True(await TVItemLocalServiceSetup(culture));

//            await LoadWebType(1, WebTypeEnum.WebRoot);
//            Assert.NotNull(webRoot);

//            List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
//            Assert.NotNull(tvItemModelParentList);

//            TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//            Assert.NotNull(tvItemModelParent);

//            string TVTextEN = "New item";
//            string TVTextFR = "Nouveau item";

//            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.Email, TVTextEN, TVTextFR);

//            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
//            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
//            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
//            Assert.True(boolRet);

//            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
//            Assert.NotNull(toRecreateList);
//            Assert.NotEmpty(toRecreateList);
//            Assert.Single(toRecreateList);
//            Assert.Equal(0, toRecreateList[0].TVItemID);
//            Assert.Equal(WebTypeEnum.WebAllEmails, toRecreateList[0].WebType);

//            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//            Assert.True(di.Exists);
//            List<FileInfo> fiList = di.GetFiles().ToList();
//            Assert.Single(fiList);

//            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllEmails }.gz");
//            Assert.True(fi.Exists);

//            await LoadWebType(0, WebTypeEnum.WebAllEmails);

//            Assert.True(webAllEmails.EmailModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
//            && c.TVItemModel.TVItem.TVType == TVTypeEnum.Email).Any());

//            EmailModel emailModel = webAllEmails.EmailModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
//            && c.TVItemModel.TVItem.TVType == TVTypeEnum.Email).FirstOrDefault();
//            Assert.NotNull(emailModel);

//            Assert.Equal(DBCommandEnum.Created, emailModel.TVItemModel.TVItem.DBCommand);
//            Assert.Equal(-1, emailModel.TVItemModel.TVItem.TVItemID);
//            Assert.Equal(tvItemModelParent.TVItem.TVItemID, emailModel.TVItemModel.TVItem.ParentID);

//            Assert.Equal(TVTextEN, emailModel.TVItemModel.TVItemLanguageList[0].TVText);
//            Assert.Equal(TVTextFR, emailModel.TVItemModel.TVItemLanguageList[1].TVText);
//            Assert.Equal(-1, emailModel.TVItemModel.TVItemLanguageList[0].TVItemID);
//            Assert.Equal(-1, emailModel.TVItemModel.TVItemLanguageList[1].TVItemID);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task Email_DeleteTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(1, WebTypeEnum.WebRoot);
//                Assert.NotNull(webRoot);

//                await LoadWebType(1, WebTypeEnum.WebAllEmails);
//                Assert.NotNull(webAllEmails);

//                List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(webAllEmails.EmailModelList.Count > 3);

//                EmailModel emailModelToDelete = (from c in webAllEmails.EmailModelList
//                                                 select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = emailModelToDelete.TVItemModel.TVItem,
//                    TVItemLanguageList = emailModelToDelete.TVItemModel.TVItemLanguageList,
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
//                Assert.Equal(0, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebAllEmails, toRecreateList[0].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Single(fiList);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllEmails }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(1, WebTypeEnum.WebAllEmails);

//                EmailModel emailModel = (from c in webAllEmails.EmailModelList
//                                         where c.TVItemModel.TVItem.TVItemID == emailModelToDelete.TVItemModel.TVItem.TVItemID
//                                         select c).FirstOrDefault();
//                Assert.NotNull(emailModel);
//                Assert.Equal(DBCommandEnum.Deleted, emailModel.TVItemModel.TVItem.DBCommand);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, emailModel.TVItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, emailModel.TVItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, emailModel.TVItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, emailModel.TVItemModel.TVItemLanguageList[1].TVText);
//            }
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        //[InlineData("fr-CA")]
//        public async Task Email_ModifyTVItemLocal_Good_Test(string culture)
//        {
//            foreach (int skip in new List<int>() { 0, 2 })
//            {
//                Assert.True(await TVItemLocalServiceSetup(culture));

//                await LoadWebType(1, WebTypeEnum.WebRoot);
//                Assert.NotNull(webRoot);

//                await LoadWebType(1, WebTypeEnum.WebAllEmails);
//                Assert.NotNull(webAllEmails);

//                List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
//                Assert.NotNull(tvItemModelParentList);

//                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
//                Assert.NotNull(tvItemModelParent);

//                Assert.True(webAllEmails.EmailModelList.Count > 3);

//                EmailModel emailModelToDelete = (from c in webAllEmails.EmailModelList
//                                                 select c).Skip(skip).Take(1).First();

//                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
//                {
//                    TVItem = emailModelToDelete.TVItemModel.TVItem,
//                    TVItemLanguageList = emailModelToDelete.TVItemModel.TVItemLanguageList,
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
//                Assert.Equal(0, toRecreateList[0].TVItemID);
//                Assert.Equal(WebTypeEnum.WebAllEmails, toRecreateList[0].WebType);

//                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
//                Assert.True(di.Exists);
//                List<FileInfo> fiList = di.GetFiles().ToList();
//                Assert.Single(fiList);

//                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllEmails }.gz");
//                Assert.True(fi.Exists);

//                await LoadWebType(1, WebTypeEnum.WebAllEmails);

//                EmailModel emailModel = (from c in webAllEmails.EmailModelList
//                                         where c.TVItemModel.TVItem.TVItemID == emailModelToDelete.TVItemModel.TVItem.TVItemID
//                                         select c).FirstOrDefault();
//                Assert.NotNull(emailModel);
//                Assert.Equal(DBCommandEnum.Modified, emailModel.TVItemModel.TVItem.DBCommand);

//                Assert.Equal(postTVItemModel.TVItem.TVItemID, emailModel.TVItemModel.TVItem.TVItemID);
//                Assert.Equal(tvItemModelParent.TVItem.TVItemID, emailModel.TVItemModel.TVItem.ParentID);

//                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, emailModel.TVItemModel.TVItemLanguageList[0].TVText);
//                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, emailModel.TVItemModel.TVItemLanguageList[1].TVText);
//            }
//        }
//    }
//}
