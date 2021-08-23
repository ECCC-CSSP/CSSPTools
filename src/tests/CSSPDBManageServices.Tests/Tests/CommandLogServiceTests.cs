using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{
    public partial class ManageServicesTests
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
        public async Task CommandLogService_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Log = "Testing Log",
                Error = "Testing Error",
                DateTimeUTC = DateTime.UtcNow,
            };

            // testing AddOrModify -- add
            var actionCommandLogPost = await CommandLogService.CommandLogAddOrModify(commandLog);
            Assert.Equal(200, ((ObjectResult)actionCommandLogPost.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogPost.Result).Value);
            CommandLog commandLogNewPost = (CommandLog)((OkObjectResult)actionCommandLogPost.Result).Value;
            Assert.NotNull(commandLogNewPost);
            Assert.Equal(commandLog.CommandLogID, commandLogNewPost.CommandLogID);
            Assert.Equal(commandLog.AppName, commandLogNewPost.AppName);
            Assert.Equal(commandLog.CommandName, commandLogNewPost.CommandName);
            Assert.Equal(commandLog.Error, commandLogNewPost.Error);
            Assert.Equal(commandLog.DateTimeUTC, commandLogNewPost.DateTimeUTC);

            // testing AddOrModify -- modify
            commandLogNewPost.AppName = "NewAppName";
            var actionCommandLogPut = await CommandLogService.CommandLogAddOrModify(commandLogNewPost);
            Assert.Equal(200, ((ObjectResult)actionCommandLogPut.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogPut.Result).Value);
            CommandLog commandLogNewPut = (CommandLog)((OkObjectResult)actionCommandLogPut.Result).Value;
            Assert.NotNull(commandLogNewPut);
            Assert.Equal(commandLogNewPost.CommandLogID, commandLogNewPut.CommandLogID);
            Assert.Equal(commandLogNewPost.AppName, commandLogNewPut.AppName);
            Assert.Equal(commandLogNewPost.CommandName, commandLogNewPut.CommandName);
            Assert.Equal(commandLog.Error, commandLogNewPost.Error);
            Assert.Equal(commandLogNewPost.DateTimeUTC, commandLogNewPut.DateTimeUTC);

            // testing GetWithCommandLogID
            var actionCommandLogGetWithID = await CommandLogService.CommandLogGetWithCommandLogID(commandLogNewPut.CommandLogID);
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetWithID.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetWithID.Result).Value);
            CommandLog commandLogNewGetWithID = (CommandLog)((OkObjectResult)actionCommandLogGetWithID.Result).Value;
            Assert.NotNull(commandLogNewGetWithID);
            Assert.Equal(commandLogNewPut.CommandLogID, commandLogNewGetWithID.CommandLogID);
            Assert.Equal(commandLogNewPut.AppName, commandLogNewGetWithID.AppName);
            Assert.Equal(commandLogNewPut.CommandName, commandLogNewGetWithID.CommandName);
            Assert.Equal(commandLog.Error, commandLogNewPost.Error);
            Assert.Equal(commandLogNewPut.DateTimeUTC, commandLogNewGetWithID.DateTimeUTC);

            // testing GetCSSPCommandLogTodayList
            var actionCommandLogGetCommandLogTodayList = await CommandLogService.CommandLogGetTodayList();
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetCommandLogTodayList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetCommandLogTodayList.Result).Value);
            List<CommandLog> commandLogNewGetWithSuccessfulAndAppNameList = (List<CommandLog>)((OkObjectResult)actionCommandLogGetCommandLogTodayList.Result).Value;
            Assert.NotNull(commandLogNewGetWithSuccessfulAndAppNameList);
            Assert.Equal(commandLogNewGetWithID.CommandLogID, commandLogNewGetWithSuccessfulAndAppNameList[0].CommandLogID);
            Assert.Equal(commandLogNewGetWithID.AppName, commandLogNewGetWithSuccessfulAndAppNameList[0].AppName);
            Assert.Equal(commandLogNewGetWithID.CommandName, commandLogNewGetWithSuccessfulAndAppNameList[0].CommandName);
            Assert.Equal(commandLog.Error, commandLogNewPost.Error);
            Assert.Equal(commandLogNewGetWithID.DateTimeUTC, commandLogNewGetWithSuccessfulAndAppNameList[0].DateTimeUTC);

            // testing GetCSSPCommandLogLastWeekList
            var actionCommandLogGetCommandLogLastWeekList = await CommandLogService.CommandLogGetLastWeekList();
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetCommandLogLastWeekList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetCommandLogLastWeekList.Result).Value);
            List<CommandLog> commandLogNewGetWithSuccessfulAndAppNameList2 = (List<CommandLog>)((OkObjectResult)actionCommandLogGetCommandLogLastWeekList.Result).Value;
            Assert.NotNull(commandLogNewGetWithSuccessfulAndAppNameList2);
            Assert.Equal(commandLogNewGetWithID.CommandLogID, commandLogNewGetWithSuccessfulAndAppNameList2[0].CommandLogID);
            Assert.Equal(commandLogNewGetWithID.AppName, commandLogNewGetWithSuccessfulAndAppNameList2[0].AppName);
            Assert.Equal(commandLogNewGetWithID.CommandName, commandLogNewGetWithSuccessfulAndAppNameList2[0].CommandName);
            Assert.Equal(commandLog.Error, commandLogNewPost.Error);
            Assert.Equal(commandLogNewGetWithID.DateTimeUTC, commandLogNewGetWithSuccessfulAndAppNameList2[0].DateTimeUTC);

            // testing GetCSSPCommandLogLastMonthList
            var actionCommandLogGetCommandLogLastMonthList = await CommandLogService.CommandLogGetLastMonthList();
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetCommandLogLastMonthList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetCommandLogLastMonthList.Result).Value);
            List<CommandLog> commandLogNewGetWithSuccessfulAndAppNameList3 = (List<CommandLog>)((OkObjectResult)actionCommandLogGetCommandLogLastMonthList.Result).Value;
            Assert.NotNull(commandLogNewGetWithSuccessfulAndAppNameList3);
            Assert.Equal(commandLogNewGetWithID.CommandLogID, commandLogNewGetWithSuccessfulAndAppNameList3[0].CommandLogID);
            Assert.Equal(commandLogNewGetWithID.AppName, commandLogNewGetWithSuccessfulAndAppNameList3[0].AppName);
            Assert.Equal(commandLogNewGetWithID.CommandName, commandLogNewGetWithSuccessfulAndAppNameList3[0].CommandName);
            Assert.Equal(commandLog.Error, commandLogNewPost.Error);
            Assert.Equal(commandLogNewGetWithID.DateTimeUTC, commandLogNewGetWithSuccessfulAndAppNameList3[0].DateTimeUTC);

            // testing GetCommandLogBetweenDatesList
            DateTime StartDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day - 1, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day + 4, 23, 59, 59);
            var actionCommandLogGetCommandLogBetweenDatesList = await CommandLogService.CommandLogGetBetweenDatesList(StartDate, EndDate);
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetCommandLogBetweenDatesList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetCommandLogBetweenDatesList.Result).Value);
            List<CommandLog> commandLogNewGetWithSuccessfulAndAppNameList4 = (List<CommandLog>)((OkObjectResult)actionCommandLogGetCommandLogBetweenDatesList.Result).Value;
            Assert.NotNull(commandLogNewGetWithSuccessfulAndAppNameList4);
            Assert.Equal(commandLogNewGetWithID.CommandLogID, commandLogNewGetWithSuccessfulAndAppNameList4[0].CommandLogID);
            Assert.Equal(commandLogNewGetWithID.AppName, commandLogNewGetWithSuccessfulAndAppNameList4[0].AppName);
            Assert.Equal(commandLogNewGetWithID.CommandName, commandLogNewGetWithSuccessfulAndAppNameList4[0].CommandName);
            Assert.Equal(commandLog.Error, commandLogNewPost.Error);
            Assert.Equal(commandLogNewGetWithID.DateTimeUTC, commandLogNewGetWithSuccessfulAndAppNameList4[0].DateTimeUTC);

            // testing Delete
            var actionDelete = await CommandLogService.CommandLogDelete(commandLogNewPost.CommandLogID);
            Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
            bool DeleteRet = (bool)((OkObjectResult)actionDelete.Result).Value;
            Assert.True(DeleteRet);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_AddOrModify_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string error = string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "commandLog");

            var actionCommandLog = await CommandLogService.CommandLogAddOrModify(null);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            Assert.Equal(error, ((BadRequestObjectResult)actionCommandLog.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_Delete_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int CommandLogID = 1234;
            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString());

            var actionCommandLog = await CommandLogService.CommandLogDelete(CommandLogID);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            Assert.Equal(error, ((BadRequestObjectResult)actionCommandLog.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_GetWithCommandLogID_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int CommandLogID = 1234;
            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString());

            var actionCommandLog = await CommandLogService.CommandLogGetWithCommandLogID(CommandLogID);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            Assert.Equal(error, ((BadRequestObjectResult)actionCommandLog.Result).Value);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_ValidateAddOrModify_AppName_Required_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Log = "Testing Log",
                Error = "Testing Error",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.AppName = "";

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "AppName");

            var actionCommandLog = await CommandLogService.CommandLogAddOrModify(commandLog);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionCommandLog.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_ValidateAddOrModify_AppName_Length_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Log = "Testing Log",
                Error = "Testing Error",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.AppName = "".PadRight(201, 'a');

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AppName", "200");

            var actionCommandLog = await CommandLogService.CommandLogAddOrModify(commandLog);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionCommandLog.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_ValidateAddOrModify_CommandName_Required_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Log = "Testing Log",
                Error = "Testing Error",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.CommandName = "";

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "CommandName");

            var actionCommandLog = await CommandLogService.CommandLogAddOrModify(commandLog);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionCommandLog.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_ValidateAddOrModify_CommandName_Length_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Log = "Testing Log",
                Error = "Testing Error",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.CommandName = "".PadRight(201, 'a');

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "CommandName", "200");

            var actionCommandLog = await CommandLogService.CommandLogAddOrModify(commandLog);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionCommandLog.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_ValidateAddOrModify_Error_Length_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Log = "Testing Log",
                Error = "Testing Error",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.Error = "".PadRight(10000001, 'a');

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Error", "10000000");

            var actionCommandLog = await CommandLogService.CommandLogAddOrModify(commandLog);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionCommandLog.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_ValidateAddOrModify_DateTimeUTC_Length_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Log = "Testing Log",
                Error = "Testing Error",
                DateTimeUTC = new DateTime(1979, 1, 1),
            };

            string error = string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTimeUTC", "1980");

            var actionCommandLog = await CommandLogService.CommandLogAddOrModify(commandLog);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionCommandLog.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_AddOrModify_CouldNotFind_For_Modify_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CSSPAppNameEnum csspAppName = CSSPAppNameEnum.CSSPUpdate;
            CSSPCommandNameEnum csspCommandName = CSSPCommandNameEnum.ClearOldUnnecessaryStats;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Log = "Testing Log",
                Error = "Testing Error",
                DateTimeUTC = DateTime.UtcNow,
            };

            // testing AddOrModify -- add
            var actionCommandLogAddOrModify = await CommandLogService.CommandLogAddOrModify(commandLog);
            Assert.Equal(200, ((ObjectResult)actionCommandLogAddOrModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogAddOrModify.Result).Value);
            CommandLog commandLogNew = (CommandLog)((OkObjectResult)actionCommandLogAddOrModify.Result).Value;
            Assert.NotNull(commandLogNew);
            Assert.Equal(commandLog.CommandLogID, commandLogNew.CommandLogID);
            Assert.Equal(commandLog.AppName, commandLogNew.AppName);
            Assert.Equal(commandLog.CommandName, commandLogNew.CommandName);
            Assert.Equal(commandLog.Error, commandLogNew.Error);
            Assert.Equal(commandLog.DateTimeUTC, commandLogNew.DateTimeUTC);

            commandLogNew.CommandLogID = 1234; // will not find
            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", commandLogNew.CommandLogID.ToString());

            // testing AddOrModify -- modify
            var actionCommandLog = await CommandLogService.CommandLogAddOrModify(commandLogNew);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            Assert.Equal(error, ((BadRequestObjectResult)actionCommandLog.Result).Value);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
