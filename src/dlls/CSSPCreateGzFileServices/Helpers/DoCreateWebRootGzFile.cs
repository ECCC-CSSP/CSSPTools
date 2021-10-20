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

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoCreateWebRootGzFile()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemRoot = await GetTVItemRoot();

            if (TVItemRoot == null)
            {
                CSSPLogService.AppendError(CSSPCultureServicesRes.TVItemRootCouldNotBeFound);
                CSSPLogService.EndFunctionLog(FunctionName);
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
                CSSPLogService.AppendError($"{ ex.Message } { inner }");
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(true);
        }
    }
}