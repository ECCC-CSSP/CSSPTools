using CSSPEnums;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using CSSPCultureServices.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSSPLogServices.Tests
{
    public partial class CSSPLogServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPLogService_StoreInCommandLog_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string ErrorStr = "Testing Error";
            string LogStr = "Testing Log";

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CSSPLogService.AppendError(ErrorStr);
            CSSPLogService.AppendLog(LogStr);

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.True(commandLogList.Count == 0);

            var actionCommandLog = await CSSPLogService.StoreInCommandLog(csspAppName, csspCommandName);
            Assert.Equal(200, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLog.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionCommandLog.Result).Value;
            Assert.True(boolRet);

            commandLogList = (from c in dbManage.CommandLogs
                              select c).ToList();

            Assert.True(commandLogList.Count == 1);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPLogService_StoreInCommandLog_Unauthorized_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            string ErrorStr = "Testing Error";
            string LogStr = "Testing Log";

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CSSPLogService.AppendError(ErrorStr);
            CSSPLogService.AppendLog(LogStr);

            List<CommandLog> commandLogList = (from c in dbManage.CommandLogs
                                               select c).ToList();

            Assert.True(commandLogList.Count == 0);

            var actionCommandLog = await CSSPLogService.StoreInCommandLog(csspAppName, csspCommandName);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCommandLog.Result).StatusCode);
            Assert.Equal(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization), ((UnauthorizedObjectResult)actionCommandLog.Result).Value);

            commandLogList = (from c in dbManage.CommandLogs
                              select c).ToList();

            Assert.True(commandLogList.Count == 0);

        }
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
