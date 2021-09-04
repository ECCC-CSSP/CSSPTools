/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebRootGzFile()
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null)
            {
                await CSSPLogService.AppendError(new ValidationResult(CSSPCultureServicesRes.TVItemRootCouldNotBeFound, new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebRoot webRoot = new WebRoot();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webRoot.TVItemModel, webRoot.TVItemModelParentList, TVItemRoot)) return await Task.FromResult(false);

                if (!await FillChildListTVItemModelList(webRoot.TVItemModelCountryList, TVItemRoot, TVTypeEnum.Country)) return await Task.FromResult(false);

                if (!await FillFileModelList(webRoot.TVFileModelList, TVItemRoot)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebRoot>(webRoot, $"{ WebTypeEnum.WebRoot }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebRoot>(webRoot, $"{ WebTypeEnum.WebRoot }.gz")) return await Task.FromResult(false);
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