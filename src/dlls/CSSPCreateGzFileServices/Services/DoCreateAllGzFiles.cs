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

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateAllGzFiles()
        {
            
            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(false);
            }

            //Console.WriteLine("Create WebAllAddresses doing...");
            //await CreateGzFile(WebTypeEnum.WebAllAddresses, 0);
            //Console.WriteLine("Create WebAllContacts doing...");
            //await CreateGzFile(WebTypeEnum.WebAllContacts, 0);
            //Console.WriteLine("CreateAllCountries doing...");
            //await CreateGzFile(WebTypeEnum.WebAllCountries, 0);
            //Console.WriteLine("Create WebAllEmails doing...");
            //await CreateGzFile(WebTypeEnum.WebAllEmails, 0);
            //Console.WriteLine("Create WebAllHelpDocs doing...");
            //await CreateGzFile(WebTypeEnum.WebAllHelpDocs, 0);
            //Console.WriteLine("Create WebAllMunicipalities doing...");
            //await CreateGzFile(WebTypeEnum.WebAllMunicipalities, 0);
            //Console.WriteLine("Create WebAllMWQMLookupMPNs doing...");
            //await CreateGzFile(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            //Console.WriteLine("Create WebAllPolSourceGroupings doing...");
            //await CreateGzFile(WebTypeEnum.WebAllPolSourceGroupings, 0);
            //Console.WriteLine("Create WebAllPolSourceSiteEffectTerms doing...");
            //await CreateGzFile(WebTypeEnum.WebAllPolSourceSiteEffectTerms, 0);
            //Console.WriteLine("Create WebAllProvinces doing...");
            //await CreateGzFile(WebTypeEnum.WebAllProvinces, 0);
            //Console.WriteLine("Create WebAllReportTypes doing...");
            //await CreateGzFile(WebTypeEnum.WebAllReportTypes, 0);
            //Console.WriteLine("Create WebAllTels doing...");
            //await CreateGzFile(WebTypeEnum.WebAllTels, 0);
            //Console.WriteLine("Create WebAllTideLocations doing...");
            //await CreateGzFile(WebTypeEnum.WebAllTideLocations, 0);
            //Console.WriteLine("Create WebRoot doing...");
            //await CreateGzFile(WebTypeEnum.WebRoot, 0);
            //Console.WriteLine("Create WebAllSearch doing...");
            //await CreateGzFile(WebTypeEnum.WebAllSearch, 0);

            List<TVTypeEnum> tvTypeEnumList = new List<TVTypeEnum>()
            {
                TVTypeEnum.Country,
                TVTypeEnum.Province,
                //TVTypeEnum.Area,
                //TVTypeEnum.Sector,
                //TVTypeEnum.Subsector,
                //TVTypeEnum.Municipality,
            };

            foreach (TVTypeEnum tvType in tvTypeEnumList)
            {
                List<TVItem> tvItemList = (from c in db.TVItems
                                           where c.TVType == tvType
                                           select c).ToList();

                foreach(TVItem tvItem in tvItemList)
                {
                    switch (tvType)
                    {
                        case TVTypeEnum.Area:
                            {
                                Console.WriteLine($"Create WebArea [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebArea, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                //Console.WriteLine($"Create WebCountry [{tvItem.TVItemID}] doing...");
                                //await CreateGzFile(WebTypeEnum.WebCountry, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMonitoringRoutineStatsCountry [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsCountry, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMonitoringOtherStatsCountry [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsCountry, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                Console.WriteLine($"Create WebMunicipality [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMunicipality, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMikeScenarios [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                //Console.WriteLine($"Create WebProvince [{tvItem.TVItemID}] doing...");
                                //await CreateGzFile(WebTypeEnum.WebProvince, tvItem.TVItemID);
                                //Console.WriteLine($"Create WebClimateSites [{tvItem.TVItemID}] doing...");
                                //await CreateGzFile(WebTypeEnum.WebClimateSites, tvItem.TVItemID);
                                //Console.WriteLine($"Create WebHydrometricSites [{tvItem.TVItemID}] doing...");
                                //await CreateGzFile(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);
                                //Console.WriteLine($"Create WebTideSites [{tvItem.TVItemID}] doing...");
                                //await CreateGzFile(WebTypeEnum.WebTideSites, tvItem.TVItemID);
                                //Console.WriteLine($"Create WebDrogueRuns [{tvItem.TVItemID}] doing...");
                                //await CreateGzFile(WebTypeEnum.WebDrogueRuns, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMonitoringRoutineStatsProvince [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMonitoringRoutineStatsProvince, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMonitoringOtherStatsProvince [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMonitoringOtherStatsProvince, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                Console.WriteLine($"Create WebSector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebSector, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                Console.WriteLine($"Create WebSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebSubsector, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMWQMRuns [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMWQMSites [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);
                                Console.WriteLine($"Create WebPolSourceSites [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);
                                Console.WriteLine($"Create WebLabSheets [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebLabSheets, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMWQMSamples1980_2020 [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSamples1980_2020, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMWQMSamples2021_2060 [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSamples2021_2060, tvItem.TVItemID);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine($"All Done....");

            return await Task.FromResult(true);
        }
    }
}
