using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.Extensions.Configuration;
using CSSPReadGzFileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using CSSPHelperModels;
using ManageServices;
using CSSPLocalLoggedInServices;
using CSSPCultureServices.Resources;
using CSSPScrambleServices;
using CSSPLogServices;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CSSPAzureLoginServices.Services
{
    public partial class CSSPAzureLoginService : ControllerBase, ICSSPAzureLoginService
    {
        public async Task<ActionResult<bool>> AzureLoginAsync(LoginModel loginModel)
        {
            await AzureLoginContactAsync(loginModel);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            await AzureLoginTVItemUserAuthorizationAsync();

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            await AzureLoginTVTypeUserAuthorizationAsync();

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            await AzureLoginManageAsync(loginModel);

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            if (!await CSSPLocalLoggedInService.SetLocalLoggedInContactInfo())
            {
                CSSPLogService.AppendError(CSSPCultureServicesRes.ErrorInSetLocalLoggedInContactInfo);
            }

            if (CSSPLogService.ErrRes.ErrList.Count > 0) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            return await Task.FromResult(Ok(true));
        }
    }
}
