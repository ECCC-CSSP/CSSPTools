/*
 * Manually edited
 * 
 */
using CSSPEnums;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        public async Task<ActionResult<bool>> DeleteGzFile(WebTypeEnum webType, int TVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum: { webType }, TVItemID: { TVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));
            if (!await ValidateDBs(FunctionName)) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            await DoDeleteGzFile(webType, TVItemID);

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(true));
        }
    }
}
