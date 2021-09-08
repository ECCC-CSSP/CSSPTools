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
    public partial class AzureAppTaskService : ControllerBase, IAzureAppTaskService
    {
        public async Task<ActionResult<bool>> DeleteAzureAppTask(int appTaskID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int appTaskID) -- appTaskID: { appTaskID }";
            if (!await CSSPLogService.FunctionLog(FunctionName)) return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));

            if (!await CheckLogin(FunctionName))
            {
                await CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));
            }

            if (!await ValidateDeleteAzureAppTask(appTaskID))
            {
                await CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            }

            if (!await DoDeleteAzureAppTask(appTaskID))
            {
                await CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            }

            await CSSPLogService.EndFunctionLog(FunctionName);
            await CSSPLogService.Save();

            return await Task.FromResult(Ok(true));
        }
    }
}