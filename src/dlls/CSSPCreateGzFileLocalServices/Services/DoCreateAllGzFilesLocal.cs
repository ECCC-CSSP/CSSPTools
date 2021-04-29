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

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private async Task<bool> DoCreateAllGzFilesLocal()
        {
            if (LoggedInService.LoggedInContactInfo == null || LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(false);
            }

            Console.WriteLine("Create WebAllAddresses doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllAddresses, 0);
            Console.WriteLine("Create WebAllContacts doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllContacts, 0);
            Console.WriteLine("CreateAllCountries doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllCountries, 0);
            Console.WriteLine("Create WebAllEmails doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllEmails, 0);
            Console.WriteLine("Create WebAllHelpDocs doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllHelpDocs, 0);
            Console.WriteLine("Create WebAllMunicipalities doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllMunicipalities, 0);
            Console.WriteLine("Create WebAllMWQMLookupMPNs doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllMWQMLookupMPNs, 0);
            Console.WriteLine("Create WebAllPolSourceGroupings doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllPolSourceGroupings, 0);
            Console.WriteLine("Create WebAllPolSourceSiteEffectTerms doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllPolSourceSiteEffectTerms, 0);
            Console.WriteLine("Create WebAllProvinces doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllProvinces, 0);
            Console.WriteLine("Create WebAllReportTypes doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllReportTypes, 0);
            Console.WriteLine("Create WebAllTels doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllTels, 0);
            Console.WriteLine("Create WebAllTideLocations doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllTideLocations, 0);
            Console.WriteLine("Create WebAllTVItemLanguages doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllTVItemLanguages, 0);
            Console.WriteLine("Create WebAllTVItems doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllTVItems, 0);

            Console.WriteLine("Create WebRoot doing...");
            await CreateGzFileLocal(WebTypeEnum.WebRoot, 0);

            List<SamplingPlan> samplingPlanList = (from c in dbLocal.SamplingPlans
                                                   select c).ToList();

            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                Console.WriteLine($"Create WebSamplingPlan [{samplingPlan.SamplingPlanID}] doing...");
                await CreateGzFileLocal(WebTypeEnum.WebSamplingPlan, samplingPlan.SamplingPlanID);
            }

            List<TVTypeEnum> tvTypeEnumList = new List<TVTypeEnum>()
            {
                TVTypeEnum.Country,
                TVTypeEnum.Province,
                TVTypeEnum.Area,
                TVTypeEnum.Sector,
                TVTypeEnum.Subsector,
                //TVTypeEnum.ClimateSite,
                //TVTypeEnum.HydrometricSite,
                TVTypeEnum.MikeScenario,
                TVTypeEnum.Municipality,
            };

            foreach (TVTypeEnum tvType in tvTypeEnumList)
            {
                List<TVItem> tvItemList = (from c in dbLocal.TVItems
                                           where c.TVType == tvType
                                           select c).ToList();

                foreach (TVItem tvItem in tvItemList)
                {
                    switch (tvType)
                    {
                        case TVTypeEnum.Area:
                            {
                                Console.WriteLine($"Create WebArea [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebArea, tvItem.TVItemID);
                            }
                            break;
                        //case TVTypeEnum.ClimateSite:
                        //    {
                        //        Console.WriteLine($"Create WebClimateDataValue [{tvItem.TVItemID}] doing...");
                        //        await CreateGzFileLocal(WebTypeEnum.WebClimateDataValue, tvItem.TVItemID);
                        //    }
                        //    break;
                        case TVTypeEnum.Country:
                            {
                                Console.WriteLine($"Create WebCountry [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebCountry, tvItem.TVItemID);
                            }
                            break;
                        //case TVTypeEnum.HydrometricSite:
                        //    {
                        //        Console.WriteLine($"Create WebHydrometricDataValue [{tvItem.TVItemID}] doing...");
                        //        await CreateGzFileLocal(WebTypeEnum.WebHydrometricDataValue, tvItem.TVItemID);
                        //    }
                        //    break;
                        case TVTypeEnum.MikeScenario:
                            {
                                Console.WriteLine($"Create WebMikeScenario [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMikeScenario, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                Console.WriteLine($"Create WebMunicipality [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMunicipality, tvItem.TVItemID);
                                Console.WriteLine($"Create WebInfrastructures [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebInfrastructures, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMikeScenarios [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMikeScenarios, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                Console.WriteLine($"Create WebProvince [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebProvince, tvItem.TVItemID);
                                Console.WriteLine($"Create WebClimateSites [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebClimateSites, tvItem.TVItemID);
                                Console.WriteLine($"Create WebHydrometricSites [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebHydrometricSites, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMunicipalities [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMunicipalities, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                Console.WriteLine($"Create WebSector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebSector, tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                Console.WriteLine($"Create WebSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebSubsector, tvItem.TVItemID);
                                Console.WriteLine($"Create WebDrogueRuns [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebDrogueRuns, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMWQMRuns [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMRuns, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMWQMSites [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSites, tvItem.TVItemID);
                                Console.WriteLine($"Create WebPolSourceSites [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebPolSourceSites, tvItem.TVItemID);
                                Console.WriteLine($"Create WebLabSheets [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebLabSheets, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMWQMSamples1980_2020 [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSamples1980_2020, tvItem.TVItemID);
                                Console.WriteLine($"Create WebMWQMSamples2021_2060 [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSamples2021_2060, tvItem.TVItemID);
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
