/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPWebModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CSSPAzureAppTaskServices.Tests
{
    public partial class AzureAppTaskServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_Good_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            List<AppTaskLocalModel> appTaskModelListRet = await TestGetAllAsync();
            Assert.Empty(appTaskModelListRet);

            // ----------- 
            // TestAddOrModify
            AppTaskLocalModel appTaskLocalModelRet = await TestAddAsync(appTaskModel);
            Assert.NotNull(appTaskLocalModelRet);
            Assert.NotNull(appTaskLocalModelRet.AppTask);
            Assert.NotEmpty(appTaskLocalModelRet.AppTaskLanguageList);


            appTaskModelListRet = await TestGetAllAsync();
            Assert.NotEmpty(appTaskModelListRet);

            // ----------- 
            // TestDelete
            await TestDeleteAsync(appTaskLocalModelRet.AppTask.AppTaskID);

            appTaskModelListRet = await TestGetAllAsync();
            Assert.Empty(appTaskModelListRet);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AlreayExist_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            List<AppTaskLocalModel> postAppTaskModelListRet = await TestGetAllAsync();
            Assert.Empty(postAppTaskModelListRet);

            AppTaskLocalModel postAppTaskModelRet = await TestAddAsync(appTaskModel);
            Assert.NotNull(postAppTaskModelRet);
            Assert.NotNull(postAppTaskModelRet.AppTask);
            Assert.NotEmpty(postAppTaskModelRet.AppTaskLanguageList);

            AppTaskLocalModel appTaskModel2 = FillAppTaskModel();
            await TestAddErrorAsync(appTaskModel2, string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_DBCommand_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.DBCommand = (DBCommandEnum)10000;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_TVItemID_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.TVItemID = 0;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_TVItemID2_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.TVItemID2 = 0;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskCommand_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.AppTaskCommand = (AppTaskCommandEnum)10000;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskStatus_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.AppTaskStatus = (AppTaskStatusEnum)10000;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_PercentCompleted_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.PercentCompleted = -1;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_Language_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.Language = (LanguageEnum)10000;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_StartDateTime_UTC_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.StartDateTime_UTC = new DateTime(1970, 1, 1);

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_EndDateTime_UTC_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.EndDateTime_UTC = new DateTime(1970, 1, 1);

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskLanguage_CountNot2_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList.Remove(appTaskModel.AppTaskLanguageList[appTaskModel.AppTaskLanguageList.Count - 1]);

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskLanguage_AppTaskLanguageID_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskLanguage_AppTaskID_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.AppTaskID = 1;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskLanguage_DBCommand_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].DBCommand = (DBCommandEnum)10000;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskLanguage_Language_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].Language = (LanguageEnum)10000;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskLanguage_StatusText_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].StatusText = "".PadLeft(251, 'a');

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskLanguage_ErrorText_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].ErrorText = "".PadLeft(251, 'a');

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_AppTaskLanguage_TranslationStatus_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].TranslationStatus = (TranslationStatusEnum)10000;

            await TestAddErrorAsync(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Add_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await CSSPAzureAppTaskServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskModel();

            CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact = null;

            await TestAddUnauthorizedAsync(appTaskModel, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
        }
    }
}
