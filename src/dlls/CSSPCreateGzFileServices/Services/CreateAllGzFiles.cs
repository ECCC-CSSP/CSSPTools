/*
 * Manually edited
 * 
 */
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        public async Task<ActionResult<bool>> CreateAllGzFiles()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckComputerName(FunctionName)) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));
            if (!await ValidateDBs(FunctionName)) return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));

            if (!await ValidateDBs(FunctionName))
            {
                CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
            }

            await DoCreateAllGzFiles();

            return await CSSPLogService.EndFunctionReturnOkTrue(FunctionName);
        }
    }
}
