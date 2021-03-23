using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPSQLiteServices
{
    public partial class Startup
    {
        private async Task<bool> FillCSSPDBTableList(List<string> ListCSSPDBTableList)
        {
            List<string> TempList = new List<string>()
                {
                    "Logs",
                    "RainExceedanceClimateSites",
                    "RainExceedances",
                    "EmailDistributionListContactLanguages",
                    "EmailDistributionListContacts",
                    "EmailDistributionListLanguages",
                    "EmailDistributionLists",
                    "AppErrLogs",
                    "AppTaskLanguages",
                    "AppTasks",
                    //"AspNetRoleClaims",
                    //"AspNetRoles",
                    //"AspNetUserClaims",
                    //"AspNetUserLogins",
                    //"AspNetUserRoles",
                    //"AspNetUserTokens",
                    "BoxModelLanguages",
                    "BoxModelResults",
                    "BoxModels",
                    "CoCoRaHSValues",
                    "CoCoRaHSSites",
                    "UseOfSites",
                    "PolSourceSiteEffectTerms",
                    "PolSourceSiteEffects",
                    "Classifications",
                    "ClimateDataValues",
                    "ClimateSites",
                    "DocTemplates",
                    "Addresses",
                    "DrogueRuns",
                    "DrogueRunPositions",
                    "Emails",
                    "HelpDocs",
                    "Tels",
                    "RatingCurves",
                    "RatingCurveValues",
                    "HydrometricDataValues",
                    "HydrometricSites",
                    "InfrastructureLanguages",
                    "Infrastructures",
                    "LabSheetTubeMPNDetails",
                    "LabSheetDetails",
                    "LabSheets",
                    "MapInfoPoints",
                    "MapInfos",
                    "MikeBoundaryConditions",
                    "MikeSources",
                    "MikeSourceStartEnds",
                    "MWQMAnalysisReportParameters",
                    "MWQMLookupMPNs",
                    "SamplingPlanEmails",
                    "SamplingPlans",
                    "SamplingPlanSubsectors",
                    "SamplingPlanSubsectorSites",
                    "MWQMRunLanguages",
                    "MWQMRuns",
                    "MWQMSampleLanguages",
                    "MWQMSamples",
                    "MWQMSiteStartEndDates",
                    "MWQMSites",
                    "MWQMSubsectorLanguages",
                    "MWQMSubsectors",
                    "PolSourceObservationIssues",
                    "PolSourceObservations",
                    "PolSourceSites",
                    "PolSourceGroupingLanguages",
                    "PolSourceGroupings",
                    "ResetPasswords",
                    "SpillLanguages",
                    "Spills",
                    "TideDataValues",
                    "TideLocations",
                    "TideSites",
                    "TVFileLanguages",
                    "TVFiles",
                    "ReportSections",
                    "ReportTypes",
                    "TVItemLanguages",
                    "TVItemLinks",
                    "TVItemUserAuthorizations",
                    "TVTypeUserAuthorizations",
                    "VPAmbients",
                    "VPResults",
                    "VPScenarioLanguages",
                    "VPScenarios",
                    "MikeScenarioResults",
                    "MikeScenarios",
                    "ContactPreferences",
                    "ContactShortcuts",
                    "Contacts",
                    //"PersistedGrants",
                    //"DeviceCodes",
                    //"AspNetUsers",
                    "TVItemStats",
                    "TVItems",
                };

            foreach (string s in TempList)
            {
                ListCSSPDBTableList.Add(s);
            }

            return await Task.FromResult(true);
        }
    }
}
