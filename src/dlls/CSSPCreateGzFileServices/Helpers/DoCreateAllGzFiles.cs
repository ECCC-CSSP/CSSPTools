/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPWebModels;
using System.Reflection;

namespace CSSPCreateGzFileServices
{
    public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateAllGzFiles()
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
            CSSPLogService.FunctionLog(FunctionName);

            await CreateGzFile(WebTypeEnum.WebAllAddresses, 0);
            await CreateGzFile(WebTypeEnum.WebAllContacts, 0);
            await CreateGzFile(WebTypeEnum.WebAllCountries, 0);
            await CreateGzFile(WebTypeEnum.WebAllEmails, 0);
            await CreateGzFile(WebTypeEnum.WebAllHelpDocs, 0);
            await CreateGzFile(WebTypeEnum.WebAllMunicipalities, 0);
            await CreateGzFile(WebTypeEnum.WebAllMWQMAnalysisReportParameters, 0);
            await CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            await CreateGzFile(WebTypeEnum.WebAllMWQMSubsectors, 0);
            await CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings, 0);
            await CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms, 0);
            await CreateGzFile(WebTypeEnum.WebAllProvinces, 0);
            await CreateGzFile(WebTypeEnum.WebAllReportTypes, 0);
            await CreateGzFile(WebTypeEnum.WebAllTels, 0);
            await CreateGzFile(WebTypeEnum.WebAllTideLocations, 0);
            await CreateGzFile(WebTypeEnum.WebAllSearch, 0);
            await CreateGzFile(WebTypeEnum.WebAllUseOfSites, 0);

            await CreateGzFile(WebTypeEnum.WebRoot, 0);

            foreach (TVItem tvItem in (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.Country
                                       select c).ToList())
            {
                await CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, tvItem.TVItemID);
                await CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, tvItem.TVItemID);
            }

            foreach (TVItem tvItem in (from c in db.TVItems
                                       where c.TVType == TVTypeEnum.Province
                                       select c).ToList())
            {
                await CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, tvItem.TVItemID);
                await CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, tvItem.TVItemID);
            }

            List<TVTypeEnum> tvTypeEnumList = new List<TVTypeEnum>()
            {
                TVTypeEnum.Country,
                TVTypeEnum.Province,
                TVTypeEnum.Area,
                TVTypeEnum.Sector,
                TVTypeEnum.Subsector,
                TVTypeEnum.Municipality,
            };


            foreach (TVTypeEnum tvType in tvTypeEnumList)
            {

                List<TVItem> tvItemList = (from c in db.TVItems
                                           where c.TVType == tvType
                                           select c).ToList();

                int total = tvItemList.Count;
                int count = 0;
                foreach (TVItem tvItem in tvItemList)
                {
                    count += 1;
                    Console.WriteLine($"{ count } / { total }");
                    switch (tvType)
                    {
                        case TVTypeEnum.Area:
                            {
                                await CreateGzFile(WebTypeEnum.WebArea, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                await CreateGzFile(WebTypeEnum.WebCountry, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                await CreateGzFile(WebTypeEnum.WebMunicipality, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                await CreateGzFile(WebTypeEnum.WebProvince, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebClimateSites, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebTideSites, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebDrogueRuns, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                await CreateGzFile(WebTypeEnum.WebSector, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                await CreateGzFile(WebTypeEnum.WebSubsector, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebLabSheets, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, tvItem.TVItemID);
                                await CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, tvItem.TVItemID);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            CSSPLogService.EndFunctionLog(FunctionName);

            return await Task.FromResult(Ok(true));
        }
    }
}
