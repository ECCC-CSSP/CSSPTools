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
using System.Linq;

namespace CSSPLogServices
{
    public interface ICSSPLogService
    {
        StringBuilder sbError { get; set; }
        StringBuilder sbLog { get; set; }
        void AppendError(string errorText);
        void AppendLog(string logText);
        Task<ActionResult<bool>> StoreInCommandLog(CSSPAppNameEnum csspAppName, CSSPCommandNameEnum csspCommandName);
    }
    public partial class CSSPLogService : ControllerBase, ICSSPLogService
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
        public CSSPLogService(ILoggedInService LoggedInService, CSSPDBManageContext dbManage) : base()
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
        public async Task<ActionResult<bool>> StoreInCommandLog(CSSPAppNameEnum csspAppName, CSSPCommandNameEnum csspCommandName)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            int nextCommandLogID = (from c in dbManage.CommandLogs
                                    orderby c.CommandLogID descending
                                    select c.CommandLogID).FirstOrDefault() + 1;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = nextCommandLogID,
                AppName = csspAppName.ToString(),
                CommandName = csspCommandName.ToString(),
                Error = sbError.ToString(),
                Log = sbLog.ToString(),
                DateTimeUTC = DateTime.UtcNow,
            };

            try
            {
                commandLog.Error = sbError.ToString();
                commandLog.Log = sbLog.ToString();
                dbManage.CommandLogs.Add(commandLog);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                string AppAndCommandName = $"AppName: {csspAppName } - CommandName: {csspCommandName}";
                Console.WriteLine($"{String.Format(CSSPCultureUpdateRes.CouldNotAddCommandLog_Error_, AppAndCommandName, ex.Message)}");
                return await Task.FromResult(BadRequest($"{String.Format(CSSPCultureUpdateRes.CouldNotAddCommandLog_Error_, AppAndCommandName, ex.Message)}"));
            }

            return await Task.FromResult(Ok(true));
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
