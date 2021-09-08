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
        private async Task<bool> ValidateDeleteAzureAppTask(int appTaskID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int appTaskID) -- appTaskID: { appTaskID }";
            if (!await CSSPLogService.FunctionLog(FunctionName)) return await Task.FromResult(false);

            if (appTaskID == 0)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"), new[] { "AppTaskID" }));
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            if (CSSPLogService.ValidationResultList.Count > 0) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}