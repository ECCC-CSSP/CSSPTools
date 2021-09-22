/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPAzureAppTaskServices
{

    public partial interface IAzureAppTaskService
    {
        Task<ActionResult<PostAppTaskModel>> AddOrModifyAzureAppTask(PostAppTaskModel postAppTaskModel);
        Task<ActionResult<bool>> DeleteAzureAppTask(int appTaskID);
        Task<ActionResult<List<PostAppTaskModel>>> GetAllAzureAppTask();
    }
    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private IEnums enums { get; }
        private ILoggedInService LoggedInService { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public AzureAppTaskService(IConfiguration Configuration, IEnums enums, ILoggedInService LoggedInService, CSSPDBContext db)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (LoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "LoggedInService") }");
            if (db == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db") }");

            if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "AzureAppTaskService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "AzureAppTaskService") }");

            this.Configuration = Configuration;
            this.enums = enums;
            this.LoggedInService = LoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}