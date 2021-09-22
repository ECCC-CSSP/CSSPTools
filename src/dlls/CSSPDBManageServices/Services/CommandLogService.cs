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
using Microsoft.Extensions.Configuration;
using CSSPHelperModels;

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
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private CSSPDBManageContext dbManage { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public CommandLogService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, CSSPDBManageContext dbManage)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPCultureService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService ") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPLogService") }");

            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
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

            if (!await CommandLogValidateAddOrModify(new ValidationContext(commandLog)))
            {
                return await Task.FromResult(BadRequest(errRes));
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
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString()));
                return await Task.FromResult(BadRequest(errRes));
            }

            try
            {
                dbManage.CommandLogs.Remove(commandLog);
                dbManage.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                return await Task.FromResult(BadRequest(errRes));
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
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", CommandLogID.ToString()));
                return await Task.FromResult(BadRequest(errRes));
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
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "CommandLog", "CommandLogID", commandLog.CommandLogID.ToString()));
                    return await Task.FromResult(BadRequest(errRes));
                }

                commandLogAddOrModify.AppName = commandLog.AppName;
                commandLogAddOrModify.CommandName = commandLog.CommandName;
                commandLogAddOrModify.DateTimeUTC = commandLog.DateTimeUTC;
                commandLogAddOrModify.Error = commandLog.Error;
                commandLogAddOrModify.Log = commandLog.Log;
            }

            try
            {
                dbManage.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                errRes.ErrList.Add(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(commandLogAddOrModify));
        }
        private async Task<bool> CommandLogValidateAddOrModify(ValidationContext validationContext)
        {
            CommandLog commandLog = validationContext.ObjectInstance as CommandLog;

            // doing AppName
            if (string.IsNullOrWhiteSpace(commandLog.AppName))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppName"));
            }
            else
            {
                if (commandLog.AppName.Length > 200)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "AppName", "200"));
                }
            }

            // doing CommandName
            if (string.IsNullOrWhiteSpace(commandLog.CommandName))
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "CommandName"));
            }
            else
            {
                if (commandLog.CommandName.Length > 200)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "CommandName", "200"));
                }
            }

            // doing Error
            if (!string.IsNullOrWhiteSpace(commandLog.Error))
            {
                if (commandLog.Error.Length > 10000000)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Error", "10000000"));
                }
            }

            // doing Log
            if (!string.IsNullOrWhiteSpace(commandLog.Log))
            {
                if (commandLog.Log.Length > 10000000)
                {
                    errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "Log", "10000000"));
                }
            }

            if (commandLog.DateTimeUTC.Year < 1980)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._YearShouldBeBiggerThan_, "DateTimeUTC", "1980"));
            }

            return errRes.ErrList.Count == 0 ? await Task.FromResult(true) : await Task.FromResult(false);

        }
        #endregion Functions private

    }
}
