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
        public async Task<ActionResult<PostAppTaskModel>> AddOrModifyAzureAppTask(PostAppTaskModel postAppTaskModel)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(PostAppTaskModel postAppTaskModel)";
            CSSPLogService.FunctionLog(FunctionName);
            
            CSSPLogService.AppendLog($"AppTaskID: { postAppTaskModel.AppTask.AppTaskID} -- AppTaskCommand: { postAppTaskModel.AppTask.AppTaskCommand } -- TVItemID: { postAppTaskModel.AppTask.TVItemID }");

            if (!await CheckLogin(FunctionName))
            {
                CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));
            }

            if (!await ValidateAzureAddOrModifyAppTaskModel(postAppTaskModel))
            {
                CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            }

            if (!await DoAddOrModifyAzureAppTask(postAppTaskModel))
            {
                CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            }

            CSSPLogService.EndFunctionLog(FunctionName);
            await CSSPLogService.Save();

            return await Task.FromResult(Ok(postAppTaskModel));
        }
    }
}