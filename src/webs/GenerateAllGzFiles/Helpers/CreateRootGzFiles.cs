﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Resources;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using UserServices.Models;
using UserServices.Services;

namespace GenerateAllGzFiles
{
    public partial class Startup
    {
        private async Task<bool> CreateRootGzFile()
        {
            await WebService.GetWebRoot();

            return await Task.FromResult(true);
        }
    }
}
