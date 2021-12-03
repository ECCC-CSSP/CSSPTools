namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebPolSourceSitesAsync(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebPolSourceSites WebPolSourceSites, WebPolSourceSites WebPolSourceSitesLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebPolSourceSitesTVItemModel(webPolSourceSites, webPolSourceSitesLocal);

        MergeJsonWebPolSourceSitesTVItemModelParentList(webPolSourceSites, webPolSourceSitesLocal);

        MergeJsonWebPolSourceSitesPolSourceSiteModelList(webPolSourceSites, webPolSourceSitesLocal);

        MergeJsonWebPolSourceSitesIsLocalized(webPolSourceSites, webPolSourceSitesLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebPolSourceSitesTVItemModel(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
    {
        if (webPolSourceSitesLocal.TVItemModel.TVItem.TVItemID != 0
            && (webPolSourceSitesLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
          || webPolSourceSitesLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
          || webPolSourceSitesLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
        {
            SyncTVItemModel(webPolSourceSites.TVItemModel, webPolSourceSitesLocal.TVItemModel);
        }
    }
    private void MergeJsonWebPolSourceSitesTVItemModelParentList(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
    {
        if ((from c in webPolSourceSitesLocal.TVItemModelParentList
             where c.TVItem.TVItemID != 0
             && (c.TVItem.DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
             select c).Any())
        {
            SyncTVItemModelParentList(webPolSourceSites.TVItemModelParentList, webPolSourceSitesLocal.TVItemModelParentList);
        }
    }
    private void MergeJsonWebPolSourceSitesPolSourceSiteModelList(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
    {
        List<PolSourceSiteModel> PolSourceSiteModelLocalList = (from c in webPolSourceSitesLocal.PolSourceSiteModelList
                                                                where c.TVItemModel.TVItem.TVItemID != 0
                                                                && c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                                select c).ToList();

        foreach (PolSourceSiteModel mwqmPolSourceSiteModelLocal in PolSourceSiteModelLocalList)
        {
            PolSourceSiteModel mwqmPolSourceSiteModelOriginal = (from c in webPolSourceSites.PolSourceSiteModelList
                                                                 where c.TVItemModel.TVItem.TVItemID == mwqmPolSourceSiteModelLocal.TVItemModel.TVItem.TVItemID
                                                                 select c).FirstOrDefault();
            if (mwqmPolSourceSiteModelOriginal == null)
            {
                webPolSourceSites.PolSourceSiteModelList.Add(mwqmPolSourceSiteModelLocal);
            }
            else
            {
                SyncPolSourceSiteModel(mwqmPolSourceSiteModelOriginal, mwqmPolSourceSiteModelLocal);
            }
        }
    }
    private void MergeJsonWebPolSourceSitesIsLocalized(WebPolSourceSites webPolSourceSites, WebPolSourceSites webPolSourceSitesLocal)
    {
        foreach (PolSourceSiteModel mwqmPolSourceSiteModel in webPolSourceSites.PolSourceSiteModelList)
        {
            // checking if files are localized
            DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ mwqmPolSourceSiteModel.TVItemModel.TVItem.TVItemID }\\");

            if (di.Exists)
            {
                List<FileInfo> FileInfoList = di.GetFiles().ToList();

                foreach (TVFileModel tvFileModel in mwqmPolSourceSiteModel.TVFileModelList)
                {
                    if ((from c in FileInfoList
                         where c.Name == tvFileModel.TVFile.ServerFileName
                         select c).Any())
                    {
                        tvFileModel.IsLocalized = true;
                    }
                    else
                    {
                        tvFileModel.IsLocalized = false;
                    }
                }
            }
        }
    }
}

