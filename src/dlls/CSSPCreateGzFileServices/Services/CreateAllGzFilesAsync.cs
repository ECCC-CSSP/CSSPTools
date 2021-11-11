/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        public async Task<ActionResult<bool>> CreateAllGzFilesAsync()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            await DoCreateAllGzFilesAsync();

            if (CSSPLogService.ErrRes.ErrList.Count > 0)
            {
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
            }

            CSSPLogService.EndFunctionLog(FunctionName);
            return await Task.FromResult(Ok(true));
        }
    }
}
