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
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AzureAppTaskService(ICSSPCultureService CSSPCultureService, IEnums enums, 
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
        public async Task<ActionResult<PostAppTaskModel>> AddOrModifyAzureAppTask(PostAppTaskModel postAppTaskModel)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!ValidateAzureAddOrModifyAppTaskModel(postAppTaskModel))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (!DoAddOrModifyAzureAppTask(postAppTaskModel))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(postAppTaskModel));
        }
        public async Task<ActionResult<bool>> DeleteAzureAppTask(int appTaskID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!ValidateDeleteAzureAppTask(appTaskID))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (!DoDeleteAzureAppTask(appTaskID))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<List<PostAppTaskModel>>> GetAllAzureAppTask()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<PostAppTaskModel> appTaskModelList = new List<PostAppTaskModel>();

            List<AppTask> appTaskList = (from c in db.AppTasks select c).ToList();
            List<AppTaskLanguage> appTaskLanguageList = (from c in db.AppTaskLanguages select c).ToList();

            foreach(AppTask appTask in appTaskList)
            {
                appTaskModelList.Add(new PostAppTaskModel()
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