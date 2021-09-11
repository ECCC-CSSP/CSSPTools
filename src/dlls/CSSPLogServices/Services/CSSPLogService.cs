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

        void AppendError(ValidationResult validationResult);
        void AppendLog(string logText);
        Task<bool> CheckComputerName(string FunctionName);
        Task<bool> CheckLogin(string FunctionName);
        void EndFunctionLog(string FullFunctionName);
        Task<ActionResult> EndFunctionReturnBadRequest(string FunctionName, string ErrorText);
        Task<ActionResult> EndFunctionReturnOkTrue(string FunctionName);
        Task<ActionResult> EndFunctionReturnUnauthorized(string FunctionName, string ErrorText);
        bool FillConfigModel(CSSPLogServiceConfigModel config);
        void FunctionLog(string FullFunctionName);
        string GetFunctionName(string FullFunctionName);
        Task<ActionResult> Save();
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
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
