namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillFileModelListAsync(List<TVFileModel> TVFileModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<TVFileModel> TVFileModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
        CSSPLogService.FunctionLog(FunctionName);

        List<TVItem> TVItemList = await GetTVItemChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);
        List<TVItemLanguage> TVItemLanguageList = await GetTVItemLanguageChildrenListWithTVItemIDAsync(TVItem, TVTypeEnum.File);

        List<TVFile> TVFileList = await GetTVFileListWithTVItemIDAsync(TVItem.TVItemID);
        List<TVFileLanguage> TVFileLanguageList = await GetTVFileLanguageListWithTVItemIDAsync(TVItem.TVItemID);

        foreach (TVFile tvFile in TVFileList)
        {
            TVFileModel tvFileModel = new TVFileModel();

            tvFileModel.TVFile = TVFileList.Where(c => c.TVFileTVItemID == tvFile.TVFileTVItemID).FirstOrDefault();
            if (tvFileModel.TVFile != null)
            {
                tvFileModel.TVFileLanguageList = TVFileLanguageList.Where(c => c.TVFileID == tvFileModel.TVFile.TVFileID).ToList();
            }

            TVItemModel tvItemModel = new TVItemModel();

            tvItemModel.TVItem = (from c in TVItemList
                                  where c.TVItemID == tvFile.TVFileTVItemID
                                  select c).FirstOrDefault();

            tvItemModel.TVItemLanguageList = (from c in TVItemLanguageList
                                              where c.TVItemID == tvFile.TVFileTVItemID
                                              orderby c.Language
                                              select c).ToList();

            tvFileModel.TVItemModel = tvItemModel;

            TVFileModelList.Add(tvFileModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
