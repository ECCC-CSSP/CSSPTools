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
        public async Task Contact_AddTVItemLocal_Good_Test(string culture)
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

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.Contact, TVTextEN, TVTextFR);

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            var boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            List<ToRecreate> toRecreateList = await TVItemLocalService.GetToRecreateList();
            Assert.NotNull(toRecreateList);
            Assert.NotEmpty(toRecreateList);
            Assert.Single(toRecreateList);
            Assert.Equal(0, toRecreateList[0].TVItemID);
            Assert.Equal(WebTypeEnum.WebAllContacts, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllContacts }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(0, WebTypeEnum.WebAllContacts);

            Assert.True(webAllContacts.ContactModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.Contact).Any());

            ContactModel contactModel = webAllContacts.ContactModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.Contact).FirstOrDefault();
            Assert.NotNull(contactModel);

            Assert.Equal(DBCommandEnum.Created, contactModel.TVItemModel.TVItem.DBCommand);
            Assert.Equal(-1, contactModel.TVItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, contactModel.TVItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, contactModel.TVItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, contactModel.TVItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, contactModel.TVItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, contactModel.TVItemModel.TVItemLanguageList[1].TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Contact_DeleteTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(1, WebTypeEnum.WebRoot);
                Assert.NotNull(webRoot);

                await LoadWebType(1, WebTypeEnum.WebAllContacts);
                Assert.NotNull(webAllContacts);

                List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webAllContacts.ContactModelList.Count > 3);

                ContactModel contactModelToDelete = (from c in webAllContacts.ContactModelList
                                                     select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = contactModelToDelete.TVItemModel.TVItem,
                    TVItemLanguageList = contactModelToDelete.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(0, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebAllContacts, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllContacts }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(1, WebTypeEnum.WebAllContacts);

                ContactModel contactModel = (from c in webAllContacts.ContactModelList
                                             where c.TVItemModel.TVItem.TVItemID == contactModelToDelete.TVItemModel.TVItem.TVItemID
                                             select c).FirstOrDefault();
                Assert.NotNull(contactModel);
                Assert.Equal(DBCommandEnum.Deleted, contactModel.TVItemModel.TVItem.DBCommand);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, contactModel.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, contactModel.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, contactModel.TVItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, contactModel.TVItemModel.TVItemLanguageList[1].TVText);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Contact_ModifyTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(1, WebTypeEnum.WebRoot);
                Assert.NotNull(webRoot);

                await LoadWebType(1, WebTypeEnum.WebAllContacts);
                Assert.NotNull(webAllContacts);

                List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webAllContacts.ContactModelList.Count > 3);

                ContactModel contactModelToDelete = (from c in webAllContacts.ContactModelList
                                                     select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = contactModelToDelete.TVItemModel.TVItem,
                    TVItemLanguageList = contactModelToDelete.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(0, toRecreateList[0].TVItemID);
                Assert.Equal(WebTypeEnum.WebAllContacts, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllContacts }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(1, WebTypeEnum.WebAllContacts);

                ContactModel contactModel = (from c in webAllContacts.ContactModelList
                                             where c.TVItemModel.TVItem.TVItemID == contactModelToDelete.TVItemModel.TVItem.TVItemID
                                             select c).FirstOrDefault();
                Assert.NotNull(contactModel);
                Assert.Equal(DBCommandEnum.Modified, contactModel.TVItemModel.TVItem.DBCommand);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, contactModel.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, contactModel.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, contactModel.TVItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, contactModel.TVItemModel.TVItemLanguageList[1].TVText);
            }
        }
    }
}
