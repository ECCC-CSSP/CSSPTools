/* 
 *  Manually Edited
 *  
 */

using CreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadGzFileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPLogServices;
using System.Linq;
using CSSPScrambleServices;
using CSSPWebModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
    {
        #region Properties
        private WebAllAddresses webAllAddresses { get; set; }
        private WebAllContacts webAllContacts { get; set; }
        private WebAllCountries webAllCountries { get; set; }
        private WebAllEmails webAllEmails { get; set; }
        private WebAllHelpDocs webAllHelpDocs { get; set; }
        private WebAllMunicipalities webAllMunicipalities { get; set; }
        private WebAllMWQMLookupMPNs webAllMWQMLookupMPNs { get; set; }
        private WebAllPolSourceGroupings webAllPolSourceGroupings { get; set; }
        private WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms { get; set; }
        private WebAllProvinces webAllProvinces { get; set; }
        private WebAllReportTypes webAllReportTypes { get; set; }
        private WebAllSearch webAllSearch { get; set; }
        private WebAllTels webAllTels { get; set; }
        private WebAllTideLocations webAllTideLocations { get; set; }
        private WebArea webArea { get; set; }
        private WebClimateSites webClimateSites { get; set; }
        private WebCountry webCountry { get; set; }
        private WebDrogueRuns webDrogueRuns { get; set; }
        private WebHydrometricSites webHydrometricSites { get; set; }
        private WebLabSheets webLabSheets { get; set; }
        private WebMikeScenarios webMikeScenarios { get; set; }
        private WebMonitoringOtherStatsCountry webMonitoringOtherStatsCountry { get; set; }
        private WebMonitoringOtherStatsProvince webMonitoringOtherStatsProvince { get; set; }
        private WebMonitoringRoutineStatsCountry webMonitoringRoutineStatsCountry { get; set; }
        private WebMonitoringRoutineStatsProvince webMonitoringRoutineStatsProvince { get; set; }
        private WebMunicipality webMunicipality { get; set; }
        private WebMWQMRuns webMWQMRuns { get; set; }
        private WebMWQMSamples webMWQMSamples1980_2020 { get; set; }
        private WebMWQMSamples webMWQMSamples2021_2060 { get; set; }
        private WebMWQMSites webMWQMSites { get; set; }
        private WebPolSourceSites webPolSourceSites { get; set; }
        private WebProvince webProvince { get; set; }
        private WebRoot webRoot { get; set; }
        private WebSector webSector { get; set; }
        private WebSubsector webSubsector { get; set; }
        private WebTideSites webTideSites { get; set; }

        #endregion Properties

        #region Constructors
        public TVItemLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private async Task<bool> TVItemLocalServiceSetup(string culture)
        {
            List<string> TableList = new List<string>() { "TVItems", "TVItemLanguages" };
            
            Assert.True(await CSSPDBLocalServiceSetup(culture));
            Assert.True(await ClearSomeTablesOfCSSPDBLocal(TableList));

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
