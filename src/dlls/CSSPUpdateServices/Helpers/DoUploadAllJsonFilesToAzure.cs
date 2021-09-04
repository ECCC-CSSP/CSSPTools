using CSSPCultureServices.Resources;
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> DoUploadAllJsonFilesToAzure()
        {
            await CSSPLogService.FunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            var actionRes = await CreateGzFileService.CreateAllGzFiles();
            if (((ObjectResult)actionRes.Result).StatusCode != 200)
            {
                await CSSPLogService.AppendError(new ValidationResult($"{ CSSPCultureUpdateRes.ErrorWhileCreateAllGzFiles  }", new[] { "" }));

                await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            }

            await CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(Ok(true));
        }
    }
}
