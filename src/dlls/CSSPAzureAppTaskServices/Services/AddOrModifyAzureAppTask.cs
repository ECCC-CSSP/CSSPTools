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
        public async Task<ActionResult<AppTaskLocalModel>> AddOrModifyAzureAppTask(AppTaskLocalModel postAppTaskModel)
        {
            if (CSSPServerLoggedInService.LoggedInContactInfo == null || CSSPServerLoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                errRes.ErrList.Add(CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                return await Task.FromResult(Unauthorized(errRes));
            }

            if (!await ValidateAzureAddOrModifyAppTaskModel(postAppTaskModel))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            if (!await DoAddOrModifyAzureAppTask(postAppTaskModel))
            {
                return await Task.FromResult(BadRequest(errRes));
            }

            return await Task.FromResult(Ok(postAppTaskModel));
        }
    }
}