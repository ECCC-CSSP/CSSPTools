namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebCountryAsync(WebCountry webCountry, WebCountry webCountryLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebCountry WebCountry, WebCountry WebCountryLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebCountryTVItemModel(webCountry, webCountryLocal);

        MergeJsonWebCountryTVItemModelParentList(webCountry, webCountryLocal);

        MergeJsonWebCountryTVItemModelProvinceList(webCountry, webCountryLocal);

        MergeJsonWebCountryTVFileModelList(webCountry, webCountryLocal);

        MergeJsonWebCountryIsLocalized(webCountry, webCountryLocal);

        MergeJsonWebCountryRainExceedanceModelList(webCountry, webCountryLocal);

        MergeJsonWebCountryEmailDistributionListModelList(webCountry, webCountryLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
    private void MergeJsonWebCountryTVItemModel(WebCountry webCountry, WebCountry webCountryLocal)
    {
        if (webCountryLocal.TVItemModel.TVItem.TVItemID != 0
            && (webCountryLocal.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
           || webCountryLocal.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
           || webCountryLocal.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original))
        {
            SyncTVItemModel(webCountry.TVItemModel, webCountryLocal.TVItemModel);
        }
    }
    private void MergeJsonWebCountryTVItemModelParentList(WebCountry webCountry, WebCountry webCountryLocal)
    {
        if ((from c in webCountryLocal.TVItemModelParentList
             where c.TVItem.TVItemID != 0
             && (c.TVItem.DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
             select c).Any())
        {
            SyncTVItemModelParentList(webCountry.TVItemModelParentList, webCountryLocal.TVItemModelParentList);
        }
    }
    private void MergeJsonWebCountryTVItemModelProvinceList(WebCountry webCountry, WebCountry webCountryLocal)
    {
        List<TVItemModel> TVItemModelList = (from c in webCountryLocal.TVItemModelProvinceList
                                             where c.TVItem.TVItemID != 0
                                             && (c.TVItem.DBCommand != DBCommandEnum.Original
                                             || c.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                             || c.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                             select c).ToList();

        foreach (TVItemModel TVItemModelLocal in TVItemModelList)
        {
            TVItemModel TVItemModelOriginal = webCountry.TVItemModelProvinceList.Where(c => c.TVItem.TVItemID == TVItemModelLocal.TVItem.TVItemID).FirstOrDefault();
            if (TVItemModelOriginal == null)
            {
                webCountry.TVItemModelProvinceList.Add(TVItemModelLocal);
            }
            else
            {
                SyncTVItemModel(TVItemModelOriginal, TVItemModelLocal);
            }
        }
    }
    private void MergeJsonWebCountryTVFileModelList(WebCountry webCountry, WebCountry webCountryLocal)
    {
        List<TVFileModel> TVFileModelLocalList = (from c in webCountryLocal.TVFileModelList
                                                  where c.TVFile.TVFileID != 0
                                                  && (c.TVFile.DBCommand != DBCommandEnum.Original
                                                  || c.TVFileLanguageList[0].DBCommand != DBCommandEnum.Original
                                                  || c.TVFileLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                  select c).ToList();

        foreach (TVFileModel tvFileModelLocal in TVFileModelLocalList)
        {
            TVFileModel tvFileModelOriginal = webCountry.TVFileModelList.Where(c => c.TVFile.TVFileID == tvFileModelLocal.TVFile.TVFileID).FirstOrDefault();
            if (tvFileModelOriginal == null)
            {
                webCountry.TVFileModelList.Add(tvFileModelLocal);
            }
            else
            {
                SyncTVFileModel(tvFileModelOriginal, tvFileModelLocal);
            }
        }
    }
    private void MergeJsonWebCountryIsLocalized(WebCountry webCountry, WebCountry webCountryLocal)
    {
        DirectoryInfo di = new DirectoryInfo($"{ Configuration["CSSPFilesPath"] }{ webCountry.TVItemModel.TVItem.TVItemID }\\");

        if (di.Exists)
        {
            List<FileInfo> FileInfoList = di.GetFiles().ToList();

            foreach (TVFileModel tvFileModel in webCountry.TVFileModelList)
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
    private void MergeJsonWebCountryRainExceedanceModelList(WebCountry webCountry, WebCountry webCountryLocal)
    {
        List<RainExceedanceModel> RainExceedanceModelLocalList = (from c in webCountryLocal.RainExceedanceModelList
                                                                  where c.TVItemModel.TVItem.TVItemID != 0
                                                                  && (c.TVItemModel.TVItem.DBCommand != DBCommandEnum.Original
                                                                  || c.TVItemModel.TVItemLanguageList[0].DBCommand != DBCommandEnum.Original
                                                                  || c.TVItemModel.TVItemLanguageList[1].DBCommand != DBCommandEnum.Original)
                                                                  select c).ToList();

        foreach (RainExceedanceModel rainExceedanceModelLocal in RainExceedanceModelLocalList)
        {
            RainExceedanceModel rainExceedanceModelOriginal = webCountry.RainExceedanceModelList.Where(c => c.TVItemModel.TVItem.TVItemID == rainExceedanceModelLocal.TVItemModel.TVItem.TVItemID).FirstOrDefault();
            if (rainExceedanceModelOriginal == null)
            {
                webCountry.RainExceedanceModelList.Add(rainExceedanceModelLocal);
            }
            else
            {
                SyncRainExceedanceModel(rainExceedanceModelOriginal, rainExceedanceModelLocal);
            }
        }
    }
    private void MergeJsonWebCountryEmailDistributionListModelList(WebCountry webCountry, WebCountry webCountryLocal)
    {
        List<EmailDistributionListModel> EmailDistributionListModelList = (from c in webCountryLocal.EmailDistributionListModelList
                                                                           where c.EmailDistributionList.EmailDistributionListID != 0
                                                                           && (c.EmailDistributionList.DBCommand != DBCommandEnum.Original)
                                                                           select c).ToList();

        foreach (EmailDistributionListModel emailDistributionListModel in EmailDistributionListModelList)
        {
            EmailDistributionListModel emailDistributionListModelOriginal = webCountry.EmailDistributionListModelList.Where(c => c.EmailDistributionList.EmailDistributionListID == emailDistributionListModel.EmailDistributionList.EmailDistributionListID).FirstOrDefault();
            if (emailDistributionListModelOriginal == null)
            {
                webCountry.EmailDistributionListModelList.Add(emailDistributionListModel);
            }
            else
            {
                SyncEmailDistributionListModel(emailDistributionListModelOriginal, emailDistributionListModel);
            }
        }
    }
}

