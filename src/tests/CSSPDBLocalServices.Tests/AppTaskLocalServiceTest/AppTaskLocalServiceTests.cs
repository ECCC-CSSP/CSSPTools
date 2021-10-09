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
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class AppTaskLocalServiceTest : CSSPDBLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Constructor_Good_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_Good_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyAppTaskLocal_Good_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            var actionTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelRes.Result).Value);
            AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);

            string StatusText = "New Status Text";
            string ErrorText = "New Error Text";

            appTaskModelRet.AppTask.DBCommand = DBCommandEnum.Modified;
            appTaskModelRet.AppTaskLanguageList[0].DBCommand = DBCommandEnum.Modified;
            appTaskModelRet.AppTaskLanguageList[0].StatusText = StatusText;
            appTaskModelRet.AppTaskLanguageList[0].ErrorText = ErrorText;
            appTaskModelRet.AppTaskLanguageList[1].DBCommand = DBCommandEnum.Modified;
            appTaskModelRet.AppTaskLanguageList[1].StatusText = StatusText;
            appTaskModelRet.AppTaskLanguageList[1].ErrorText = ErrorText;

            actionTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskModel);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelRes.Result).Value);
            appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);

            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet.AppTask.DBCommand);
            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet.AppTaskLanguageList[0].DBCommand);
            Assert.Equal(StatusText, appTaskModelRet.AppTaskLanguageList[0].StatusText);
            Assert.Equal(ErrorText, appTaskModelRet.AppTaskLanguageList[0].ErrorText);
            Assert.Equal(DBCommandEnum.Modified, appTaskModelRet.AppTaskLanguageList[1].DBCommand);
            Assert.Equal(StatusText, appTaskModelRet.AppTaskLanguageList[1].StatusText);
            Assert.Equal(ErrorText, appTaskModelRet.AppTaskLanguageList[1].ErrorText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AlreayExist_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            var actionTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelRes.Result).Value);
            AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);

            AppTaskLocalModel appTaskModel2 = FillAppTaskLocalModel();

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ModifyAppTaskLocal_CouldNotFind_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.AppTaskID = -100000;
            appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = -1;
            appTaskModel.AppTaskLanguageList[1].AppTaskLanguageID = -1;
            appTaskModel.AppTaskLanguageList[0].AppTaskID = -1;
            appTaskModel.AppTaskLanguageList[1].AppTaskID = -1;

            var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteAppTaskLocal_NotFound_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            var actionTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(200, ((ObjectResult)actionTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemModelRes.Result).Value);
            AppTaskLocalModel appTaskModelRet = (AppTaskLocalModel)((OkObjectResult)actionTVItemModelRes.Result).Value;
            Assert.NotNull(appTaskModelRet);

            appTaskModelRet.AppTask.AppTaskID = -100000;

            var actionPostTVItemModelRes = await AppTaskLocalService.DeleteAppTaskLocal(appTaskModelRet);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_DBCommand_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.DBCommand = (DBCommandEnum)10000;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
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
        public async Task AddAppTaskLocal_TVItemID_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.TVItemID = 0;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_TVItemID2_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.TVItemID2 = 0;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVItemID2"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskCommand_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.AppTaskCommand = (AppTaskCommandEnum)10000;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskCommand"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskStatus_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.AppTaskStatus = (AppTaskStatusEnum)10000;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskStatus"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_PercentCompleted_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.PercentCompleted = -1;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "PercentCompleted"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_Language_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.Language = (LanguageEnum)10000;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
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
        public async Task AddAppTaskLocal_StartDateTime_UTC_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.StartDateTime_UTC = new DateTime(1970, 1, 1);

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "StartDateTime_UTC", "1979"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_EndDateTime_UTC_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.EndDateTime_UTC = new DateTime(1970, 1, 1);

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "EndDateTime_UTC", "1979"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskLanguage_CountNot2_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTaskLanguageList.Remove(appTaskModel.AppTaskLanguageList[appTaskModel.AppTaskLanguageList.Count - 1]);

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "appTaskModel.AppTaskLanguageList.Count", "2"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskLanguage_AppTaskLanguageID_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTaskLanguageList[0].AppTaskLanguageID = 1;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskLanguageID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskLanguage_AppTaskID_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTaskLanguageList[0].AppTaskID = 1;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AppTaskID", "0"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskLanguage_DBCommand_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTaskLanguageList[0].DBCommand = (DBCommandEnum)10000;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
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
        public async Task AddAppTaskLocal_AppTaskLanguage_Language_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTaskLanguageList[0].Language = (LanguageEnum)10000;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "Language", "en"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskLanguage_StatusText_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTaskLanguageList[0].StatusText = "".PadLeft(251, 'a');

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StatusText", 250), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskLanguage_ErrorText_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTaskLanguageList[0].ErrorText = "".PadLeft(251, 'a');

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorText", 250), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_AppTaskLanguage_TranslationStatus_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTaskLanguageList[0].TranslationStatus = (TranslationStatusEnum)10000;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
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
        public async Task DeleteAppTaskModel_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.AppTaskID = 0;

            var actionPostTVItemModelRes = await AppTaskLocalService.DeleteAppTaskLocal(appTaskModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddAppTaskLocal_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

            var actionPostTVItemModelRes = await AppTaskLocalService.AddAppTaskLocal(appTaskModel);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task DeleteAppTaskModel_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            appTaskModel.AppTask.AppTaskID = 1000;

            CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

            var actionPostTVItemModelRes = await AppTaskLocalService.DeleteAppTaskLocal(appTaskModel);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task GetAllAppTaskLocal_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

            var actionPostTVItemModelRes = await AppTaskLocalService.GetAllAppTaskLocal();
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), errRes.ErrList);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddModifyTaskLocal_Unauthorized_Error_Test(string culture)
        {
            Assert.True(await AppTaskLocalServiceSetup(culture));

            AppTaskLocalModel appTaskModel = FillAppTaskLocalModel();

            CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

            var actionPostTVItemModelRes = await AppTaskLocalService.ModifyAppTaskLocal(appTaskModel);
            Assert.Equal(401, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value);
            ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.NotNull(errRes);
            Assert.NotEmpty(errRes.ErrList);
            Assert.Contains(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), errRes.ErrList);
        }
    }
}
