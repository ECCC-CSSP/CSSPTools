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

namespace CSSPLogServices
{
    public partial class CSSPLogService : ControllerBase, ICSSPLogService
    {
        public async Task<bool> CheckComputerName(string FunctionName)
        {
            if (Environment.MachineName.ToString().ToLower() != config.ComputerName)
            {
                AppendError($"{ CSSPCultureServicesRes.ThisAppCanOnlyBeRunOnComputerName } { config.ComputerName }. { CSSPCultureServicesRes.ThisComputerNameIs } { Environment.MachineName.ToString().ToLower() }");
                EndFunctionLog(FunctionName);
                await Save();

                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
