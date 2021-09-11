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
using CSSPCreateGzFileServices.Models;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        public async Task<ActionResult<bool>> CreateAllGzFiles()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckComputerName(FunctionName)) return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));
            if (!await ValidateDBs(FunctionName)) return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));

            if (!await ValidateDBs(FunctionName))
            {
                CSSPLogService.EndFunctionLog(FunctionName);
                await CSSPLogService.Save();

                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            }

            await DoCreateAllGzFiles();

            return await CSSPLogService.EndFunctionReturnOkTrue(FunctionName);
        }
    }
}
