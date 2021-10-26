﻿/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoCreateWebAllUseOfSitesGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            WebAllUseOfSites webAllUseOfSites  = new WebAllUseOfSites();

            try
            {
                webAllUseOfSites.UseOfSiteList = await GetAllUseOfSiteList();

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllUseOfSites>(webAllUseOfSites, $"{ WebTypeEnum.WebAllUseOfSites  }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllUseOfSites>(webAllUseOfSites, $"{ WebTypeEnum.WebAllUseOfSites  }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
