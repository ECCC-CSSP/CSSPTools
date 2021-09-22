/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPHelperModels;
using LoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CSSPLogServices
{
    public interface ICSSPLogService
    {
        string CSSPAppName { get; set; }
        string CSSPCommandName { get; set; }
        StringBuilder sbError { get; set; }
        StringBuilder sbLog { get; set; }
        ErrRes ErrRes { get; set; }

        void AppendError(string Err);
        void AppendLog(string logText);
        Task<bool> CheckComputerName(string FunctionName);
        Task<bool> CheckLogin(string FunctionName);
        void EndFunctionLog(string FullFunctionName);
        Task<ActionResult> EndFunctionReturnBadRequest(string FunctionName, string ErrorText);
        Task<ActionResult> EndFunctionReturnOkTrue(string FunctionName);
        Task<ActionResult> EndFunctionReturnUnauthorized(string FunctionName, string ErrorText);
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
        public ErrRes ErrRes { get; set; } = new ErrRes();

        private CSSPDBManageContext dbManage { get; }
        private ILoggedInService LoggedInService { get; }
        private IConfiguration Configuration { get; }
        private int FunctionCount { get; set; } = 0;
        #endregion Properties

        #region Constructors
        public CSSPLogService(IConfiguration Configuration, ILoggedInService LoggedInService, CSSPDBManageContext dbManage) : base()
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (LoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "LoggedInService ") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPLogService") }");
            if (string.IsNullOrEmpty(Configuration["ComputerName"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "ComputerName", "CSSPLogService") }");

            this.Configuration = Configuration;
            this.LoggedInService = LoggedInService;
            this.dbManage = dbManage;
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
