using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        private async Task<bool> LogError4ArgsDateReturnFalse(string FunctionName)
        {
            CSSPLogService.AppendError($"CSSPUpdate.exe { CSSPLogService.CSSPCommandName } 2000 01 01");
            CSSPLogService.AppendError($"CSSPUpdate.exe { CSSPLogService.CSSPCommandName } yyyy MM dd");
            CSSPLogService.AppendError($"CSSPUpdate.exe { CSSPLogService.CSSPCommandName } { DateTime.Now.Year } { DateTime.Now.Month } { DateTime.Now.Day }");

            CSSPLogService.FunctionLog(FunctionName);

            return await Task.FromResult(false);
        }
    }
}