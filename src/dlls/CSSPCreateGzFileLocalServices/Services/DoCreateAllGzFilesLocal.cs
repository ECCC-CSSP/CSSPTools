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

            Console.WriteLine("CreateAllWebAddresses doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllAddresses, 0, 0);
            Console.WriteLine("CreateAllWebEmails doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllEmails, 0, 0);
            Console.WriteLine("CreateAllWebTels doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllTels, 0, 0);
            Console.WriteLine("CreateAllWebContacts doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllContacts, 0, 0);
            Console.WriteLine("GetAllHelpDocs doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllHelpDocs, 0, 0);
            Console.WriteLine("GetAllMWQMLookupMPNs doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllMWQMLookupMPNs, 0, 0);
            Console.WriteLine("CreateWebAllPolSourceGroupings doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllPolSourceGroupings, 0, 0);
            Console.WriteLine("CreateWebAllReportTypes doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllReportTypes, 0, 0);
            Console.WriteLine("CreateWebRoot doing...");
            await CreateGzFileLocal(WebTypeEnum.WebRoot, 0, 0);
            Console.WriteLine("CreateWebAllTideLocations doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllTideLocations, 0, 0);
            Console.WriteLine("CreateAllMunicipalities doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllMunicipalities, 0, 0);
            Console.WriteLine("CreateAllProvinces doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllProvinces, 0, 0);
            Console.WriteLine("CreateAllCountries doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllCountries, 0, 0);
            Console.WriteLine("CreateWebAllTVItems doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllTVItems, 0, 0);
            Console.WriteLine("CreateWebAllTVItemLanguages doing...");
            await CreateGzFileLocal(WebTypeEnum.WebAllTVItemLanguages, 0, 0);

            List<SamplingPlan> samplingPlanList = (from c in dbLocal.SamplingPlans
                                                   select c).ToList();

            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                Console.WriteLine($"CreateWebSamplingPlan [{samplingPlan.SamplingPlanID}] doing...");
                await CreateGzFileLocal(WebTypeEnum.WebSamplingPlan, samplingPlan.SamplingPlanID, 0);
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
                List<TVItem> tvItemList = (from c in dbLocal.TVItems
                                           where c.TVType == tvType
                                           select c).ToList();

                foreach(TVItem tvItem in tvItemList)
                {
                    switch (tvType)
                    {
                        case TVTypeEnum.Area:
                            {
                                Console.WriteLine($"CreateWebArea [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebArea, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.ClimateSite:
                            {
                                Console.WriteLine($"CreateWebClimateDataValue [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebClimateDataValue, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                Console.WriteLine($"CreateWebCountry [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebCountry, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.HydrometricSite:
                            {
                                Console.WriteLine($"CreateWebHydrometricDataValue [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebHydrometricDataValue, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.MikeScenario:
                            {
                                Console.WriteLine($"CreateWebMikeScenario [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMikeScenario, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                Console.WriteLine($"CreateWebMunicipality [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMunicipality, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                Console.WriteLine($"CreateWebProvince [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebProvince, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebClimateSite [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebClimateSite, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebHydrometricSite [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebHydrometricSite, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebMunicipalities [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMunicipalities, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                Console.WriteLine($"CreateWebSector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebSector, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                Console.WriteLine($"CreateWebSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebSubsector, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebDrogueRun [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebDrogueRun, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebMWQMRun [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMRun, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebMWQMSite [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSite, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebPolSourceSite [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebPolSourceSite, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWeb10YearOfSample1980_1989FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year1980);
                                Console.WriteLine($"CreateWeb10YearOfSample1990_1999FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year1990);
                                Console.WriteLine($"CreateWeb10YearOfSample2000_2009FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2000);
                                Console.WriteLine($"CreateWeb10YearOfSample2010_2019FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2010);
                                Console.WriteLine($"CreateWeb10YearOfSample2020_2029FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2020);
                                Console.WriteLine($"CreateWeb10YearOfSample2030_2039FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2030);
                                Console.WriteLine($"CreateWeb10YearOfSample2040_2049FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2040);
                                Console.WriteLine($"CreateWeb10YearOfSample2050_2059FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFileLocal(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2050);
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
