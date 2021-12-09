namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    protected async Task<bool> ClearSomeTablesOfCSSPDBLocalAsync(List<string> TableList)
    {
        if (TableList.Count == 0)
        {
            TableList = new List<string>()
            {
                "Addresses",
                "AppErrLogs",
                "AppTaskLanguages",
                "AppTasks",
                "BoxModelLanguages",
                "BoxModelResults",
                "BoxModels",
                "Classifications",
                "ClimateDataValues",
                "ClimateSites",
                "CoCoRaHSSites",
                "CoCoRaHSValues",
                "ContactPreferences",
                "ContactShortcuts",
                "Contacts",
                "DocTemplates",
                "DrogueRunPositions",
                "DrogueRuns",
                "EmailDistributionListContactLanguages",
                "EmailDistributionListContacts",
                "EmailDistributionListLanguages",
                "EmailDistributionLists",
                "Emails",
                "HelpDocs",
                "HydrometricDataValues",
                "HydrometricSites",
                "InfrastructureLanguages",
                "Infrastructures",
                "LabSheetDetails",
                "LabSheetTubeMPNDetails",
                "LabSheets",
                "Logs",
                "MWQMAnalysisReportParameters",
                "MWQMLookupMPNs",
                "MWQMRunLanguages",
                "MWQMRuns",
                "MWQMSampleLanguages",
                "MWQMSamples",
                "MWQMSiteStartEndDates",
                "MWQMSites",
                "MWQMSubsectorLanguages",
                "MWQMSubsectors",
                "MapInfoPoints",
                "MapInfos",
                "MikeBoundaryConditions",
                "MikeScenarioResults",
                "MikeScenarios",
                "MikeSourceStartEnds",
                "MikeSources",
                "PolSourceGroupingLanguages",
                "PolSourceGroupings",
                "PolSourceObservationIssues",
                "PolSourceObservations",
                "PolSourceSiteEffectTerms",
                "PolSourceSiteEffects",
                "PolSourceSites",
                "RainExceedanceClimateSites",
                "RainExceedances",
                "RatingCurveValues",
                "RatingCurves",
                "ReportSections",
                "ReportTypes",
                "ResetPasswords",
                "SamplingPlanEmails",
                "SamplingPlanSubsectorSites",
                "SamplingPlanSubsectors",
                "SamplingPlans",
                "SpillLanguages",
                "Spills",
                "TVFileLanguages",
                "TVFiles",
                "TVItemLanguages",
                "TVItemLinks",
                "TVItemStats",
                "TVItemUserAuthorizations",
                "TVItems",
                "TVTypeUserAuthorizations",
                "Tels",
                "TideDataValues",
                "TideLocations",
                "TideSites",
                "UseOfSites",
                "VPAmbients",
                "VPResults",
                "VPScenarioLanguages",
                "VPScenarios",
            };
        }

        foreach (string tableName in TableList)
        {
            try
            {
                dbLocal.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }

        return await Task.FromResult(true);
    }
}

