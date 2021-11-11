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
        private async Task<bool> DoCreateWebMWQMSamples1980_2020GzFileAsync(int SubsectorTVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(SubsectorTVItemID: { SubsectorTVItemID })";
            CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemSubsector = await GetTVItemWithTVItemIDAsync(SubsectorTVItemID);
            
            if (TVItemSubsector == null || TVItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()));
                CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebMWQMSamples webMWQMSamples = new WebMWQMSamples();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelListAsync(webMWQMSamples.TVItemModel, webMWQMSamples.TVItemModelParentList, TVItemSubsector)) return await Task.FromResult(false);

                if (!await FillMWQMSampleModelList1980_2020Async(webMWQMSamples.MWQMSampleModelList, TVItemSubsector)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocalAsync<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStoreAsync<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
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
