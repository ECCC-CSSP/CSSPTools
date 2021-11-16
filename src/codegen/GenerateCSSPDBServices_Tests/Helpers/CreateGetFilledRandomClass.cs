using CSSPDBModels;
using GenerateCodeBaseServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> CreateGetFilledRandomClass(PropertyInfo prop, CSSPProp csspProp, string TypeName, string TypeNameLower, StringBuilder sb)
        {
            switch (csspProp.PropType)
            {
                case "Int16":
                case "Int32":
                case "Int64":
                case "Single":
                case "Double":
                    {
                        string propTypeTxt = "Int";
                        string numbExt = "";
                        if (csspProp.PropType == "Single")
                        {
                            propTypeTxt = "Float";
                            numbExt = ".0f";
                        }
                        else if (csspProp.PropType == "Double")
                        {
                            propTypeTxt = "Double";
                            numbExt = ".0D";
                        }

                        if (csspProp.IsKey)
                        {
                            //sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { prop.Name };");
                        }
                        else
                        {
                            //if (csspProp.PropName == "LastUpdateContactTVItemID")
                            //{
                            //    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = 2;");
                            //}
                            //else 
                            if (csspProp.HasCSSPExistAttribute)
                            {
                                switch (csspProp.ExistTypeName)
                                {
                                    case "AppTask":
                                        {
                                            AppTask appTask = db.AppTasks.AsNoTracking().FirstOrDefault();
                                            if (appTask == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { appTask.AppTaskID };");
                                            }
                                        }
                                        break;
                                    case "BoxModel":
                                        {
                                            BoxModel boxModel = db.BoxModels.AsNoTracking().FirstOrDefault();
                                            if (boxModel == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { boxModel.BoxModelID };");
                                            }
                                        }
                                        break;
                                    case "ClimateSite":
                                        {
                                            ClimateSite climateSite = db.ClimateSites.AsNoTracking().FirstOrDefault();
                                            if (climateSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { climateSite.ClimateSiteID };");
                                            }
                                        }
                                        break;
                                    case "CoCoRaHSSite":
                                        {
                                            CoCoRaHSSite coCoRaHSSite = db.CoCoRaHSSites.AsNoTracking().FirstOrDefault();
                                            if (coCoRaHSSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { coCoRaHSSite.CoCoRaHSSiteID };");
                                            }
                                        }
                                        break;
                                    case "Contact":
                                        {
                                            Contact contact = db.Contacts.AsNoTracking().FirstOrDefault();
                                            if (contact == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { contact.ContactID };");
                                            }
                                        }
                                        break;
                                    case "DrogueRun":
                                        {
                                            DrogueRun drogueRun = db.DrogueRuns.AsNoTracking().FirstOrDefault();
                                            if (drogueRun == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { drogueRun.DrogueRunID };");
                                            }
                                        }
                                        break;
                                    case "EmailDistributionList":
                                        {
                                            EmailDistributionList emailDistributionList = db.EmailDistributionLists.AsNoTracking().FirstOrDefault();
                                            if (emailDistributionList == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { emailDistributionList.EmailDistributionListID };");
                                            }
                                        }
                                        break;
                                    case "EmailDistributionListContact":
                                        {
                                            EmailDistributionListContact emailDistributionListContact = db.EmailDistributionListContacts.AsNoTracking().FirstOrDefault();
                                            if (emailDistributionListContact == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { emailDistributionListContact.EmailDistributionListContactID };");
                                            }
                                        }
                                        break;
                                    case "HydrometricSite":
                                        {
                                            HydrometricSite hydrometricSite = db.HydrometricSites.AsNoTracking().FirstOrDefault();
                                            if (hydrometricSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { hydrometricSite.HydrometricSiteID };");
                                            }
                                        }
                                        break;
                                    case "Infrastructure":
                                        {
                                            Infrastructure infrastructure = db.Infrastructures.AsNoTracking().FirstOrDefault();
                                            if (infrastructure == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { infrastructure.InfrastructureID };");
                                            }
                                        }
                                        break;
                                    case "LabSheet":
                                        {
                                            LabSheet labSheet = db.LabSheets.AsNoTracking().FirstOrDefault();
                                            if (labSheet == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { labSheet.LabSheetID };");
                                            }
                                        }
                                        break;
                                    case "LabSheetDetail":
                                        {
                                            LabSheetDetail labSheetDetail = db.LabSheetDetails.AsNoTracking().FirstOrDefault();
                                            if (labSheetDetail == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { labSheetDetail.LabSheetDetailID };");
                                            }
                                        }
                                        break;
                                    case "MapInfo":
                                        {
                                            MapInfo mapInfo = db.MapInfos.AsNoTracking().FirstOrDefault();
                                            if (mapInfo == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mapInfo.MapInfoID };");
                                            }
                                        }
                                        break;
                                    case "MikeSource":
                                        {
                                            MikeSource mikeSource = db.MikeSources.AsNoTracking().FirstOrDefault();
                                            if (mikeSource == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mikeSource.MikeSourceID };");
                                            }
                                        }
                                        break;
                                    case "MWQMAnalysisReportParameter":
                                        {
                                            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = db.MWQMAnalysisReportParameters.AsNoTracking().FirstOrDefault();
                                            if (mwqmAnalysisReportParameter == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID };");
                                            }
                                        }
                                        break;
                                    case "MWQMRun":
                                        {
                                            MWQMRun mwqmRun = db.MWQMRuns.AsNoTracking().FirstOrDefault();
                                            if (mwqmRun == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmRun.MWQMRunID };");
                                            }
                                        }
                                        break;
                                    case "MWQMSample":
                                        {
                                            MWQMSample mwqmSample = db.MWQMSamples.AsNoTracking().FirstOrDefault();
                                            if (mwqmSample == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmSample.MWQMSampleID };");
                                            }
                                        }
                                        break;
                                    case "MWQMSubsector":
                                        {
                                            MWQMSubsector mwqmSubsector = db.MWQMSubsectors.AsNoTracking().FirstOrDefault();
                                            if (mwqmSubsector == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { mwqmSubsector.MWQMSubsectorID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceGrouping":
                                        {
                                            PolSourceGrouping polSourceGrouping = db.PolSourceGroupings.AsNoTracking().FirstOrDefault();
                                            if (polSourceGrouping == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceGrouping.PolSourceGroupingID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceObservation":
                                        {
                                            PolSourceObservation polSourceObservation = db.PolSourceObservations.AsNoTracking().FirstOrDefault();
                                            if (polSourceObservation == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceObservation.PolSourceObservationID };");
                                            }
                                        }
                                        break;
                                    case "PolSourceSite":
                                        {
                                            PolSourceSite polSourceSite = db.PolSourceSites.AsNoTracking().FirstOrDefault();
                                            if (polSourceSite == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { polSourceSite.PolSourceSiteID };");
                                            }
                                        }
                                        break;
                                    case "RatingCurve":
                                        {
                                            RatingCurve ratingCurve = db.RatingCurves.AsNoTracking().FirstOrDefault();
                                            if (ratingCurve == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { ratingCurve.RatingCurveID };");
                                            }
                                        }
                                        break;
                                    case "ReportType":
                                        {
                                            ReportType reportType = db.ReportTypes.AsNoTracking().FirstOrDefault();
                                            if (reportType == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { reportType.ReportTypeID };");
                                            }
                                        }
                                        break;
                                    case "SamplingPlanSubsector":
                                        {
                                            SamplingPlanSubsector samplingPlanSubsector = db.SamplingPlanSubsectors.AsNoTracking().FirstOrDefault();
                                            if (samplingPlanSubsector == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { samplingPlanSubsector.SamplingPlanSubsectorID };");
                                            }
                                        }
                                        break;
                                    case "SamplingPlan":
                                        {
                                            SamplingPlan samplingPlan = db.SamplingPlans.AsNoTracking().FirstOrDefault();
                                            if (samplingPlan == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { samplingPlan.SamplingPlanID };");
                                            }
                                        }
                                        break;
                                    case "Spill":
                                        {
                                            Spill spill = db.Spills.AsNoTracking().FirstOrDefault();
                                            if (spill == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { spill.SpillID };");
                                            }
                                        }
                                        break;
                                    case "TVFile":
                                        {
                                            TVFile tvFile = db.TVFiles.AsNoTracking().FirstOrDefault();
                                            if (tvFile == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvFile.TVFileID };");
                                            }
                                        }
                                        break;
                                    case "VPScenario":
                                        {
                                            VPScenario vpScenario = db.VPScenarios.AsNoTracking().FirstOrDefault();
                                            if (vpScenario == null)
                                            {
                                                sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            else
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { vpScenario.VPScenarioID };");
                                            }
                                        }
                                        break;
                                    case "TVItem":
                                        {
                                            if (TypeName == "MikeScenario" && csspProp.PropName == "ParentMikeScenarioID")
                                            {
                                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = null;");
                                            }
                                            else
                                            {
                                                if (csspProp.AllowableTVTypeList.Count == 0)
                                                {
                                                    sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                }
                                                else
                                                {
                                                    TVItem tvItem = db.TVItems.AsNoTracking().Where(c => c.TVType == csspProp.AllowableTVTypeList[0]).FirstOrDefault();
                                                    if (tvItem == null)
                                                    {
                                                        sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                                    }
                                                    else
                                                    {
                                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = { tvItem.TVItemID };");
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        {
                                            sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                        }
                                        break;
                                }
                            }
                            else if (csspProp.Min != null && csspProp.Max != null)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            { prop.Name } = MinBiggerMaxPleaseFix,");
                                }
                                else
                                {
                                    if (TypeName == "MWQMLookupMPN" && (prop.Name == "Tubes01" || prop.Name == "Tubes1" || prop.Name == "Tubes10"))
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ 2 }{ numbExt }, { 5.ToString() }{ numbExt });");
                                    }
                                    else if (TypeName == "MWQMLookupMPN" && prop.Name == "MPN_100ml")
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = 14;");
                                    }
                                    else
                                    {
                                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ csspProp.Min }{ numbExt }, { csspProp.Max.ToString() }{ numbExt });");
                                    }
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ csspProp.Min }{ numbExt }, { (csspProp.Min + 10).ToString() }{ numbExt });");
                            }
                            else if (csspProp.Max != null)
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandom{ propTypeTxt }({ (csspProp.Max - 10) }{ numbExt }, { csspProp.Max.ToString() }{ numbExt });");
                            }
                            else
                            {
                                sb.AppendLine($@"            // should implement a Range for the property { prop.Name } and type { TypeName }");
                            }
                        }
                    }
                    break;
                case "DateTime":
                case "DateTimeOffset":
                    {
                        switch ($"{ TypeName }_{ csspProp.PropName }")
                        {
                            case "AppTask_EndDateTime_UTC":
                            case "ClimateSite_HourlyEndDate_Local":
                            case "ClimateSite_DailyEndDate_Local":
                            case "ClimateSite_MonthlyEndDate_Local":
                            case "HydrometricSite_EndDate_Local":
                            case "MikeScenario_MikeScenarioEndDateTime_Local":
                            case "MikeSourceStartEnd_EndDateAndTime_Local":
                            case "MWQMRun_EndDateTime_Local":
                            case "MWQMSiteStartEndDate_EndDate":
                            case "MWQMSubsector_IncludeRainEndDate":
                            case "MWQMSubsector_NoRainEndDate":
                            case "MWQMSubsector_OnlyRainEndDate":
                            case "Spill_EndDateTime_Local":
                            case "TVItemLink_EndDateTime_Local":
                                break;
                            case "AppTask_StartDateTime_UTC":
                            case "ClimateSite_HourlyStartDate_Local":
                            case "ClimateSite_DailyStartDate_Local":
                            case "ClimateSite_MonthlyStartDate_Local":
                            case "HydrometricSite_StartDate_Local":
                            case "MikeScenario_MikeScenarioStartDateTime_Local":
                            case "MikeSourceStartEnd_StartDateAndTime_Local":
                            case "MWQMRun_StartDateTime_Local":
                            case "MWQMSiteStartEndDate_StartDate":
                            case "MWQMSubsector_IncludeRainStartDate":
                            case "MWQMSubsector_NoRainStartDate":
                            case "MWQMSubsector_OnlyRainStartDate":
                            case "Spill_StartDateTime_Local":
                            case "TVItemLink_StartDateTime_Local":
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new DateTime(2005, 3, 6);");
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name.Replace("Start", "End") }"") { TypeNameLower }.{ prop.Name.Replace("Start", "End") } = new DateTime(2005, 3, 7);");
                                }
                                break;
                            default:
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new DateTime(2005, 3, 6);");
                                }
                                break;
                        }
                    }
                    break;
                case "Boolean":
                    {
                        sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = true;");
                    }
                    break;
                case "String":
                    {
                        if (csspProp.HasCSSPExistAttribute)
                        {
                            switch (csspProp.ExistTypeName)
                            {
                                //case "AspNetUser":
                                //    {
                                //        AspNetUser appTask = dbTestDB.AspNetUsers.AsNoTracking().FirstOrDefault();
                                //        if (appTask == null)
                                //        {
                                //            sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                //        }
                                //        else
                                //        {
                                //            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ""{ appTask.Id }"";");
                                //        }
                                //    }
                                //    break;
                                default:
                                    {
                                        sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                    }
                                    break;
                            }
                        }
                        else if (csspProp.HasDataTypeAttribute) // will have to do this better ... works because it's only use when email
                        {
                            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomEmail();");
                        }
                        else
                        {
                            if (csspProp.Min != null && csspProp.Max > 0)
                            {
                                if (csspProp.Min > csspProp.Max)
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = MinBiggerMaxLengthPleaseFix;");
                                }
                                else
                                {
                                    double? StrLen = (int)csspProp.Min + 5;
                                    if (StrLen > csspProp.Max)
                                    {
                                        StrLen = csspProp.Max;
                                    }
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen });");
                                }
                            }
                            else if (csspProp.Min != null)
                            {
                                double StrLen = (int)csspProp.Min + 5;
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen });");
                            }
                            else if (csspProp.Max > 0)
                            {
                                double? StrLen = 5;
                                if (StrLen > csspProp.Max)
                                {
                                    StrLen = csspProp.Max;
                                }
                                if (TypeName == "Contact" && csspProp.HasCSSPExistAttribute)
                                {
                                    switch (csspProp.ExistTypeName)
                                    {
                                        //case "AspNetUser":
                                        //    {
                                        //        AspNetUser AspNetUser = dbTestDB.AspNetUsers.AsNoTracking().FirstOrDefault();

                                        //        if (AspNetUser == null)
                                        //        {
                                        //            sb.AppendLine($@"            // Need to implement (no items found, would need to add at least one in the TestDB) [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                        //        }
                                        //        else
                                        //        {
                                        //            sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ""{ AspNetUser.Id }"";");
                                        //        }
                                        //    }
                                        //    break;
                                        default:
                                            {
                                                sb.AppendLine($@"            // Need to implement [{ TypeName } { csspProp.PropName } { csspProp.ExistTypeName } { csspProp.ExistFieldID }]");
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", { StrLen.ToString() });");
                                }
                            }
                            else
                            {
                                if (csspProp.IsList)
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = new List<string>() {{ GetRandomString("""", 20), GetRandomString("""", 20) }};");
                                }
                                else
                                {
                                    sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = GetRandomString("""", 20);");
                                }
                            }
                        }
                    }
                    break;
                case "Byte[]":
                    {
                        if (TypeName == "ContactLogin")
                        {
                            if (csspProp.PropName == "PasswordSalt")
                            {
                                // Don't do anything for this property
                                // everything will be done while at the PasswordHash property
                            }

                            if (csspProp.PropName == "PasswordHash")
                            {
                                sb.AppendLine(@"            ContactService contactService = new ContactService(LanguageRequest, dbTestDB, ContactID);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            Register register = new Register();");
                                sb.AppendLine(@"            register.Password = GetRandomPassword(); // the only thing needed for CreatePasswordHashAndSalt");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            byte[] passwordHash;");
                                sb.AppendLine(@"            byte[] passwordSalt;");
                                sb.AppendLine(@"            contactService.CreatePasswordHashAndSalt(register, out passwordHash, out passwordSalt);");
                                sb.AppendLine(@"");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordHash"") contactLogin.PasswordHash = passwordHash;");
                                sb.AppendLine(@"            if (OmitPropName != ""PasswordSalt"") contactLogin.PasswordSalt = passwordSalt;");
                            }
                        }
                    }
                    break;
                default:
                    {
                        if (csspProp.PropType.Contains("Enum"))
                        {
                            if (csspProp.PropType.Contains("LanguageEnum"))
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == ""fr"" ? LanguageEnum.fr : LanguageEnum.en;");
                            }
                            else
                            {
                                sb.AppendLine($@"            if (OmitPropName != ""{ prop.Name }"") { TypeNameLower }.{ prop.Name } = ({ csspProp.PropType })GetRandomEnumType(typeof({ csspProp.PropType }));");
                            }
                        }
                        else if (csspProp.PropName.EndsWith("Web") || csspProp.PropName.EndsWith("Report"))
                        {
                            // nothing for now
                        }
                        else
                        {
                            sb.AppendLine($@"            //CSSPError: property [{ csspProp.PropName }] and type [{ TypeName }] is  not implemented");
                        }
                    }
                    break;
            }

            return await Task.FromResult(true);
        }
    }
}
