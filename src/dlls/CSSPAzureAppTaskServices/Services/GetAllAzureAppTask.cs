/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using CSSPServerLoggedInServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPAzureAppTaskServices
{
    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        public async Task<ActionResult<List<AppTaskLocalModel>>> GetAllAzureAppTask()
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            List<AppTaskLocalModel> appTaskModelList = new List<AppTaskLocalModel>();

            List<AppTask> appTaskList = (from c in db.AppTasks select c).ToList();
            List<AppTaskLanguage> appTaskLanguageList = (from c in db.AppTaskLanguages select c).ToList();

            foreach (AppTask appTask in appTaskList)
            {
                appTaskModelList.Add(new AppTaskLocalModel()
                {
                    AppTask = appTask,
                    AppTaskLanguageList = (from c in appTaskLanguageList
                                           where c.AppTaskID == appTask.AppTaskID
                                           select c).ToList()
                });
            }

            return await Task.FromResult(Ok(appTaskModelList));
        }
    }
}