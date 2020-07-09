/*
 * Manually edited
 * 
 */
using Azure.Storage.Blobs;
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        private async Task<bool> DoCreateAllGzFiles()
        {
            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(false);
            }

            Console.WriteLine("GetWebContact doing...");
            await GetWebContact();
            Console.WriteLine("GetHelpDoc doing...");
            await GetHelpDoc();
            Console.WriteLine("GetMWQMLookupMPN doing...");
            await GetMWQMLookupMPN();
            Console.WriteLine("GetWebPolSourceGrouping doing...");
            await GetWebPolSourceGrouping();
            Console.WriteLine("GetWebReportType doing...");
            await GetWebReportType();
            Console.WriteLine("GetWebRoot doing...");
            await GetWebRoot();
            Console.WriteLine("GetWebTideLocation doing...");
            await GetWebTideLocation();

            List<SamplingPlan> samplingPlanList = (from c in db.SamplingPlans
                                                   select c).ToList();

            foreach(SamplingPlan samplingPlan in samplingPlanList)
            {
                Console.WriteLine($"GetWebSamplingPlan [{samplingPlan.SamplingPlanID}] doing...");
                await GetWebSamplingPlan(samplingPlan.SamplingPlanID);
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
                                Console.WriteLine($"GetWebArea [{tvItem.TVItemID}] doing...");
                                await GetWebArea(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.ClimateSite:
                            {
                                Console.WriteLine($"GetWebClimateDataValue [{tvItem.TVItemID}] doing...");
                                await GetWebClimateDataValue(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Country:
                            {
                                Console.WriteLine($"GetWebCountry [{tvItem.TVItemID}] doing...");
                                await GetWebCountry(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.HydrometricSite:
                            {
                                Console.WriteLine($"GetWebHydrometricDataValue [{tvItem.TVItemID}] doing...");
                                await GetWebHydrometricDataValue(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.MikeScenario:
                            {
                                Console.WriteLine($"GetWebMikeScenario [{tvItem.TVItemID}] doing...");
                                await GetWebMikeScenario(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Municipality:
                            {
                                Console.WriteLine($"GetWebMunicipality [{tvItem.TVItemID}] doing...");
                                await GetWebMunicipality(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Province:
                            {
                                Console.WriteLine($"GetWebProvince [{tvItem.TVItemID}] doing...");
                                await GetWebProvince(tvItem.TVItemID);
                                Console.WriteLine($"GetWebClimateSite [{tvItem.TVItemID}] doing...");
                                await GetWebClimateSite(tvItem.TVItemID);
                                Console.WriteLine($"GetWebHydrometricSite [{tvItem.TVItemID}] doing...");
                                await GetWebHydrometricSite(tvItem.TVItemID);
                                Console.WriteLine($"GetWebMunicipalities [{tvItem.TVItemID}] doing...");
                                await GetWebMunicipalities(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Sector:
                            {
                                Console.WriteLine($"GetWebSector [{tvItem.TVItemID}] doing...");
                                await GetWebSector(tvItem.TVItemID);
                            }
                            break;
                        case TVTypeEnum.Subsector:
                            {
                                Console.WriteLine($"GetWebSubsector [{tvItem.TVItemID}] doing...");
                                await GetWebSubsector(tvItem.TVItemID);
                                Console.WriteLine($"GetWebDrogueRun [{tvItem.TVItemID}] doing...");
                                await GetWebDrogueRun(tvItem.TVItemID);
                                Console.WriteLine($"GetWebMWQMRun [{tvItem.TVItemID}] doing...");
                                await GetWebMWQMRun(tvItem.TVItemID);
                                Console.WriteLine($"GetWebMWQMSite [{tvItem.TVItemID}] doing...");
                                await GetWebMWQMSite(tvItem.TVItemID);
                                Console.WriteLine($"GetWebPolSourceSite [{tvItem.TVItemID}] doing...");
                                await GetWebPolSourceSite(tvItem.TVItemID);
                                Console.WriteLine($"GetWeb10YearOfSample1980_1989FromSubsector [{tvItem.TVItemID}] doing...");
                                await GetWeb10YearOfSample1980_1989FromSubsector(tvItem.TVItemID);
                                Console.WriteLine($"GetWeb10YearOfSample1990_1999FromSubsector [{tvItem.TVItemID}] doing...");
                                await GetWeb10YearOfSample1990_1999FromSubsector(tvItem.TVItemID);
                                Console.WriteLine($"GetWeb10YearOfSample2000_2009FromSubsector [{tvItem.TVItemID}] doing...");
                                await GetWeb10YearOfSample2000_2009FromSubsector(tvItem.TVItemID);
                                Console.WriteLine($"GetWeb10YearOfSample2010_2019FromSubsector [{tvItem.TVItemID}] doing...");
                                await GetWeb10YearOfSample2010_2019FromSubsector(tvItem.TVItemID);
                                Console.WriteLine($"GetWeb10YearOfSample2020_2029FromSubsector [{tvItem.TVItemID}] doing...");
                                await GetWeb10YearOfSample2020_2029FromSubsector(tvItem.TVItemID);
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
