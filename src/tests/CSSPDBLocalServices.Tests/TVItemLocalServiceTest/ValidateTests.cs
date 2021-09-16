/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public async Task TVItemLocalService_Validate_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItem", "DBCommand", string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVType_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItem", "TVType", string.Format(CSSPCultureServicesRes._IsRequired, "TVType"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVLevel_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItem", "TVLevel", string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVPath_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItem", "TVPath", string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_ParentID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItem", "ParentID", string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemParent_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemParent", "DBCommand", string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemParent_TVType_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemParent", "TVType", string.Format(CSSPCultureServicesRes._IsRequired, "TVType"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemParent_TVLevel_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemParent", "TVLevel", string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemParent_TVPath_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemParent", "TVPath", string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemParent_ParentID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemParent", "ParentID", string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemGrandParent_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemGrandParent", "DBCommand", string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemGrandParent_TVType_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemGrandParent", "TVType", string.Format(CSSPCultureServicesRes._IsRequired, "TVType"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemGrandParent_TVLevel_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemGrandParent", "TVLevel", string.Format(CSSPCultureServicesRes._IsRequired, "TVLevel"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemGrandParent_TVPath_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemGrandParent", "TVPath", string.Format(CSSPCultureServicesRes._IsRequired, "TVPath"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemGrandParent_ParentID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemGrandParent", "ParentID", string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_EN_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageEN", "DBCommand", string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_EN_TVItemLanguageID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageEN", "TVItemLanguageID", string.Format(CSSPCultureServicesRes._IsRequired, "TVItemLanguageID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_EN_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageEN", "TVItemID", string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_EN_Language_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageEN", "Language", string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_EN_TVText_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageEN", "TVText", string.Format(CSSPCultureServicesRes._IsRequired, "TVText"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_EN_TranslationStatus_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageEN", "TranslationStatus", string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_FR_DBCommand_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageFR", "DBCommand", string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_FR_TVItemLanguageID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageFR", "TVItemLanguageID", string.Format(CSSPCultureServicesRes._IsRequired, "TVItemLanguageID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_FR_TVItemID_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageFR", "TVItemID", string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_FR_Language_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageFR", "Language", string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_FR_TVText_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageFR", "TVText", string.Format(CSSPCultureServicesRes._IsRequired, "TVText"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Validate_TVItemLanguage_FR_TranslationStatus_Error_Test(string culture)
        {
            Assert.True(await TVItemLocalServiceSetup(culture, false));

            await DoValidateTest(7, WebTypeEnum.WebProvince, TVTypeEnum.Area, "TVItemLanguageFR", "TranslationStatus", string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
        }
    }
}
