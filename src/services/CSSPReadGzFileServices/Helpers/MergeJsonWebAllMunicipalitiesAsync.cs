namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAllMunicipalitiesAsync(WebAllMunicipalities webAllMunicipalities, WebAllMunicipalities webAllMunicipalitiesLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllMunicipalities WebAllMunicipalities, WebAllMunicipalities WebAllMunicipalitiesLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebAllMunicipalitiesTVItemModelList(webAllMunicipalities, webAllMunicipalitiesLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }

    private void MergeJsonWebAllMunicipalitiesTVItemModelList(WebAllMunicipalities webAllMunicipalities, WebAllMunicipalities webAllMunicipalitiesLocal)
    {
        List<TVItemModel> tvItemModelLocalList = (from c in webAllMunicipalitiesLocal.TVItemModelList
                                                  where c.TVItem.DBCommand != DBCommandEnum.Original
                                                  || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                  || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original
                                                  select c).ToList();

        foreach (TVItemModel tvItemModelLocal in tvItemModelLocalList)
        {
            TVItemModel tvItemModelOriginal = webAllMunicipalities.TVItemModelList.Where(c => c.TVItem.TVItemID == tvItemModelLocal.TVItem.TVItemID).FirstOrDefault();
            if (tvItemModelOriginal == null)
            {
                webAllMunicipalities.TVItemModelList.Add(tvItemModelLocal);
            }
            else
            {
                SyncTVModel(tvItemModelOriginal, tvItemModelLocal);
            }
        }
    }
}

