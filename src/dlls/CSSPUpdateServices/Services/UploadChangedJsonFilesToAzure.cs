/*
 * Manually edited
 * 
 */
using CreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
    {
        public async Task<ActionResult<bool>> UploadChangedJsonFilesToAzure(DateTime UpdateFromDate)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(DateTime UpdateFromDate) -- UpdateFromDate: { UpdateFromDate }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            if (await GetNeedToChangedWebAllAddresses(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllAddresses);
            }

            if (await GetNeedToChangedWebAllContacts(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllContacts);
            }

            if (await GetNeedToChangedWebAllCountries(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllCountries);
            }

            if (await GetNeedToChangedWebAllEmails(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllEmails);
            }

            if (await GetNeedToChangedWebAllHelpDocs(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllHelpDocs);
            }

            if (await GetNeedToChangedWebAllMunicipalities(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMunicipalities);
            }

            if (await GetNeedToChangedWebAllMWQMLookupMPNs(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs);
            }

            if (await GetNeedToChangedWebAllPolSourceGroupings(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings);
            }

            if (await GetNeedToChangedWebAllPolSourceSiteEffectTerms(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms);
            }

            if (await GetNeedToChangedWebAllProvinces(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllProvinces);
            }

            if (await GetNeedToChangedWebAllReportTypes(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllReportTypes);
            }

            if (await GetNeedToChangedWebAllSearch(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllSearch);
            }

            if (await GetNeedToChangedWebAllTels(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTels);
            }

            if (await GetNeedToChangedWebAllTideLocations(UpdateFromDate))
            {
                await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllTideLocations);
            }


            List<TVItem> TVItemToRecreateList = new List<TVItem>();

            List<int> TVItemIDList = await GetTVItemIDListAllOfChangedMapInfo(UpdateFromDate);
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListAllOfChangedTVFile(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListAllOfChangedTVItem(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListAllOfChangedTVItemLink(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListAllOfChangedUseOfSite(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListCountryOfChangedEmailDistributionList(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListCountryOfChangedRainExceedance(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListMunicipalityOfChangedBoxModel(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListMunicipalityOfChangedInfrastructure(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListMunicipalityOfChangedMikeScenario(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListMunicipalityOfChangedVPScenario(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedClimateSite(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedDrogueRun(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedHydrometricSite(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedSamplingPlan(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListProvinceOfChangedTideSite(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedClassification(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedLabSheet(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMAnalysisReportParameter(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMRun(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMSample(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMSite(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedMWQMSubsector(UpdateFromDate)).Distinct().ToList();
            TVItemIDList = TVItemIDList.Concat(await GetTVItemIDListSubsectorOfChangedPolSourceSite(UpdateFromDate)).Distinct().ToList();

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
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebRoot, 0);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebAllSearch, 0);
                        }
                        break;
                    case TVTypeEnum.Country:
                        {
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebCountry, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Province:
                        {
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebProvince, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebClimateSites, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebTideSites, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebDrogueRuns, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Municipality:
                        {
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMunicipality, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Area:
                        {
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebArea, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Sector:
                        {
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSector, tvItem.TVItemID);
                        }
                        break;
                    case TVTypeEnum.Subsector:
                        {
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebSubsector, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebLabSheets, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, tvItem.TVItemID);
                            await CreateGzFileService.CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, tvItem.TVItemID);
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
}
