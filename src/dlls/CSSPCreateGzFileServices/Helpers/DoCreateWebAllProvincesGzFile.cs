﻿/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CSSPWebModels;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebAllProvincesGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null || TVItemRoot.TVType != TVTypeEnum.Root)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_, 
                    "TVItem", "TVType", TVTypeEnum.Root.ToString()), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebAllProvinces webAllProvinces = new WebAllProvinces();

            try
            {
                if (!await FillProvinceModelList(webAllProvinces.TVItemModelList, TVItemRoot)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllProvinces>(webAllProvinces, $"{ WebTypeEnum.WebAllProvinces }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllProvinces>(webAllProvinces, $"{ WebTypeEnum.WebAllProvinces }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                await CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            await CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
