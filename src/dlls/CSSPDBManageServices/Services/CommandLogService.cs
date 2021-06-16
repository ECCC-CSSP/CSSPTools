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

namespace ManageServices
{
    public partial interface ICommandLogService
    {
        Task<ActionResult<CommandLog>> CommandLogAddOrModify(CommandLog CommandLog);
        Task<ActionResult<bool>> CommandLogDelete(int CommandLogID);
        Task<ActionResult<List<CommandLog>>> CommandLogGetTodayList();
        Task<ActionResult<List<CommandLog>>> CommandLogGetLastWeekList();
        Task<ActionResult<List<CommandLog>>> CommandLogGetLastMonthList();
        Task<ActionResult<List<CommandLog>>> CommandLogGetBetweenDatesList(DateTime StartDate, DateTime EndDate);
        Task<ActionResult<CommandLog>> CommandLogGetWithCommandLogID(int CommandLogID);

    }
    public partial class CommandLogService : ControllerBase, ICommandLogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBManageContext dbManage { get; set; }
        private IEnumerable<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public CommandLogService(ICSSPCultureService CSSPCultureService, CSSPDBManageContext dbManage)
        {
            this.dbManage = dbManage;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<CommandLog>> CommandLogAddOrModify(CommandLog commandLog)
        {
            if (commandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._IsNullOrEmpty, "commandLog")));
            }

            ValidationResults = CommandLogValidateAddOrModify(new ValidationContext(commandLog));
            if (ValidationResults.Count() > 0)
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await DoCommandLogAddOrModify(commandLog);
        }
        public async Task<ActionResult<bool>> CommandLogDelete(int CommandLogID)
        {
            CommandLog commandLog = (from c in dbManage.CommandLogs
                                     where c.CommandLogID == CommandLogID
                                     select c).FirstOrDefault();

            if (commandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString())));
            }

            try
            {
                dbManage.CommandLogs.Remove(commandLog);
                dbManage.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<CommandLog>> CommandLogGetWithCommandLogID(int CommandLogID)
        {
            CommandLog commandLog = (from c in dbManage.CommandLogs.AsNoTracking()
                                     where c.CommandLogID == CommandLogID
                                     select c).FirstOrDefault();

            if (commandLog == null)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString())));
            }

            return await Task.FromResult(Ok(commandLog));
        }
        public async Task<ActionResult<List<CommandLog>>> CommandLogGetTodayList()
        {
            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return await CommandLogGetBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CommandLog>>> CommandLogGetLastWeekList()
        {
            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 7, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return await CommandLogGetBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CommandLog>>> CommandLogGetLastMonthList()
        {
            DateTime StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, DateTime.Now.Day - 7, 0, 0, 0);
            DateTime EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return await CommandLogGetBetweenDatesList(StartDate, EndDate);
        }
        public async Task<ActionResult<List<CommandLog>>> CommandLogGetBetweenDatesList(DateTime StartDate, DateTime EndDate)
        {
            List<CommandLog> CommandLogList = (from c in dbManage.CommandLogs.AsNoTracking()
                                               where c.DateTimeUTC >= StartDate
                                               && c.DateTimeUTC <= EndDate
                                               orderby c.CommandLogID
                                               select c).ToList();

            return await Task.FromResult(Ok(CommandLogList));
        }
        #endregion Functions public

        #region Functions private
        private async Task<ActionResult<CommandLog>> DoCommandLogAddOrModify(CommandLog commandLog)
        {
            CommandLog commandLogAddOrModify = new CommandLog();

            if (commandLog.CommandLogID == 0) // add
            {
                commandLogAddOrModify = commandLog;
                int? LastIndex = (from c in dbManage.CommandLogs
                                  orderby c.CommandLogID descending
                                  select c.CommandLogID).FirstOrDefault() + 1;

                commandLog.CommandLogID = (int)LastIndex;
                dbManage.CommandLogs.Add(commandLog);
            }
            else // modify
            {
                commandLogAddOrModify = (from c in dbManage.CommandLogs
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
                dbManage.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return await Task.FromResult(BadRequest(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")));
            }

            return await Task.FromResult(Ok(commandLogAddOrModify));
        }
        private IEnumerable<ValidationResult> CommandLogValidateAddOrModify(ValidationContext validationContext)
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
