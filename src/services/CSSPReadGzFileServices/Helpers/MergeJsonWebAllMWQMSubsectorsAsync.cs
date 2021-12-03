namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAllMWQMSubsectorsAsync(WebAllMWQMSubsectors webAllMWQMSubsectors, WebAllMWQMSubsectors webAllMWQMSubsectorsLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllMWQMSubsectors webAllMWQMSubsectors, WebAllMWQMSubsectors webAllMWQMSubsectorsLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebSubsectorMWQMSubsector(webAllMWQMSubsectors, webAllMWQMSubsectorsLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebSubsectorMWQMSubsector(WebAllMWQMSubsectors webAllMWQMSubsectors, WebAllMWQMSubsectors webAllMWQMSubsectorsLocal)
    {
        List<MWQMSubsectorModel> mwqmSubsectorModelLocalList = (from c in webAllMWQMSubsectorsLocal.MWQMSubsectorModelList
                                                                where c.MWQMSubsector.MWQMSubsectorID != 0
                                                                && c.MWQMSubsector.DBCommand != DBCommandEnum.Original
                                                                || c.MWQMSubsectorLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                || c.MWQMSubsectorLanguageList[1].DBCommand != DBCommandEnum.Original
                                                                select c).ToList();

        foreach (MWQMSubsectorModel mwqmSubsectorModelLocal in mwqmSubsectorModelLocalList)
        {
            MWQMSubsectorModel mwqmSubsectorModelOriginal = webAllMWQMSubsectors.MWQMSubsectorModelList.Where(c => c.MWQMSubsector.MWQMSubsectorID == mwqmSubsectorModelLocal.MWQMSubsector.MWQMSubsectorID).FirstOrDefault();
            if (mwqmSubsectorModelOriginal == null)
            {
                webAllMWQMSubsectors.MWQMSubsectorModelList.Add(mwqmSubsectorModelLocal);
            }
            else
            {
                mwqmSubsectorModelOriginal = mwqmSubsectorModelLocal;
            }
        }
    }
}

