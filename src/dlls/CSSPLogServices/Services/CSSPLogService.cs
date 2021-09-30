/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPHelperModels;
using CSSPLocalLoggedInServices;
using CSSPScrambleServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        private List<int> skip { get; set; } = new List<int>()
        {
            3, 1, -3, 2, 2, 0, 4, 1, -2, 2, -1, 3, -2, 0, 1, 3, 1, 2, -4, -1, 1, 2, 0, 2, 1,
            -1, 4, -4, 2, 3, 1, 2, 3, 1, 2, 3, 1, 3, 1, -2, -1, -1, 4, -2, 2, -3, 2, 2, 0, 4,
            3, 1, 1, -2, -1, 3, -2, 0, 3, 2, 0, 1, 4, 1, 1, -4, -1, 2, 0, 2, 1, -3, 2, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, 2, 1,
            -2, 3, 1, -3, 2, 3, -2, -1, 4, 1, -2, 2, 2, -1, 0, 4, 1, -2, -1, 3, -2, 0, 3, -1, 1, -4, -1, 2, 0, 2, 1,
            -1, 2, 3, 2, 1, -3, 2, 3, 2, 0, 4, 1, 2, -2, -1, 0, 3, -2, 0, 3, 1, -4, -1, 3, 2, 0, 2, 1,
            -4, 3, 1, -3, 1, 2, 2, 0, 1, 2, 4, 1, -1, 3, -1, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, -1, 2, 1,
            1, 3, 4, 1, -3, -2, 2, 2, 0, -1, 4, 1, -2, -1, 3, 2, -2, 0, 1, 3, 1, -2, -4, -1, -1, 2, 0, 2, 1,
            4, 3, -2, -1, 2, 0, 2, -1, 4, 2, 0, 1, -1, -1, -3, -2, 2, -4, 3, 2, 1, -3, 2, -1, 2, 4, 0, 0, 1,
            2, 1, -2, -4, 1, 3, -3, 1, -1, 2, 1, 0, 4, -1, 1, -1, -3, 1, 1, -3, -4, 1, -3, 1, -3, 1, -1, 0,
            4, 2, 1, -3, 1, -2, 1, -4, 1, -2, 0, 3, -1, 4, 1, -2, 1, 0, -4, -1, -3, 2, 1, 4, -1, 1, 2, 4, 2
        };
        #endregion Variables

        #region Properties
        public string CSSPAppName { get; set; } = "Unknown";
        public string CSSPCommandName { get; set; } = "Unknown";
        public StringBuilder sbError { get; set; } = new StringBuilder();
        public StringBuilder sbLog { get; set; } = new StringBuilder();
        public ErrRes ErrRes { get; set; } = new ErrRes();

        private IConfiguration Configuration { get; }
        private ICSSPScrambleService CSSPScrambleService { get; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; }
        private CSSPDBManageContext dbManage { get; }
        private int FunctionCount { get; set; } = 0;
        #endregion Properties

        #region Constructors
        public CSSPLogService(IConfiguration Configuration, ICSSPScrambleService CSSPScrambleService, ICSSPLocalLoggedInService CSSPLocalLoggedInService, CSSPDBManageContext dbManage) : base()
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (CSSPLocalLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService ") }");
            if (dbManage == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "dbManage") }");

            if (string.IsNullOrEmpty(Configuration["CSSPDBManage"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "CSSPLogService") }");
            if (string.IsNullOrEmpty(Configuration["ComputerName"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "ComputerName", "CSSPLogService") }");

            this.Configuration = Configuration;
            this.CSSPScrambleService = CSSPScrambleService;
            this.CSSPLocalLoggedInService = CSSPLocalLoggedInService;
            this.dbManage = dbManage;
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
