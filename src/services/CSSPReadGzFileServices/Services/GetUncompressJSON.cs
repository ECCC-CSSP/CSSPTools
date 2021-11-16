/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPWebModels;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;

namespace CSSPReadGzFileServices
{
    public partial class CSSPReadGzFileService : ControllerBase, ICSSPReadGzFileService
    {
        public async Task<T> GetUncompressJSON<T>(WebTypeEnum webType, int TVItemID = 0)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum: { webType }, TVItemID: { TVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            // might need to implement the check for unauthorized
            //if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            var actionRes = await ReadJSON<T>(webType, TVItemID);

            CSSPLogService.EndFunctionLog(FunctionName);

            if (CSSPLogService.ErrRes.ErrList.Count > 0)
            {
                return await Task.FromResult(JsonSerializer.Deserialize<T>("{}"));
            }

            return (T)((OkObjectResult)actionRes.Result).Value;
        }
    }
}
