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
using System.Reflection;
using CSSPFileServices.Models;
using CSSPReadGzFileServices.Models;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        public async Task<bool> FillConfigModel(CSSPReadGzFileServiceConfigModel config)
        {
            this.config = config;

            return await Task.FromResult(true);
        }
    }
}
