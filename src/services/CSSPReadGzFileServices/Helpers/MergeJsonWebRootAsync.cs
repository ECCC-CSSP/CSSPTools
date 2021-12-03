namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebRootAsync(WebRoot webRoot, WebRoot webRootLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebRoot WebRoot, WebRoot WebRootLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebRootTVItemModel(webRoot, webRootLocal);

        MergeJsonWebRootTVItemModelParentList(webRoot, webRootLocal);

        MergeJsonWebRootTVItemModelCountryList(webRoot, webRootLocal);

        MergeJsonWebRootTVFileModelList(webRoot, webRootLocal);

        MergeJsonWebRootIsLocalized(webRoot, webRootLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebRootTVItemModel(WebRoot webRoot, WebRoot webRootLocal)
    {
        if (webRootLocal.TVItemModel.TVItem.TVItemID != 0
            && (webRootLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
           || webRootLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
           || webRootLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
        {
            SyncTVItemModel(webRoot.TVItemModel, webRootLocal.TVItemModel);
        }
    }
    private void MergeJsonWebRootTVItemModelParentList(WebRoot webRoot, WebRoot webRootLocal)
    {
        if ((from c in webRootLocal.TVItemModelParentList
             where c.TVItem.TVItemID != 0
             && (c.TVItem.DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
             select c).Any())
        {
            SyncTVItemModelParentList(webRoot.TVItemModelParentList, webRootLocal.TVItemModelParentList);
        }
    }
    private void MergeJsonWebRootTVItemModelCountryList(WebRoot webRoot, WebRoot webRootLocal)
    {
        List<TVItemModel> TVItemModelLocalList = (from c in webRootLocal.TVItemModelCountryList
                                                  where c.TVItem.TVItemID != 0
                                                  && (c.TVItem.DBCommand != DBCommandEnum.Original
                                                  || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                  || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                  select c).ToList();

        foreach (TVItemModel TVItemModelLocal in TVItemModelLocalList)
        {
            TVItemModel TVItemModelOriginal = webRoot.TVItemModelCountryList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault();
            if (TVItemModelOriginal == null)
            {
                webRoot.TVItemModelCountryList.Add(TVItemModelLocal);
            }
            else
            {
                SyncTVItemModel(TVItemModelOriginal, TVItemModelLocal);
            }
        }
    }
    private void MergeJsonWebRootTVFileModelList(WebRoot webRoot, WebRoot webRootLocal)
    {
        List<TVFileModel> TVFileModelLocalList = (from c in webRootLocal.TVFileModelList
                                                  where c.TVFile.TVFileID != 0
                                                  && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                  || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                  || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                  select c).ToList();

        foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
        {
            TVFileModel tvFileModelOriginal = webRoot.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();
            if (tvFileModelOriginal == null)
            {
                webRoot.TVFileModelList.Add(tvFileModelLocal);
            }
            else
            {
                SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
            }
        }
    }
    private void MergeJsonWebRootIsLocalized(WebRoot webRoot, WebRoot webRootLocal)
    {
        DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ webRoot.TVItemModel.TVItem.TVItemID }\\");

        if (di.Exists)
        {
            List<FileInfo> FileInfoList = di.GetFiles().ToList();

            foreach (TVFileModel tvFileModel in webRoot.TVFileModelList)
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

