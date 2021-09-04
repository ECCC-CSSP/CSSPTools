using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> DoUploadChangedJsonFilesToAzure()
        {
            await CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            //if (!await CreateGzFileService.CreateChangedGzFiles())
            //{
            //    await CSSPLogService.AppendError($"{ CSSPCultureUpdateRes.ErrorWhileCreateAllGzFiles  }");

            //    await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.UploadAllJsonFilesToAzure);

            //    return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));

            //}

            await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
