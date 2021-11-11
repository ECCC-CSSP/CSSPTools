/*
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

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<bool> DoCreateWebAllMunicipalitiesGzFileAsync()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemRoot = await GetTVItemRootAsync();

            if (TVItemRoot == null || TVItemRoot.TVType != TVTypeEnum.Root)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_, 
                    "TVItem", "TVType", TVTypeEnum.Root.ToString()));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebAllMunicipalities webAllMunicipalities = new WebAllMunicipalities();

            try
            {
                if (!await FillAllMunicipalityModelListAsync(webAllMunicipalities.TVItemModelList, TVItemRoot)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocalAsync<WebAllMunicipalities>(webAllMunicipalities, $"{ WebTypeEnum.WebAllMunicipalities }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStoreAsync<WebAllMunicipalities>(webAllMunicipalities, $"{ WebTypeEnum.WebAllMunicipalities }.gz")) return await Task.FromResult(false);
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
