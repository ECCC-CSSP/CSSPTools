/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPAzureAppTaskServices
{

    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        private async Task<bool> DoDeleteAzureAppTask(int appTaskID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(PostAppTaskModel postAppTaskModel)";

            if (!await CSSPLogService.FunctionLog(FunctionName)) return await Task.FromResult(false);

            AppTask appTask = (from c in db.AppTasks
                               where c.AppTaskID == appTaskID
                               select c).FirstOrDefault();

            if (appTask == null)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskID.ToString()), new[] { "" }));
                return false;
            }
            else
            {
                db.AppTasks.Remove(appTask);

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes.CouldNotDelete_Error_, "AppTask", ex.Message), new[] { "AppTask" }));
                    return false;
                }

            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            if (CSSPLogService.ValidationResultList.Count > 0) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}