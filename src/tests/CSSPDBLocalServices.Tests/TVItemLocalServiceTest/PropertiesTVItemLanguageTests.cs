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
        public async Task Properties_TVItemLanguage_EN_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].DBCommand = (DBCommandEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_TVItemLanguage_EN_TVItemLanguageID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVItemLanguageID = 1;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemLanguageID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_TVItemLanguage_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVItemID = 1;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PropertiesLanguage_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].Language = (LanguageEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_TVText_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TVText = "";

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PropertiesTranslationStatus_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.en - 1].TranslationStatus = (TranslationStatusEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_TVItemLanguage_FR_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].DBCommand = (DBCommandEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_TVItemLanguage_FR_TVItemLanguageID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVItemLanguageID = 1;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemLanguageID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_TVItemLanguage_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVItemID = 1;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "TVItemID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_Language_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].Language = (LanguageEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "Language"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_TVText_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TVText = "";

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVText"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Properties_TranslationStatus_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture));

            TVItemLocalModel postTVItemModel = await FillTVItemLocalModelForAdd(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, TVTypeEnum.Province);

            postTVItemModel.TVItemLanguageList[(int)LanguageEnum.fr - 1].TranslationStatus = (TranslationStatusEnum)10000;

            var actionPostTVItemModelRes = await TVItemLocalService.AddTVItemLocal(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"), errRes.ErrList);
        }
    }
}
