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
        private async Task<bool> DoCreateWebAllMunicipalitiesGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null || TVItemRoot.TVType != TVTypeEnum.Root)
            {
                CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_, 
                    "TVItem", "TVType", TVTypeEnum.Root.ToString()), new[] { "" }));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebAllMunicipalities webAllMunicipalities = new WebAllMunicipalities();

            try
            {
                if (!await FillAllMunicipalityModelList(webAllMunicipalities.TVItemModelList, TVItemRoot)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebAllMunicipalities>(webAllMunicipalities, $"{ WebTypeEnum.WebAllMunicipalities }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebAllMunicipalities>(webAllMunicipalities, $"{ WebTypeEnum.WebAllMunicipalities }.gz")) return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                CSSPLogService.AppendError(new ValidationResult($"{ ex.Message } { inner }", new[] { "" }));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}
