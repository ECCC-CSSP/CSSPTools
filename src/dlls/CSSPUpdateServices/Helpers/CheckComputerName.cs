using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using CSSPWebModels;
using System.Text.Json;
using System.IO;
using CSSPCultureServices.Resources;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        private async Task<bool> CheckComputerName()
        {
            if (Environment.MachineName.ToString().ToLower() != ComputerName)
            {
                CSSPLogService.AppendError($"{ CSSPCultureUpdateRes.ThisAppCanOnlyBeRunOnComputerName } { ComputerName }. { CSSPCultureUpdateRes.ThisComputerNameIs } { Environment.MachineName.ToString().ToLower() }");

                await CSSPLogService.StoreInCommandLog(CSSPAppNameEnum.CSSPUpdate, CSSPCommandNameEnum.ClearOldUnnecessaryStats);

                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
