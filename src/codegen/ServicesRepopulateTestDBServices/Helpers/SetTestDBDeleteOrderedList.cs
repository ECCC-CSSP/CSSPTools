using GenerateCodeBaseServices.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesRepopulateTestDBServices.Services
{
    public partial class ServicesRepopulateTestDBService : IServicesRepopulateTestDBService
    {
        private async Task<bool> SetTestDBDeleteOrderedList(List<Table> tableTestDBList)
        {
            List<string> ListTableToDelete = new List<string>()
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
                "AspNetRoles",
                "AspNetUserClaims",
                "AspNetUserLogins",
                "AspNetUserRoles",
                "BoxModelLanguages",
                "BoxModelResults",
                "BoxModels",
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
                //"MWQMSitePolSourceSites",
                "MWQMSites",
                "MWQMSubsectorLanguages",
                "MWQMSubsectors",
                "PolSourceObservationIssues",
                "PolSourceObservations",
                "PolSourceSites",
                "ResetPasswords",
                "SpillLanguages",
                "Spills",
                "TideDataValues",
                "TideLocations",
                "TideSites",
                "TVFileLanguages",
                "TVFiles",
                //"ReportSectionLanguages",
                "ReportSections",
                //"ReportTypeLanguages",
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
                "AspNetUsers",
                "TVItemStats",
                "TVItems",
            };

            // checking if all table exist in the table to delete ordered list
            foreach (Table table in tableTestDBList)
            {
                if (!ListTableToDelete.Where(c => c == table.TableName).Any())
                {
                    ActionCommandDBService.ExecutionStatusText.AppendLine($"{ table.TableName } is missing in the list of table to delete");
                    return await Task.FromResult(false);
                }
            }

            int OrdinalToDelete = 0;
            foreach (string s in ListTableToDelete)
            {
                OrdinalToDelete += 1;

                Table table = (from c in tableTestDBList
                               where c.TableName == s
                               select c).FirstOrDefault();

                if (table == null)
                {
                    ActionCommandDBService.ExecutionStatusText.AppendLine($"{ s } is missing in the list of table");
                    return await Task.FromResult(false);
                }

                table.ordinalToDelete = OrdinalToDelete;
            }

            return await Task.FromResult(true);
        }
    }
}
