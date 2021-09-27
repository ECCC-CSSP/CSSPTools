using CSSPCultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        private async Task<bool> LogError4ArgsReturnFalse(List<string> AllowableCSSPCommandNameList, string FunctionName)
        {
            CSSPLogService.AppendError($"{CSSPCultureServicesRes.AllowableCommandsAre}:");
            foreach (string CSSPCommandNameItem in AllowableCSSPCommandNameList)
            {
                CSSPLogService.AppendError($"CSSPUpdate.exe {CSSPCommandNameItem} yyyy MM dd");
            }

            CSSPLogService.FunctionLog(FunctionName);

            return await Task.FromResult(false);
        }
    }
}