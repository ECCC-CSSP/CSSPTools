/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<bool> DoCreateAllGzFiles()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(false);
            }

            Console.WriteLine("CreateWebContact doing...");
            await CreateWebContactGzFile();
            Console.WriteLine("GetHelpDoc doing...");
            await GetHelpDoc();
            Console.WriteLine("GetMWQMLookupMPN doing...");
            await GetMWQMLookupMPN();
            Console.WriteLine("CreateWebPolSourceGrouping doing...");
            await CreateWebPolSourceGroupingGzFile();
            Console.WriteLine("CreateWebReportType doing...");
            await CreateWebReportTypeGzFile();
            Console.WriteLine("CreateWebRoot doing...");
            await CreateWebRootGzFile();
            Console.WriteLine("CreateWebTideLocation doing...");
            await CreateWebTideLocationGzFile();

            List<SamplingPlan> samplingPlanList = (from c in db.SamplingPlans
                                                   select c).ToList();

            foreach(SamplingPlan samplingPlan in samplingPlanList)
            {
                Console.WriteLine($"CreateWebSamplingPlan [{samplingPlan.SamplingPlanID}] doing...");
                await CreateWebSamplingPlanGzFile(samplingPlan.SamplingPlanID);
            }

            List < TVTypeEnum > tvTypeEnumList = new List<TVTypeEnum>()
            {
                TVTypeEnum.Country,
                TVTypeEnum.Province,
                TVTypeEnum.Area,
                TVTypeEnum.Sector,
                TVTypeEnum.Subsector,
                TVTypeEnum.ClimateSite,
                TVTypeEnum.HydrometricSite,
                TVTypeEnum.MikeScenario,
                TVTypeEnum.Municipality,
            };

            foreach(TVTypeEnum tvType in tvTypeEnumList)
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
                                Console.WriteLine($"CreateWebArea [{tvItem.TVItemID}] doing...");
                                await CreateWebAreaGzFile(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.ClimateSite:
                            {
                                Console.WriteLine($"CreateWebClimateDataValue [{tvItem.TVItemID}] doing...");
                                await CreateWebClimateDataValueGzFile(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                Console.WriteLine($"CreateWebCountry [{tvItem.TVItemID}] doing...");
                                await CreateWebCountryGzFile(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.HydrometricSite:
                            {
                                Console.WriteLine($"CreateWebHydrometricDataValue [{tvItem.TVItemID}] doing...");
                                await CreateWebHydrometricDataValueGzFile(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.MikeScenario:
                            {
                                Console.WriteLine($"CreateWebMikeScenario [{tvItem.TVItemID}] doing...");
                                await CreateWebMikeScenarioGzFile(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                Console.WriteLine($"CreateWebMunicipality [{tvItem.TVItemID}] doing...");
                                await CreateWebMunicipalityGzFile(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                Console.WriteLine($"CreateWebProvince [{tvItem.TVItemID}] doing...");
                                await CreateWebProvinceGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWebClimateSite [{tvItem.TVItemID}] doing...");
                                await CreateWebClimateSiteGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWebHydrometricSite [{tvItem.TVItemID}] doing...");
                                await CreateWebHydrometricSiteGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWebMunicipalities [{tvItem.TVItemID}] doing...");
                                await CreateWebMunicipalitiesGzFile(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                Console.WriteLine($"CreateWebSector [{tvItem.TVItemID}] doing...");
                                await CreateWebSectorGzFile(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                Console.WriteLine($"CreateWebSubsector [{tvItem.TVItemID}] doing...");
                                await CreateWebSubsectorGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWebDrogueRun [{tvItem.TVItemID}] doing...");
                                await CreateWebDrogueRunGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWebMWQMRun [{tvItem.TVItemID}] doing...");
                                await CreateWebMWQMRunGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWebMWQMSite [{tvItem.TVItemID}] doing...");
                                await CreateWebMWQMSiteGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWebPolSourceSite [{tvItem.TVItemID}] doing...");
                                await CreateWebPolSourceSiteGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWeb10YearOfSample1980_1989FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateWeb10YearOfSample1980_1989FromSubsectorGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWeb10YearOfSample1990_1999FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateWeb10YearOfSample1990_1999FromSubsectorGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWeb10YearOfSample2000_2009FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateWeb10YearOfSample2000_2009FromSubsectorGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWeb10YearOfSample2010_2019FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateWeb10YearOfSample2010_2019FromSubsectorGzFile(tvItem.TVItemID);
                                Console.WriteLine($"CreateWeb10YearOfSample2020_2029FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateWeb10YearOfSample2020_2029FromSubsectorGzFile(tvItem.TVItemID);
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
