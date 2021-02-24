using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CSSPCultureServices.Resources;
using CSSPDBCommandLogModels;

namespace CSSPDBCommandLogServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPDBCommandLogServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBCommandLogService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPDBCommandLogService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBCommandLogService_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPCommandLog csspCSSPCommandLog = new CSSPCommandLog()
            {
                //CSSPCommandLogID = 1000000,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            CSSPDBCommandLogService.dbCommandLog.Database.BeginTransaction();

            // testing Post
            var actionCSSPCommandLogPost = await CSSPDBCommandLogService.Post(csspCSSPCommandLog);
            Assert.Equal(200, ((ObjectResult)actionCSSPCommandLogPost.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPCommandLogPost.Result).Value);
            CSSPCommandLog csspCSSPCommandLogNewPost = (CSSPCommandLog)((OkObjectResult)actionCSSPCommandLogPost.Result).Value;
            Assert.NotNull(csspCSSPCommandLogNewPost);
            Assert.Equal(csspCSSPCommandLog.CSSPCommandLogID, csspCSSPCommandLogNewPost.CSSPCommandLogID);
            Assert.Equal(csspCSSPCommandLog.AppName, csspCSSPCommandLogNewPost.AppName);
            Assert.Equal(csspCSSPCommandLog.CommandName, csspCSSPCommandLogNewPost.CommandName);
            Assert.Equal(csspCSSPCommandLog.Successful, csspCSSPCommandLogNewPost.Successful);
            Assert.Equal(csspCSSPCommandLog.ErrorMessage, csspCSSPCommandLogNewPost.ErrorMessage);
            Assert.Equal(csspCSSPCommandLog.DateTimeUTC, csspCSSPCommandLogNewPost.DateTimeUTC);

            // testing Put
            csspCSSPCommandLogNewPost.AppName = "NewAppName";
            var actionCSSPCommandLogPut = await CSSPDBCommandLogService.Put(csspCSSPCommandLogNewPost);
            Assert.Equal(200, ((ObjectResult)actionCSSPCommandLogPut.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPCommandLogPut.Result).Value);
            CSSPCommandLog csspCSSPCommandLogNewPut = (CSSPCommandLog)((OkObjectResult)actionCSSPCommandLogPut.Result).Value;
            Assert.NotNull(csspCSSPCommandLogNewPut);
            Assert.Equal(csspCSSPCommandLogNewPost.CSSPCommandLogID, csspCSSPCommandLogNewPut.CSSPCommandLogID);
            Assert.Equal(csspCSSPCommandLogNewPost.AppName, csspCSSPCommandLogNewPut.AppName);
            Assert.Equal(csspCSSPCommandLogNewPost.CommandName, csspCSSPCommandLogNewPut.CommandName);
            Assert.Equal(csspCSSPCommandLogNewPost.Successful, csspCSSPCommandLogNewPut.Successful);
            Assert.Equal(csspCSSPCommandLog.ErrorMessage, csspCSSPCommandLogNewPost.ErrorMessage);
            Assert.Equal(csspCSSPCommandLogNewPost.DateTimeUTC, csspCSSPCommandLogNewPut.DateTimeUTC);

            // testing GetWithCSSPCommandLogID
            var actionCSSPCommandLogGetWithID = await CSSPDBCommandLogService.GetWithCSSPCommandLogID(csspCSSPCommandLogNewPut.CSSPCommandLogID);
            Assert.Equal(200, ((ObjectResult)actionCSSPCommandLogGetWithID.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPCommandLogGetWithID.Result).Value);
            CSSPCommandLog csspCSSPCommandLogNewGetWithID = (CSSPCommandLog)((OkObjectResult)actionCSSPCommandLogGetWithID.Result).Value;
            Assert.NotNull(csspCSSPCommandLogNewGetWithID);
            Assert.Equal(csspCSSPCommandLogNewPut.CSSPCommandLogID, csspCSSPCommandLogNewGetWithID.CSSPCommandLogID);
            Assert.Equal(csspCSSPCommandLogNewPut.AppName, csspCSSPCommandLogNewGetWithID.AppName);
            Assert.Equal(csspCSSPCommandLogNewPut.CommandName, csspCSSPCommandLogNewGetWithID.CommandName);
            Assert.Equal(csspCSSPCommandLogNewPut.Successful, csspCSSPCommandLogNewGetWithID.Successful);
            Assert.Equal(csspCSSPCommandLog.ErrorMessage, csspCSSPCommandLogNewPost.ErrorMessage);
            Assert.Equal(csspCSSPCommandLogNewPut.DateTimeUTC, csspCSSPCommandLogNewGetWithID.DateTimeUTC);

            // testing GetCSSPCommandLogTodayList
            var actionCSSPCommandLogGetCSSPCommandLogTodayList = await CSSPDBCommandLogService.GetCSSPCommandLogTodayList();
            Assert.Equal(200, ((ObjectResult)actionCSSPCommandLogGetCSSPCommandLogTodayList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPCommandLogGetCSSPCommandLogTodayList.Result).Value);
            List<CSSPCommandLog> csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList = (List<CSSPCommandLog>)((OkObjectResult)actionCSSPCommandLogGetCSSPCommandLogTodayList.Result).Value;
            Assert.NotNull(csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.CSSPCommandLogID, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList[0].CSSPCommandLogID);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.AppName, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList[0].AppName);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.CommandName, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList[0].CommandName);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.Successful, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList[0].Successful);
            Assert.Equal(csspCSSPCommandLog.ErrorMessage, csspCSSPCommandLogNewPost.ErrorMessage);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.DateTimeUTC, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList[0].DateTimeUTC);

            // testing GetCSSPCommandLogLastWeekList
            var actionCSSPCommandLogGetCSSPCommandLogLastWeekList = await CSSPDBCommandLogService.GetCSSPCommandLogLastWeekList();
            Assert.Equal(200, ((ObjectResult)actionCSSPCommandLogGetCSSPCommandLogLastWeekList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPCommandLogGetCSSPCommandLogLastWeekList.Result).Value);
            List<CSSPCommandLog> csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList2 = (List<CSSPCommandLog>)((OkObjectResult)actionCSSPCommandLogGetCSSPCommandLogLastWeekList.Result).Value;
            Assert.NotNull(csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList2);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.CSSPCommandLogID, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList2[0].CSSPCommandLogID);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.AppName, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList2[0].AppName);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.CommandName, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList2[0].CommandName);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.Successful, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList2[0].Successful);
            Assert.Equal(csspCSSPCommandLog.ErrorMessage, csspCSSPCommandLogNewPost.ErrorMessage);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.DateTimeUTC, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList2[0].DateTimeUTC);

            // testing GetCSSPCommandLogLastMonthList
            var actionCSSPCommandLogGetCSSPCommandLogLastMonthList = await CSSPDBCommandLogService.GetCSSPCommandLogLastMonthList();
            Assert.Equal(200, ((ObjectResult)actionCSSPCommandLogGetCSSPCommandLogLastMonthList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPCommandLogGetCSSPCommandLogLastMonthList.Result).Value);
            List<CSSPCommandLog> csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList3 = (List<CSSPCommandLog>)((OkObjectResult)actionCSSPCommandLogGetCSSPCommandLogLastMonthList.Result).Value;
            Assert.NotNull(csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList3);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.CSSPCommandLogID, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList3[0].CSSPCommandLogID);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.AppName, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList3[0].AppName);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.CommandName, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList3[0].CommandName);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.Successful, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList3[0].Successful);
            Assert.Equal(csspCSSPCommandLog.ErrorMessage, csspCSSPCommandLogNewPost.ErrorMessage);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.DateTimeUTC, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList3[0].DateTimeUTC);

            // testing GetCSSPCommandLogLastMonthList
            DateTime StartDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day - 1, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day + 4, 23, 59, 59);
            var actionCSSPCommandLogGetCSSPCommandLogBetweenDatesList = await CSSPDBCommandLogService.GetCSSPCommandLogBetweenDatesList(StartDate, EndDate);
            Assert.Equal(200, ((ObjectResult)actionCSSPCommandLogGetCSSPCommandLogBetweenDatesList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCSSPCommandLogGetCSSPCommandLogBetweenDatesList.Result).Value);
            List<CSSPCommandLog> csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList4 = (List<CSSPCommandLog>)((OkObjectResult)actionCSSPCommandLogGetCSSPCommandLogBetweenDatesList.Result).Value;
            Assert.NotNull(csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList4);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.CSSPCommandLogID, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList4[0].CSSPCommandLogID);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.AppName, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList4[0].AppName);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.CommandName, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList4[0].CommandName);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.Successful, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList4[0].Successful);
            Assert.Equal(csspCSSPCommandLog.ErrorMessage, csspCSSPCommandLogNewPost.ErrorMessage);
            Assert.Equal(csspCSSPCommandLogNewGetWithID.DateTimeUTC, csspCSSPCommandLogNewGetWithSuccessfulAndAppNameList4[0].DateTimeUTC);

            // testing GetCSSPCommandLogNextIndexToUse
            var actionGetCSSPCommandLogNextIndexToUse = await CSSPDBCommandLogService.GetCSSPCommandLogNextIndexToUse();
            Assert.Equal(200, ((ObjectResult)actionGetCSSPCommandLogNextIndexToUse.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionGetCSSPCommandLogNextIndexToUse.Result).Value);
            int? LastIndexRet = (int?)((OkObjectResult)actionGetCSSPCommandLogNextIndexToUse.Result).Value;
            Assert.NotNull(LastIndexRet);
            Assert.True(LastIndexRet > 0);

            // testing Delete
            var actionDelete = await CSSPDBCommandLogService.Delete(csspCSSPCommandLogNewPost.CSSPCommandLogID);
            Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
            bool DeleteRet = (bool)((OkObjectResult)actionDelete.Result).Value;
            Assert.True(DeleteRet);

            CSSPDBCommandLogService.dbCommandLog.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBCommandLogService_Unauthorized_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            CSSPCommandLog csspCSSPCommandLog = new CSSPCommandLog()
            {
                //CSSPCommandLogID = 1000000,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            CSSPDBCommandLogService.dbCommandLog.Database.BeginTransaction();

            var actionCSSPCommandLog1 = await CSSPDBCommandLogService.GetCSSPCommandLogNextIndexToUse();
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog1.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog1.Result).StatusCode);

            var actionCSSPCommandLog2 = await CSSPDBCommandLogService.GetWithCSSPCommandLogID(12345);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog2.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog2.Result).StatusCode);

            var actionCSSPCommandLog3 = await CSSPDBCommandLogService.GetCSSPCommandLogTodayList();
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog3.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog3.Result).StatusCode);

            var actionCSSPCommandLog4 = await CSSPDBCommandLogService.GetCSSPCommandLogLastWeekList();
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog4.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog4.Result).StatusCode);

            var actionCSSPCommandLog5 = await CSSPDBCommandLogService.GetCSSPCommandLogLastMonthList();
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog5.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog5.Result).StatusCode);

            DateTime StartDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day - 1, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day + 4, 23, 59, 59);
            var actionCSSPCommandLog6 = await CSSPDBCommandLogService.GetCSSPCommandLogBetweenDatesList(StartDate, EndDate);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog6.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog6.Result).StatusCode);

            var actionCSSPCommandLog7 = await CSSPDBCommandLogService.Delete(1234);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog7.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog7.Result).StatusCode);

            var actionCSSPCommandLog8 = await CSSPDBCommandLogService.Post(csspCSSPCommandLog);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog8.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog8.Result).StatusCode);

            var actionCSSPCommandLog9 = await CSSPDBCommandLogService.Post(csspCSSPCommandLog);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog9.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCSSPCommandLog9.Result).StatusCode);

            CSSPDBCommandLogService.dbCommandLog.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBCommandLogService_GetWithCSSPCommandLogID_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int CSSPCommandLogID = 0;

            CSSPDBCommandLogService.dbCommandLog.Database.BeginTransaction();

            var actionCSSPCommandLog = await CSSPDBCommandLogService.GetWithCSSPCommandLogID(CSSPCommandLogID);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPCommandLog.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPCommandLog", "CSSPCommandLogID", CSSPCommandLogID.ToString()),
                ((BadRequestObjectResult)actionCSSPCommandLog.Result).Value);

            CSSPDBCommandLogService.dbCommandLog.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBCommandLogService_Delete_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPDBCommandLogService.dbCommandLog.Database.BeginTransaction();

            int CSSPCommandLogID = 0;

            var actionCSSPCommandLog = await CSSPDBCommandLogService.Delete(CSSPCommandLogID);
            Assert.NotEqual(200, ((ObjectResult)actionCSSPCommandLog.Result).StatusCode);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPCommandLog.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CSSPCommandLog", "CSSPCommandLogID", CSSPCommandLogID.ToString()),
                ((BadRequestObjectResult)actionCSSPCommandLog.Result).Value);

            CSSPDBCommandLogService.dbCommandLog.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBCommandLogService_Post_BadRequest_CSSPCommandLog_Equal_null_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPDBCommandLogService.dbCommandLog.Database.BeginTransaction();

            CSSPCommandLog csspCSSPCommandLog = null;

            var actionCSSPCommandLog = await CSSPDBCommandLogService.Post(csspCSSPCommandLog);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPCommandLog.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "CSSPCommandLog"),
                ((BadRequestObjectResult)actionCSSPCommandLog.Result).Value);

            CSSPDBCommandLogService.dbCommandLog.Database.RollbackTransaction();
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPDBCommandLogService_Put_BadRequest_CSSPCommandLog_Equal_null_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPDBCommandLogService.dbCommandLog.Database.BeginTransaction();

            CSSPCommandLog csspCSSPCommandLog = null;

            var actionCSSPCommandLog = await CSSPDBCommandLogService.Put(csspCSSPCommandLog);
            Assert.Equal(400, ((BadRequestObjectResult)actionCSSPCommandLog.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "CSSPCommandLog"),
                ((BadRequestObjectResult)actionCSSPCommandLog.Result).Value);

            CSSPDBCommandLogService.dbCommandLog.Database.RollbackTransaction();
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
