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
        private async Task<bool> ValidateDeleteAppTaskLocal(int appTaskID)
        {
            if (appTaskID == 0)
            {
                errRes.ErrList.Add(string.Format(CSSPCultureServicesRes._IsRequired, "AppTaskID"));
            }

            return errRes.ErrList.Count == 0 ? await Task.FromResult(true) :  await Task.FromResult(false);
        }
    }
}