/*
 * Manually edited
 *
 */

using CSSPAzureAppTaskServices.Models;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPWebModels;
using LoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        Task<bool> FillConfigModel(CSSPAzureAppTaskServiceConfigModel config);

    }
    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private ICSSPLogService CSSPLogService { get; }
        private IEnums enums { get; }
        private CSSPAzureAppTaskServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        public AzureAppTaskService(ICSSPCultureService CSSPCultureService, IEnums enums,
            ILoggedInService LoggedInService, ICSSPLogService CSSPLogService, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.CSSPLogService = CSSPLogService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}