/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPReadGzFileServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ManageServices;
using System.IO;

namespace CSSPDBLocalServices.Tests
{
    public partial class ProvinceLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_Existing_Good_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);

            TVItemModel tvItemModelProvinceToModify = webCountry.TVItemModelProvinceList[0];

            string TVTextEN = "Changed Province";
            string TVTextFR = "Province changé";

            var actionProvinceRes = await ProvinceLocalService.ModifyTVTextProvinceLocal(ParentTVItemID, tvItemModelProvinceToModify.TVItem.TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionProvinceRes.Result).Value);
            TVItemModel tvItemModelChangedRet = (TVItemModel)((OkObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(tvItemModelChangedRet);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, 0);

            TVItemModel tvItemModelRet = (from c in webCountry.TVItemModelProvinceList
                                          where c.TVItem.TVItemID == tvItemModelProvinceToModify.TVItem.TVItemID
                                          select c).FirstOrDefault();

            Assert.NotNull(tvItemModelRet);

            CheckTVItem(webCountry.TVItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.en);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.fr);

            CheckTVItem(tvItemModelRet, DBCommandEnum.Original);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Modified, TVTextEN, LanguageEnum.en);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Modified, TVTextFR, LanguageEnum.fr);

            List<TVItemModel> tvItemModelList = new List<TVItemModel>()
            {
                webCountry.TVItemModel,
                tvItemModelChangedRet,
            };

            CheckDBLocal(tvItemModelList);

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

            Assert.True(di.Exists);

            List<FileInfo> fiList = di.GetFiles().ToList();

            Assert.Equal(3, fiList.Count);

            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllProvinces }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebProvince }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ ParentTVItemID }.gz").Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_Good_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            int ParentTVItemID = 5;

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, ParentTVItemID);

            var actionProvinceRes = await ProvinceLocalService.AddProvinceLocal(webCountry.TVItemModel.TVItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionProvinceRes.Result).Value);
            TVItemModel tvItemModelRet = (TVItemModel)((OkObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(tvItemModelRet);

            // see AddProvinceLocal test for more detail testing

            string TVTextEN = "Modified Province";
            string TVTextFR = "Province modifié";

            var actionProvinceRes2 = await ProvinceLocalService.ModifyTVTextProvinceLocal(ParentTVItemID, tvItemModelRet.TVItem.TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(200, ((ObjectResult)actionProvinceRes2.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionProvinceRes2.Result).Value);
            TVItemModel tvItemModelModifiedRet = (TVItemModel)((OkObjectResult)actionProvinceRes2.Result).Value;
            Assert.NotNull(tvItemModelModifiedRet);

            webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, 0);

            tvItemModelRet = (from c in webCountry.TVItemModelProvinceList
                              where c.TVItem.TVItemID == tvItemModelRet.TVItem.TVItemID
                              select c).FirstOrDefault();

            Assert.NotNull(tvItemModelRet);

            CheckTVItem(webCountry.TVItemModel, DBCommandEnum.Original);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.en);
            CheckTVItemLanguage(webCountry.TVItemModel, DBCommandEnum.Original, "Canada", LanguageEnum.fr);

            CheckTVItem(tvItemModelRet, DBCommandEnum.Created);
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, TVTextEN, LanguageEnum.en); // Created stays created when modified
            CheckTVItemLanguage(tvItemModelRet, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr); // Created stays created when modified

            List<TVItemModel> tvItemModelList = new List<TVItemModel>()
            {
                webCountry.TVItemModel,
                tvItemModelModifiedRet,
            };

            CheckDBLocal(tvItemModelList);

            DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

            Assert.True(di.Exists);

            List<FileInfo> fiList = di.GetFiles().ToList();

            Assert.Equal(3, fiList.Count);

            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllProvinces }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebProvince }_{ tvItemModelRet.TVItem.TVItemID }.gz").Any());
            Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebCountry }_{ ParentTVItemID }.gz").Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_ParentTVItemID_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            string TVTextEN = "Modified Province";
            string TVTextFR = "Province modifié";

            int ParentTVItemID = 0;
            int TVItemID = 7;

            var actionProvinceRes = await ProvinceLocalService.ModifyTVTextProvinceLocal(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_TVItemID_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            string TVTextEN = "Modified Province";
            string TVTextFR = "Province modifié";

            int ParentTVItemID = 5;
            int TVItemID = 0;

            var actionProvinceRes = await ProvinceLocalService.ModifyTVTextProvinceLocal(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_TVTextEN_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, 0);

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);

            TVItemModel tvItemModelProvinceToModify = webCountry.TVItemModelProvinceList[0];

            string TVTextEN = "";
            string TVTextFR = "Province modifié";

            var actionProvinceRes = await ProvinceLocalService.ModifyTVTextProvinceLocal(webCountry.TVItemModel.TVItem.TVItemID, tvItemModelProvinceToModify.TVItem.TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_TVTextFR_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, 0);

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);

            TVItemModel tvItemModelProvinceToModify = webCountry.TVItemModelProvinceList[0];

            string TVTextEN = "Modified Province";
            string TVTextFR = "";

            var actionProvinceRes = await ProvinceLocalService.ModifyTVTextProvinceLocal(webCountry.TVItemModel.TVItem.TVItemID, tvItemModelProvinceToModify.TVItem.TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_CouldNotFind_WebCountry_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, 0);

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);

            TVItemModel tvItemModelProvinceToModify = webCountry.TVItemModelProvinceList[0];

            string TVTextEN = "Modified Province";
            string TVTextFR = "Province Changé";

            int ParentTVItemID = 100000;
            int TVItemID = 7;

            var actionProvinceRes = await ProvinceLocalService.ModifyTVTextProvinceLocal(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_CouldNotFind_Province_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, 0);

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);

            TVItemModel tvItemModelProvinceToModify = webCountry.TVItemModelProvinceList[0];

            string TVTextEN = "Modified Province";
            string TVTextFR = "Province Changé";

            int ParentTVItemID = 5;
            int TVItemID = 100000;

            var actionProvinceRes = await ProvinceLocalService.ModifyTVTextProvinceLocal(ParentTVItemID, TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "TVItemModel", "TVItemID", $"{ TVItemID }"), errRes.ErrList[0]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyProvinceLocal_SiblingWithSameName_Error_Test(string culture)
        {
            Assert.True(await ProvinceLocalServiceSetup(culture));

            WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, 0);

            Assert.NotEmpty(webCountry.TVItemModelProvinceList);
            Assert.True(webCountry.TVItemModelProvinceList.Count > 1);

            TVItemModel tvItemModelProvinceToDelete = webCountry.TVItemModelProvinceList[1];

            string TVTextEN = webCountry.TVItemModelProvinceList[0].TVItemLanguageList[0].TVText;
            string TVTextFR = webCountry.TVItemModelProvinceList[0].TVItemLanguageList[1].TVText;

            string message = $"{ TVTextEN } (en)     { TVTextFR } (fr)";

            CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._AlreadyExists, message));
            var actionProvinceRes = await ProvinceLocalService.ModifyTVTextProvinceLocal(webCountry.TVItemModel.TVItem.TVItemID, tvItemModelProvinceToDelete.TVItem.TVItemID, TVTextEN, TVTextFR);
            Assert.Equal(400, ((ObjectResult)actionProvinceRes.Result).StatusCode);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionProvinceRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, message), errRes.ErrList[0]);
        }
    }
}
