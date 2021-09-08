/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using LoggedInServices;
using System.ComponentModel.DataAnnotations;
using CSSPLogServices;
using System.Reflection;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        public async Task<bool> CheckComputerName(string FunctionName)
        {
            if (Environment.MachineName.ToString().ToLower() != config.ComputerName)
            {
                string errMessage = $"{ CSSPCultureUpdateRes.ThisAppCanOnlyBeRunOnComputerName } { config.ComputerName }. { CSSPCultureUpdateRes.ThisComputerNameIs } { Environment.MachineName.ToString().ToLower() }";
                await CSSPLogService.AppendLog(errMessage);

                await CSSPLogService.AppendError(new ValidationResult(errMessage, new[] { "" }));

                await CSSPLogService.EndFunctionLog(FunctionName);

                await CSSPLogService.Save();

                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
