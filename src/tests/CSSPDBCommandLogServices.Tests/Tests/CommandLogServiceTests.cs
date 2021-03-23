using CSSPCultureServices.Resources;
using CSSPDBCommandLogModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CommandLogServices.Tests
{
    [Collection("Sequential")]
    public partial class CommandLogServicesTests
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
        public async Task CommandLogService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CommandLogService);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            // testing AddOrModify -- add
            var actionCommandLogPost = await CommandLogService.AddOrModify(commandLog);
            Assert.Equal(200, ((ObjectResult)actionCommandLogPost.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogPost.Result).Value);
            CommandLog commandLogNewPost = (CommandLog)((OkObjectResult)actionCommandLogPost.Result).Value;
            Assert.NotNull(commandLogNewPost);
            Assert.Equal(commandLog.CommandLogID, commandLogNewPost.CommandLogID);
            Assert.Equal(commandLog.AppName, commandLogNewPost.AppName);
            Assert.Equal(commandLog.CommandName, commandLogNewPost.CommandName);
            Assert.Equal(commandLog.Successful, commandLogNewPost.Successful);
            Assert.Equal(commandLog.ErrorMessage, commandLogNewPost.ErrorMessage);
            Assert.Equal(commandLog.DateTimeUTC, commandLogNewPost.DateTimeUTC);

            // testing AddOrModify -- modify
            commandLogNewPost.AppName = "NewAppName";
            var actionCommandLogPut = await CommandLogService.AddOrModify(commandLogNewPost);
            Assert.Equal(200, ((ObjectResult)actionCommandLogPut.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogPut.Result).Value);
            CommandLog commandLogNewPut = (CommandLog)((OkObjectResult)actionCommandLogPut.Result).Value;
            Assert.NotNull(commandLogNewPut);
            Assert.Equal(commandLogNewPost.CommandLogID, commandLogNewPut.CommandLogID);
            Assert.Equal(commandLogNewPost.AppName, commandLogNewPut.AppName);
            Assert.Equal(commandLogNewPost.CommandName, commandLogNewPut.CommandName);
            Assert.Equal(commandLogNewPost.Successful, commandLogNewPut.Successful);
            Assert.Equal(commandLog.ErrorMessage, commandLogNewPost.ErrorMessage);
            Assert.Equal(commandLogNewPost.DateTimeUTC, commandLogNewPut.DateTimeUTC);

            // testing GetWithCommandLogID
            var actionCommandLogGetWithID = await CommandLogService.GetWithCommandLogID(commandLogNewPut.CommandLogID);
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetWithID.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetWithID.Result).Value);
            CommandLog commandLogNewGetWithID = (CommandLog)((OkObjectResult)actionCommandLogGetWithID.Result).Value;
            Assert.NotNull(commandLogNewGetWithID);
            Assert.Equal(commandLogNewPut.CommandLogID, commandLogNewGetWithID.CommandLogID);
            Assert.Equal(commandLogNewPut.AppName, commandLogNewGetWithID.AppName);
            Assert.Equal(commandLogNewPut.CommandName, commandLogNewGetWithID.CommandName);
            Assert.Equal(commandLogNewPut.Successful, commandLogNewGetWithID.Successful);
            Assert.Equal(commandLog.ErrorMessage, commandLogNewPost.ErrorMessage);
            Assert.Equal(commandLogNewPut.DateTimeUTC, commandLogNewGetWithID.DateTimeUTC);

            // testing GetCSSPCommandLogTodayList
            var actionCommandLogGetCommandLogTodayList = await CommandLogService.GetCommandLogTodayList();
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetCommandLogTodayList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetCommandLogTodayList.Result).Value);
            List<CommandLog> commandLogNewGetWithSuccessfulAndAppNameList = (List<CommandLog>)((OkObjectResult)actionCommandLogGetCommandLogTodayList.Result).Value;
            Assert.NotNull(commandLogNewGetWithSuccessfulAndAppNameList);
            Assert.Equal(commandLogNewGetWithID.CommandLogID, commandLogNewGetWithSuccessfulAndAppNameList[0].CommandLogID);
            Assert.Equal(commandLogNewGetWithID.AppName, commandLogNewGetWithSuccessfulAndAppNameList[0].AppName);
            Assert.Equal(commandLogNewGetWithID.CommandName, commandLogNewGetWithSuccessfulAndAppNameList[0].CommandName);
            Assert.Equal(commandLogNewGetWithID.Successful, commandLogNewGetWithSuccessfulAndAppNameList[0].Successful);
            Assert.Equal(commandLog.ErrorMessage, commandLogNewPost.ErrorMessage);
            Assert.Equal(commandLogNewGetWithID.DateTimeUTC, commandLogNewGetWithSuccessfulAndAppNameList[0].DateTimeUTC);

            // testing GetCSSPCommandLogLastWeekList
            var actionCommandLogGetCommandLogLastWeekList = await CommandLogService.GetCommandLogLastWeekList();
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetCommandLogLastWeekList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetCommandLogLastWeekList.Result).Value);
            List<CommandLog> commandLogNewGetWithSuccessfulAndAppNameList2 = (List<CommandLog>)((OkObjectResult)actionCommandLogGetCommandLogLastWeekList.Result).Value;
            Assert.NotNull(commandLogNewGetWithSuccessfulAndAppNameList2);
            Assert.Equal(commandLogNewGetWithID.CommandLogID, commandLogNewGetWithSuccessfulAndAppNameList2[0].CommandLogID);
            Assert.Equal(commandLogNewGetWithID.AppName, commandLogNewGetWithSuccessfulAndAppNameList2[0].AppName);
            Assert.Equal(commandLogNewGetWithID.CommandName, commandLogNewGetWithSuccessfulAndAppNameList2[0].CommandName);
            Assert.Equal(commandLogNewGetWithID.Successful, commandLogNewGetWithSuccessfulAndAppNameList2[0].Successful);
            Assert.Equal(commandLog.ErrorMessage, commandLogNewPost.ErrorMessage);
            Assert.Equal(commandLogNewGetWithID.DateTimeUTC, commandLogNewGetWithSuccessfulAndAppNameList2[0].DateTimeUTC);

            // testing GetCSSPCommandLogLastMonthList
            var actionCommandLogGetCommandLogLastMonthList = await CommandLogService.GetCommandLogLastMonthList();
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetCommandLogLastMonthList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetCommandLogLastMonthList.Result).Value);
            List<CommandLog> commandLogNewGetWithSuccessfulAndAppNameList3 = (List<CommandLog>)((OkObjectResult)actionCommandLogGetCommandLogLastMonthList.Result).Value;
            Assert.NotNull(commandLogNewGetWithSuccessfulAndAppNameList3);
            Assert.Equal(commandLogNewGetWithID.CommandLogID, commandLogNewGetWithSuccessfulAndAppNameList3[0].CommandLogID);
            Assert.Equal(commandLogNewGetWithID.AppName, commandLogNewGetWithSuccessfulAndAppNameList3[0].AppName);
            Assert.Equal(commandLogNewGetWithID.CommandName, commandLogNewGetWithSuccessfulAndAppNameList3[0].CommandName);
            Assert.Equal(commandLogNewGetWithID.Successful, commandLogNewGetWithSuccessfulAndAppNameList3[0].Successful);
            Assert.Equal(commandLog.ErrorMessage, commandLogNewPost.ErrorMessage);
            Assert.Equal(commandLogNewGetWithID.DateTimeUTC, commandLogNewGetWithSuccessfulAndAppNameList3[0].DateTimeUTC);

            // testing GetCommandLogBetweenDatesList
            DateTime StartDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day - 1, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day + 4, 23, 59, 59);
            var actionCommandLogGetCommandLogBetweenDatesList = await CommandLogService.GetCommandLogBetweenDatesList(StartDate, EndDate);
            Assert.Equal(200, ((ObjectResult)actionCommandLogGetCommandLogBetweenDatesList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogGetCommandLogBetweenDatesList.Result).Value);
            List<CommandLog> commandLogNewGetWithSuccessfulAndAppNameList4 = (List<CommandLog>)((OkObjectResult)actionCommandLogGetCommandLogBetweenDatesList.Result).Value;
            Assert.NotNull(commandLogNewGetWithSuccessfulAndAppNameList4);
            Assert.Equal(commandLogNewGetWithID.CommandLogID, commandLogNewGetWithSuccessfulAndAppNameList4[0].CommandLogID);
            Assert.Equal(commandLogNewGetWithID.AppName, commandLogNewGetWithSuccessfulAndAppNameList4[0].AppName);
            Assert.Equal(commandLogNewGetWithID.CommandName, commandLogNewGetWithSuccessfulAndAppNameList4[0].CommandName);
            Assert.Equal(commandLogNewGetWithID.Successful, commandLogNewGetWithSuccessfulAndAppNameList4[0].Successful);
            Assert.Equal(commandLog.ErrorMessage, commandLogNewPost.ErrorMessage);
            Assert.Equal(commandLogNewGetWithID.DateTimeUTC, commandLogNewGetWithSuccessfulAndAppNameList4[0].DateTimeUTC);

            // testing Delete
            var actionDelete = await CommandLogService.Delete(commandLogNewPost.CommandLogID);
            Assert.Equal(200, ((ObjectResult)actionDelete.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDelete.Result).Value);
            bool DeleteRet = (bool)((OkObjectResult)actionDelete.Result).Value;
            Assert.True(DeleteRet);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_Unauthorized_All_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            LoggedInService.LoggedInContactInfo = null;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            var actionCommandLog1 = await CommandLogService.AddOrModify(commandLog);
            Assert.NotEqual(200, ((ObjectResult)actionCommandLog1.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCommandLog1.Result).StatusCode);

            var actionCommandLog2 = await CommandLogService.Delete(12345);
            Assert.NotEqual(200, ((ObjectResult)actionCommandLog2.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCommandLog2.Result).StatusCode);

            var actionCommandLog3 = await CommandLogService.GetCommandLogTodayList();
            Assert.NotEqual(200, ((ObjectResult)actionCommandLog3.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCommandLog3.Result).StatusCode);

            var actionCommandLog4 = await CommandLogService.GetCommandLogLastWeekList();
            Assert.NotEqual(200, ((ObjectResult)actionCommandLog4.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCommandLog4.Result).StatusCode);

            var actionCommandLog5 = await CommandLogService.GetCommandLogLastMonthList();
            Assert.NotEqual(200, ((ObjectResult)actionCommandLog5.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCommandLog5.Result).StatusCode);

            DateTime StartDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day - 1, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day + 4, 23, 59, 59);
            var actionCommandLog6 = await CommandLogService.GetCommandLogBetweenDatesList(StartDate, EndDate);
            Assert.NotEqual(200, ((ObjectResult)actionCommandLog6.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCommandLog6.Result).StatusCode);

            var actionCommandLog7 = await CommandLogService.GetWithCommandLogID(1234);
            Assert.NotEqual(200, ((ObjectResult)actionCommandLog7.Result).StatusCode);
            Assert.Equal(401, ((UnauthorizedObjectResult)actionCommandLog7.Result).StatusCode);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_AddOrModify_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            string error = string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "CommandLog");

            var actionCommandLog = await CommandLogService.AddOrModify(null);
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

            var actionCommandLog = await CommandLogService.Delete(CommandLogID);
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

            var actionCommandLog = await CommandLogService.GetWithCommandLogID(CommandLogID);
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

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.AppName = "";

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "AppName");

            var actionCommandLog = await CommandLogService.AddOrModify(commandLog);
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

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.AppName = "".PadRight(201, 'a');

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AppName", "200");

            var actionCommandLog = await CommandLogService.AddOrModify(commandLog);
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

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.CommandName = "";

            string error = string.Format(CSSPCultureServicesRes._IsRequired, "CommandName");

            var actionCommandLog = await CommandLogService.AddOrModify(commandLog);
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

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.CommandName = "".PadRight(201, 'a');

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "CommandName", "200");

            var actionCommandLog = await CommandLogService.AddOrModify(commandLog);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionCommandLog.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(error)).Any());
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CommandLogService_ValidateAddOrModify_ErrorMessage_Length_BadRequest_Test(string culture)
        {
            Assert.True(await Setup(culture));

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            commandLog.ErrorMessage = "".PadRight(1001, 'a');

            string error = string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorMessage", "1000");

            var actionCommandLog = await CommandLogService.AddOrModify(commandLog);
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

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = new DateTime(1978, 1, 1),
            };

            string error = string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTimeUTC", "1980");

            var actionCommandLog = await CommandLogService.AddOrModify(commandLog);
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

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "TestingAppName",
                CommandName = "TestingCommandName",
                Successful = true,
                ErrorMessage = "TestingErrorMessage",
                DateTimeUTC = DateTime.UtcNow,
            };

            // testing AddOrModify -- add
            var actionCommandLogAddOrModify = await CommandLogService.AddOrModify(commandLog);
            Assert.Equal(200, ((ObjectResult)actionCommandLogAddOrModify.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionCommandLogAddOrModify.Result).Value);
            CommandLog commandLogNew = (CommandLog)((OkObjectResult)actionCommandLogAddOrModify.Result).Value;
            Assert.NotNull(commandLogNew);
            Assert.Equal(commandLog.CommandLogID, commandLogNew.CommandLogID);
            Assert.Equal(commandLog.AppName, commandLogNew.AppName);
            Assert.Equal(commandLog.CommandName, commandLogNew.CommandName);
            Assert.Equal(commandLog.Successful, commandLogNew.Successful);
            Assert.Equal(commandLog.ErrorMessage, commandLogNew.ErrorMessage);
            Assert.Equal(commandLog.DateTimeUTC, commandLogNew.DateTimeUTC);

            commandLogNew.CommandLogID = 1234; // will not find
            string error = string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", commandLogNew.CommandLogID.ToString());

            // testing AddOrModify -- modify
            var actionCommandLog = await CommandLogService.AddOrModify(commandLogNew);
            Assert.Equal(400, ((ObjectResult)actionCommandLog.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionCommandLog.Result).Value);
            Assert.Equal(error, ((BadRequestObjectResult)actionCommandLog.Result).Value);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private
    }
}
