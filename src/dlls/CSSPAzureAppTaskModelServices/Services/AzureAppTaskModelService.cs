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
using LoggedInServices;
using Microsoft.Extensions.Configuration;
using CSSPWebModels;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CSSPDBPreferenceModels;

namespace CSSPAzureAppTaskModelServices
{

    public partial interface IAzureAppTaskModelService
    {
        Task<ActionResult<List<AppTaskModel>>> GetAllAzureAppTaskModel();
        Task<ActionResult<AppTaskModel>> AddOrModifyAzureAppTaskModel(AppTaskModel appTaskModel);
        Task<ActionResult<bool>> DeleteAzureAppTaskModel(int AppTaskID);
    }
    public partial class AzureAppTaskModelService : ControllerBase, IAzureAppTaskModelService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AzureAppTaskModelService(ICSSPCultureService CSSPCultureService, IEnums enums, 
            ILoggedInService LoggedInService, CSSPDBContext db)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<AppTaskModel>> AddOrModifyAzureAppTaskModel(AppTaskModel appTaskModel)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!ValidateAzureAddOrModifyAppTaskModel(new ValidationContext(appTaskModel)))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (!DoAddOrModifyAzureAppTaskModel(appTaskModel))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(appTaskModel));
        }
        public async Task<ActionResult<bool>> DeleteAzureAppTaskModel(int AppTaskID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!ValidateDeleteAzureAppTaskModel(AppTaskID))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (!DoDeleteAzureAppTaskModel(AppTaskID))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<List<AppTaskModel>>> GetAllAzureAppTaskModel()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<AppTaskModel> appTaskModelList = new List<AppTaskModel>();

            List<AppTask> appTaskList = (from c in db.AppTasks select c).ToList();
            List<AppTaskLanguage> appTaskLanguageList = (from c in db.AppTaskLanguages select c).ToList();

            foreach(AppTask appTask in appTaskList)
            {
                appTaskModelList.Add(new AppTaskModel()
                {
                    AppTask = appTask,
                    AppTaskLanguageList = (from c in appTaskLanguageList
                                           where c.AppTaskID == appTask.AppTaskID
                                           select c).ToList()
                });
            }

            return await Task.FromResult(Ok(appTaskModelList));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}