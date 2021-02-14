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

            Console.WriteLine("CreateWebContact doing...");
            await CreateGzFile(WebTypeEnum.WebContact, 0, 0);
            Console.WriteLine("GetHelpDoc doing...");
            await CreateGzFile(WebTypeEnum.WebHelpDoc, 0, 0);
            Console.WriteLine("GetMWQMLookupMPN doing...");
            await CreateGzFile(WebTypeEnum.WebMWQMLookupMPN, 0, 0);
            Console.WriteLine("CreateWebPolSourceGrouping doing...");
            await CreateGzFile(WebTypeEnum.WebPolSourceGrouping, 0, 0);
            Console.WriteLine("CreateWebReportType doing...");
            await CreateGzFile(WebTypeEnum.WebReportType, 0, 0);
            Console.WriteLine("CreateWebRoot doing...");
            await CreateGzFile(WebTypeEnum.WebRoot, 0, 0);
            Console.WriteLine("CreateWebTideLocation doing...");
            await CreateGzFile(WebTypeEnum.WebTideLocation, 0, 0);
            Console.WriteLine("CreateWebAllTVItem doing...");
            await CreateGzFile(WebTypeEnum.WebAllTVItem, 0, 0);
            Console.WriteLine("CreateWebAllTVItemLanguage doing...");
            await CreateGzFile(WebTypeEnum.WebAllTVItemLanguage, 0, 0);

            List<SamplingPlan> samplingPlanList = (from c in db.SamplingPlans
                                                   select c).ToList();

            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                Console.WriteLine($"CreateWebSamplingPlan [{samplingPlan.SamplingPlanID}] doing...");
                await CreateGzFile(WebTypeEnum.WebSamplingPlan, samplingPlan.SamplingPlanID, 0);
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
                                await CreateGzFile(WebTypeEnum.WebArea, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.ClimateSite:
                            {
                                Console.WriteLine($"CreateWebClimateDataValue [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebClimateDataValue, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                Console.WriteLine($"CreateWebCountry [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebCountry, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.HydrometricSite:
                            {
                                Console.WriteLine($"CreateWebHydrometricDataValue [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebHydrometricDataValue, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.MikeScenario:
                            {
                                Console.WriteLine($"CreateWebMikeScenario [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMikeScenario, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                Console.WriteLine($"CreateWebMunicipality [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMunicipality, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                Console.WriteLine($"CreateWebProvince [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebProvince, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebClimateSite [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebClimateSite, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebHydrometricSite [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebHydrometricSite, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebMunicipalities [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMunicipalities, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                Console.WriteLine($"CreateWebSector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebSector, tvItem.TVItemID, 0);
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                Console.WriteLine($"CreateWebSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebSubsector, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebDrogueRun [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebDrogueRun, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebMWQMRun [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMRun, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebMWQMSite [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSite, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWebPolSourceSite [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebPolSourceSite, tvItem.TVItemID, 0);
                                Console.WriteLine($"CreateWeb10YearOfSample1980_1989FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year1980);
                                Console.WriteLine($"CreateWeb10YearOfSample1990_1999FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year1990);
                                Console.WriteLine($"CreateWeb10YearOfSample2000_2009FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2000);
                                Console.WriteLine($"CreateWeb10YearOfSample2010_2019FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2010);
                                Console.WriteLine($"CreateWeb10YearOfSample2020_2029FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2020);
                                Console.WriteLine($"CreateWeb10YearOfSample2030_2039FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2030);
                                Console.WriteLine($"CreateWeb10YearOfSample2040_2049FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2040);
                                Console.WriteLine($"CreateWeb10YearOfSample2050_2059FromSubsector [{tvItem.TVItemID}] doing...");
                                await CreateGzFile(WebTypeEnum.WebMWQMSample, tvItem.TVItemID, WebTypeYearEnum.Year2050);
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
