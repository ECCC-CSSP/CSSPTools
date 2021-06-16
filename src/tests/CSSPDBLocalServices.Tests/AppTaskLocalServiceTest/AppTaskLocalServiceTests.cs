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
    [Collection("Sequential")]
    public partial class AppTaskLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            Assert.NotNull(db);
            Assert.NotNull(dbLocal);
            Assert.NotNull(dbManage);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.NotNull(FileService);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(CreateGzFileService);
            Assert.NotNull(ReadGzFileService);
            Assert.NotNull(AppTaskLocalService);
            Assert.NotNull(TVItemLocalService);
            Assert.NotNull(CSSPSQLiteService);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_Add_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            await CreateCSSPDBLocal();

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            List<PostAppTaskModel> appTaskModelListRet2 = await TestGetAll();
            int appTaskModelCount = appTaskModelListRet2.Count;

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            List<PostAppTaskModel> appTaskModelListRet = await TestGetAll();
            Assert.True(appTaskModelListRet.Count > 0);
            Assert.Equal(appTaskModelCount + 1, appTaskModelListRet.Count);

            Assert.True(await TestDelete(appTaskModelRet.AppTask.AppTaskID));

            List<PostAppTaskModel> appTaskModelListRet3 = await TestGetAll();
            Assert.Equal(appTaskModelCount, appTaskModelListRet3.Count);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_Modify_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            await CreateCSSPDBLocal();

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

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

            Assert.True(await TestDelete(appTaskModelRet.AppTask.AppTaskID));

            List<PostAppTaskModel> appTaskModelListRet3 = await TestGetAll();
            Assert.Equal(appTaskModelCount, appTaskModelListRet3.Count);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_Add_AlreayExist_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            List<PostAppTaskModel> appTaskModelListRet2 = await TestGetAll();
            int appTaskModelCount = appTaskModelListRet2.Count;

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            PostAppTaskModel appTaskModel2 = FillPostAppTaskModel();
            await TestAddOrModifyError(appTaskModel2, string.Format(CSSPCultureServicesRes._AlreadyExists, "AppTask"));

            Assert.True(await TestDelete(appTaskModelRet.AppTask.AppTaskID));

            List<PostAppTaskModel> appTaskModelListRet3 = await TestGetAll();
            Assert.Equal(appTaskModelCount, appTaskModelListRet3.Count);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_Modify_CouldNotFind_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            List<PostAppTaskModel> appTaskModelListRet2 = await TestGetAll();
            int appTaskModelCount = appTaskModelListRet2.Count;

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            int AppTaskIDToDelete = appTaskModelRet.AppTask.AppTaskID;

            PostAppTaskModel appTaskModel2 = FillPostAppTaskModel();
            appTaskModel2.AppTask.AppTaskID = -100000;
            appTaskModel2.AppTaskLanguageList[0].AppTaskLanguageID = -1;
            appTaskModel2.AppTaskLanguageList[1].AppTaskLanguageID = -1;
            appTaskModel2.AppTaskLanguageList[0].AppTaskID = -1;
            appTaskModel2.AppTaskLanguageList[1].AppTaskID = -1;
            await TestAddOrModifyError(appTaskModel2, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskModel2.AppTask.AppTaskID.ToString()));

            Assert.True(await TestDelete(appTaskModelRet.AppTask.AppTaskID));

            List<PostAppTaskModel> appTaskModelListRet3 = await TestGetAll();
            Assert.Equal(appTaskModelCount, appTaskModelListRet3.Count);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_DeleteAppTaskModel_AppTask_NotFound_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            List<PostAppTaskModel> appTaskModelListRet2 = await TestGetAll();
            int appTaskModelCount = appTaskModelListRet2.Count;

            PostAppTaskModel appTaskModelRet = await TestAddOrModify(appTaskModel);

            int AppTaskID = -100000;

            await TestDeleteError(AppTaskID, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", AppTaskID.ToString()));

            Assert.True(await TestDelete(appTaskModelRet.AppTask.AppTaskID));

            List<PostAppTaskModel> appTaskModelListRet3 = await TestGetAll();
            Assert.Equal(appTaskModelCount, appTaskModelListRet3.Count);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_DBCommand_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.DBCommand = (DBCommandEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_TVItemID_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.TVItemID = 0;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_TVItemID2_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.TVItemID2 = 0;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskCommand_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.AppTaskCommand = (AppTaskCommandEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskStatus_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.AppTaskStatus = (AppTaskStatusEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_PercentCompleted_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.PercentCompleted = -1;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_Language_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.Language = (LanguageEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "Language"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_StartDateTime_UTC_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.StartDateTime_UTC = new DateTime(1970, 1, 1);

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_EndDateTime_UTC_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.EndDateTime_UTC = new DateTime(1970, 1, 1);

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskLanguage_CountNot2_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTaskLanguageList.Remove(appTaskModel.AppTaskLanguageList[appTaskModel.AppTaskLanguageList.Count - 1]);

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskLanguage_AppTaskLanguageID_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskLanguage_AppTaskID_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTask.AppTaskID = 1;
            appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 0;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskLanguage_DBCommand_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].DBCommand = (DBCommandEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "DBCommand"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskLanguage_Language_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].Language = (LanguageEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskLanguage_StatusText_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].StatusText = "".PadLeft(251, 'a');

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskLanguage_ErrorText_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].ErrorText = "".PadLeft(251, 'a');

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_AppTaskLanguage_TranslationStatus_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            appTaskModel.AppTaskLanguageList[0].TranslationStatus = (TranslationStatusEnum)10000;

            await TestAddOrModifyError(appTaskModel, string.Format(CSSPCultureServicesRes._IsRequired, "TranslationStatus"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_DeleteAppTaskModel_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            int AppTaskID = 0;

            await TestDeleteError(AppTaskID, string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_AddOrModifyLocal_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            PostAppTaskModel appTaskModel = FillPostAppTaskModel();

            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

            await TestAddOrModifyUnauthorized(appTaskModel, string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_DeleteAppTaskModel_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            int AppTaskID = 1000;

            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

            await TestDeleteUnauthorized(AppTaskID, string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AppTaskLocalService_GetAllAppTaskModel_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            LoggedInService.LoggedInContactInfo.LoggedInContact = null;

            await TestGetAllUnauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
        }
    }
}
