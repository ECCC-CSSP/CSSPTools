/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
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
            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            if (!await ValidateDeleteAzureAppTask(appTaskID))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            if (!await DoDeleteAzureAppTask(appTaskID))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}