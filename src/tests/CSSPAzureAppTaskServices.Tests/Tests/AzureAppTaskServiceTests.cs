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

namespace CSSPAzureAppTaskServices.Tests
{
    [Collection("Sequential")]
    public partial class AzureAppTaskServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.NotNull(db);
            Assert.NotNull(AzureAppTaskService);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_Add_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            List<PostAppTaskModel> appTaskModelListRet2 = await TestGetAll();
            int appTaskModelCount = appTaskModelListRet2.Count;

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            List<PostAppTaskModel> appTaskModelListRet = await TestGetAll();
            Assert.True(appTaskModelListRet.Count > 0);
            Assert.Equal(appTaskModelCount + 1, appTaskModelListRet.Count);

            await TestDelete(appTaskModelRet.AppTask.AppTaskID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_Modify_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            List<PostAppTaskModel> appTaskModelListRet2 = await TestGetAll();
            int appTaskModelCount = appTaskModelListRet2.Count;

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            string StatusText = "New Status Text";
            string ErrorText = "New Error Text";

            appTaskModelRet.AppTask.DBCommand = DBCommandEnum.Modified;
            appTaskModelRet.AppTaskLanguageList[0].DBCommand = DBCommandEnum.Modified;
            appTaskModelRet.AppTaskLanguageList[0].StatusText = StatusText;
            appTaskModelRet.AppTaskLanguageList[0].ErrorText = ErrorText;
            appTaskModelRet.AppTaskLanguageList[1].DBCommand = DBCommandEnum.Modified;
            appTaskModelRet.AppTaskLanguageList[1].StatusText = StatusText;
            appTaskModelRet.AppTaskLanguageList[1].ErrorText = ErrorText;

            PostAppTaskModel appTaskModelRet5 = await TestAddOrModify(appTaskModelRet);

            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTask.DBCommand);
            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTaskLanguageList[0].DBCommand);
            Assert.Equal(StatusText, appTaskModelRet5.AppTaskLanguageList[0].StatusText);
            Assert.Equal(ErrorText, appTaskModelRet5.AppTaskLanguageList[0].ErrorText);
            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet5.AppTaskLanguageList[1].DBCommand);
            Assert.Equal(StatusText, appTaskModelRet5.AppTaskLanguageList[1].StatusText);
            Assert.Equal(ErrorText, appTaskModelRet5.AppTaskLanguageList[1].ErrorText);

            List<PostAppTaskModel> appTaskModelListRet = await TestGetAll();

            Assert.True(appTaskModelListRet.Count > 0);
            Assert.Equal(appTaskModelCount + 1, appTaskModelListRet.Count);

            await TestDelete(appTaskModelRet.AppTask.AppTaskID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_Add_AlreayExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            PostAppTaskModel appTaskModel2 = FillAppTaskModel();
            await TestAddOrModifyError(appTaskModel2, string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));

            await TestDelete(appTaskModelRet.AppTask.AppTaskID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_Modify_CouldNotFind_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            int AppTaskIDToDelete = appTaskModelRet.AppTask.AppTaskID;

            PostAppTaskModel appTaskModel2 = FillAppTaskModel();
            appTaskModel2.AppTask.AppTaskID = -1;
            appTaskModel2.AppTaskLanguageList[0].AppTaskLanguageID = -1;
            appTaskModel2.AppTaskLanguageList[1].AppTaskLanguageID = -1;
            appTaskModel2.AppTaskLanguageList[0].AppTaskID = -1;
            appTaskModel2.AppTaskLanguageList[1].AppTaskID = -1;
            await TestAddOrModifyError(appTaskModel2, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskModel2.AppTask.AppTaskID.ToString()));

            await TestDelete(AppTaskIDToDelete);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_DeleteAzureAppTask_AppTask_NotFound_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            int AppTaskID = -1;

            await TestDeleteError(AppTaskID, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()));

            await TestDelete(appTaskModelRet.AppTask.AppTaskID);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_DBCommand_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.DBCommand = (DBCommandEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_TVItemID_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.TVItemID = 0;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_TVItemID2_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.TVItemID2 = 0;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskCommand_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.AppTaskCommand = (AppTaskCommandEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskStatus_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.AppTaskStatus = (AppTaskStatusEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_PercentCompleted_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.PercentCompleted = -1;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_Language_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.Language = (LanguageEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_StartDateTime_UTC_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.StartDateTime_UTC = new DateTime(1970, 1, 1);

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_EndDateTime_UTC_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.EndDateTime_UTC = new DateTime(1970, 1, 1);

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskLanguage_CountNot2_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList.Remove(appTaskModel.AppTaskLanguageList[appTaskModel.AppTaskLanguageList.Count - 1]);

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskLanguage_AppTaskLanguageID_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskLanguage_AppTaskID_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTask.AppTaskID = 1;
            appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 0;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskLanguage_DBCommand_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].DBCommand = (DBCommandEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskLanguage_Language_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].Language = (LanguageEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskLanguage_StatusText_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].StatusText = "".PadLeft(251,'a');

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskLanguage_ErrorText_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].ErrorText = "".PadLeft(251, 'a');

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_AppTaskLanguage_TranslationStatus_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].TranslationStatus = (TranslationStatusEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_DeleteAzureAppTask_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int AppTaskID = 0;

            await TestDeleteError(AppTaskID, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_AddOrModifyAzureAppTask_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostAppTaskModel appTaskModel = FillAppTaskModel();

            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

            await TestAddOrModifyUnauthorized(appTaskModel, string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_DeleteAzureAppTask_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int AppTaskID = 1000;

            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

            await TestDeleteUnauthorized(AppTaskID, string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AzureAppTaskService_GetAllAzureAppTask_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

            await TestGetAllUnauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }
    }
}
