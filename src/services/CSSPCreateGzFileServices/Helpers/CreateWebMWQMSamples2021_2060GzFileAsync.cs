﻿namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMWQMSamples2021_2060GzFileAsync(int SubsectorTVItemID)
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

            if (!await FillMWQMSampleModelList2021_2060Async(webMWQMSamples.MWQMSampleModelList, TVItemSubsector)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMWQMSamples>(webMWQMSamples, $"{ WebTypeEnum.WebMWQMSamples2021_2060 }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
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

