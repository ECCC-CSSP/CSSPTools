namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> UploadChangedJsonFilesToAzureAsync(DateTime UpdateFromDate)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(DateTime UpdateFromDate) -- UpdateFromDate: { UpdateFromDate }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        if (await GetNeedToChangedWebAllAddressesAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllAddresses);
        }

        if (await GetNeedToChangedWebAllContactsAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllContacts);
        }

        if (await GetNeedToChangedWebAllCountriesAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllCountries);
        }

        if (await GetNeedToChangedWebAllEmailsAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllEmails);
        }

        if (await GetNeedToChangedWebAllHelpDocsAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllHelpDocs);
        }

        if (await GetNeedToChangedWebAllMunicipalitiesAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllMunicipalities);
        }

        if (await GetNeedToChangedWebAllMWQMLookupMPNsAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllMWQMLookupMPNs);
        }

        if (await GetNeedToChangedWebAllPolSourceGroupingsAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllPolSourceGroupings);
        }

        if (await GetNeedToChangedWebAllPolSourceSiteEffectTermsAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
        }

        if (await GetNeedToChangedWebAllProvincesAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllProvinces);
        }

        if (await GetNeedToChangedWebAllReportTypesAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllReportTypes);
        }

        if (await GetNeedToChangedWebAllSearchAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllSearch);
        }

        if (await GetNeedToChangedWebAllTelsAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllTels);
        }

        if (await GetNeedToChangedWebAllTideLocationsAsync(UpdateFromDate))
        {
            await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllTideLocations);
        }


        List<TVItem> TVItemToRecreateList = new List<TVItem>();

        List<int> TVItemIDList = await GetTVItemIDListAllOfChangedMapInfoAsync(UpdateFromDate);
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListAllOfChangedTVFileAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListAllOfChangedTVItemAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListAllOfChangedTVItemLinkAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListAllOfChangedUseOfSiteAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListCountryOfChangedEmailDistributionListAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListCountryOfChangedRainExceedanceAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListMunicipalityOfChangedBoxModelAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListMunicipalityOfChangedInfrastructureAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListMunicipalityOfChangedMikeScenarioAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListMunicipalityOfChangedVPScenarioAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedClimateSiteAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedDrogueRunAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedHydrometricSiteAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedSamplingPlanAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedTideSiteAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedClassificationAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedLabSheetAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMAnalysisReportParameterAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMRunAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMSampleAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMSiteAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMSubsectorAsync(UpdateFromDate)).Distinct().ToList();
        TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedPolSourceSiteAsync(UpdateFromDate)).Distinct().ToList();

        CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.NumberOfTVItemIDAffected_, TVItemIDList.Count) } { DateTime.Now } ...");

        List<TVItem> TVItemList = (from c in db.TVItems
                                   where c.TVType == TVTypeEnum.Root
                                   || c.TVType == TVTypeEnum.Country
                                   || c.TVType == TVTypeEnum.Province
                                   || c.TVType == TVTypeEnum.Municipality
                                   || c.TVType == TVTypeEnum.Area
                                   || c.TVType == TVTypeEnum.Sector
                                   || c.TVType == TVTypeEnum.Subsector
                                   select c).ToList();

        foreach (int TVItemID in TVItemIDList)
        {
            TVItem tvItem = (from c in TVItemList
                             where c.TVItemID == TVItemID
                             select c).FirstOrDefault();

            if (tvItem != null)
            {
                if (!TVItemToRecreateList.Where(c => c.TVItemID == tvItem.TVItemID).Any())
                {
                    TVItemToRecreateList.Add(tvItem);

                    List<int> TVItemIDParentList = tvItem.TVPath.Split("p", StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();

                    foreach (int TVItemIDParent in TVItemIDParentList)
                    {
                        if (!TVItemToRecreateList.Where(c => c.TVItemID == TVItemIDParent).Any())
                        {
                            TVItem tvItemParent = TVItemList.Where(c => c.TVItemID == TVItemIDParent).FirstOrDefault();

                            if (tvItemParent != null)
                            {
                                TVItemToRecreateList.Add(tvItemParent);
                            }
                        }
                    }
                }
            }
        }

        TVItemToRecreateList = TVItemToRecreateList.Distinct().ToList();

        foreach (TVItem tvItem in TVItemToRecreateList)
        {
            switch (tvItem.TVType)
            {
                case TVTypeEnum.Root:
                    {
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebRoot, 0);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebAllSearch, 0);
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebCountry, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMonitoringRoutineStatsCountry, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMonitoringOtherStatsCountry, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebProvince, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebClimateSites, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebTideSites, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebDrogueRuns, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMonitoringRoutineStatsProvince, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMonitoringOtherStatsProvince, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMunicipality, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebArea, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebSector, tvItem.TVItemID);
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebSubsector, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebLabSheets, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMWQMSamples1980_2020, tvItem.TVItemID);
                        await CreateGzFileService.CreateGzFileAsync(WebTypeEnum.WebMWQMSamples2021_2060, tvItem.TVItemID);
                    }
                    break;
                default:
                    break;
            }

        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

