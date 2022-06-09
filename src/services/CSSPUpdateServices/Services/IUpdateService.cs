namespace CSSPUpdateServices;

public interface ICSSPUpdateService
{
    Task<bool> RunCommandAsync(string[] args);
    Task<ActionResult<bool>> ClearOldUnnecessaryStatsAsync();
    Task<ActionResult<bool>> RemoveAzureDirectoriesNotFoundInTVFilesAsync();
    Task<ActionResult<bool>> RemoveAzureFilesNotFoundInTVFilesAsync();
    Task<ActionResult<bool>> RemoveExternalHardDriveDirectoriesNotFoundInTVFilesAsync();
    Task<ActionResult<bool>> RemoveExternalHardDriveFilesNotFoundInTVFilesAsync();
    Task<ActionResult<bool>> RemoveLocalDirectoriesNotFoundInTVFilesAsync();
    Task<ActionResult<bool>> RemoveLocalFilesNotFoundInTVFilesAsync();
    Task<ActionResult<bool>> RemoveNationalBackupDirectoriesNotFoundInTVFilesAsync();
    Task<ActionResult<bool>> RemoveNationalBackupFilesNotFoundInTVFilesAsync();
    Task<ActionResult<bool>> RemoveTVFilesDoubleAssociatedWithTVItemsTypeFileAsync();
    Task<ActionResult<bool>> RemoveTVItemsNoAssociatedWithTVFilesAsync();
    Task<ActionResult<bool>> UpdateAllTVItemStatsAsync();
    Task<ActionResult<bool>> UpdateChangedTVItemStatsAsync(DateTime UpdateFromDate);
    Task<ActionResult<bool>> UploadAllFilesToAzureAsync();
    Task<ActionResult<bool>> UploadAllJsonFilesToAzureAsync();
    Task<ActionResult<bool>> UploadChangedFilesToAzureAsync(DateTime UpdateFromDate);
    Task<ActionResult<bool>> UploadChangedJsonFilesToAzureAsync(DateTime UpdateFromDate);

    Task<bool> GetNeedToChangedWebAllAddressesAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllContactsAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllCountriesAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllEmailsAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllHelpDocsAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllMunicipalitiesAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllMWQMLookupMPNsAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllPolSourceGroupingsAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllPolSourceSiteEffectTermsAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllProvincesAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllReportTypesAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllSearchAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllTelsAsync(DateTime LastWriteTimeUtc);
    Task<bool> GetNeedToChangedWebAllTideLocationsAsync(DateTime LastWriteTimeUtc);

    Task<ActionResult<bool>> GetRunSiteSampleStatsForCountryAsync(List<TVItemStat> TVItemStat2List);
    Task<ActionResult<bool>> GetRunSiteSampleStatsUnderProvinceAsync(List<TVItem> TVItemList, List<TVItem> TVItemProvList, List<TVItemStat> TVItemStat2List);
    List<TVTypeEnum> GetSubTVTypeForTVItemStatAsync(TVTypeEnum TVType);

    Task<List<int>> GetTVItemIDListAllOfChangedMapInfoAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListAllOfChangedTVFileAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListAllOfChangedTVItemAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListAllOfChangedTVItemLinkAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListAllOfChangedUseOfSiteAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListCountryOfChangedEmailDistributionListAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListCountryOfChangedRainExceedanceAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListMunicipalityOfChangedBoxModelAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListMunicipalityOfChangedInfrastructureAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListMunicipalityOfChangedMikeScenarioAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListMunicipalityOfChangedVPScenarioAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListProvinceOfChangedClimateSiteAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListProvinceOfChangedDrogueRunAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListProvinceOfChangedHydrometricSiteAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListProvinceOfChangedSamplingPlanAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListProvinceOfChangedTideSiteAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListSubsectorOfChangedClassificationAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListSubsectorOfChangedLabSheetAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMAnalysisReportParameterAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMRunAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSampleAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSiteAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListSubsectorOfChangedMWQMSubsectorAsync(DateTime LastWriteTimeUtc);
    Task<List<int>> GetTVItemIDListSubsectorOfChangedPolSourceSiteAsync(DateTime LastWriteTimeUtc);

}
