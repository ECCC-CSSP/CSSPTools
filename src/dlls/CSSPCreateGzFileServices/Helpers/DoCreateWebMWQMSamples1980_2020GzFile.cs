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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateWebMWQMSamples1980_2020GzFile(int SubsectorTVItemID)
        {
            string FunctionName = $"{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(SubsectorTVItemID: { SubsectorTVItemID })";
            await CSSPLogService.FunctionLog(FunctionName);

            TVItem TVItemSubsector = await GetTVItemWithTVItemID(SubsectorTVItemID);
            
            if (TVItemSubsector == null || TVItemSubsector.TVType != TVTypeEnum.Subsector)
            {
                await CSSPLogService.AppendError(new ValidationResult(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_And_Equal_,
                    "TVItem", SubsectorTVItemID.ToString(), "TVType", TVTypeEnum.Subsector.ToString()), new[] { "" }));
                await CSSPLogService.EndFunctionLog(FunctionName);
                return await Task.FromResult(false);
            }

            WebMWQMSamples webMWQMSamples = new WebMWQMSamples();

            try
            {
                if (!await FillTVItemModelAndParentTVItemModelList(webMWQMSamples.TVItemModel, webMWQMSamples.TVItemModelParentList, TVItemSubsector)) return await Task.FromResult(false);

                if (!await FillMWQMSampleModelList1980_2020(webMWQMSamples.MWQMSampleModelList, TVItemSubsector)) return await Task.FromResult(false);

                if (dbLocal != null)
                {
                    if (!await DoStoreLocal<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
                }
                else
                {
                    if (!await DoStore<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
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
