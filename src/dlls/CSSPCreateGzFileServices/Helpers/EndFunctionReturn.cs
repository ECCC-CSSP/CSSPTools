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
using CSSPCreateGzFileServices.Models;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> EndFunctionReturn(string FunctionName)
        {
            await CSSPLogService.EndFunctionLog(FunctionName);
            await CSSPLogService.Save();

            if (CSSPLogService.ValidationResultList.Count > 0)
            {
                return await Task.FromResult(BadRequest(CSSPLogService.ValidationResultList));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}