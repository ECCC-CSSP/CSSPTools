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
        private async Task<bool> CheckLogin(string FunctionName)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                await CSSPLogService.AppendError(new ValidationResult(CSSPCultureServicesRes.YouDoNotHaveAuthorization, new[] { "" }));

                await CSSPLogService.EndFunctionLog(FunctionName);

                await CSSPLogService.Save();

                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}