namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> CreateWebAllMWQMSubsectorsGzFileAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        WebAllMWQMSubsectors webAllMWQMSubsectors = new WebAllMWQMSubsectors();

        try
        {
            List<MWQMSubsector> mwqmSubsectorList = await GetAllMWQMSubsectorAsync();
            List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = await GetAllMWQMSubsectorLanguageAsync();

            foreach (MWQMSubsector mwqmSubsector in mwqmSubsectorList)
            {
                webAllMWQMSubsectors.MWQMSubsectorModelList.Add(new MWQMSubsectorModel()
                {
                    MWQMSubsector = mwqmSubsector,
                    MWQMSubsectorLanguageList = (from c in mwqmSubsectorLanguageList
                                                 where c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID
                                                 orderby c.Language
                                                 select c).ToList()
                });
            }

            if (Local)
            {
                if (!await StoreLocalAsync<WebAllMWQMSubsectors>(webAllMWQMSubsectors, $"{ WebTypeEnum.WebAllMWQMSubsectors }.gz")) return await Task.FromResult(false);
            }
            else
            {
                if (!await StoreAsync<WebAllMWQMSubsectors>(webAllMWQMSubsectors, $"{ WebTypeEnum.WebAllMWQMSubsectors }.gz")) return await Task.FromResult(false);
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
