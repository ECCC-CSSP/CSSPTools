/*
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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebAllTideLocationsGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            WebAllTideLocations webAllTideLocations = new WebAllTideLocations();

            try
            {
                webAllTideLocations.TideLocationList = await GetTideLocation();

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllTideLocations>(webAllTideLocations, $"{ WebTypeEnum.WebAllTideLocations }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllTideLocations>(webAllTideLocations, $"{ WebTypeEnum.WebAllTideLocations }.gz")) return await Task.FromResult(false);
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
