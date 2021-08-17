/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPEnums;
using LoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    public interface ILogService
    {
        StringBuilder sbError { get; set; }
        StringBuilder sbLog { get; set; }
        void AppendError(string errorText);
        void AppendLog(string logText);
        Task<ActionResult<bool>> StoreInCommandLog(string appName, string commandName);
    }
    public partial class LogService : ControllerBase, ILogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public StringBuilder sbError { get; set; } = new StringBuilder();
        public StringBuilder sbLog { get; set; } = new StringBuilder();
        private CSSPDBManageContext dbManage { get; }
        private ILoggedInService LoggedInService { get; }

        #endregion Properties

        #region Constructors
        public LogService(ILoggedInService LoggedInService, CSSPDBManageContext dbManage) : base()
        {
            this.LoggedInService = LoggedInService;
            this.dbManage = dbManage;
        }
        #endregion Constructors

        #region Functions public
        public void AppendError(string errorText)
        {
            Console.WriteLine($"\r{errorText}");
            sbError.AppendLine(errorText);
        }
        public void AppendLog(string logText)
        {
            Console.WriteLine($"\r{logText}");
            sbLog.AppendLine(logText);
        }
        public async Task<ActionResult<bool>> StoreInCommandLog(string appName, string commandName)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(""));
            }

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = appName,
                CommandName = commandName,
                Successful = false,
                DetailLog = sbLog.ToString(),
                ErrorMessage = sbError.ToString(),
                DateTimeUTC = DateTime.UtcNow,
            };

            try
            {
                commandLog.DetailLog = sbLog.ToString();
                commandLog.ErrorMessage = sbError.ToString();
                dbManage.CommandLogs.Add(commandLog);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                string AppAndCommandName = $"AppName: {appName } - CommandName: {commandName}";
                Console.WriteLine($"{String.Format(CSSPCultureUpdateRes.CouldNotAddCommandLog_Error_, AppAndCommandName, ex.Message)}");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
