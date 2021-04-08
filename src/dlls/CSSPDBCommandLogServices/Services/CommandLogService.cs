/*
 * Manually edited
 *
 */

using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSSPDBCommandLogModels;
using LoggedInServices;

namespace CSSPDBCommandLogServices
{
    public partial interface ICommandLogService
    {
        Task<ActionResult<CommandLog>> AddOrModify(CommandLog CommandLog);
        Task<ActionResult<bool>> Delete(int CommandLogID);
        Task<ActionResult<List<CommandLog>>> GetCommandLogTodayList();
        Task<ActionResult<List<CommandLog>>> GetCommandLogLastWeekList();
        Task<ActionResult<List<CommandLog>>> GetCommandLogLastMonthList();
        Task<ActionResult<List<CommandLog>>> GetCommandLogBetweenDatesList(DateTime StartDate, DateTime EndDate);
        Task<ActionResult<CommandLog>> GetWithCommandLogID(int CommandLogID);

    }
    public partial class CommandLogService : ControllerBase, ICommandLogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBCommandLogContext dbCommandLog { get; set; }
        private ILoggedInService LoggedInService { get; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public CommandLogService(ICSSPCultureService CSSPCultureService, ILoggedInService LoggedInService, CSSPDBCommandLogContext dbCommandLog)
        {
            this.LoggedInService = LoggedInService;
            this.dbCommandLog = dbCommandLog;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<CommandLog>> AddOrModify(CommandLog CommandLog)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (CommandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "CommandLog")));
            }

            ValidationResults = ValidateAddOrModify(new ValidationContext(CommandLog));
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await DoAddOrModify(CommandLog);
        }
        public async Task<ActionResult<bool>> Delete(int CommandLogID)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            CommandLog CommandLog = (from c in dbCommandLog.CommandLogs
                                     where c.CommandLogID == CommandLogID
                                     select c).FirstOrDefault();

            if (CommandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString())));
            }

            try
            {
                dbCommandLog.CommandLogs.Remove(CommandLog);
                dbCommandLog.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<CommandLog>> GetWithCommandLogID(int CommandLogID)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            CommandLog CommandLog = (from c in dbCommandLog.CommandLogs.AsNoTracking()
                                             where c.CommandLogID == CommandLogID
                                             select c).FirstOrDefault();

            if (CommandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString())));
            }

            return await Task.FromResult(Ok(CommandLog));
        }
        public async Task<ActionResult<List<CommandLog>>> GetCommandLogTodayList()
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return await GetCommandLogBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CommandLog>>> GetCommandLogLastWeekList()
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 7, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return await GetCommandLogBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CommandLog>>> GetCommandLogLastMonthList()
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day - 7, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return await GetCommandLogBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CommandLog>>> GetCommandLogBetweenDatesList(DateTime StartDate, DateTime EndDate)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<CommandLog> CommandLogList = (from c in dbCommandLog.CommandLogs.AsNoTracking()
                                                       where c.DateTimeUTC >= StartDate
                                                       && c.DateTimeUTC <= EndDate
                                                       orderby c.CommandLogID
                                                       select c).ToList();

            return await Task.FromResult(Ok(CommandLogList));
        }
        #endregion Functions public

        #region Functions private
        private async Task<ActionResult<CommandLog>> DoAddOrModify(CommandLog commandLog)
        {
            CommandLog commandLogAddOrModify = new CommandLog();

            if (commandLog.CommandLogID == 0) // add
            {
                commandLogAddOrModify = commandLog;
                int? LastIndex = (from c in dbCommandLog.CommandLogs
                                  orderby c.CommandLogID descending
                                  select c.CommandLogID).FirstOrDefault() + 1;

                commandLog.CommandLogID = (int)LastIndex;
                dbCommandLog.CommandLogs.Add(commandLog);
            }
            else // modify
            {
                commandLogAddOrModify = (from c in dbCommandLog.CommandLogs
                                              where c.CommandLogID == commandLog.CommandLogID
                                              select c).FirstOrDefault();

                if (commandLogAddOrModify == null)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", commandLog.CommandLogID.ToString())));
                }

                commandLogAddOrModify.AppName = commandLog.AppName;
                commandLogAddOrModify.CommandName = commandLog.CommandName;
                commandLogAddOrModify.DateTimeUTC = commandLog.DateTimeUTC;
                commandLogAddOrModify.ErrorMessage = commandLog.ErrorMessage;
                commandLogAddOrModify.Successful = commandLog.Successful;
            }

            try
            {
                dbCommandLog.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(commandLogAddOrModify));
        }
        private IEnumerable<ValidationResult> ValidateAddOrModify(ValidationContext validationContext)
        {
            CommandLog commandLog = validationContext.ObjectInstance as CommandLog;

            // doing AppName
            if (string.IsNullOrWhiteSpace(commandLog.AppName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppName"), new[] { "AppName" });
            }
            else
            {
                if (commandLog.AppName.Length > 200)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AppName", "200"), new[] { "AppName" });
                }
            }

            // doing CommandName
            if (string.IsNullOrWhiteSpace(commandLog.CommandName))
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "CommandName"), new[] { "CommandName" });
            }
            else
            {
                if (commandLog.CommandName.Length > 200)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "CommandName", "200"), new[] { "CommandName" });
                }
            }

            // doing ErrorMessage
            if (!string.IsNullOrWhiteSpace(commandLog.ErrorMessage))
            {
                if (commandLog.ErrorMessage.Length > 1000)
                {
                    yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "ErrorMessage", "1000"), new[] { "ErrorMessage" });
                }
            }

            if (commandLog.DateTimeUTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTimeUTC", "1980"), new[] { "DateTimeUTC" });
            }

            // no need to verify if it already exist in the db as we should always add the command log nomatter what

        }
        #endregion Functions private

    }
}
