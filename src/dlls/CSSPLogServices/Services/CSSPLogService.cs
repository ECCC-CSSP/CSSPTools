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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CSSPLogServices.Models;
using System.Reflection;

namespace CSSPLogServices
{
    public interface ICSSPLogService
    {
        string CSSPAppName { get; set; }
        string CSSPCommandName { get; set; }
        StringBuilder sbError { get; set; }
        StringBuilder sbLog { get; set; }
        List<ValidationResult> ValidationResultList { get; set; }

        Task<bool> AppendError(ValidationResult validationResult);
        Task<bool> AppendLog(string logText);
        Task<bool> EndFunctionLog(string FullFunctionName);
        Task<bool> FillConfigModel(CSSPLogServiceConfigModel config);
        Task<bool> FunctionLog(string FullFunctionName);
        Task<string> GetFunctionName(string FullFunctionName);
        Task<bool> Save();
    }
    public partial class CSSPLogService : ControllerBase, ICSSPLogService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public string CSSPAppName { get; set; } = "Unknown";
        public string CSSPCommandName { get; set; } = "Unknown";
        public StringBuilder sbError { get; set; } = new StringBuilder();
        public StringBuilder sbLog { get; set; } = new StringBuilder();
        public List<ValidationResult> ValidationResultList { get; set; } = new List<ValidationResult>();

        private CSSPDBManageContext dbManage { get; }
        private ILoggedInService LoggedInService { get; }
        private IConfiguration Configuration { get; }
        private string ComputerName { get; set; } = "Unknown";
        private int FunctionCount { get; set; } = 0;
        private CSSPLogServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPLogService(IConfiguration Configuration, ILoggedInService LoggedInService, CSSPDBManageContext dbManage) : base()
        {
            this.LoggedInService = LoggedInService;
            this.dbManage = dbManage;
            this.Configuration = Configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> AppendError(ValidationResult validationResult)
        {
            ValidationResultList.Add(validationResult);

            string errorText = $"{CSSPCultureUpdateRes.ERROR}: {validationResult.ErrorMessage}";

            Console.WriteLine($"\r{errorText}");

            sbLog.AppendLine($"    {errorText}");
            sbError.AppendLine(errorText);

            return await Task.FromResult(true);
        }
        public async Task<bool> AppendLog(string logText)
        {
            Console.WriteLine($"\r{logText}");
            sbLog.AppendLine($"    {logText}");

            return await Task.FromResult(true);
        }
        public async Task<bool> EndFunctionLog(string FunctionStr)
        {
            sbLog.AppendLine($"{ FunctionCount } - { DateTime.Now } -   { CSSPCultureUpdateRes.End } - { FunctionStr }");

            FunctionCount -= 1;

            return await Task.FromResult(true);
        }
        public async Task<bool> FillConfigModel(CSSPLogServiceConfigModel config)
        {
            this.config = config;

            return await Task.FromResult(true);
        }
        public async Task<bool> FunctionLog(string FunctionStr)
        {
            FunctionCount += 1;

            sbLog.AppendLine($"{ FunctionCount } - { DateTime.Now } - { CSSPCultureUpdateRes.Start } - { FunctionStr }");

            return await Task.FromResult(true);
        }
        public async Task<string> GetFunctionName(string FullFunctionName)
        {
            string FunctionName = FullFunctionName;
            FunctionName = FunctionName.Substring(FunctionName.IndexOf("<") + 1);
            FunctionName = FunctionName.Substring(0, FunctionName.IndexOf(">"));

            return await Task.FromResult(FunctionName);
        }
        public async Task<bool> Save()
        {
            //if (LoggedInService.LoggedInContactInfo == null)
            //{
            //    return await Task.FromResult(false);
            //}

            int nextCommandLogID = (from c in dbManage.CommandLogs
                                    orderby c.CommandLogID descending
                                    select c.CommandLogID).FirstOrDefault() + 1;

            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = nextCommandLogID,
                AppName = CSSPAppName.ToString(),
                CommandName = CSSPCommandName.ToString(),
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
                string AppAndCommandName = $"AppName: {CSSPAppName } - CommandName: {CSSPCommandName}";
                Console.WriteLine($"{String.Format(CSSPCultureUpdateRes.CouldNotAddCommandLog_Error_, AppAndCommandName, ex.Message)}");

                FunctionCount = 0;

                return await Task.FromResult(false);
            }

            FunctionCount = 0;

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
