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
using System.Threading.Tasks;

namespace CSSPDBLocalServices
{

    public partial class AppTaskLocalService : ControllerBase, IAppTaskLocalService
    {
        private async Task<bool> ValidateDeleteAppTaskLocal(AppTaskLocalModel appTaskModel)
        {
            if (appTaskModel.AppTask.AppTaskID == 0)
            {
                CSSPLogService.ErrRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
            }

            return CSSPLogService.ErrRes.ErrList.Count == 0 ? await Task.FromResult(true) :  await Task.FromResult(false);
        }
    }
}