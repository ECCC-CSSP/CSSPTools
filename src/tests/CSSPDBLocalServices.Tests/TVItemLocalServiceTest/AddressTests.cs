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
        public async Task Address_AddTVItemLocal_Good_Test(string culture)
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

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd2(tvItemModelParent, TVTypeEnum.Address, TVTextEN, TVTextFR);

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
            Assert.Equal(WebTypeEnum.WebAllAddresses, toRecreateList[0].WebType);

            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
            Assert.True(di.Exists);
            List<FileInfo> fiList = di.GetFiles().ToList();
            Assert.Single(fiList);

            FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllAddresses }.gz");
            Assert.True(fi.Exists);

            await LoadWebType(1, WebTypeEnum.WebAllAddresses);

            Assert.True(webAllAddresses.AddressModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.Address).Any());

            AddressModel addressModel = webAllAddresses.AddressModelList.Where(c => c.TVItemModel.TVItem.TVItemID == -1
            && c.TVItemModel.TVItem.TVType == TVTypeEnum.Address).FirstOrDefault();
            Assert.NotNull(addressModel);

            Assert.Equal(DBCommandEnum.Created, addressModel.TVItemModel.TVItem.DBCommand);
            Assert.Equal(-1, addressModel.TVItemModel.TVItem.TVItemID);
            Assert.Equal(tvItemModelParent.TVItem.TVItemID, addressModel.TVItemModel.TVItem.ParentID);

            Assert.Equal(TVTextEN, addressModel.TVItemModel.TVItemLanguageList[0].TVText);
            Assert.Equal(TVTextFR, addressModel.TVItemModel.TVItemLanguageList[1].TVText);
            Assert.Equal(-1, addressModel.TVItemModel.TVItemLanguageList[0].TVItemID);
            Assert.Equal(-1, addressModel.TVItemModel.TVItemLanguageList[1].TVItemID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Address_DeleteTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(1, WebTypeEnum.WebRoot);
                Assert.NotNull(webRoot);

                await LoadWebType(1, WebTypeEnum.WebAllAddresses);
                Assert.NotNull(webAllAddresses);

                List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webAllAddresses.AddressModelList.Count > 3);

                AddressModel addressModelToDelete = (from c in webAllAddresses.AddressModelList
                                                     select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = addressModelToDelete.TVItemModel.TVItem,
                    TVItemLanguageList = addressModelToDelete.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(WebTypeEnum.WebAllAddresses, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllAddresses }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(1, WebTypeEnum.WebAllAddresses);

                AddressModel addressModel = (from c in webAllAddresses.AddressModelList
                                             where c.TVItemModel.TVItem.TVItemID == addressModelToDelete.TVItemModel.TVItem.TVItemID
                                             select c).FirstOrDefault();
                Assert.NotNull(addressModel);
                Assert.Equal(DBCommandEnum.Deleted, addressModel.TVItemModel.TVItem.DBCommand);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, addressModel.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, addressModel.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, addressModel.TVItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, addressModel.TVItemModel.TVItemLanguageList[1].TVText);
            }
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Address_ModifyTVItemLocal_Good_Test(string culture)
        {
            foreach (int skip in new List<int>() { 0, 2 })
            {
                Assert.True(await TVItemLocalServiceSetup(culture));

                await LoadWebType(1, WebTypeEnum.WebRoot);
                Assert.NotNull(webRoot);

                await LoadWebType(1, WebTypeEnum.WebAllAddresses);
                Assert.NotNull(webAllAddresses);

                List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;
                Assert.NotNull(tvItemModelParentList);

                TVItemModel tvItemModelParent = tvItemModelParentList.Last();
                Assert.NotNull(tvItemModelParent);

                Assert.True(webAllAddresses.AddressModelList.Count > 3);

                AddressModel addressModelToDelete = (from c in webAllAddresses.AddressModelList
                                                     select c).Skip(skip).Take(1).First();

                TVItemLocalModel postTVItemModel = new TVItemLocalModel()
                {
                    TVItem = addressModelToDelete.TVItemModel.TVItem,
                    TVItemLanguageList = addressModelToDelete.TVItemModel.TVItemLanguageList,
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
                Assert.Equal(WebTypeEnum.WebAllAddresses, toRecreateList[0].WebType);

                DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPJSONPathLocal"] }");
                Assert.True(di.Exists);
                List<FileInfo> fiList = di.GetFiles().ToList();
                Assert.Single(fiList);

                FileInfo fi = new FileInfo($"{ Configuration["CSSPJSONPathLocal"] }{ WebTypeEnum.WebAllAddresses }.gz");
                Assert.True(fi.Exists);

                await LoadWebType(1, WebTypeEnum.WebAllAddresses);

                AddressModel addressModel = (from c in webAllAddresses.AddressModelList
                                             where c.TVItemModel.TVItem.TVItemID == addressModelToDelete.TVItemModel.TVItem.TVItemID
                                             select c).FirstOrDefault();
                Assert.NotNull(addressModel);
                Assert.Equal(DBCommandEnum.Modified, addressModel.TVItemModel.TVItem.DBCommand);

                Assert.Equal(postTVItemModel.TVItem.TVItemID, addressModel.TVItemModel.TVItem.TVItemID);
                Assert.Equal(tvItemModelParent.TVItem.TVItemID, addressModel.TVItemModel.TVItem.ParentID);

                Assert.Equal(postTVItemModel.TVItemLanguageList[0].TVText, addressModel.TVItemModel.TVItemLanguageList[0].TVText);
                Assert.Equal(postTVItemModel.TVItemLanguageList[1].TVText, addressModel.TVItemModel.TVItemLanguageList[1].TVText);
            }
        }
    }
}
