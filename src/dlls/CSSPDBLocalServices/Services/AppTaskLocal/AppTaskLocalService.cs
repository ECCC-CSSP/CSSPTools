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

namespace CSSPDBLocalServices
{

    public partial interface IAppTaskLocalService
    {
        Task<ActionResult<PostAppTaskModel>> AddOrModifyLocal(PostAppTaskModel postAppTaskModel);
        Task<ActionResult<bool>> DeleteLocal(int appTaskID);
        Task<ActionResult<List<PostAppTaskModel>>> GetAllAppTaskLocal();
    }
    public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBLocalContext dbLocal { get; }
        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        private List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLocalService(IConfiguration Configuration, ICSSPCultureService CSSPCultureService, IEnums enums, ILoggedInService LoggedInService,
           CSSPDBLocalContext dbLocal)
        {
            this.Configuration = Configuration;
            this.CSSPCultureService = CSSPCultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.dbLocal = dbLocal;
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<PostAppTaskModel>> AddOrModifyLocal(PostAppTaskModel appTaskModel)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!ValidateAddOrModifyAppTaskLocal(appTaskModel))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (!DoAddOrModifyAppTask(appTaskModel))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(appTaskModel));
        }
        public async Task<ActionResult<bool>> DeleteLocal(int appTaskID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            if (!ValidateDeleteAppTaskLocal(appTaskID))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            if (!DoDeleteAppTaskLocal(appTaskID))
            {
                return await Task.FromResult(BadRequest(ValidationResults));
            }

            return await Task.FromResult(Ok(true));
        }
        public async Task<ActionResult<List<PostAppTaskModel>>> GetAllAppTaskLocal()
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            List<PostAppTaskModel> appTaskModelList = new List<PostAppTaskModel>();

            List<AppTask> appTaskList = (from c in dbLocal.AppTasks select c).ToList();
            List<AppTaskLanguage> appTaskLanguageList = (from c in dbLocal.AppTaskLanguages select c).ToList();

            foreach (AppTask appTask in appTaskList)
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