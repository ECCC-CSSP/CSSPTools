/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task<ActionResult<bool>> DoCreateWebMonitoringRoutineStatsByYearForCountryGzFile(int CountryTVItemID)
        {
            if (LoggedInService.LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            TVItem tvItemRoot = await GetTVItemRoot();

            TVItem tvItemTest = await GetTVItemWithTVItemID(CountryTVItemID);

            if (tvItemTest == null || tvItemTest.TVType != TVTypeEnum.Country)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes._CouldNotBeFoundFor_Equal_,
                    "TVItem", "TVType", TVTypeEnum.Country.ToString())));
            }

            TVItem tvItemCountry = await GetTVItemWithTVItemID(CountryTVItemID);
            List<TVItemLanguage> tvItemLanguageCountryList = await GetTVItemLanguageWithTVItemID(CountryTVItemID);

            WebMonitoringRoutineStatsByYearForCountry webMonitoringRoutineStatsByYearForCountry = new WebMonitoringRoutineStatsByYearForCountry();

            List<StatByYear> statByYearRoutineCountryList = new List<StatByYear>();

            for (int j = DateTime.Now.Year; j >= 1980; j--)
            {
                Console.WriteLine($"Doing Year {j}...");

                StatByYear statByYearRoutine = new StatByYear();
                statByYearRoutine.Year = j;
                statByYearRoutine.MWQMSiteCount = GetMWQMSiteCountRoutineUnderCountry(tvItemCountry, j);
                statByYearRoutine.MWQMRunCount = GetMWQMRunCountRoutineUnderCountry(tvItemCountry, j);
                statByYearRoutine.MWQMSampleCount = GetMWQMSampleCountRoutineUnderCountry(tvItemCountry, j);

                statByYearRoutineCountryList.Add(statByYearRoutine);

            }

            webMonitoringRoutineStatsByYearForCountry.MonitoringStatsByYearModelList.Add(new MonitoringStatsByYearModel()
            {
                TVItemModel = new TVItemModel()
                {
                    TVItem = tvItemCountry,
                    TVItemLanguageList = (from c in tvItemLanguageCountryList
                                          where c.TVItemID == tvItemCountry.TVItemID
                                          select c).ToList()

                },
                StatByYearList = statByYearRoutineCountryList
            });

            try
            {

                if (dbLocal != null)
                {
                    await DoStoreLocal<WebMonitoringRoutineStatsByYearForCountry>(webMonitoringRoutineStatsByYearForCountry, $"{ WebTypeEnum.WebMonitoringRoutineStatsByYearForCountry }_{tvItemCountry.TVItemID}.gz");
                }
                else
                {
                    await DoStore<WebMonitoringRoutineStatsByYearForCountry>(webMonitoringRoutineStatsByYearForCountry, $"{ WebTypeEnum.WebMonitoringRoutineStatsByYearForCountry }_{tvItemCountry.TVItemID}.gz");
                }
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? $"Inner: { ex.InnerException.Message }" : "";
                return await Task.FromResult(BadRequest($"{ ex.Message } { inner }"));
            }

            return await Task.FromResult(Ok(true));
        }
    }
}
