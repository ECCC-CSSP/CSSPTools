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
using System.ComponentModel.DataAnnotations;
using CSSPLogServices;
using System.Reflection;

namespace CSSPLogServices
{
    public partial class CSSPLogService : ControllerBase, ICSSPLogService
    {
        public async Task<ActionResult> EndFunctionReturnUnauthorized(string FunctionName, string ErrorText)
        {
            AppendError(ErrorText);
            EndFunctionLog(FunctionName);

            return await Task.FromResult(Unauthorized(ErrRes));
        }
    }
}
