namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebMWQMSamples1980_2020GzFileAsync(int SubsectorTVItemID)
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

        WebMWQMSamples1980_2020 webMWQMSamples1980_2020 = new WebMWQMSamples1980_2020();

        try
        {
            if (!await FillTVItemModelAndParentTVItemModelListAsync(webMWQMSamples1980_2020.TVItemModel, webMWQMSamples1980_2020.TVItemModelParentList, TVItemSubsector)) return await Task.FromResult(false);

            if (!await FillMWQMSampleModelList1980_2020Async(webMWQMSamples1980_2020.MWQMSampleModelList, TVItemSubsector)) return await Task.FromResult(false);

            if (Local)
            {
                if (!await StoreLocalAsync<WebMWQMSamples1980_2020>(webMWQMSamples1980_2020, $"{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebMWQMSamples1980_2020>(webMWQMSamples1980_2020, $"{ WebTypeEnum.WebMWQMSamples1980_2020 }_{ SubsectorTVItemID }.gz")) return await Task.FromResult(false);
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

