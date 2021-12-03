namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAreaAsync(WebArea webArea, WebArea webAreaLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebArea WebArea, WebArea WebAreaLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebAreaTVItemModel(webArea, webAreaLocal);

        MergeJsonWebAreaTVItemModelParentList(webArea, webAreaLocal);

        MergeJsonWebAreaTVItemModelSectorList(webArea, webAreaLocal);

        MergeJsonWebAreaTVFileModelList(webArea, webAreaLocal);

        MergeJsonWebAreaIsLocalized(webArea, webAreaLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebAreaTVItemModel(WebArea webArea, WebArea webAreaLocal)
    {
        if (webAreaLocal.TVItemModel.TVItem.TVItemID != 0
            && (webAreaLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
            || webAreaLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
            || webAreaLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
        {
            SyncTVItemModel(webArea.TVItemModel, webAreaLocal.TVItemModel);
        }
    }
    private void MergeJsonWebAreaTVItemModelParentList(WebArea webArea, WebArea webAreaLocal)
    {
        if ((from c in webAreaLocal.TVItemModelParentList
             where c.TVItem.TVItemID != 0
             && (c.TVItem.DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
             select c).Any())
        {
            SyncTVItemModelParentList(webArea.TVItemModelParentList, webAreaLocal.TVItemModelParentList);
        }
    }
    private void MergeJsonWebAreaTVItemModelSectorList(WebArea webArea, WebArea webAreaLocal)
    {
        List<TVItemModel> TVItemModelList = (from c in webAreaLocal.TVItemModelSectorList
                                             where c.TVItem.TVItemID != 0
                                             && (c.TVItem.DBCommand != DBCommandEnum.Original
                                             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                             select c).ToList();

        foreach (TVItemModel TVItemModel in TVItemModelList)
        {
            TVItemModel TVItemModelOriginal = webArea.TVItemModelSectorList.Where(c => c.TVItem.TVItemID == TVItemModel.TVItem.TVItemID).FirstOrDefault();
            if (TVItemModelOriginal == null)
            {
                webArea.TVItemModelSectorList.Add(TVItemModel);
            }
            else
            {
                SyncTVItemModel(TVItemModelOriginal, TVItemModel);
            }
        }
    }
    private void MergeJsonWebAreaTVFileModelList(WebArea webArea, WebArea webAreaLocal)
    {
        List<TVFileModel> TVFileModelList = (from c in webAreaLocal.TVFileModelList
                                             where c.TVFile.TVFileID != 0
                                             && (c.TVFile.DBCommand != DBCommandEnum.Original
                                             || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                             || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                             select c).ToList();

        foreach (TVFileModel tvFileModelLocal in TVFileModelList)
        {
            TVFileModel tvFileModelOriginal = webArea.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();
            if (tvFileModelOriginal == null)
            {
                webArea.TVFileModelList.Add(tvFileModelLocal);
            }
            else
            {
                SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
            }
        }
    }
    private void MergeJsonWebAreaIsLocalized(WebArea webArea, WebArea webAreaLocal)
    {
        DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ webArea.TVItemModel.TVItem.TVItemID }\\");

        if (di.Exists)
        {
            List<FileInfo> FileInfoList = di.GetFiles().ToList();

            foreach (TVFileModel tvFileModel in webArea.TVFileModelList)
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

