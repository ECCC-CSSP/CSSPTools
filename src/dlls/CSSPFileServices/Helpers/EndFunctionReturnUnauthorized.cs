﻿/*
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

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        private async Task<ActionResult> EndFunctionReturnUnauthorized(string FunctionName, string ErrorText)
        {
            await CSSPLogService.AppendError(new ValidationResult(ErrorText, new[] { "" }));
            await CSSPLogService.EndFunctionLog(FunctionName);
            await CSSPLogService.Save();

            return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));
        }
    }
}
