/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPServerLoggedInServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPAzureAppTaskServices
{

    public partial interface IAzureAppTaskService
    {
        Task<ActionResult<AppTaskLocalModel>> AddAzureAppTaskAsync(AppTaskLocalModel postAppTaskModel);
        Task<ActionResult<AppTaskLocalModel>> DeleteAzureAppTaskAsync(int appTaskID);
        Task<ActionResult<List<AppTaskLocalModel>>> GetAllAzureAppTaskAsync();
        Task<ActionResult<AppTaskLocalModel>> ModifyAzureAppTaskAsync(AppTaskLocalModel postAppTaskModel);
    }
    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private IEnums enums { get; }
        private ICSSPServerLoggedInService CSSPServerLoggedInService { get; }
        private ErrRes errRes { get; set; } = new ErrRes();
        #endregion Properties

        #region Constructors
        public AzureAppTaskService(IConfiguration Configuration, IEnums enums, ICSSPServerLoggedInService CSSPServerLoggedInService, CSSPDBContext db)
        {
            if (Configuration == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Configuration") }");
            if (enums == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
            if (CSSPServerLoggedInService == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPServerLoggedInService") }");
            if (db == null) throw new Exception($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db") }");

            if (string.IsNullOrEmpty(Configuration["AzureCSSPDB"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureCSSPDB", "AzureAppTaskService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "AzureAppTaskService") }");

            this.Configuration = Configuration;
            this.enums = enums;
            this.CSSPServerLoggedInService = CSSPServerLoggedInService;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}