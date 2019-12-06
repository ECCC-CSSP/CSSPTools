using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPEnumsDLL.Services
{
    public partial class BaseEnumService
    {

        #region Functions Get Enum Text
        public string GetEnumText_AddressTypeEnum(AddressTypeEnum? addressTypeE)
        {
            if (addressTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (addressTypeE)
            {
                case AddressTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case AddressTypeEnum.Mailing:
                    return BaseEnumServiceRes.AddressTypeEnumMailing;
                case AddressTypeEnum.Shipping:
                    return BaseEnumServiceRes.AddressTypeEnumShipping;
                case AddressTypeEnum.Civic:
                    return BaseEnumServiceRes.AddressTypeEnumCivic;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_AerationTypeEnum(AerationTypeEnum? aerationTypeE)
        {
            if (aerationTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (aerationTypeE)
            {
                case AerationTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case AerationTypeEnum.MechanicalAirLines:
                    return BaseEnumServiceRes.AerationTypeEnumMechanicalAirLines;
                case AerationTypeEnum.MechanicalSurfaceMixers:
                    return BaseEnumServiceRes.AerationTypeEnumMechanicalSurfaceMixers;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_AlarmSystemTypeEnum(AlarmSystemTypeEnum? alarmSystemTypeE)
        {
            if (alarmSystemTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (alarmSystemTypeE)
            {
                case AlarmSystemTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case AlarmSystemTypeEnum.SCADA:
                    return BaseEnumServiceRes.AlarmSystemTypeEnumSCADA;
                case AlarmSystemTypeEnum.None:
                    return BaseEnumServiceRes.AlarmSystemTypeEnumNone;
                case AlarmSystemTypeEnum.OnlyVisualLight:
                    return BaseEnumServiceRes.AlarmSystemTypeEnumOnlyVisualLight;
                case AlarmSystemTypeEnum.SCADAAndLight:
                    return BaseEnumServiceRes.AlarmSystemTypeEnumSCADAAndLight;
                case AlarmSystemTypeEnum.PagerAndLight:
                    return BaseEnumServiceRes.AlarmSystemTypeEnumPagerAndLight;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_AnalysisCalculationTypeEnum(AnalysisCalculationTypeEnum? analysisCalculationTypeE)
        {
            if (analysisCalculationTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (analysisCalculationTypeE)
            {
                case AnalysisCalculationTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case AnalysisCalculationTypeEnum.AllAllAll:
                    return BaseEnumServiceRes.AnalysisCalculationTypeEnumAllAllAll;
                case AnalysisCalculationTypeEnum.WetAllAll:
                    return BaseEnumServiceRes.AnalysisCalculationTypeEnumWetAllAll;
                case AnalysisCalculationTypeEnum.DryAllAll:
                    return BaseEnumServiceRes.AnalysisCalculationTypeEnumDryAllAll;
                case AnalysisCalculationTypeEnum.WetWetAll:
                    return BaseEnumServiceRes.AnalysisCalculationTypeEnumWetWetAll;
                case AnalysisCalculationTypeEnum.DryDryAll:
                    return BaseEnumServiceRes.AnalysisCalculationTypeEnumDryDryAll;
                case AnalysisCalculationTypeEnum.WetDryAll:
                    return BaseEnumServiceRes.AnalysisCalculationTypeEnumWetDryAll;
                case AnalysisCalculationTypeEnum.DryWetAll:
                    return BaseEnumServiceRes.AnalysisCalculationTypeEnumDryWetAll;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_AnalysisReportExportCommandEnum(AnalysisReportExportCommandEnum? analysisReportExportCommandE)
        {
            if (analysisReportExportCommandE == null)
                return BaseEnumServiceRes.Empty;

            switch (analysisReportExportCommandE)
            {
                case AnalysisReportExportCommandEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case AnalysisReportExportCommandEnum.Report:
                    return BaseEnumServiceRes.AnalysisReportExportCommandEnumReport;
                case AnalysisReportExportCommandEnum.Excel:
                    return BaseEnumServiceRes.AnalysisReportExportCommandEnumExcel;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_AnalyzeMethodEnum(AnalyzeMethodEnum? analyzeMethodE)
        {
            if (analyzeMethodE == null)
                return BaseEnumServiceRes.Empty;

            switch (analyzeMethodE)
            {
                case AnalyzeMethodEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case AnalyzeMethodEnum.MF:
                    return BaseEnumServiceRes.AnalyzeMethodEnumMF;
                case AnalyzeMethodEnum.ZZ_510Q:
                    return BaseEnumServiceRes.AnalyzeMethodEnumZZ_510Q;
                case AnalyzeMethodEnum.ZZ_509Q:
                    return BaseEnumServiceRes.AnalyzeMethodEnumZZ_509Q;
                case AnalyzeMethodEnum.ZZ_0:
                    return BaseEnumServiceRes.AnalyzeMethodEnumZZ_0;
                case AnalyzeMethodEnum.ZZ_525Q:
                    return BaseEnumServiceRes.AnalyzeMethodEnumZZ_525Q;
                case AnalyzeMethodEnum.MPN:
                    return BaseEnumServiceRes.AnalyzeMethodEnumMPN;
                case AnalyzeMethodEnum.ZZ_0Q:
                    return BaseEnumServiceRes.AnalyzeMethodEnumZZ_0Q;
                case AnalyzeMethodEnum.AnalyzeMethod8:
                    return BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod8;
                case AnalyzeMethodEnum.AnalyzeMethod9:
                    return BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod9;
                case AnalyzeMethodEnum.AnalyzeMethod10:
                    return BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod10;
                case AnalyzeMethodEnum.AnalyzeMethod11:
                    return BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod11;
                case AnalyzeMethodEnum.AnalyzeMethod12:
                    return BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod12;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_AppTaskCommandEnum(AppTaskCommandEnum? appTaskCommandE)
        {
            if (appTaskCommandE == null)
                return BaseEnumServiceRes.Empty;

            switch (appTaskCommandE)
            {
                case AppTaskCommandEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case AppTaskCommandEnum.GenerateWebTide:
                    return BaseEnumServiceRes.AppTaskCommandEnumGenerateWebTide;
                case AppTaskCommandEnum.MikeScenarioAskToRun:
                    return BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioAskToRun;
                case AppTaskCommandEnum.MikeScenarioImport:
                    return BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioImport;
                case AppTaskCommandEnum.MikeScenarioOtherFileImport:
                    return BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioOtherFileImport;
                case AppTaskCommandEnum.MikeScenarioRunning:
                    return BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioRunning;
                case AppTaskCommandEnum.MikeScenarioToCancel:
                    return BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioToCancel;
                case AppTaskCommandEnum.MikeScenarioWaitingToRun:
                    return BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioWaitingToRun;
                case AppTaskCommandEnum.SetupWebTide:
                    return BaseEnumServiceRes.AppTaskCommandEnumSetupWebTide;
                case AppTaskCommandEnum.UpdateClimateSiteInformation:
                    return BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteInformation;
                case AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyFromStartDateToEndDate:
                    return BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteDailyAndHourlyFromStartDateToEndDate;
                case AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate:
                    return BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate;
                case AppTaskCommandEnum.CreateFCForm:
                    return BaseEnumServiceRes.AppTaskCommandEnumCreateFCForm;
                case AppTaskCommandEnum.CreateSamplingPlanSamplingPlanTextFile:
                    return BaseEnumServiceRes.AppTaskCommandEnumCreateSamplingPlanSamplingPlanTextFile;
                case AppTaskCommandEnum.CreateDocumentFromTemplate:
                    return BaseEnumServiceRes.AppTaskCommandEnumCreateDocumentFromTemplate;
                case AppTaskCommandEnum.GetClimateSitesDataForRunsOfYear:
                    return BaseEnumServiceRes.AppTaskCommandEnumGetClimateSitesDataForRunsOfYear;
                case AppTaskCommandEnum.CreateWebTideDataWLAtFirstNode:
                    return BaseEnumServiceRes.AppTaskCommandEnumCreateWebTideDataWLAtFirstNode;
                case AppTaskCommandEnum.ExportEmailDistributionLists:
                    return BaseEnumServiceRes.AppTaskCommandEnumExportEmailDistributionLists;
                case AppTaskCommandEnum.ExportAnalysisToExcel:
                    return BaseEnumServiceRes.AppTaskCommandEnumExportAnalysisToExcel;
                case AppTaskCommandEnum.CreateDocumentFromParameters:
                    return BaseEnumServiceRes.AppTaskCommandEnumCreateDocumentFromParameters;
                case AppTaskCommandEnum.CreateDocxPDF:
                    return BaseEnumServiceRes.AppTaskCommandEnumCreateDocxPDF;
                case AppTaskCommandEnum.CreateXlsxPDF:
                    return BaseEnumServiceRes.AppTaskCommandEnumCreateXlsxPDF;
                case AppTaskCommandEnum.OpenDataCSVOfMWQMSites:
                    return BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVOfMWQMSites;
                case AppTaskCommandEnum.OpenDataKMZOfMWQMSites:
                    return BaseEnumServiceRes.AppTaskCommandEnumOpenDataKMZOfMWQMSites;
                case AppTaskCommandEnum.OpenDataXlsxOfMWQMSitesAndSamples:
                    return BaseEnumServiceRes.AppTaskCommandEnumOpenDataXlsxOfMWQMSitesAndSamples;
                case AppTaskCommandEnum.OpenDataCSVOfMWQMSamples:
                    return BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVOfMWQMSamples;
                case AppTaskCommandEnum.GetAllPrecipitationForYear:
                    return BaseEnumServiceRes.AppTaskCommandEnumGetAllPrecipitationForYear;
                case AppTaskCommandEnum.FillRunPrecipByClimateSitePriorityForYear:
                    return BaseEnumServiceRes.AppTaskCommandEnumFillRunPrecipByClimateSitePriorityForYear;
                case AppTaskCommandEnum.FindMissingPrecipForProvince:
                    return BaseEnumServiceRes.AppTaskCommandEnumFindMissingPrecipForProvince;
                case AppTaskCommandEnum.ExportToArcGIS:
                    return BaseEnumServiceRes.AppTaskCommandEnumExportToArcGIS;
                case AppTaskCommandEnum.GenerateClassificationForCSSPWebToolsVisualization:
                    return BaseEnumServiceRes.AppTaskCommandEnumGenerateClassificationForCSSPWebToolsVisualization;
                case AppTaskCommandEnum.GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization:
                    return BaseEnumServiceRes.AppTaskCommandEnumGenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization;
                case AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSites:
                    return BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVNationalOfMWQMSites;
                case AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSamples:
                    return BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVNationalOfMWQMSamples;
                case AppTaskCommandEnum.ProvinceToolsCreateClassificationInputsKML:
                    return BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateClassificationInputsKML;
                case AppTaskCommandEnum.ProvinceToolsCreateGroupingInputsKML:
                    return BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateGroupingInputsKML;
                case AppTaskCommandEnum.ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML:
                    return BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateMWQMSitesAndPolSourceSitesKML;
                case AppTaskCommandEnum.UpdateHydrometricSiteInformation:
                    return BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteInformation;
                case AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate:
                    return BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate;
                case AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate:
                    return BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate;
                case AppTaskCommandEnum.GetHydrometricSitesDataForRunsOfYear:
                    return BaseEnumServiceRes.AppTaskCommandEnumGetHydrometricSitesDataForRunsOfYear;
                case AppTaskCommandEnum.GetAllDischargesForYear:
                    return BaseEnumServiceRes.AppTaskCommandEnumGetAllDischargesForYear;
                case AppTaskCommandEnum.FillRunDischargesByHydrometricSitePriorityForYear:
                    return BaseEnumServiceRes.AppTaskCommandEnumFillRunDischargesByHydrometricSitePriorityForYear;
                case AppTaskCommandEnum.FindMissingDischargesForProvince:
                    return BaseEnumServiceRes.AppTaskCommandEnumFindMissingDischargesForProvince;
                case AppTaskCommandEnum.LoadHydrometricDataValue:
                    return BaseEnumServiceRes.AppTaskCommandEnumLoadHydrometricDataValue;
                case AppTaskCommandEnum.GenerateKMLFileClassificationForCSSPWebToolsVisualization:
                    return BaseEnumServiceRes.AppTaskCommandEnumGenerateKMLFileClassificationForCSSPWebToolsVisualization;
                case AppTaskCommandEnum.ProvinceToolsGenerateStats:
                    return BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsGenerateStats;
                case AppTaskCommandEnum.MikeScenarioPrepareResults:
                    return BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioPrepareResults;
                case AppTaskCommandEnum.ClimateSiteLoadCoCoRaHSData:
                    return BaseEnumServiceRes.AppTaskCommandEnumClimateSiteLoadCoCoRaHSData;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_AppTaskStatusEnum(AppTaskStatusEnum? appTaskStatusE)
        {
            if (appTaskStatusE == null)
                return BaseEnumServiceRes.Empty;

            switch (appTaskStatusE)
            {
                case AppTaskStatusEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case AppTaskStatusEnum.Created:
                    return BaseEnumServiceRes.AppTaskStatusEnumCreated;
                case AppTaskStatusEnum.Running:
                    return BaseEnumServiceRes.AppTaskStatusEnumRunning;
                case AppTaskStatusEnum.Completed:
                    return BaseEnumServiceRes.AppTaskStatusEnumCompleted;
                case AppTaskStatusEnum.Cancelled:
                    return BaseEnumServiceRes.AppTaskStatusEnumCancelled;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_BeaufortScaleEnum(BeaufortScaleEnum? beaufortScaleE)
        {
            if (beaufortScaleE == null)
                return BaseEnumServiceRes.Empty;

            switch (beaufortScaleE)
            {
                case BeaufortScaleEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case BeaufortScaleEnum.Calm:
                    return BaseEnumServiceRes.BeaufortScaleEnumCalm;
                case BeaufortScaleEnum.LightAir:
                    return BaseEnumServiceRes.BeaufortScaleEnumLightAir;
                case BeaufortScaleEnum.LightBreeze:
                    return BaseEnumServiceRes.BeaufortScaleEnumLightBreeze;
                case BeaufortScaleEnum.GentleBreeze:
                    return BaseEnumServiceRes.BeaufortScaleEnumGentleBreeze;
                case BeaufortScaleEnum.ModerateBreeze:
                    return BaseEnumServiceRes.BeaufortScaleEnumModerateBreeze;
                case BeaufortScaleEnum.FreshBreeze:
                    return BaseEnumServiceRes.BeaufortScaleEnumFreshBreeze;
                case BeaufortScaleEnum.StrongBreeze:
                    return BaseEnumServiceRes.BeaufortScaleEnumStrongBreeze;
                case BeaufortScaleEnum.HighWind_ModerateGale_NearGale:
                    return BaseEnumServiceRes.BeaufortScaleEnumHighWind_ModerateGale_NearGale;
                case BeaufortScaleEnum.Gale_FreshGale:
                    return BaseEnumServiceRes.BeaufortScaleEnumGale_FreshGale;
                case BeaufortScaleEnum.Strong_SevereGale:
                    return BaseEnumServiceRes.BeaufortScaleEnumStrong_SevereGale;
                case BeaufortScaleEnum.Storm_WholeGale:
                    return BaseEnumServiceRes.BeaufortScaleEnumStorm_WholeGale;
                case BeaufortScaleEnum.ViolentStorm:
                    return BaseEnumServiceRes.BeaufortScaleEnumViolentStorm;
                case BeaufortScaleEnum.HurricaneForce:
                    return BaseEnumServiceRes.BeaufortScaleEnumHurricaneForce;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_BoxModelResultTypeEnum(BoxModelResultTypeEnum? boxModelResultTypeE)
        {
            if (boxModelResultTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (boxModelResultTypeE)
            {
                case BoxModelResultTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case BoxModelResultTypeEnum.Dilution:
                    return BaseEnumServiceRes.BoxModelResultTypeEnumDilution;
                case BoxModelResultTypeEnum.NoDecayUntreated:
                    return BaseEnumServiceRes.BoxModelResultTypeEnumNoDecayUntreated;
                case BoxModelResultTypeEnum.NoDecayPreDisinfection:
                    return BaseEnumServiceRes.BoxModelResultTypeEnumNoDecayPreDisinfection;
                case BoxModelResultTypeEnum.DecayUntreated:
                    return BaseEnumServiceRes.BoxModelResultTypeEnumDecayUntreated;
                case BoxModelResultTypeEnum.DecayPreDisinfection:
                    return BaseEnumServiceRes.BoxModelResultTypeEnumDecayPreDisinfection;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ClassificationTypeEnum(ClassificationTypeEnum? classificationTypeE)
        {
            if (classificationTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (classificationTypeE)
            {
                case ClassificationTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ClassificationTypeEnum.Approved:
                    return BaseEnumServiceRes.ClassificationTypeEnumApproved;
                case ClassificationTypeEnum.Restricted:
                    return BaseEnumServiceRes.ClassificationTypeEnumRestricted;
                case ClassificationTypeEnum.Prohibited:
                    return BaseEnumServiceRes.ClassificationTypeEnumProhibited;
                case ClassificationTypeEnum.ConditionallyApproved:
                    return BaseEnumServiceRes.ClassificationTypeEnumConditionallyApproved;
                case ClassificationTypeEnum.ConditionallyRestricted:
                    return BaseEnumServiceRes.ClassificationTypeEnumConditionallyRestricted;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_CollectionSystemTypeEnum(CollectionSystemTypeEnum? collectionSystemTypeE)
        {
            if (collectionSystemTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (collectionSystemTypeE)
            {
                case CollectionSystemTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case CollectionSystemTypeEnum.CompletelySeparated:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCompletelySeparated;
                case CollectionSystemTypeEnum.CompletelyCombined:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCompletelyCombined;
                case CollectionSystemTypeEnum.Combined90Separated10:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined90Separated10;
                case CollectionSystemTypeEnum.Combined80Separated20:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined80Separated20;
                case CollectionSystemTypeEnum.Combined70Separated30:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined70Separated30;
                case CollectionSystemTypeEnum.Combined60Separated40:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined60Separated40;
                case CollectionSystemTypeEnum.Combined50Separated50:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined50Separated50;
                case CollectionSystemTypeEnum.Combined40Separated60:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined40Separated60;
                case CollectionSystemTypeEnum.Combined30Separated70:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined30Separated70;
                case CollectionSystemTypeEnum.Combined20Separated80:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined20Separated80;
                case CollectionSystemTypeEnum.Combined10Separated90:
                    return BaseEnumServiceRes.CollectionSystemTypeEnumCombined10Separated90;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ContactTitleEnum(ContactTitleEnum? contactTitleE)
        {
            if (contactTitleE == null)
                return BaseEnumServiceRes.Empty;

            switch (contactTitleE)
            {
                case ContactTitleEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ContactTitleEnum.DirectorGeneral:
                    return BaseEnumServiceRes.ContactTitleEnumDirectorGeneral;
                case ContactTitleEnum.DirectorPublicWorks:
                    return BaseEnumServiceRes.ContactTitleEnumDirectorPublicWorks;
                case ContactTitleEnum.Superintendent:
                    return BaseEnumServiceRes.ContactTitleEnumSuperintendent;
                case ContactTitleEnum.Engineer:
                    return BaseEnumServiceRes.ContactTitleEnumEngineer;
                case ContactTitleEnum.Foreman:
                    return BaseEnumServiceRes.ContactTitleEnumForeman;
                case ContactTitleEnum.Operator:
                    return BaseEnumServiceRes.ContactTitleEnumOperator;
                case ContactTitleEnum.FacilitiesManager:
                    return BaseEnumServiceRes.ContactTitleEnumFacilitiesManager;
                case ContactTitleEnum.Supervisor:
                    return BaseEnumServiceRes.ContactTitleEnumSupervisor;
                case ContactTitleEnum.Technician:
                    return BaseEnumServiceRes.ContactTitleEnumTechnician;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_CSSPWQInputSheetTypeEnum(CSSPWQInputSheetTypeEnum? cSSPWQInputSheetTypeE)
        {
            if (cSSPWQInputSheetTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (cSSPWQInputSheetTypeE)
            {
                case CSSPWQInputSheetTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case CSSPWQInputSheetTypeEnum.A1:
                    return BaseEnumServiceRes.CSSPWQInputSheetTypeEnumA1;
                case CSSPWQInputSheetTypeEnum.LTB:
                    return BaseEnumServiceRes.CSSPWQInputSheetTypeEnumLTB;
                case CSSPWQInputSheetTypeEnum.EC:
                    return BaseEnumServiceRes.CSSPWQInputSheetTypeEnumEC;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_CSSPWQInputTypeEnum(CSSPWQInputTypeEnum? cSSPWQInputTypeE)
        {
            if (cSSPWQInputTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (cSSPWQInputTypeE)
            {
                case CSSPWQInputTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case CSSPWQInputTypeEnum.Subsector:
                    return BaseEnumServiceRes.CSSPWQInputTypeEnumSubsector;
                case CSSPWQInputTypeEnum.Municipality:
                    return BaseEnumServiceRes.CSSPWQInputTypeEnumMunicipality;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_DailyOrHourlyDataEnum(DailyOrHourlyDataEnum? dailyOrHourlyDataE)
        {
            if (dailyOrHourlyDataE == null)
                return BaseEnumServiceRes.Empty;

            switch (dailyOrHourlyDataE)
            {
                case DailyOrHourlyDataEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case DailyOrHourlyDataEnum.Daily:
                    return BaseEnumServiceRes.DailyOrHourlyDataEnumDaily;
                case DailyOrHourlyDataEnum.Hourly:
                    return BaseEnumServiceRes.DailyOrHourlyDataEnumHourly;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_DisinfectionTypeEnum(DisinfectionTypeEnum? disinfectionTypeE)
        {
            if (disinfectionTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (disinfectionTypeE)
            {
                case DisinfectionTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case DisinfectionTypeEnum.None:
                    return BaseEnumServiceRes.DisinfectionTypeEnumNone;
                case DisinfectionTypeEnum.UV:
                    return BaseEnumServiceRes.DisinfectionTypeEnumUV;
                case DisinfectionTypeEnum.ChlorinationNoDechlorination:
                    return BaseEnumServiceRes.DisinfectionTypeEnumChlorinationNoDechlorination;
                case DisinfectionTypeEnum.ChlorinationWithDechlorination:
                    return BaseEnumServiceRes.DisinfectionTypeEnumChlorinationWithDechlorination;
                case DisinfectionTypeEnum.UVSeasonal:
                    return BaseEnumServiceRes.DisinfectionTypeEnumUVSeasonal;
                case DisinfectionTypeEnum.ChlorinationNoDechlorinationSeasonal:
                    return BaseEnumServiceRes.DisinfectionTypeEnumChlorinationNoDechlorinationSeasonal;
                case DisinfectionTypeEnum.ChlorinationWithDechlorinationSeasonal:
                    return BaseEnumServiceRes.DisinfectionTypeEnumChlorinationWithDechlorinationSeasonal;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_DrogueTypeEnum(DrogueTypeEnum? drogueTypeE)
        {
            if (drogueTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (drogueTypeE)
            {
                case DrogueTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case DrogueTypeEnum.SmallDrogue:
                    return BaseEnumServiceRes.DrogueTypeEnumSmallDrogue;
                case DrogueTypeEnum.LargeDrogue:
                    return BaseEnumServiceRes.DrogueTypeEnumLargeDrogue;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_EmailTypeEnum(EmailTypeEnum? emailTypeE)
        {
            if (emailTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (emailTypeE)
            {
                case EmailTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case EmailTypeEnum.Personal:
                    return BaseEnumServiceRes.EmailTypeEnumPersonal;
                case EmailTypeEnum.Work:
                    return BaseEnumServiceRes.EmailTypeEnumWork;
                case EmailTypeEnum.Personal2:
                    return BaseEnumServiceRes.EmailTypeEnumPersonal2;
                case EmailTypeEnum.Work2:
                    return BaseEnumServiceRes.EmailTypeEnumWork2;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ExcelExportShowDataTypeEnum(ExcelExportShowDataTypeEnum? excelExportShowDataTypeE)
        {
            if (excelExportShowDataTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (excelExportShowDataTypeE)
            {
                case ExcelExportShowDataTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ExcelExportShowDataTypeEnum.FecalColiform:
                    return BaseEnumServiceRes.ExcelExportShowDataTypeEnumFecalColiform;
                case ExcelExportShowDataTypeEnum.Temperature:
                    return BaseEnumServiceRes.ExcelExportShowDataTypeEnumTemperature;
                case ExcelExportShowDataTypeEnum.Salinity:
                    return BaseEnumServiceRes.ExcelExportShowDataTypeEnumSalinity;
                case ExcelExportShowDataTypeEnum.P90:
                    return BaseEnumServiceRes.ExcelExportShowDataTypeEnumP90;
                case ExcelExportShowDataTypeEnum.GemetricMean:
                    return BaseEnumServiceRes.ExcelExportShowDataTypeEnumGemetricMean;
                case ExcelExportShowDataTypeEnum.Median:
                    return BaseEnumServiceRes.ExcelExportShowDataTypeEnumMedian;
                case ExcelExportShowDataTypeEnum.PercOfP90Over43:
                    return BaseEnumServiceRes.ExcelExportShowDataTypeEnumPercOfP90Over43;
                case ExcelExportShowDataTypeEnum.PercOfP90Over260:
                    return BaseEnumServiceRes.ExcelExportShowDataTypeEnumPercOfP90Over260;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_FacilityTypeEnum(FacilityTypeEnum? facilityTypeE)
        {
            if (facilityTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (facilityTypeE)
            {
                case FacilityTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case FacilityTypeEnum.Lagoon:
                    return BaseEnumServiceRes.FacilityTypeEnumLagoon;
                case FacilityTypeEnum.Plant:
                    return BaseEnumServiceRes.FacilityTypeEnumPlant;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_FilePurposeEnum(FilePurposeEnum? filePurposeE)
        {
            if (filePurposeE == null)
                return BaseEnumServiceRes.Empty;

            switch (filePurposeE)
            {
                case FilePurposeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case FilePurposeEnum.MikeInput:
                    return BaseEnumServiceRes.FilePurposeEnumMikeInput;
                case FilePurposeEnum.MikeInputMDF:
                    return BaseEnumServiceRes.FilePurposeEnumMikeInputMDF;
                case FilePurposeEnum.MikeResultDFSU:
                    return BaseEnumServiceRes.FilePurposeEnumMikeResultDFSU;
                case FilePurposeEnum.MikeResultKMZ:
                    return BaseEnumServiceRes.FilePurposeEnumMikeResultKMZ;
                case FilePurposeEnum.Information:
                    return BaseEnumServiceRes.FilePurposeEnumInformation;
                case FilePurposeEnum.Image:
                    return BaseEnumServiceRes.FilePurposeEnumImage;
                case FilePurposeEnum.Picture:
                    return BaseEnumServiceRes.FilePurposeEnumPicture;
                case FilePurposeEnum.ReportGenerated:
                    return BaseEnumServiceRes.FilePurposeEnumReportGenerated;
                case FilePurposeEnum.TemplateGenerated:
                    return BaseEnumServiceRes.FilePurposeEnumTemplateGenerated;
                case FilePurposeEnum.GeneratedFCForm:
                    return BaseEnumServiceRes.FilePurposeEnumGeneratedFCForm;
                case FilePurposeEnum.Template:
                    return BaseEnumServiceRes.FilePurposeEnumTemplate;
                case FilePurposeEnum.Map:
                    return BaseEnumServiceRes.FilePurposeEnumMap;
                case FilePurposeEnum.Analysis:
                    return BaseEnumServiceRes.FilePurposeEnumAnalysis;
                case FilePurposeEnum.OpenData:
                    return BaseEnumServiceRes.FilePurposeEnumOpenData;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_FileStatusEnum(FileStatusEnum? fileStatusE)
        {
            if (fileStatusE == null)
                return BaseEnumServiceRes.Empty;

            switch (fileStatusE)
            {
                case FileStatusEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case FileStatusEnum.Changed:
                    return BaseEnumServiceRes.FileStatusEnumChanged;
                case FileStatusEnum.Sent:
                    return BaseEnumServiceRes.FileStatusEnumSent;
                case FileStatusEnum.Accepted:
                    return BaseEnumServiceRes.FileStatusEnumAccepted;
                case FileStatusEnum.Rejected:
                    return BaseEnumServiceRes.FileStatusEnumRejected;
                case FileStatusEnum.Fail:
                    return BaseEnumServiceRes.FileStatusEnumFail;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_FileTypeEnum(FileTypeEnum? fileTypeE)
        {
            if (fileTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (fileTypeE)
            {
                case FileTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case FileTypeEnum.DFS0:
                    return BaseEnumServiceRes.FileTypeEnumDFS0;
                case FileTypeEnum.DFS1:
                    return BaseEnumServiceRes.FileTypeEnumDFS1;
                case FileTypeEnum.DFSU:
                    return BaseEnumServiceRes.FileTypeEnumDFSU;
                case FileTypeEnum.KMZ:
                    return BaseEnumServiceRes.FileTypeEnumKMZ;
                case FileTypeEnum.LOG:
                    return BaseEnumServiceRes.FileTypeEnumLOG;
                case FileTypeEnum.M21FM:
                    return BaseEnumServiceRes.FileTypeEnumM21FM;
                case FileTypeEnum.M3FM:
                    return BaseEnumServiceRes.FileTypeEnumM3FM;
                case FileTypeEnum.MDF:
                    return BaseEnumServiceRes.FileTypeEnumMDF;
                case FileTypeEnum.MESH:
                    return BaseEnumServiceRes.FileTypeEnumMESH;
                case FileTypeEnum.XLSX:
                    return BaseEnumServiceRes.FileTypeEnumXLSX;
                case FileTypeEnum.DOCX:
                    return BaseEnumServiceRes.FileTypeEnumDOCX;
                case FileTypeEnum.PDF:
                    return BaseEnumServiceRes.FileTypeEnumPDF;
                case FileTypeEnum.JPG:
                    return BaseEnumServiceRes.FileTypeEnumJPG;
                case FileTypeEnum.JPEG:
                    return BaseEnumServiceRes.FileTypeEnumJPEG;
                case FileTypeEnum.GIF:
                    return BaseEnumServiceRes.FileTypeEnumGIF;
                case FileTypeEnum.PNG:
                    return BaseEnumServiceRes.FileTypeEnumPNG;
                case FileTypeEnum.HTML:
                    return BaseEnumServiceRes.FileTypeEnumHTML;
                case FileTypeEnum.TXT:
                    return BaseEnumServiceRes.FileTypeEnumTXT;
                case FileTypeEnum.XYZ:
                    return BaseEnumServiceRes.FileTypeEnumXYZ;
                case FileTypeEnum.KML:
                    return BaseEnumServiceRes.FileTypeEnumKML;
                case FileTypeEnum.CSV:
                    return BaseEnumServiceRes.FileTypeEnumCSV;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_InfrastructureTypeEnum(InfrastructureTypeEnum? infrastructureTypeE)
        {
            if (infrastructureTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (infrastructureTypeE)
            {
                case InfrastructureTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case InfrastructureTypeEnum.WWTP:
                    return BaseEnumServiceRes.InfrastructureTypeEnumWWTP;
                case InfrastructureTypeEnum.LiftStation:
                    return BaseEnumServiceRes.InfrastructureTypeEnumLiftStation;
                case InfrastructureTypeEnum.Other:
                    return BaseEnumServiceRes.InfrastructureTypeEnumOther;
                case InfrastructureTypeEnum.SeeOtherMunicipality:
                    return BaseEnumServiceRes.InfrastructureTypeEnumSeeOtherMunicipality;
                case InfrastructureTypeEnum.LineOverflow:
                    return BaseEnumServiceRes.InfrastructureTypeEnumLineOverflow;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_KMZActionEnum(KMZActionEnum? kMZActionE)
        {
            if (kMZActionE == null)
                return BaseEnumServiceRes.Empty;

            switch (kMZActionE)
            {
                case KMZActionEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case KMZActionEnum.DoNothing:
                    return BaseEnumServiceRes.KMZActionEnumDoNothing;
                case KMZActionEnum.GenerateKMZContourAnimation:
                    return BaseEnumServiceRes.KMZActionEnumGenerateKMZContourAnimation;
                case KMZActionEnum.GenerateKMZContourLimit:
                    return BaseEnumServiceRes.KMZActionEnumGenerateKMZContourLimit;
                case KMZActionEnum.GenerateKMZCurrentAnimation:
                    return BaseEnumServiceRes.KMZActionEnumGenerateKMZCurrentAnimation;
                case KMZActionEnum.GenerateKMZCurrentMaximum:
                    return BaseEnumServiceRes.KMZActionEnumGenerateKMZCurrentMaximum;
                case KMZActionEnum.GenerateKMZMesh:
                    return BaseEnumServiceRes.KMZActionEnumGenerateKMZMesh;
                case KMZActionEnum.GenerateKMZStudyArea:
                    return BaseEnumServiceRes.KMZActionEnumGenerateKMZStudyArea;
                case KMZActionEnum.GenerateKMZBoundaryConditionNodes:
                    return BaseEnumServiceRes.KMZActionEnumGenerateKMZBoundaryConditionNodes;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_LaboratoryEnum(LaboratoryEnum? laboratoryE)
        {
            if (laboratoryE == null)
                return BaseEnumServiceRes.Empty;

            switch (laboratoryE)
            {
                case LaboratoryEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case LaboratoryEnum.ZZ_0:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_0;
                case LaboratoryEnum.ZZ_1:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_1;
                case LaboratoryEnum.ZZ_2:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_2;
                case LaboratoryEnum.ZZ_3:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_3;
                case LaboratoryEnum.ZZ_4:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_4;
                case LaboratoryEnum.ZZ_1Q:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_1Q;
                case LaboratoryEnum.ZZ_2Q:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_2Q;
                case LaboratoryEnum.ZZ_3Q:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_3Q;
                case LaboratoryEnum.ZZ_4Q:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_4Q;
                case LaboratoryEnum.ZZ_5Q:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_5Q;
                case LaboratoryEnum.ZZ_11BC:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_11BC;
                case LaboratoryEnum.ZZ_12BC:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_12BC;
                case LaboratoryEnum.ZZ_13BC:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_13BC;
                case LaboratoryEnum.ZZ_14BC:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_14BC;
                case LaboratoryEnum.ZZ_15BC:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_15BC;
                case LaboratoryEnum.ZZ_16BC:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_16BC;
                case LaboratoryEnum.ZZ_17BC:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_17BC;
                case LaboratoryEnum.ZZ_18BC:
                    return BaseEnumServiceRes.LaboratoryEnumZZ_18BC;
                case LaboratoryEnum.MonctonEnvironmentCanada:
                    return BaseEnumServiceRes.LaboratoryEnumMonctonEnvironmentCanada;
                case LaboratoryEnum.BIOEnvironmentCanada:
                    return BaseEnumServiceRes.LaboratoryEnumBIOEnvironmentCanada;
                case LaboratoryEnum.EasternCharlotteWaterwayLaboratory:
                    return BaseEnumServiceRes.LaboratoryEnumEasternCharlotteWaterwayLaboratory;
                case LaboratoryEnum.InstitutDeRechercheSurLesZonesCotieres:
                    return BaseEnumServiceRes.LaboratoryEnumInstitutDeRechercheSurLesZonesCotieres;
                case LaboratoryEnum.CentreDeRechercheSurLesAliments:
                    return BaseEnumServiceRes.LaboratoryEnumCentreDeRechercheSurLesAliments;
                case LaboratoryEnum.CaraquetMobileLaboratoryEnvironmentCanada:
                    return BaseEnumServiceRes.LaboratoryEnumCaraquetMobileLaboratoryEnvironmentCanada;
                case LaboratoryEnum.MaxxamAnalyticsBedford:
                    return BaseEnumServiceRes.LaboratoryEnumMaxxamAnalyticsBedford;
                case LaboratoryEnum.MaxxamAnalyticsSydney:
                    return BaseEnumServiceRes.LaboratoryEnumMaxxamAnalyticsSydney;
                case LaboratoryEnum.PEIAnalyticalLaboratory:
                    return BaseEnumServiceRes.LaboratoryEnumPEIAnalyticalLaboratory;
                case LaboratoryEnum.NLMobileLaboratory:
                    return BaseEnumServiceRes.LaboratoryEnumNLMobileLaboratory;
                case LaboratoryEnum.AvalonLaboratoriesInc:
                    return BaseEnumServiceRes.LaboratoryEnumAvalonLaboratoriesInc;
                case LaboratoryEnum.Maxxam:
                    return BaseEnumServiceRes.LaboratoryEnumMaxxam;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_LabSheetStatusEnum(LabSheetStatusEnum? labSheetStatusE)
        {
            if (labSheetStatusE == null)
                return BaseEnumServiceRes.Empty;

            switch (labSheetStatusE)
            {
                case LabSheetStatusEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case LabSheetStatusEnum.Created:
                    return BaseEnumServiceRes.LabSheetStatusEnumCreated;
                case LabSheetStatusEnum.Transferred:
                    return BaseEnumServiceRes.LabSheetStatusEnumTransferred;
                case LabSheetStatusEnum.Accepted:
                    return BaseEnumServiceRes.LabSheetStatusEnumAccepted;
                case LabSheetStatusEnum.Rejected:
                    return BaseEnumServiceRes.LabSheetStatusEnumRejected;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_LabSheetTypeEnum(LabSheetTypeEnum? labSheetTypeE)
        {
            if (labSheetTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (labSheetTypeE)
            {
                case LabSheetTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case LabSheetTypeEnum.A1:
                    return BaseEnumServiceRes.LabSheetTypeEnumA1;
                case LabSheetTypeEnum.LTB:
                    return BaseEnumServiceRes.LabSheetTypeEnumLTB;
                case LabSheetTypeEnum.EC:
                    return BaseEnumServiceRes.LabSheetTypeEnumEC;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_LanguageEnum(LanguageEnum? languageE)
        {
            if (languageE == null)
                return BaseEnumServiceRes.Empty;

            switch (languageE)
            {
                case LanguageEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case LanguageEnum.en:
                    return BaseEnumServiceRes.LanguageEnumen;
                case LanguageEnum.fr:
                    return BaseEnumServiceRes.LanguageEnumfr;
                case LanguageEnum.enAndfr:
                    return BaseEnumServiceRes.LanguageEnumenAndfr;
                case LanguageEnum.es:
                    return BaseEnumServiceRes.LanguageEnumes;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_LogCommandEnum(LogCommandEnum? logCommandE)
        {
            if (logCommandE == null)
                return BaseEnumServiceRes.Empty;

            switch (logCommandE)
            {
                case LogCommandEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case LogCommandEnum.Add:
                    return BaseEnumServiceRes.LogCommandEnumAdd;
                case LogCommandEnum.Change:
                    return BaseEnumServiceRes.LogCommandEnumChange;
                case LogCommandEnum.Delete:
                    return BaseEnumServiceRes.LogCommandEnumDelete;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_MapInfoDrawTypeEnum(MapInfoDrawTypeEnum? mapInfoDrawTypeE)
        {
            if (mapInfoDrawTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (mapInfoDrawTypeE)
            {
                case MapInfoDrawTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case MapInfoDrawTypeEnum.Point:
                    return BaseEnumServiceRes.MapInfoDrawTypeEnumPoint;
                case MapInfoDrawTypeEnum.Polyline:
                    return BaseEnumServiceRes.MapInfoDrawTypeEnumPolyline;
                case MapInfoDrawTypeEnum.Polygon:
                    return BaseEnumServiceRes.MapInfoDrawTypeEnumPolygon;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum(MikeBoundaryConditionLevelOrVelocityEnum? mikeBoundaryConditionLevelOrVelocityE)
        {
            if (mikeBoundaryConditionLevelOrVelocityE == null)
                return BaseEnumServiceRes.Empty;

            switch (mikeBoundaryConditionLevelOrVelocityE)
            {
                case MikeBoundaryConditionLevelOrVelocityEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case MikeBoundaryConditionLevelOrVelocityEnum.Level:
                    return BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocityEnumLevel;
                case MikeBoundaryConditionLevelOrVelocityEnum.Velocity:
                    return BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocityEnumVelocity;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_MikeScenarioSpecialResultKMLTypeEnum(MikeScenarioSpecialResultKMLTypeEnum? mikeScenarioSpecialResultKMLTypeE)
        {
            if (mikeScenarioSpecialResultKMLTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (mikeScenarioSpecialResultKMLTypeE)
            {
                case MikeScenarioSpecialResultKMLTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case MikeScenarioSpecialResultKMLTypeEnum.Mesh:
                    return BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumMesh;
                case MikeScenarioSpecialResultKMLTypeEnum.StudyArea:
                    return BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumStudyArea;
                case MikeScenarioSpecialResultKMLTypeEnum.BoundaryConditions:
                    return BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumBoundaryConditions;
                case MikeScenarioSpecialResultKMLTypeEnum.PollutionLimit:
                    return BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumPollutionLimit;
                case MikeScenarioSpecialResultKMLTypeEnum.PollutionAnimation:
                    return BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumPollutionAnimation;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_MWQMSiteLatestClassificationEnum(MWQMSiteLatestClassificationEnum? mWQMSiteLatestClassificationE)
        {
            if (mWQMSiteLatestClassificationE == null)
                return BaseEnumServiceRes.Empty;

            switch (mWQMSiteLatestClassificationE)
            {
                case MWQMSiteLatestClassificationEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case MWQMSiteLatestClassificationEnum.Approved:
                    return BaseEnumServiceRes.MWQMSiteLatestClassificationEnumApproved;
                case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
                    return BaseEnumServiceRes.MWQMSiteLatestClassificationEnumConditionallyApproved;
                case MWQMSiteLatestClassificationEnum.Restricted:
                    return BaseEnumServiceRes.MWQMSiteLatestClassificationEnumRestricted;
                case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
                    return BaseEnumServiceRes.MWQMSiteLatestClassificationEnumConditionallyRestricted;
                case MWQMSiteLatestClassificationEnum.Prohibited:
                    return BaseEnumServiceRes.MWQMSiteLatestClassificationEnumProhibited;
                case MWQMSiteLatestClassificationEnum.Unclassified:
                    return BaseEnumServiceRes.MWQMSiteLatestClassificationEnumUnclassified;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_PolSourceInactiveReasonEnum(PolSourceInactiveReasonEnum? polSourceInactiveReasonE)
        {
            if (polSourceInactiveReasonE == null)
                return BaseEnumServiceRes.Empty;

            switch (polSourceInactiveReasonE)
            {
                case PolSourceInactiveReasonEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case PolSourceInactiveReasonEnum.Abandoned:
                    return BaseEnumServiceRes.PolSourceInactiveReasonEnumAbandoned;
                case PolSourceInactiveReasonEnum.Closed:
                    return BaseEnumServiceRes.PolSourceInactiveReasonEnumClosed;
                case PolSourceInactiveReasonEnum.Removed:
                    return BaseEnumServiceRes.PolSourceInactiveReasonEnumRemoved;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_PolSourceIssueRiskEnum(PolSourceIssueRiskEnum? polSourceIssueRiskE)
        {
            if (polSourceIssueRiskE == null)
                return BaseEnumServiceRes.Empty;

            switch (polSourceIssueRiskE)
            {
                case PolSourceIssueRiskEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case PolSourceIssueRiskEnum.LowRisk:
                    return BaseEnumServiceRes.PolSourceIssueRiskEnumLowRisk;
                case PolSourceIssueRiskEnum.ModerateRisk:
                    return BaseEnumServiceRes.PolSourceIssueRiskEnumModerateRisk;
                case PolSourceIssueRiskEnum.HighRisk:
                    return BaseEnumServiceRes.PolSourceIssueRiskEnumHighRisk;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_PositionEnum(PositionEnum? positionE)
        {
            if (positionE == null)
                return BaseEnumServiceRes.Empty;

            switch (positionE)
            {
                case PositionEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case PositionEnum.LeftBottom:
                    return BaseEnumServiceRes.PositionEnumLeftBottom;
                case PositionEnum.RightBottom:
                    return BaseEnumServiceRes.PositionEnumRightBottom;
                case PositionEnum.LeftTop:
                    return BaseEnumServiceRes.PositionEnumLeftTop;
                case PositionEnum.RightTop:
                    return BaseEnumServiceRes.PositionEnumRightTop;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_PreliminaryTreatmentTypeEnum(PreliminaryTreatmentTypeEnum? preliminaryTreatmentTypeE)
        {
            if (preliminaryTreatmentTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (preliminaryTreatmentTypeE)
            {
                case PreliminaryTreatmentTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case PreliminaryTreatmentTypeEnum.NotApplicable:
                    return BaseEnumServiceRes.PreliminaryTreatmentTypeEnumNotApplicable;
                case PreliminaryTreatmentTypeEnum.BarScreen:
                    return BaseEnumServiceRes.PreliminaryTreatmentTypeEnumBarScreen;
                case PreliminaryTreatmentTypeEnum.Grinder:
                    return BaseEnumServiceRes.PreliminaryTreatmentTypeEnumGrinder;
                case PreliminaryTreatmentTypeEnum.MechanicalScreening:
                    return BaseEnumServiceRes.PreliminaryTreatmentTypeEnumMechanicalScreening;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_PrimaryTreatmentTypeEnum(PrimaryTreatmentTypeEnum? primaryTreatmentTypeE)
        {
            if (primaryTreatmentTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (primaryTreatmentTypeE)
            {
                case PrimaryTreatmentTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case PrimaryTreatmentTypeEnum.NotApplicable:
                    return BaseEnumServiceRes.PrimaryTreatmentTypeEnumNotApplicable;
                case PrimaryTreatmentTypeEnum.Sedimentation:
                    return BaseEnumServiceRes.PrimaryTreatmentTypeEnumSedimentation;
                case PrimaryTreatmentTypeEnum.ChemicalCoagulation:
                    return BaseEnumServiceRes.PrimaryTreatmentTypeEnumChemicalCoagulation;
                case PrimaryTreatmentTypeEnum.Filtration:
                    return BaseEnumServiceRes.PrimaryTreatmentTypeEnumFiltration;
                case PrimaryTreatmentTypeEnum.PrimaryClarification:
                    return BaseEnumServiceRes.PrimaryTreatmentTypeEnumPrimaryClarification;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportConditionEnum(ReportConditionEnum? reportConditionE)
        {
            if (reportConditionE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportConditionE)
            {
                case ReportConditionEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportConditionEnum.ReportConditionTrue:
                    return BaseEnumServiceRes.ReportConditionEnumReportConditionTrue;
                case ReportConditionEnum.ReportConditionFalse:
                    return BaseEnumServiceRes.ReportConditionEnumReportConditionFalse;
                case ReportConditionEnum.ReportConditionContain:
                    return BaseEnumServiceRes.ReportConditionEnumReportConditionContain;
                case ReportConditionEnum.ReportConditionStart:
                    return BaseEnumServiceRes.ReportConditionEnumReportConditionStart;
                case ReportConditionEnum.ReportConditionEnd:
                    return BaseEnumServiceRes.ReportConditionEnumReportConditionEnd;
                case ReportConditionEnum.ReportConditionBigger:
                    return BaseEnumServiceRes.ReportConditionEnumReportConditionBigger;
                case ReportConditionEnum.ReportConditionSmaller:
                    return BaseEnumServiceRes.ReportConditionEnumReportConditionSmaller;
                case ReportConditionEnum.ReportConditionEqual:
                    return BaseEnumServiceRes.ReportConditionEnumReportConditionEqual;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportFieldTypeEnum(ReportFieldTypeEnum? reportFieldTypeE)
        {
            if (reportFieldTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportFieldTypeE)
            {
                case ReportFieldTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportFieldTypeEnum.NumberWhole:
                    return BaseEnumServiceRes.ReportFieldTypeEnumNumberWhole;
                case ReportFieldTypeEnum.NumberWithDecimal:
                    return BaseEnumServiceRes.ReportFieldTypeEnumNumberWithDecimal;
                case ReportFieldTypeEnum.DateAndTime:
                    return BaseEnumServiceRes.ReportFieldTypeEnumDateAndTime;
                case ReportFieldTypeEnum.Text:
                    return BaseEnumServiceRes.ReportFieldTypeEnumText;
                case ReportFieldTypeEnum.TrueOrFalse:
                    return BaseEnumServiceRes.ReportFieldTypeEnumTrueOrFalse;
                case ReportFieldTypeEnum.FilePurpose:
                    return BaseEnumServiceRes.ReportFieldTypeEnumFilePurpose;
                case ReportFieldTypeEnum.FileType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumFileType;
                case ReportFieldTypeEnum.TranslationStatus:
                    return BaseEnumServiceRes.ReportFieldTypeEnumTranslationStatus;
                case ReportFieldTypeEnum.BoxModelResultType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumBoxModelResultType;
                case ReportFieldTypeEnum.InfrastructureType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumInfrastructureType;
                case ReportFieldTypeEnum.FacilityType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumFacilityType;
                case ReportFieldTypeEnum.AerationType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumAerationType;
                case ReportFieldTypeEnum.PreliminaryTreatmentType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumPreliminaryTreatmentType;
                case ReportFieldTypeEnum.PrimaryTreatmentType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumPrimaryTreatmentType;
                case ReportFieldTypeEnum.SecondaryTreatmentType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumSecondaryTreatmentType;
                case ReportFieldTypeEnum.TertiaryTreatmentType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumTertiaryTreatmentType;
                case ReportFieldTypeEnum.TreatmentType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumTreatmentType;
                case ReportFieldTypeEnum.DisinfectionType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumDisinfectionType;
                case ReportFieldTypeEnum.CollectionSystemType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumCollectionSystemType;
                case ReportFieldTypeEnum.AlarmSystemType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumAlarmSystemType;
                case ReportFieldTypeEnum.ScenarioStatus:
                    return BaseEnumServiceRes.ReportFieldTypeEnumScenarioStatus;
                case ReportFieldTypeEnum.StorageDataType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumStorageDataType;
                case ReportFieldTypeEnum.Language:
                    return BaseEnumServiceRes.ReportFieldTypeEnumLanguage;
                case ReportFieldTypeEnum.SampleType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumSampleType;
                case ReportFieldTypeEnum.BeaufortScale:
                    return BaseEnumServiceRes.ReportFieldTypeEnumBeaufortScale;
                case ReportFieldTypeEnum.AnalyzeMethod:
                    return BaseEnumServiceRes.ReportFieldTypeEnumAnalyzeMethod;
                case ReportFieldTypeEnum.SampleMatrix:
                    return BaseEnumServiceRes.ReportFieldTypeEnumSampleMatrix;
                case ReportFieldTypeEnum.Laboratory:
                    return BaseEnumServiceRes.ReportFieldTypeEnumLaboratory;
                case ReportFieldTypeEnum.SampleStatus:
                    return BaseEnumServiceRes.ReportFieldTypeEnumSampleStatus;
                case ReportFieldTypeEnum.SamplingPlanType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumSamplingPlanType;
                case ReportFieldTypeEnum.LabSheetSampleType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumLabSheetSampleType;
                case ReportFieldTypeEnum.LabSheetType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumLabSheetType;
                case ReportFieldTypeEnum.LabSheetStatus:
                    return BaseEnumServiceRes.ReportFieldTypeEnumLabSheetStatus;
                case ReportFieldTypeEnum.PolSourceInactiveReason:
                    return BaseEnumServiceRes.ReportFieldTypeEnumPolSourceInactiveReason;
                case ReportFieldTypeEnum.PolSourceObsInfo:
                    return BaseEnumServiceRes.ReportFieldTypeEnumPolSourceObsInfo;
                case ReportFieldTypeEnum.AddressType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumAddressType;
                case ReportFieldTypeEnum.StreetType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumStreetType;
                case ReportFieldTypeEnum.ContactTitle:
                    return BaseEnumServiceRes.ReportFieldTypeEnumContactTitle;
                case ReportFieldTypeEnum.EmailType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumEmailType;
                case ReportFieldTypeEnum.TelType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumTelType;
                case ReportFieldTypeEnum.TideText:
                    return BaseEnumServiceRes.ReportFieldTypeEnumTideText;
                case ReportFieldTypeEnum.TideDataType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumTideDataType;
                case ReportFieldTypeEnum.SpecialTableType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumSpecialTableType;
                case ReportFieldTypeEnum.MWQMSiteLatestClassification:
                    return BaseEnumServiceRes.ReportFieldTypeEnumMWQMSiteLatestClassification;
                case ReportFieldTypeEnum.PolSourceIssueRisk:
                    return BaseEnumServiceRes.ReportFieldTypeEnumPolSourceIssueRisk;
                case ReportFieldTypeEnum.MikeScenarioSpecialResultKMLType:
                    return BaseEnumServiceRes.ReportFieldTypeEnumMikeScenarioSpecialResultKMLType;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportFileTypeEnum(ReportFileTypeEnum? reportFileTypeE)
        {
            if (reportFileTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportFileTypeE)
            {
                case ReportFileTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportFileTypeEnum.CSV:
                    return BaseEnumServiceRes.ReportFileTypeEnumCSV;
                case ReportFileTypeEnum.Word:
                    return BaseEnumServiceRes.ReportFileTypeEnumWord;
                case ReportFileTypeEnum.Excel:
                    return BaseEnumServiceRes.ReportFileTypeEnumExcel;
                case ReportFileTypeEnum.KML:
                    return BaseEnumServiceRes.ReportFileTypeEnumKML;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportFormatingDateEnum(ReportFormatingDateEnum? reportFormatingDateE)
        {
            if (reportFormatingDateE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportFormatingDateE)
            {
                case ReportFormatingDateEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportFormatingDateEnum.ReportFormatingDateYearOnly:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearOnly;
                case ReportFormatingDateEnum.ReportFormatingDateMonthDecimalOnly:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthDecimalOnly;
                case ReportFormatingDateEnum.ReportFormatingDateMonthShortTextOnly:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthShortTextOnly;
                case ReportFormatingDateEnum.ReportFormatingDateMonthFullTextOnly:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthFullTextOnly;
                case ReportFormatingDateEnum.ReportFormatingDateDayOnly:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateDayOnly;
                case ReportFormatingDateEnum.ReportFormatingDateHourOnly:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateHourOnly;
                case ReportFormatingDateEnum.ReportFormatingDateMinuteOnly:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMinuteOnly;
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthDecimalDay:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthDecimalDay;
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthShortTextDay:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthShortTextDay;
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthFullTextDay:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthFullTextDay;
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthDecimalDayHourMinute:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthDecimalDayHourMinute;
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthShortTextDayHourMinute:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthShortTextDayHourMinute;
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthFullTextDayHourMinute:
                    return BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthFullTextDayHourMinute;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportFormatingNumberEnum(ReportFormatingNumberEnum? reportFormatingNumberE)
        {
            if (reportFormatingNumberE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportFormatingNumberE)
            {
                case ReportFormatingNumberEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportFormatingNumberEnum.ReportFormatingNumber0Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber0Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumber1Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber1Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumber2Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber2Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumber3Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber3Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumber4Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber4Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumber5Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber5Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumber6Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber6Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific0Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific0Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific1Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific1Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific2Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific2Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific3Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific3Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific4Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific4Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific5Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific5Decimal;
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific6Decimal:
                    return BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific6Decimal;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportGenerateObjectsKeywordEnum(ReportGenerateObjectsKeywordEnum? reportGenerateObjectsKeywordE)
        {
            if (reportGenerateObjectsKeywordE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportGenerateObjectsKeywordE)
            {
                case ReportGenerateObjectsKeywordEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_RE_EVALUATION_COVER_PAGE:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_RE_EVALUATION_COVER_PAGE;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_ALL:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_ALL;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_WET:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_WET;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_DRY:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_DRY;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_DATA_AVAILABILITY:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_DATA_AVAILABILITY;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_SITES_BY_YEAR:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_SITES_BY_YEAR;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_RUNS_BY_YEAR:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_RUNS_BY_YEAR;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_SAMPLES_BY_YEAR:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_SAMPLES_BY_YEAR;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_FC_TABLE:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_FC_TABLE;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_SALINITY_TABLE:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_SALINITY_TABLE;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_TEMPERATURE_TABLE:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_TEMPERATURE_TABLE;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_SITES:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_SITES;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_SITES_COMPACT:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_SITES_COMPACT;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITIES:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITIES;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_MAP:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_MAP;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_CONTACTS:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_CONTACTS;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_DETAIL:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_DETAIL;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_ECCC_AND_SWCP_LOGO:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_ECCC_AND_SWCP_LOGO;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_CSSP_LOGO:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_CSSP_LOGO;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_LOCATION_OF_SURVEY_AREA_MAP:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_LOCATION_OF_SURVEY_AREA_MAP;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_CURRENT_CLASSIFICATION_AND_SAMPLING_LOCATION_MAP:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_CURRENT_CLASSIFICATION_AND_SAMPLING_LOCATION_MAP;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_RECOMMENDED_CLASSIFICATION_MAP:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_RECOMMENDED_CLASSIFICATION_MAP;
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_LOCATIONS_MAP:
                    return BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_LOCATIONS_MAP;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportSortingEnum(ReportSortingEnum? reportSortingE)
        {
            if (reportSortingE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportSortingE)
            {
                case ReportSortingEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportSortingEnum.ReportSortingAscending:
                    return BaseEnumServiceRes.ReportSortingEnumReportSortingAscending;
                case ReportSortingEnum.ReportSortingDescending:
                    return BaseEnumServiceRes.ReportSortingEnumReportSortingDescending;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportTreeNodeSubTypeEnum(ReportTreeNodeSubTypeEnum? reportTreeNodeSubTypeE)
        {
            if (reportTreeNodeSubTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportTreeNodeSubTypeE)
            {
                case ReportTreeNodeSubTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportTreeNodeSubTypeEnum.TableSelectable:
                    return BaseEnumServiceRes.ReportTreeNodeSubTypeEnumTableSelectable;
                case ReportTreeNodeSubTypeEnum.Field:
                    return BaseEnumServiceRes.ReportTreeNodeSubTypeEnumField;
                case ReportTreeNodeSubTypeEnum.FieldsHolder:
                    return BaseEnumServiceRes.ReportTreeNodeSubTypeEnumFieldsHolder;
                case ReportTreeNodeSubTypeEnum.TableNotSelectable:
                    return BaseEnumServiceRes.ReportTreeNodeSubTypeEnumTableNotSelectable;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ReportTreeNodeTypeEnum(ReportTreeNodeTypeEnum? reportTreeNodeTypeE)
        {
            if (reportTreeNodeTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (reportTreeNodeTypeE)
            {
                case ReportTreeNodeTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ReportTreeNodeTypeEnum.ReportRootType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportRootType;
                case ReportTreeNodeTypeEnum.ReportCountryType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportCountryType;
                case ReportTreeNodeTypeEnum.ReportProvinceType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportProvinceType;
                case ReportTreeNodeTypeEnum.ReportAreaType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportAreaType;
                case ReportTreeNodeTypeEnum.ReportSectorType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSectorType;
                case ReportTreeNodeTypeEnum.ReportSubsectorType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorType;
                case ReportTreeNodeTypeEnum.ReportMWQMSiteType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteType;
                case ReportTreeNodeTypeEnum.ReportMWQMRunType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunType;
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteType;
                case ReportTreeNodeTypeEnum.ReportMunicipalityType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityType;
                case ReportTreeNodeTypeEnum.ReportRootFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportRootFileType;
                case ReportTreeNodeTypeEnum.ReportInfrastructureType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureType;
                case ReportTreeNodeTypeEnum.ReportBoxModelType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportBoxModelType;
                case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioType;
                case ReportTreeNodeTypeEnum.ReportMikeScenarioType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioType;
                case ReportTreeNodeTypeEnum.ReportMikeSourceType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeSourceType;
                case ReportTreeNodeTypeEnum.ReportMWQMSiteSampleType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteSampleType;
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteObsType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteObsType;
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteObsIssueType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteObsIssueType;
                case ReportTreeNodeTypeEnum.ReportMikeScenarioGeneralParameterType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioGeneralParameterType;
                case ReportTreeNodeTypeEnum.ReportMunicipalityContactType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactType;
                case ReportTreeNodeTypeEnum.ReportConditionType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportConditionType;
                case ReportTreeNodeTypeEnum.ReportStatisticType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportStatisticType;
                case ReportTreeNodeTypeEnum.ReportFieldsType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFieldsType;
                case ReportTreeNodeTypeEnum.ReportFieldType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFieldType;
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteAddressType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteAddressType;
                case ReportTreeNodeTypeEnum.ReportMunicipalityContactTelType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactTelType;
                case ReportTreeNodeTypeEnum.ReportMunicipalityContactEmailType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactEmailType;
                case ReportTreeNodeTypeEnum.ReportBoxModelResultType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportBoxModelResultType;
                case ReportTreeNodeTypeEnum.ReportClimateSiteType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportClimateSiteType;
                case ReportTreeNodeTypeEnum.ReportClimateSiteDataType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportClimateSiteDataType;
                case ReportTreeNodeTypeEnum.ReportHydrometricSiteType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteType;
                case ReportTreeNodeTypeEnum.ReportHydrometricSiteDataType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteDataType;
                case ReportTreeNodeTypeEnum.ReportHydrometricSiteRatingCurveType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteRatingCurveType;
                case ReportTreeNodeTypeEnum.ReportHydrometricSiteRatingCurveValueType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteRatingCurveValueType;
                case ReportTreeNodeTypeEnum.ReportInfrastructureAddressType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureAddressType;
                case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetType;
                case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetDetailType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetDetailType;
                case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetTubeMPNDetailType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetTubeMPNDetailType;
                case ReportTreeNodeTypeEnum.ReportMWQMRunSampleType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunSampleType;
                case ReportTreeNodeTypeEnum.ReportCountryFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportCountryFileType;
                case ReportTreeNodeTypeEnum.ReportProvinceFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportProvinceFileType;
                case ReportTreeNodeTypeEnum.ReportAreaFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportAreaFileType;
                case ReportTreeNodeTypeEnum.ReportSectorFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSectorFileType;
                case ReportTreeNodeTypeEnum.ReportSubsectorFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorFileType;
                case ReportTreeNodeTypeEnum.ReportMWQMSiteFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteFileType;
                case ReportTreeNodeTypeEnum.ReportMWQMRunFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunFileType;
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteFileType;
                case ReportTreeNodeTypeEnum.ReportMunicipalityFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityFileType;
                case ReportTreeNodeTypeEnum.ReportInfrastructureFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureFileType;
                case ReportTreeNodeTypeEnum.ReportMikeScenarioFileType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioFileType;
                case ReportTreeNodeTypeEnum.ReportMikeSourceStartEndType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeSourceStartEndType;
                case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetType;
                case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetDetailType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetDetailType;
                case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetTubeMPNDetailType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetTubeMPNDetailType;
                case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetType;
                case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetDetailType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetDetailType;
                case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetTubeMPNDetailType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetTubeMPNDetailType;
                case ReportTreeNodeTypeEnum.ReportSamplingPlanType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanType;
                case ReportTreeNodeTypeEnum.ReportSamplingPlanSubsectorType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanSubsectorType;
                case ReportTreeNodeTypeEnum.ReportSamplingPlanSubsectorSiteType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanSubsectorSiteType;
                case ReportTreeNodeTypeEnum.ReportMikeBoundaryConditionType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeBoundaryConditionType;
                case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioAmbientType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioAmbientType;
                case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioResultType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioResultType;
                case ReportTreeNodeTypeEnum.ReportMPNLookupType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMPNLookupType;
                case ReportTreeNodeTypeEnum.ReportMWQMSiteStartAndEndType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteStartAndEndType;
                case ReportTreeNodeTypeEnum.ReportSubsectorTideSiteType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorTideSiteType;
                case ReportTreeNodeTypeEnum.ReportSubsectorTideSiteDataType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorTideSiteDataType;
                case ReportTreeNodeTypeEnum.ReportOrderType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportOrderType;
                case ReportTreeNodeTypeEnum.ReportFormatType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFormatType;
                case ReportTreeNodeTypeEnum.ReportMunicipalityContactAddressType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactAddressType;
                case ReportTreeNodeTypeEnum.ReportSubsectorClimateSiteType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorClimateSiteType;
                case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteType;
                case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteDataType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteDataType;
                case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteRatingCurveType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteRatingCurveType;
                case ReportTreeNodeTypeEnum.ReportSubsectorClimateSiteDataType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorClimateSiteDataType;
                case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteRatingCurveValueType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteRatingCurveValueType;
                case ReportTreeNodeTypeEnum.ReportSubsectorSpecialTableType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorSpecialTableType;
                case ReportTreeNodeTypeEnum.ReportMikeScenarioSpecialResultKMLType:
                    return BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioSpecialResultKMLType;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_SameDayNextDayEnum(SameDayNextDayEnum? sameDayNextDayE)
        {
            if (sameDayNextDayE == null)
                return BaseEnumServiceRes.Empty;

            switch (sameDayNextDayE)
            {
                case SameDayNextDayEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case SameDayNextDayEnum.SameDay:
                    return BaseEnumServiceRes.SameDayNextDayEnumSameDay;
                case SameDayNextDayEnum.NextDay:
                    return BaseEnumServiceRes.SameDayNextDayEnumNextDay;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_SampleMatrixEnum(SampleMatrixEnum? sampleMatrixE)
        {
            if (sampleMatrixE == null)
                return BaseEnumServiceRes.Empty;

            switch (sampleMatrixE)
            {
                case SampleMatrixEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case SampleMatrixEnum.W:
                    return BaseEnumServiceRes.SampleMatrixEnumW;
                case SampleMatrixEnum.S:
                    return BaseEnumServiceRes.SampleMatrixEnumS;
                case SampleMatrixEnum.B:
                    return BaseEnumServiceRes.SampleMatrixEnumB;
                case SampleMatrixEnum.MPNQ:
                    return BaseEnumServiceRes.SampleMatrixEnumMPNQ;
                case SampleMatrixEnum.SampleMatrix5:
                    return BaseEnumServiceRes.SampleMatrixEnumSampleMatrix5;
                case SampleMatrixEnum.SampleMatrix6:
                    return BaseEnumServiceRes.SampleMatrixEnumSampleMatrix6;
                case SampleMatrixEnum.Water:
                    return BaseEnumServiceRes.SampleMatrixEnumWater;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_SampleStatusEnum(SampleStatusEnum? sampleStatusE)
        {
            if (sampleStatusE == null)
                return BaseEnumServiceRes.Empty;

            switch (sampleStatusE)
            {
                case SampleStatusEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case SampleStatusEnum.Active:
                    return BaseEnumServiceRes.SampleStatusEnumActive;
                case SampleStatusEnum.Archived:
                    return BaseEnumServiceRes.SampleStatusEnumArchived;
                case SampleStatusEnum.SampleStatus3:
                    return BaseEnumServiceRes.SampleStatusEnumSampleStatus3;
                case SampleStatusEnum.SampleStatus4:
                    return BaseEnumServiceRes.SampleStatusEnumSampleStatus4;
                case SampleStatusEnum.SampleStatus5:
                    return BaseEnumServiceRes.SampleStatusEnumSampleStatus5;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_SampleTypeEnum(SampleTypeEnum? sampleTypeE)
        {
            if (sampleTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (sampleTypeE)
            {
                case SampleTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case SampleTypeEnum.DailyDuplicate:
                    return BaseEnumServiceRes.SampleTypeEnumDailyDuplicate;
                case SampleTypeEnum.Infrastructure:
                    return BaseEnumServiceRes.SampleTypeEnumInfrastructure;
                case SampleTypeEnum.IntertechDuplicate:
                    return BaseEnumServiceRes.SampleTypeEnumIntertechDuplicate;
                case SampleTypeEnum.IntertechRead:
                    return BaseEnumServiceRes.SampleTypeEnumIntertechRead;
                case SampleTypeEnum.RainCMP:
                    return BaseEnumServiceRes.SampleTypeEnumRainCMP;
                case SampleTypeEnum.RainRun:
                    return BaseEnumServiceRes.SampleTypeEnumRainRun;
                case SampleTypeEnum.ReopeningEmergencyRain:
                    return BaseEnumServiceRes.SampleTypeEnumReopeningEmergencyRain;
                case SampleTypeEnum.ReopeningSpill:
                    return BaseEnumServiceRes.SampleTypeEnumReopeningSpill;
                case SampleTypeEnum.Routine:
                    return BaseEnumServiceRes.SampleTypeEnumRoutine;
                case SampleTypeEnum.Sanitary:
                    return BaseEnumServiceRes.SampleTypeEnumSanitary;
                case SampleTypeEnum.Study:
                    return BaseEnumServiceRes.SampleTypeEnumStudy;
                case SampleTypeEnum.Sediment:
                    return BaseEnumServiceRes.SampleTypeEnumSediment;
                case SampleTypeEnum.Bivalve:
                    return BaseEnumServiceRes.SampleTypeEnumBivalve;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_SamplingPlanTypeEnum(SamplingPlanTypeEnum? samplingPlanTypeE)
        {
            if (samplingPlanTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (samplingPlanTypeE)
            {
                case SamplingPlanTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case SamplingPlanTypeEnum.Subsector:
                    return BaseEnumServiceRes.SamplingPlanTypeEnumSubsector;
                case SamplingPlanTypeEnum.Municipality:
                    return BaseEnumServiceRes.SamplingPlanTypeEnumMunicipality;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_ScenarioStatusEnum(ScenarioStatusEnum? scenarioStatusE)
        {
            if (scenarioStatusE == null)
                return BaseEnumServiceRes.Empty;

            switch (scenarioStatusE)
            {
                case ScenarioStatusEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case ScenarioStatusEnum.Normal:
                    return BaseEnumServiceRes.ScenarioStatusEnumNormal;
                case ScenarioStatusEnum.Copying:
                    return BaseEnumServiceRes.ScenarioStatusEnumCopying;
                case ScenarioStatusEnum.Copied:
                    return BaseEnumServiceRes.ScenarioStatusEnumCopied;
                case ScenarioStatusEnum.Changing:
                    return BaseEnumServiceRes.ScenarioStatusEnumChanging;
                case ScenarioStatusEnum.Changed:
                    return BaseEnumServiceRes.ScenarioStatusEnumChanged;
                case ScenarioStatusEnum.AskToRun:
                    return BaseEnumServiceRes.ScenarioStatusEnumAskToRun;
                case ScenarioStatusEnum.Running:
                    return BaseEnumServiceRes.ScenarioStatusEnumRunning;
                case ScenarioStatusEnum.Completed:
                    return BaseEnumServiceRes.ScenarioStatusEnumCompleted;
                case ScenarioStatusEnum.Cancelled:
                    return BaseEnumServiceRes.ScenarioStatusEnumCancelled;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_SearchTagEnum(SearchTagEnum? searchTagE)
        {
            if (searchTagE == null)
                return BaseEnumServiceRes.Empty;

            switch (searchTagE)
            {
                case SearchTagEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case SearchTagEnum.c:
                    return BaseEnumServiceRes.SearchTagEnumc;
                case SearchTagEnum.e:
                    return BaseEnumServiceRes.SearchTagEnume;
                case SearchTagEnum.t:
                    return BaseEnumServiceRes.SearchTagEnumt;
                case SearchTagEnum.fi:
                    return BaseEnumServiceRes.SearchTagEnumfi;
                case SearchTagEnum.fp:
                    return BaseEnumServiceRes.SearchTagEnumfp;
                case SearchTagEnum.frg:
                    return BaseEnumServiceRes.SearchTagEnumfrg;
                case SearchTagEnum.ftg:
                    return BaseEnumServiceRes.SearchTagEnumftg;
                case SearchTagEnum.fpdf:
                    return BaseEnumServiceRes.SearchTagEnumfpdf;
                case SearchTagEnum.fdocx:
                    return BaseEnumServiceRes.SearchTagEnumfdocx;
                case SearchTagEnum.fxlsx:
                    return BaseEnumServiceRes.SearchTagEnumfxlsx;
                case SearchTagEnum.fkmz:
                    return BaseEnumServiceRes.SearchTagEnumfkmz;
                case SearchTagEnum.fxyz:
                    return BaseEnumServiceRes.SearchTagEnumfxyz;
                case SearchTagEnum.fdfs:
                    return BaseEnumServiceRes.SearchTagEnumfdfs;
                case SearchTagEnum.fmike:
                    return BaseEnumServiceRes.SearchTagEnumfmike;
                case SearchTagEnum.fmdf:
                    return BaseEnumServiceRes.SearchTagEnumfmdf;
                case SearchTagEnum.fm21fm:
                    return BaseEnumServiceRes.SearchTagEnumfm21fm;
                case SearchTagEnum.fm3fm:
                    return BaseEnumServiceRes.SearchTagEnumfm3fm;
                case SearchTagEnum.fmesh:
                    return BaseEnumServiceRes.SearchTagEnumfmesh;
                case SearchTagEnum.flog:
                    return BaseEnumServiceRes.SearchTagEnumflog;
                case SearchTagEnum.ftxt:
                    return BaseEnumServiceRes.SearchTagEnumftxt;
                case SearchTagEnum.m:
                    return BaseEnumServiceRes.SearchTagEnumm;
                case SearchTagEnum.p:
                    return BaseEnumServiceRes.SearchTagEnump;
                case SearchTagEnum.ms:
                    return BaseEnumServiceRes.SearchTagEnumms;
                case SearchTagEnum.cs:
                    return BaseEnumServiceRes.SearchTagEnumcs;
                case SearchTagEnum.hs:
                    return BaseEnumServiceRes.SearchTagEnumhs;
                case SearchTagEnum.ts:
                    return BaseEnumServiceRes.SearchTagEnumts;
                case SearchTagEnum.ww:
                    return BaseEnumServiceRes.SearchTagEnumww;
                case SearchTagEnum.ls:
                    return BaseEnumServiceRes.SearchTagEnumls;
                case SearchTagEnum.st:
                    return BaseEnumServiceRes.SearchTagEnumst;
                case SearchTagEnum.ps:
                    return BaseEnumServiceRes.SearchTagEnumps;
                case SearchTagEnum.a:
                    return BaseEnumServiceRes.SearchTagEnuma;
                case SearchTagEnum.s:
                    return BaseEnumServiceRes.SearchTagEnums;
                case SearchTagEnum.ss:
                    return BaseEnumServiceRes.SearchTagEnumss;
                case SearchTagEnum.u:
                    return BaseEnumServiceRes.SearchTagEnumu;
                case SearchTagEnum.notag:
                    return BaseEnumServiceRes.SearchTagEnumnotag;
                case SearchTagEnum.fcsv:
                    return BaseEnumServiceRes.SearchTagEnumfcsv;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_SecondaryTreatmentTypeEnum(SecondaryTreatmentTypeEnum? secondaryTreatmentTypeE)
        {
            if (secondaryTreatmentTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (secondaryTreatmentTypeE)
            {
                case SecondaryTreatmentTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case SecondaryTreatmentTypeEnum.NotApplicable:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumNotApplicable;
                case SecondaryTreatmentTypeEnum.RotatingBiologicalContactor:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumRotatingBiologicalContactor;
                case SecondaryTreatmentTypeEnum.TricklingFilters:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumTricklingFilters;
                case SecondaryTreatmentTypeEnum.SequencingBatchReactor:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumSequencingBatchReactor;
                case SecondaryTreatmentTypeEnum.OxidationDitch:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumOxidationDitch;
                case SecondaryTreatmentTypeEnum.ExtendedAeration:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumExtendedAeration;
                case SecondaryTreatmentTypeEnum.ContactStabilization:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumContactStabilization;
                case SecondaryTreatmentTypeEnum.PhysicalChemicalProcesses:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumPhysicalChemicalProcesses;
                case SecondaryTreatmentTypeEnum.MovingBedBioReactor:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumMovingBedBioReactor;
                case SecondaryTreatmentTypeEnum.BiologicalAearatedFilters:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumBiologicalAearatedFilters;
                case SecondaryTreatmentTypeEnum.AeratedSubmergedBioFilmReactor:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumAeratedSubmergedBioFilmReactor;
                case SecondaryTreatmentTypeEnum.IntegratedFixedFilmActivatedSludge:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumIntegratedFixedFilmActivatedSludge;
                case SecondaryTreatmentTypeEnum.ActivatedSludge:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumActivatedSludge;
                case SecondaryTreatmentTypeEnum.ExtendedActivatedSludge:
                    return BaseEnumServiceRes.SecondaryTreatmentTypeEnumExtendedActivatedSludge;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_SpecialTableTypeEnum(SpecialTableTypeEnum? specialTableTypeE)
        {
            if (specialTableTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (specialTableTypeE)
            {
                case SpecialTableTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case SpecialTableTypeEnum.FCDensitiesTable:
                    return BaseEnumServiceRes.SpecialTableTypeEnumFCDensitiesTable;
                case SpecialTableTypeEnum.SalinityTable:
                    return BaseEnumServiceRes.SpecialTableTypeEnumSalinityTable;
                case SpecialTableTypeEnum.TemperatureTable:
                    return BaseEnumServiceRes.SpecialTableTypeEnumTemperatureTable;
                case SpecialTableTypeEnum.GeometricMeanTable:
                    return BaseEnumServiceRes.SpecialTableTypeEnumGeometricMeanTable;
                case SpecialTableTypeEnum.MedianTable:
                    return BaseEnumServiceRes.SpecialTableTypeEnumMedianTable;
                case SpecialTableTypeEnum.P90Table:
                    return BaseEnumServiceRes.SpecialTableTypeEnumP90Table;
                case SpecialTableTypeEnum.PercentOver43Table:
                    return BaseEnumServiceRes.SpecialTableTypeEnumPercentOver43Table;
                case SpecialTableTypeEnum.PercentOver260Table:
                    return BaseEnumServiceRes.SpecialTableTypeEnumPercentOver260Table;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_StorageDataTypeEnum(StorageDataTypeEnum? storageDataTypeE)
        {
            if (storageDataTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (storageDataTypeE)
            {
                case StorageDataTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case StorageDataTypeEnum.Archived:
                    return BaseEnumServiceRes.StorageDataTypeEnumArchived;
                case StorageDataTypeEnum.Forcasted:
                    return BaseEnumServiceRes.StorageDataTypeEnumForcasted;
                case StorageDataTypeEnum.Observed:
                    return BaseEnumServiceRes.StorageDataTypeEnumObserved;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_StreetTypeEnum(StreetTypeEnum? streetTypeE)
        {
            if (streetTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (streetTypeE)
            {
                case StreetTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case StreetTypeEnum.Street:
                    return BaseEnumServiceRes.StreetTypeEnumStreet;
                case StreetTypeEnum.Road:
                    return BaseEnumServiceRes.StreetTypeEnumRoad;
                case StreetTypeEnum.Avenue:
                    return BaseEnumServiceRes.StreetTypeEnumAvenue;
                case StreetTypeEnum.Crescent:
                    return BaseEnumServiceRes.StreetTypeEnumCrescent;
                case StreetTypeEnum.Court:
                    return BaseEnumServiceRes.StreetTypeEnumCourt;
                case StreetTypeEnum.Alley:
                    return BaseEnumServiceRes.StreetTypeEnumAlley;
                case StreetTypeEnum.Drive:
                    return BaseEnumServiceRes.StreetTypeEnumDrive;
                case StreetTypeEnum.Blvd:
                    return BaseEnumServiceRes.StreetTypeEnumBlvd;
                case StreetTypeEnum.Route:
                    return BaseEnumServiceRes.StreetTypeEnumRoute;
                case StreetTypeEnum.Lane:
                    return BaseEnumServiceRes.StreetTypeEnumLane;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_TelTypeEnum(TelTypeEnum? telTypeE)
        {
            if (telTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (telTypeE)
            {
                case TelTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case TelTypeEnum.Personal:
                    return BaseEnumServiceRes.TelTypeEnumPersonal;
                case TelTypeEnum.Work:
                    return BaseEnumServiceRes.TelTypeEnumWork;
                case TelTypeEnum.Mobile:
                    return BaseEnumServiceRes.TelTypeEnumMobile;
                case TelTypeEnum.Personal2:
                    return BaseEnumServiceRes.TelTypeEnumPersonal2;
                case TelTypeEnum.Work2:
                    return BaseEnumServiceRes.TelTypeEnumWork2;
                case TelTypeEnum.Mobile2:
                    return BaseEnumServiceRes.TelTypeEnumMobile2;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_TertiaryTreatmentTypeEnum(TertiaryTreatmentTypeEnum? tertiaryTreatmentTypeE)
        {
            if (tertiaryTreatmentTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (tertiaryTreatmentTypeE)
            {
                case TertiaryTreatmentTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case TertiaryTreatmentTypeEnum.NotApplicable:
                    return BaseEnumServiceRes.TertiaryTreatmentTypeEnumNotApplicable;
                case TertiaryTreatmentTypeEnum.Adsorption:
                    return BaseEnumServiceRes.TertiaryTreatmentTypeEnumAdsorption;
                case TertiaryTreatmentTypeEnum.Flocculation:
                    return BaseEnumServiceRes.TertiaryTreatmentTypeEnumFlocculation;
                case TertiaryTreatmentTypeEnum.MembraneFiltration:
                    return BaseEnumServiceRes.TertiaryTreatmentTypeEnumMembraneFiltration;
                case TertiaryTreatmentTypeEnum.IonExchange:
                    return BaseEnumServiceRes.TertiaryTreatmentTypeEnumIonExchange;
                case TertiaryTreatmentTypeEnum.ReverseOsmosis:
                    return BaseEnumServiceRes.TertiaryTreatmentTypeEnumReverseOsmosis;
                case TertiaryTreatmentTypeEnum.BiologicalNutrientRemoval:
                    return BaseEnumServiceRes.TertiaryTreatmentTypeEnumBiologicalNutrientRemoval;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_TideDataTypeEnum(TideDataTypeEnum? tideDataTypeE)
        {
            if (tideDataTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (tideDataTypeE)
            {
                case TideDataTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case TideDataTypeEnum.Min15:
                    return BaseEnumServiceRes.TideDataTypeEnumMin15;
                case TideDataTypeEnum.Min60:
                    return BaseEnumServiceRes.TideDataTypeEnumMin60;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_TideTextEnum(TideTextEnum? tideTextE)
        {
            if (tideTextE == null)
                return BaseEnumServiceRes.Empty;

            switch (tideTextE)
            {
                case TideTextEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case TideTextEnum.LowTide:
                    return BaseEnumServiceRes.TideTextEnumLowTide;
                case TideTextEnum.LowTideFalling:
                    return BaseEnumServiceRes.TideTextEnumLowTideFalling;
                case TideTextEnum.LowTideRising:
                    return BaseEnumServiceRes.TideTextEnumLowTideRising;
                case TideTextEnum.MidTide:
                    return BaseEnumServiceRes.TideTextEnumMidTide;
                case TideTextEnum.MidTideFalling:
                    return BaseEnumServiceRes.TideTextEnumMidTideFalling;
                case TideTextEnum.MidTideRising:
                    return BaseEnumServiceRes.TideTextEnumMidTideRising;
                case TideTextEnum.HighTide:
                    return BaseEnumServiceRes.TideTextEnumHighTide;
                case TideTextEnum.HighTideFalling:
                    return BaseEnumServiceRes.TideTextEnumHighTideFalling;
                case TideTextEnum.HighTideRising:
                    return BaseEnumServiceRes.TideTextEnumHighTideRising;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_TranslationStatusEnum(TranslationStatusEnum? translationStatusE)
        {
            if (translationStatusE == null)
                return BaseEnumServiceRes.Empty;

            switch (translationStatusE)
            {
                case TranslationStatusEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case TranslationStatusEnum.NotTranslated:
                    return BaseEnumServiceRes.TranslationStatusEnumNotTranslated;
                case TranslationStatusEnum.ElectronicallyTranslated:
                    return BaseEnumServiceRes.TranslationStatusEnumElectronicallyTranslated;
                case TranslationStatusEnum.Translated:
                    return BaseEnumServiceRes.TranslationStatusEnumTranslated;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_TreatmentTypeEnum(TreatmentTypeEnum? treatmentTypeE)
        {
            if (treatmentTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (treatmentTypeE)
            {
                case TreatmentTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case TreatmentTypeEnum.ActivatedSludge:
                    return BaseEnumServiceRes.TreatmentTypeEnumActivatedSludge;
                case TreatmentTypeEnum.ActivatedSludgeWithBiofilter:
                    return BaseEnumServiceRes.TreatmentTypeEnumActivatedSludgeWithBiofilter;
                case TreatmentTypeEnum.LagoonNoAeration1Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration1Cell;
                case TreatmentTypeEnum.LagoonNoAeration2Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration2Cell;
                case TreatmentTypeEnum.LagoonNoAeration3Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration3Cell;
                case TreatmentTypeEnum.LagoonNoAeration4Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration4Cell;
                case TreatmentTypeEnum.LagoonNoAeration5Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration5Cell;
                case TreatmentTypeEnum.LagoonWithAeration1Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration1Cell;
                case TreatmentTypeEnum.LagoonWithAeration2Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration2Cell;
                case TreatmentTypeEnum.LagoonWithAeration3Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration3Cell;
                case TreatmentTypeEnum.LagoonWithAeration4Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration4Cell;
                case TreatmentTypeEnum.LagoonWithAeration5Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration5Cell;
                case TreatmentTypeEnum.LagoonWithAeration6Cell:
                    return BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration6Cell;
                case TreatmentTypeEnum.StabalizingPondOnly:
                    return BaseEnumServiceRes.TreatmentTypeEnumStabalizingPondOnly;
                case TreatmentTypeEnum.OxidationDitchOnly:
                    return BaseEnumServiceRes.TreatmentTypeEnumOxidationDitchOnly;
                case TreatmentTypeEnum.CirculatingFluidizedBed:
                    return BaseEnumServiceRes.TreatmentTypeEnumCirculatingFluidizedBed;
                case TreatmentTypeEnum.TricklingFilter:
                    return BaseEnumServiceRes.TreatmentTypeEnumTricklingFilter;
                case TreatmentTypeEnum.RecirculatingSandFilter:
                    return BaseEnumServiceRes.TreatmentTypeEnumRecirculatingSandFilter;
                case TreatmentTypeEnum.TrashRackRakeOnly:
                    return BaseEnumServiceRes.TreatmentTypeEnumTrashRackRakeOnly;
                case TreatmentTypeEnum.SepticTank:
                    return BaseEnumServiceRes.TreatmentTypeEnumSepticTank;
                case TreatmentTypeEnum.Secondary:
                    return BaseEnumServiceRes.TreatmentTypeEnumSecondary;
                case TreatmentTypeEnum.Tertiary:
                    return BaseEnumServiceRes.TreatmentTypeEnumTertiary;
                case TreatmentTypeEnum.VolumeFermenter:
                    return BaseEnumServiceRes.TreatmentTypeEnumVolumeFermenter;
                case TreatmentTypeEnum.BioFilmReactor:
                    return BaseEnumServiceRes.TreatmentTypeEnumBioFilmReactor;
                case TreatmentTypeEnum.BioGreen:
                    return BaseEnumServiceRes.TreatmentTypeEnumBioGreen;
                case TreatmentTypeEnum.BioDisks:
                    return BaseEnumServiceRes.TreatmentTypeEnumBioDisks;
                case TreatmentTypeEnum.ChemicalPrimary:
                    return BaseEnumServiceRes.TreatmentTypeEnumChemicalPrimary;
                case TreatmentTypeEnum.Chromoglass:
                    return BaseEnumServiceRes.TreatmentTypeEnumChromoglass;
                case TreatmentTypeEnum.Primary:
                    return BaseEnumServiceRes.TreatmentTypeEnumPrimary;
                case TreatmentTypeEnum.SequencingBatchReactor:
                    return BaseEnumServiceRes.TreatmentTypeEnumSequencingBatchReactor;
                case TreatmentTypeEnum.PeatSystem:
                    return BaseEnumServiceRes.TreatmentTypeEnumPeatSystem;
                case TreatmentTypeEnum.Physicochimique:
                    return BaseEnumServiceRes.TreatmentTypeEnumPhysicochimique;
                case TreatmentTypeEnum.RotatingBiologicalContactor:
                    return BaseEnumServiceRes.TreatmentTypeEnumRotatingBiologicalContactor;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_TVAuthEnum(TVAuthEnum? tVAuthE)
        {
            if (tVAuthE == null)
                return BaseEnumServiceRes.Empty;

            switch (tVAuthE)
            {
                case TVAuthEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case TVAuthEnum.NoAccess:
                    return BaseEnumServiceRes.TVAuthEnumNoAccess;
                case TVAuthEnum.Read:
                    return BaseEnumServiceRes.TVAuthEnumRead;
                case TVAuthEnum.Write:
                    return BaseEnumServiceRes.TVAuthEnumWrite;
                case TVAuthEnum.Create:
                    return BaseEnumServiceRes.TVAuthEnumCreate;
                case TVAuthEnum.Delete:
                    return BaseEnumServiceRes.TVAuthEnumDelete;
                case TVAuthEnum.Admin:
                    return BaseEnumServiceRes.TVAuthEnumAdmin;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_TVTypeEnum(TVTypeEnum? tVTypeE)
        {
            if (tVTypeE == null)
                return BaseEnumServiceRes.Empty;

            switch (tVTypeE)
            {
                case TVTypeEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case TVTypeEnum.Root:
                    return BaseEnumServiceRes.TVTypeEnumRoot;
                case TVTypeEnum.Address:
                    return BaseEnumServiceRes.TVTypeEnumAddress;
                case TVTypeEnum.Area:
                    return BaseEnumServiceRes.TVTypeEnumArea;
                case TVTypeEnum.ClimateSite:
                    return BaseEnumServiceRes.TVTypeEnumClimateSite;
                case TVTypeEnum.Contact:
                    return BaseEnumServiceRes.TVTypeEnumContact;
                case TVTypeEnum.Country:
                    return BaseEnumServiceRes.TVTypeEnumCountry;
                case TVTypeEnum.Email:
                    return BaseEnumServiceRes.TVTypeEnumEmail;
                case TVTypeEnum.File:
                    return BaseEnumServiceRes.TVTypeEnumFile;
                case TVTypeEnum.HydrometricSite:
                    return BaseEnumServiceRes.TVTypeEnumHydrometricSite;
                case TVTypeEnum.Infrastructure:
                    return BaseEnumServiceRes.TVTypeEnumInfrastructure;
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                    return BaseEnumServiceRes.TVTypeEnumMikeBoundaryConditionWebTide;
                case TVTypeEnum.MikeBoundaryConditionMesh:
                    return BaseEnumServiceRes.TVTypeEnumMikeBoundaryConditionMesh;
                case TVTypeEnum.MikeScenario:
                    return BaseEnumServiceRes.TVTypeEnumMikeScenario;
                case TVTypeEnum.MikeSource:
                    return BaseEnumServiceRes.TVTypeEnumMikeSource;
                case TVTypeEnum.Municipality:
                    return BaseEnumServiceRes.TVTypeEnumMunicipality;
                case TVTypeEnum.MWQMSite:
                    return BaseEnumServiceRes.TVTypeEnumMWQMSite;
                case TVTypeEnum.PolSourceSite:
                    return BaseEnumServiceRes.TVTypeEnumPolSourceSite;
                case TVTypeEnum.Province:
                    return BaseEnumServiceRes.TVTypeEnumProvince;
                case TVTypeEnum.Sector:
                    return BaseEnumServiceRes.TVTypeEnumSector;
                case TVTypeEnum.Subsector:
                    return BaseEnumServiceRes.TVTypeEnumSubsector;
                case TVTypeEnum.Tel:
                    return BaseEnumServiceRes.TVTypeEnumTel;
                case TVTypeEnum.TideSite:
                    return BaseEnumServiceRes.TVTypeEnumTideSite;
                case TVTypeEnum.MWQMSiteSample:
                    return BaseEnumServiceRes.TVTypeEnumMWQMSiteSample;
                case TVTypeEnum.WasteWaterTreatmentPlant:
                    return BaseEnumServiceRes.TVTypeEnumWasteWaterTreatmentPlant;
                case TVTypeEnum.LiftStation:
                    return BaseEnumServiceRes.TVTypeEnumLiftStation;
                case TVTypeEnum.Spill:
                    return BaseEnumServiceRes.TVTypeEnumSpill;
                case TVTypeEnum.BoxModel:
                    return BaseEnumServiceRes.TVTypeEnumBoxModel;
                case TVTypeEnum.VisualPlumesScenario:
                    return BaseEnumServiceRes.TVTypeEnumVisualPlumesScenario;
                case TVTypeEnum.Outfall:
                    return BaseEnumServiceRes.TVTypeEnumOutfall;
                case TVTypeEnum.OtherInfrastructure:
                    return BaseEnumServiceRes.TVTypeEnumOtherInfrastructure;
                case TVTypeEnum.MWQMRun:
                    return BaseEnumServiceRes.TVTypeEnumMWQMRun;
                case TVTypeEnum.NoDepuration:
                    return BaseEnumServiceRes.TVTypeEnumNoDepuration;
                case TVTypeEnum.Failed:
                    return BaseEnumServiceRes.TVTypeEnumFailed;
                case TVTypeEnum.Passed:
                    return BaseEnumServiceRes.TVTypeEnumPassed;
                case TVTypeEnum.NoData:
                    return BaseEnumServiceRes.TVTypeEnumNoData;
                case TVTypeEnum.LessThan10:
                    return BaseEnumServiceRes.TVTypeEnumLessThan10;
                case TVTypeEnum.MeshNode:
                    return BaseEnumServiceRes.TVTypeEnumMeshNode;
                case TVTypeEnum.WebTideNode:
                    return BaseEnumServiceRes.TVTypeEnumWebTideNode;
                case TVTypeEnum.SamplingPlan:
                    return BaseEnumServiceRes.TVTypeEnumSamplingPlan;
                case TVTypeEnum.SeeOtherMunicipality:
                    return BaseEnumServiceRes.TVTypeEnumSeeOtherMunicipality;
                case TVTypeEnum.LineOverflow:
                    return BaseEnumServiceRes.TVTypeEnumLineOverflow;
                case TVTypeEnum.BoxModelInputs:
                    return BaseEnumServiceRes.TVTypeEnumBoxModelInputs;
                case TVTypeEnum.BoxModelResults:
                    return BaseEnumServiceRes.TVTypeEnumBoxModelResults;
                case TVTypeEnum.ClimateSiteInfo:
                    return BaseEnumServiceRes.TVTypeEnumClimateSiteInfo;
                case TVTypeEnum.ClimateSiteData:
                    return BaseEnumServiceRes.TVTypeEnumClimateSiteData;
                case TVTypeEnum.HydrometricSiteInfo:
                    return BaseEnumServiceRes.TVTypeEnumHydrometricSiteInfo;
                case TVTypeEnum.HydrometricSiteData:
                    return BaseEnumServiceRes.TVTypeEnumHydrometricSiteData;
                case TVTypeEnum.InfrastructureInfo:
                    return BaseEnumServiceRes.TVTypeEnumInfrastructureInfo;
                case TVTypeEnum.LabSheetInfo:
                    return BaseEnumServiceRes.TVTypeEnumLabSheetInfo;
                case TVTypeEnum.LabSheetDetailInfo:
                    return BaseEnumServiceRes.TVTypeEnumLabSheetDetailInfo;
                case TVTypeEnum.MapInfo:
                    return BaseEnumServiceRes.TVTypeEnumMapInfo;
                case TVTypeEnum.MapInfoPoint:
                    return BaseEnumServiceRes.TVTypeEnumMapInfoPoint;
                case TVTypeEnum.MikeSourceStartEndInfo:
                    return BaseEnumServiceRes.TVTypeEnumMikeSourceStartEndInfo;
                case TVTypeEnum.MWQMLookupMPNInfo:
                    return BaseEnumServiceRes.TVTypeEnumMWQMLookupMPNInfo;
                case TVTypeEnum.SamplingPlanInfo:
                    return BaseEnumServiceRes.TVTypeEnumSamplingPlanInfo;
                case TVTypeEnum.SamplingPlanSubsectorInfo:
                    return BaseEnumServiceRes.TVTypeEnumSamplingPlanSubsectorInfo;
                case TVTypeEnum.SamplingPlanSubsectorSiteInfo:
                    return BaseEnumServiceRes.TVTypeEnumSamplingPlanSubsectorSiteInfo;
                case TVTypeEnum.MWQMSiteStartEndInfo:
                    return BaseEnumServiceRes.TVTypeEnumMWQMSiteStartEndInfo;
                case TVTypeEnum.MWQMSubsectorInfo:
                    return BaseEnumServiceRes.TVTypeEnumMWQMSubsectorInfo;
                case TVTypeEnum.PolSourceSiteInfo:
                    return BaseEnumServiceRes.TVTypeEnumPolSourceSiteInfo;
                case TVTypeEnum.PolSourceSiteObsInfo:
                    return BaseEnumServiceRes.TVTypeEnumPolSourceSiteObsInfo;
                case TVTypeEnum.HydrometricRatingCurveInfo:
                    return BaseEnumServiceRes.TVTypeEnumHydrometricRatingCurveInfo;
                case TVTypeEnum.HydrometricRatingCurveDataInfo:
                    return BaseEnumServiceRes.TVTypeEnumHydrometricRatingCurveDataInfo;
                case TVTypeEnum.TideLocationInfo:
                    return BaseEnumServiceRes.TVTypeEnumTideLocationInfo;
                case TVTypeEnum.TideSiteDataInfo:
                    return BaseEnumServiceRes.TVTypeEnumTideSiteDataInfo;
                case TVTypeEnum.UseOfSite:
                    return BaseEnumServiceRes.TVTypeEnumUseOfSite;
                case TVTypeEnum.VisualPlumesScenarioInfo:
                    return BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioInfo;
                case TVTypeEnum.VisualPlumesScenarioAmbient:
                    return BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioAmbient;
                case TVTypeEnum.VisualPlumesScenarioResults:
                    return BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioResults;
                case TVTypeEnum.TotalFile:
                    return BaseEnumServiceRes.TVTypeEnumTotalFile;
                case TVTypeEnum.MikeSourceIsRiver:
                    return BaseEnumServiceRes.TVTypeEnumMikeSourceIsRiver;
                case TVTypeEnum.MikeSourceIncluded:
                    return BaseEnumServiceRes.TVTypeEnumMikeSourceIncluded;
                case TVTypeEnum.MikeSourceNotIncluded:
                    return BaseEnumServiceRes.TVTypeEnumMikeSourceNotIncluded;
                case TVTypeEnum.RainExceedance:
                    return BaseEnumServiceRes.TVTypeEnumRainExceedance;
                case TVTypeEnum.EmailDistributionList:
                    return BaseEnumServiceRes.TVTypeEnumEmailDistributionList;
                case TVTypeEnum.OpenData:
                    return BaseEnumServiceRes.TVTypeEnumOpenData;
                case TVTypeEnum.ProvinceTools:
                    return BaseEnumServiceRes.TVTypeEnumProvinceTools;
                case TVTypeEnum.Classification:
                    return BaseEnumServiceRes.TVTypeEnumClassification;
                case TVTypeEnum.Approved:
                    return BaseEnumServiceRes.TVTypeEnumApproved;
                case TVTypeEnum.Restricted:
                    return BaseEnumServiceRes.TVTypeEnumRestricted;
                case TVTypeEnum.Prohibited:
                    return BaseEnumServiceRes.TVTypeEnumProhibited;
                case TVTypeEnum.ConditionallyApproved:
                    return BaseEnumServiceRes.TVTypeEnumConditionallyApproved;
                case TVTypeEnum.ConditionallyRestricted:
                    return BaseEnumServiceRes.TVTypeEnumConditionallyRestricted;
                case TVTypeEnum.OpenDataNational:
                    return BaseEnumServiceRes.TVTypeEnumOpenDataNational;
                case TVTypeEnum.PolSourceSiteMikeScenario:
                    return BaseEnumServiceRes.TVTypeEnumPolSourceSiteMikeScenario;
                case TVTypeEnum.SubsectorTools:
                    return BaseEnumServiceRes.TVTypeEnumSubsectorTools;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }
        public string GetEnumText_WebTideDataSetEnum(WebTideDataSetEnum? webTideDataSetE)
        {
            if (webTideDataSetE == null)
                return BaseEnumServiceRes.Empty;

            switch (webTideDataSetE)
            {
                case WebTideDataSetEnum.Error:
                    return BaseEnumServiceRes.Empty;
                case WebTideDataSetEnum.arctic9:
                    return BaseEnumServiceRes.WebTideDataSetEnumarctic9;
                case WebTideDataSetEnum.brador:
                    return BaseEnumServiceRes.WebTideDataSetEnumbrador;
                case WebTideDataSetEnum.HRglobal:
                    return BaseEnumServiceRes.WebTideDataSetEnumHRglobal;
                case WebTideDataSetEnum.h3o:
                    return BaseEnumServiceRes.WebTideDataSetEnumh3o;
                case WebTideDataSetEnum.hudson:
                    return BaseEnumServiceRes.WebTideDataSetEnumhudson;
                case WebTideDataSetEnum.ne_pac4:
                    return BaseEnumServiceRes.WebTideDataSetEnumne_pac4;
                case WebTideDataSetEnum.nwatl:
                    return BaseEnumServiceRes.WebTideDataSetEnumnwatl;
                case WebTideDataSetEnum.QuatsinoModel14:
                    return BaseEnumServiceRes.WebTideDataSetEnumQuatsinoModel14;
                case WebTideDataSetEnum.sshelf:
                    return BaseEnumServiceRes.WebTideDataSetEnumsshelf;
                case WebTideDataSetEnum.flood:
                    return BaseEnumServiceRes.WebTideDataSetEnumflood;
                case WebTideDataSetEnum.vigf8:
                    return BaseEnumServiceRes.WebTideDataSetEnumvigf8;
                default:
                    return BaseEnumServiceRes.Empty;
            }
        }

        #endregion Functions Get Enum Text

        #region Function Get Enum Text Ordered
        public List<AddressTypeEnumTextOrdered> GetAddressTypeEnumTextOrderedList()
        {
            List<AddressTypeEnumTextOrdered> AddressTypeEnumTextOrderedList = new List<AddressTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(AddressTypeEnum)).Count(); i < count; i++)
            {
                AddressTypeEnumTextOrderedList.Add(new AddressTypeEnumTextOrdered() { AddressType = (AddressTypeEnum)i, AddressTypeText = GetEnumText_AddressTypeEnum((AddressTypeEnum)i) });
            }

            AddressTypeEnumTextOrderedList = (from c in AddressTypeEnumTextOrderedList
                                              orderby c.AddressTypeText
                                              select c).ToList();

            return AddressTypeEnumTextOrderedList;
        }
        public List<AerationTypeEnumTextOrdered> GetAerationTypeEnumTextOrderedList()
        {
            List<AerationTypeEnumTextOrdered> AerationTypeEnumTextOrderedList = new List<AerationTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(AerationTypeEnum)).Count(); i < count; i++)
            {
                AerationTypeEnumTextOrderedList.Add(new AerationTypeEnumTextOrdered() { AerationType = (AerationTypeEnum)i, AerationTypeText = GetEnumText_AerationTypeEnum((AerationTypeEnum)i) });
            }

            AerationTypeEnumTextOrderedList = (from c in AerationTypeEnumTextOrderedList
                                              orderby c.AerationTypeText
                                              select c).ToList();

            return AerationTypeEnumTextOrderedList;
        }
        public List<AlarmSystemTypeEnumTextOrdered> GetAlarmSystemTypeEnumTextOrderedList()
        {
            List<AlarmSystemTypeEnumTextOrdered> AlarmSystemTypeEnumTextOrderedList = new List<AlarmSystemTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(AlarmSystemTypeEnum)).Count(); i < count; i++)
            {
                AlarmSystemTypeEnumTextOrderedList.Add(new AlarmSystemTypeEnumTextOrdered() { AlarmSystemType = (AlarmSystemTypeEnum)i, AlarmSystemTypeText = GetEnumText_AlarmSystemTypeEnum((AlarmSystemTypeEnum)i) });
            }

            AlarmSystemTypeEnumTextOrderedList = (from c in AlarmSystemTypeEnumTextOrderedList
                                              orderby c.AlarmSystemTypeText
                                              select c).ToList();

            return AlarmSystemTypeEnumTextOrderedList;
        }
        public List<AnalysisCalculationTypeEnumTextOrdered> GetAnalysisCalculationTypeEnumTextOrderedList()
        {
            List<AnalysisCalculationTypeEnumTextOrdered> AnalysisCalculationTypeEnumTextOrderedList = new List<AnalysisCalculationTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(AnalysisCalculationTypeEnum)).Count(); i < count; i++)
            {
                AnalysisCalculationTypeEnumTextOrderedList.Add(new AnalysisCalculationTypeEnumTextOrdered() { AnalysisCalculationType = (AnalysisCalculationTypeEnum)i, AnalysisCalculationTypeText = GetEnumText_AnalysisCalculationTypeEnum((AnalysisCalculationTypeEnum)i) });
            }

            AnalysisCalculationTypeEnumTextOrderedList = (from c in AnalysisCalculationTypeEnumTextOrderedList
                                              orderby c.AnalysisCalculationTypeText
                                              select c).ToList();

            return AnalysisCalculationTypeEnumTextOrderedList;
        }
        public List<AnalysisReportExportCommandEnumTextOrdered> GetAnalysisReportExportCommandEnumTextOrderedList()
        {
            List<AnalysisReportExportCommandEnumTextOrdered> AnalysisReportExportCommandEnumTextOrderedList = new List<AnalysisReportExportCommandEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(AnalysisReportExportCommandEnum)).Count(); i < count; i++)
            {
                AnalysisReportExportCommandEnumTextOrderedList.Add(new AnalysisReportExportCommandEnumTextOrdered() { AnalysisReportExportCommand = (AnalysisReportExportCommandEnum)i, AnalysisReportExportCommandText = GetEnumText_AnalysisReportExportCommandEnum((AnalysisReportExportCommandEnum)i) });
            }

            AnalysisReportExportCommandEnumTextOrderedList = (from c in AnalysisReportExportCommandEnumTextOrderedList
                                              orderby c.AnalysisReportExportCommandText
                                              select c).ToList();

            return AnalysisReportExportCommandEnumTextOrderedList;
        }
        public List<AnalyzeMethodEnumTextOrdered> GetAnalyzeMethodEnumTextOrderedList()
        {
            List<AnalyzeMethodEnumTextOrdered> AnalyzeMethodEnumTextOrderedList = new List<AnalyzeMethodEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(AnalyzeMethodEnum)).Count(); i < count; i++)
            {
                AnalyzeMethodEnumTextOrderedList.Add(new AnalyzeMethodEnumTextOrdered() { AnalyzeMethod = (AnalyzeMethodEnum)i, AnalyzeMethodText = GetEnumText_AnalyzeMethodEnum((AnalyzeMethodEnum)i) });
            }

            AnalyzeMethodEnumTextOrderedList = (from c in AnalyzeMethodEnumTextOrderedList
                                              orderby c.AnalyzeMethodText
                                              select c).ToList();

            return AnalyzeMethodEnumTextOrderedList;
        }
        public List<AppTaskCommandEnumTextOrdered> GetAppTaskCommandEnumTextOrderedList()
        {
            List<AppTaskCommandEnumTextOrdered> AppTaskCommandEnumTextOrderedList = new List<AppTaskCommandEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(AppTaskCommandEnum)).Count(); i < count; i++)
            {
                AppTaskCommandEnumTextOrderedList.Add(new AppTaskCommandEnumTextOrdered() { AppTaskCommand = (AppTaskCommandEnum)i, AppTaskCommandText = GetEnumText_AppTaskCommandEnum((AppTaskCommandEnum)i) });
            }

            AppTaskCommandEnumTextOrderedList = (from c in AppTaskCommandEnumTextOrderedList
                                              orderby c.AppTaskCommandText
                                              select c).ToList();

            return AppTaskCommandEnumTextOrderedList;
        }
        public List<AppTaskStatusEnumTextOrdered> GetAppTaskStatusEnumTextOrderedList()
        {
            List<AppTaskStatusEnumTextOrdered> AppTaskStatusEnumTextOrderedList = new List<AppTaskStatusEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(AppTaskStatusEnum)).Count(); i < count; i++)
            {
                AppTaskStatusEnumTextOrderedList.Add(new AppTaskStatusEnumTextOrdered() { AppTaskStatus = (AppTaskStatusEnum)i, AppTaskStatusText = GetEnumText_AppTaskStatusEnum((AppTaskStatusEnum)i) });
            }

            AppTaskStatusEnumTextOrderedList = (from c in AppTaskStatusEnumTextOrderedList
                                              orderby c.AppTaskStatusText
                                              select c).ToList();

            return AppTaskStatusEnumTextOrderedList;
        }
        public List<BeaufortScaleEnumTextOrdered> GetBeaufortScaleEnumTextOrderedList()
        {
            List<BeaufortScaleEnumTextOrdered> BeaufortScaleEnumTextOrderedList = new List<BeaufortScaleEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(BeaufortScaleEnum)).Count(); i < count; i++)
            {
                BeaufortScaleEnumTextOrderedList.Add(new BeaufortScaleEnumTextOrdered() { BeaufortScale = (BeaufortScaleEnum)i, BeaufortScaleText = GetEnumText_BeaufortScaleEnum((BeaufortScaleEnum)i) });
            }

            BeaufortScaleEnumTextOrderedList = (from c in BeaufortScaleEnumTextOrderedList
                                              orderby c.BeaufortScaleText
                                              select c).ToList();

            return BeaufortScaleEnumTextOrderedList;
        }
        public List<BoxModelResultTypeEnumTextOrdered> GetBoxModelResultTypeEnumTextOrderedList()
        {
            List<BoxModelResultTypeEnumTextOrdered> BoxModelResultTypeEnumTextOrderedList = new List<BoxModelResultTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(BoxModelResultTypeEnum)).Count(); i < count; i++)
            {
                BoxModelResultTypeEnumTextOrderedList.Add(new BoxModelResultTypeEnumTextOrdered() { BoxModelResultType = (BoxModelResultTypeEnum)i, BoxModelResultTypeText = GetEnumText_BoxModelResultTypeEnum((BoxModelResultTypeEnum)i) });
            }

            BoxModelResultTypeEnumTextOrderedList = (from c in BoxModelResultTypeEnumTextOrderedList
                                              orderby c.BoxModelResultTypeText
                                              select c).ToList();

            return BoxModelResultTypeEnumTextOrderedList;
        }
        public List<ClassificationTypeEnumTextOrdered> GetClassificationTypeEnumTextOrderedList()
        {
            List<ClassificationTypeEnumTextOrdered> ClassificationTypeEnumTextOrderedList = new List<ClassificationTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ClassificationTypeEnum)).Count(); i < count; i++)
            {
                ClassificationTypeEnumTextOrderedList.Add(new ClassificationTypeEnumTextOrdered() { ClassificationType = (ClassificationTypeEnum)i, ClassificationTypeText = GetEnumText_ClassificationTypeEnum((ClassificationTypeEnum)i) });
            }

            ClassificationTypeEnumTextOrderedList = (from c in ClassificationTypeEnumTextOrderedList
                                              orderby c.ClassificationTypeText
                                              select c).ToList();

            return ClassificationTypeEnumTextOrderedList;
        }
        public List<CollectionSystemTypeEnumTextOrdered> GetCollectionSystemTypeEnumTextOrderedList()
        {
            List<CollectionSystemTypeEnumTextOrdered> CollectionSystemTypeEnumTextOrderedList = new List<CollectionSystemTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(CollectionSystemTypeEnum)).Count(); i < count; i++)
            {
                CollectionSystemTypeEnumTextOrderedList.Add(new CollectionSystemTypeEnumTextOrdered() { CollectionSystemType = (CollectionSystemTypeEnum)i, CollectionSystemTypeText = GetEnumText_CollectionSystemTypeEnum((CollectionSystemTypeEnum)i) });
            }

            CollectionSystemTypeEnumTextOrderedList = (from c in CollectionSystemTypeEnumTextOrderedList
                                              orderby c.CollectionSystemTypeText
                                              select c).ToList();

            return CollectionSystemTypeEnumTextOrderedList;
        }
        public List<ContactTitleEnumTextOrdered> GetContactTitleEnumTextOrderedList()
        {
            List<ContactTitleEnumTextOrdered> ContactTitleEnumTextOrderedList = new List<ContactTitleEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ContactTitleEnum)).Count(); i < count; i++)
            {
                ContactTitleEnumTextOrderedList.Add(new ContactTitleEnumTextOrdered() { ContactTitle = (ContactTitleEnum)i, ContactTitleText = GetEnumText_ContactTitleEnum((ContactTitleEnum)i) });
            }

            ContactTitleEnumTextOrderedList = (from c in ContactTitleEnumTextOrderedList
                                              orderby c.ContactTitleText
                                              select c).ToList();

            return ContactTitleEnumTextOrderedList;
        }
        public List<CSSPWQInputSheetTypeEnumTextOrdered> GetCSSPWQInputSheetTypeEnumTextOrderedList()
        {
            List<CSSPWQInputSheetTypeEnumTextOrdered> CSSPWQInputSheetTypeEnumTextOrderedList = new List<CSSPWQInputSheetTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(CSSPWQInputSheetTypeEnum)).Count(); i < count; i++)
            {
                CSSPWQInputSheetTypeEnumTextOrderedList.Add(new CSSPWQInputSheetTypeEnumTextOrdered() { CSSPWQInputSheetType = (CSSPWQInputSheetTypeEnum)i, CSSPWQInputSheetTypeText = GetEnumText_CSSPWQInputSheetTypeEnum((CSSPWQInputSheetTypeEnum)i) });
            }

            CSSPWQInputSheetTypeEnumTextOrderedList = (from c in CSSPWQInputSheetTypeEnumTextOrderedList
                                              orderby c.CSSPWQInputSheetTypeText
                                              select c).ToList();

            return CSSPWQInputSheetTypeEnumTextOrderedList;
        }
        public List<CSSPWQInputTypeEnumTextOrdered> GetCSSPWQInputTypeEnumTextOrderedList()
        {
            List<CSSPWQInputTypeEnumTextOrdered> CSSPWQInputTypeEnumTextOrderedList = new List<CSSPWQInputTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(CSSPWQInputTypeEnum)).Count(); i < count; i++)
            {
                CSSPWQInputTypeEnumTextOrderedList.Add(new CSSPWQInputTypeEnumTextOrdered() { CSSPWQInputType = (CSSPWQInputTypeEnum)i, CSSPWQInputTypeText = GetEnumText_CSSPWQInputTypeEnum((CSSPWQInputTypeEnum)i) });
            }

            CSSPWQInputTypeEnumTextOrderedList = (from c in CSSPWQInputTypeEnumTextOrderedList
                                              orderby c.CSSPWQInputTypeText
                                              select c).ToList();

            return CSSPWQInputTypeEnumTextOrderedList;
        }
        public List<DailyOrHourlyDataEnumTextOrdered> GetDailyOrHourlyDataEnumTextOrderedList()
        {
            List<DailyOrHourlyDataEnumTextOrdered> DailyOrHourlyDataEnumTextOrderedList = new List<DailyOrHourlyDataEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(DailyOrHourlyDataEnum)).Count(); i < count; i++)
            {
                DailyOrHourlyDataEnumTextOrderedList.Add(new DailyOrHourlyDataEnumTextOrdered() { DailyOrHourlyData = (DailyOrHourlyDataEnum)i, DailyOrHourlyDataText = GetEnumText_DailyOrHourlyDataEnum((DailyOrHourlyDataEnum)i) });
            }

            DailyOrHourlyDataEnumTextOrderedList = (from c in DailyOrHourlyDataEnumTextOrderedList
                                              orderby c.DailyOrHourlyDataText
                                              select c).ToList();

            return DailyOrHourlyDataEnumTextOrderedList;
        }
        public List<DisinfectionTypeEnumTextOrdered> GetDisinfectionTypeEnumTextOrderedList()
        {
            List<DisinfectionTypeEnumTextOrdered> DisinfectionTypeEnumTextOrderedList = new List<DisinfectionTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(DisinfectionTypeEnum)).Count(); i < count; i++)
            {
                DisinfectionTypeEnumTextOrderedList.Add(new DisinfectionTypeEnumTextOrdered() { DisinfectionType = (DisinfectionTypeEnum)i, DisinfectionTypeText = GetEnumText_DisinfectionTypeEnum((DisinfectionTypeEnum)i) });
            }

            DisinfectionTypeEnumTextOrderedList = (from c in DisinfectionTypeEnumTextOrderedList
                                              orderby c.DisinfectionTypeText
                                              select c).ToList();

            return DisinfectionTypeEnumTextOrderedList;
        }
        public List<DrogueTypeEnumTextOrdered> GetDrogueTypeEnumTextOrderedList()
        {
            List<DrogueTypeEnumTextOrdered> DrogueTypeEnumTextOrderedList = new List<DrogueTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(DrogueTypeEnum)).Count(); i < count; i++)
            {
                DrogueTypeEnumTextOrderedList.Add(new DrogueTypeEnumTextOrdered() { DrogueType = (DrogueTypeEnum)i, DrogueTypeText = GetEnumText_DrogueTypeEnum((DrogueTypeEnum)i) });
            }

            DrogueTypeEnumTextOrderedList = (from c in DrogueTypeEnumTextOrderedList
                                              orderby c.DrogueTypeText
                                              select c).ToList();

            return DrogueTypeEnumTextOrderedList;
        }
        public List<EmailTypeEnumTextOrdered> GetEmailTypeEnumTextOrderedList()
        {
            List<EmailTypeEnumTextOrdered> EmailTypeEnumTextOrderedList = new List<EmailTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(EmailTypeEnum)).Count(); i < count; i++)
            {
                EmailTypeEnumTextOrderedList.Add(new EmailTypeEnumTextOrdered() { EmailType = (EmailTypeEnum)i, EmailTypeText = GetEnumText_EmailTypeEnum((EmailTypeEnum)i) });
            }

            EmailTypeEnumTextOrderedList = (from c in EmailTypeEnumTextOrderedList
                                              orderby c.EmailTypeText
                                              select c).ToList();

            return EmailTypeEnumTextOrderedList;
        }
        public List<ExcelExportShowDataTypeEnumTextOrdered> GetExcelExportShowDataTypeEnumTextOrderedList()
        {
            List<ExcelExportShowDataTypeEnumTextOrdered> ExcelExportShowDataTypeEnumTextOrderedList = new List<ExcelExportShowDataTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ExcelExportShowDataTypeEnum)).Count(); i < count; i++)
            {
                ExcelExportShowDataTypeEnumTextOrderedList.Add(new ExcelExportShowDataTypeEnumTextOrdered() { ExcelExportShowDataType = (ExcelExportShowDataTypeEnum)i, ExcelExportShowDataTypeText = GetEnumText_ExcelExportShowDataTypeEnum((ExcelExportShowDataTypeEnum)i) });
            }

            ExcelExportShowDataTypeEnumTextOrderedList = (from c in ExcelExportShowDataTypeEnumTextOrderedList
                                              orderby c.ExcelExportShowDataTypeText
                                              select c).ToList();

            return ExcelExportShowDataTypeEnumTextOrderedList;
        }
        public List<FacilityTypeEnumTextOrdered> GetFacilityTypeEnumTextOrderedList()
        {
            List<FacilityTypeEnumTextOrdered> FacilityTypeEnumTextOrderedList = new List<FacilityTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(FacilityTypeEnum)).Count(); i < count; i++)
            {
                FacilityTypeEnumTextOrderedList.Add(new FacilityTypeEnumTextOrdered() { FacilityType = (FacilityTypeEnum)i, FacilityTypeText = GetEnumText_FacilityTypeEnum((FacilityTypeEnum)i) });
            }

            FacilityTypeEnumTextOrderedList = (from c in FacilityTypeEnumTextOrderedList
                                              orderby c.FacilityTypeText
                                              select c).ToList();

            return FacilityTypeEnumTextOrderedList;
        }
        public List<FilePurposeEnumTextOrdered> GetFilePurposeEnumTextOrderedList()
        {
            List<FilePurposeEnumTextOrdered> FilePurposeEnumTextOrderedList = new List<FilePurposeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(FilePurposeEnum)).Count(); i < count; i++)
            {
                FilePurposeEnumTextOrderedList.Add(new FilePurposeEnumTextOrdered() { FilePurpose = (FilePurposeEnum)i, FilePurposeText = GetEnumText_FilePurposeEnum((FilePurposeEnum)i) });
            }

            FilePurposeEnumTextOrderedList = (from c in FilePurposeEnumTextOrderedList
                                              orderby c.FilePurposeText
                                              select c).ToList();

            return FilePurposeEnumTextOrderedList;
        }
        public List<FileStatusEnumTextOrdered> GetFileStatusEnumTextOrderedList()
        {
            List<FileStatusEnumTextOrdered> FileStatusEnumTextOrderedList = new List<FileStatusEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(FileStatusEnum)).Count(); i < count; i++)
            {
                FileStatusEnumTextOrderedList.Add(new FileStatusEnumTextOrdered() { FileStatus = (FileStatusEnum)i, FileStatusText = GetEnumText_FileStatusEnum((FileStatusEnum)i) });
            }

            FileStatusEnumTextOrderedList = (from c in FileStatusEnumTextOrderedList
                                              orderby c.FileStatusText
                                              select c).ToList();

            return FileStatusEnumTextOrderedList;
        }
        public List<FileTypeEnumTextOrdered> GetFileTypeEnumTextOrderedList()
        {
            List<FileTypeEnumTextOrdered> FileTypeEnumTextOrderedList = new List<FileTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(FileTypeEnum)).Count(); i < count; i++)
            {
                FileTypeEnumTextOrderedList.Add(new FileTypeEnumTextOrdered() { FileType = (FileTypeEnum)i, FileTypeText = GetEnumText_FileTypeEnum((FileTypeEnum)i) });
            }

            FileTypeEnumTextOrderedList = (from c in FileTypeEnumTextOrderedList
                                              orderby c.FileTypeText
                                              select c).ToList();

            return FileTypeEnumTextOrderedList;
        }
        public List<InfrastructureTypeEnumTextOrdered> GetInfrastructureTypeEnumTextOrderedList()
        {
            List<InfrastructureTypeEnumTextOrdered> InfrastructureTypeEnumTextOrderedList = new List<InfrastructureTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(InfrastructureTypeEnum)).Count(); i < count; i++)
            {
                InfrastructureTypeEnumTextOrderedList.Add(new InfrastructureTypeEnumTextOrdered() { InfrastructureType = (InfrastructureTypeEnum)i, InfrastructureTypeText = GetEnumText_InfrastructureTypeEnum((InfrastructureTypeEnum)i) });
            }

            InfrastructureTypeEnumTextOrderedList = (from c in InfrastructureTypeEnumTextOrderedList
                                              orderby c.InfrastructureTypeText
                                              select c).ToList();

            return InfrastructureTypeEnumTextOrderedList;
        }
        public List<KMZActionEnumTextOrdered> GetKMZActionEnumTextOrderedList()
        {
            List<KMZActionEnumTextOrdered> KMZActionEnumTextOrderedList = new List<KMZActionEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(KMZActionEnum)).Count(); i < count; i++)
            {
                KMZActionEnumTextOrderedList.Add(new KMZActionEnumTextOrdered() { KMZAction = (KMZActionEnum)i, KMZActionText = GetEnumText_KMZActionEnum((KMZActionEnum)i) });
            }

            KMZActionEnumTextOrderedList = (from c in KMZActionEnumTextOrderedList
                                              orderby c.KMZActionText
                                              select c).ToList();

            return KMZActionEnumTextOrderedList;
        }
        public List<LaboratoryEnumTextOrdered> GetLaboratoryEnumTextOrderedList()
        {
            List<LaboratoryEnumTextOrdered> LaboratoryEnumTextOrderedList = new List<LaboratoryEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(LaboratoryEnum)).Count(); i < count; i++)
            {
                LaboratoryEnumTextOrderedList.Add(new LaboratoryEnumTextOrdered() { Laboratory = (LaboratoryEnum)i, LaboratoryText = GetEnumText_LaboratoryEnum((LaboratoryEnum)i) });
            }

            LaboratoryEnumTextOrderedList = (from c in LaboratoryEnumTextOrderedList
                                              orderby c.LaboratoryText
                                              select c).ToList();

            return LaboratoryEnumTextOrderedList;
        }
        public List<LabSheetStatusEnumTextOrdered> GetLabSheetStatusEnumTextOrderedList()
        {
            List<LabSheetStatusEnumTextOrdered> LabSheetStatusEnumTextOrderedList = new List<LabSheetStatusEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(LabSheetStatusEnum)).Count(); i < count; i++)
            {
                LabSheetStatusEnumTextOrderedList.Add(new LabSheetStatusEnumTextOrdered() { LabSheetStatus = (LabSheetStatusEnum)i, LabSheetStatusText = GetEnumText_LabSheetStatusEnum((LabSheetStatusEnum)i) });
            }

            LabSheetStatusEnumTextOrderedList = (from c in LabSheetStatusEnumTextOrderedList
                                              orderby c.LabSheetStatusText
                                              select c).ToList();

            return LabSheetStatusEnumTextOrderedList;
        }
        public List<LabSheetTypeEnumTextOrdered> GetLabSheetTypeEnumTextOrderedList()
        {
            List<LabSheetTypeEnumTextOrdered> LabSheetTypeEnumTextOrderedList = new List<LabSheetTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(LabSheetTypeEnum)).Count(); i < count; i++)
            {
                LabSheetTypeEnumTextOrderedList.Add(new LabSheetTypeEnumTextOrdered() { LabSheetType = (LabSheetTypeEnum)i, LabSheetTypeText = GetEnumText_LabSheetTypeEnum((LabSheetTypeEnum)i) });
            }

            LabSheetTypeEnumTextOrderedList = (from c in LabSheetTypeEnumTextOrderedList
                                              orderby c.LabSheetTypeText
                                              select c).ToList();

            return LabSheetTypeEnumTextOrderedList;
        }
        public List<LanguageEnumTextOrdered> GetLanguageEnumTextOrderedList()
        {
            List<LanguageEnumTextOrdered> LanguageEnumTextOrderedList = new List<LanguageEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(LanguageEnum)).Count(); i < count; i++)
            {
                LanguageEnumTextOrderedList.Add(new LanguageEnumTextOrdered() { Language = (LanguageEnum)i, LanguageText = GetEnumText_LanguageEnum((LanguageEnum)i) });
            }

            LanguageEnumTextOrderedList = (from c in LanguageEnumTextOrderedList
                                              orderby c.LanguageText
                                              select c).ToList();

            return LanguageEnumTextOrderedList;
        }
        public List<LogCommandEnumTextOrdered> GetLogCommandEnumTextOrderedList()
        {
            List<LogCommandEnumTextOrdered> LogCommandEnumTextOrderedList = new List<LogCommandEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(LogCommandEnum)).Count(); i < count; i++)
            {
                LogCommandEnumTextOrderedList.Add(new LogCommandEnumTextOrdered() { LogCommand = (LogCommandEnum)i, LogCommandText = GetEnumText_LogCommandEnum((LogCommandEnum)i) });
            }

            LogCommandEnumTextOrderedList = (from c in LogCommandEnumTextOrderedList
                                              orderby c.LogCommandText
                                              select c).ToList();

            return LogCommandEnumTextOrderedList;
        }
        public List<MapInfoDrawTypeEnumTextOrdered> GetMapInfoDrawTypeEnumTextOrderedList()
        {
            List<MapInfoDrawTypeEnumTextOrdered> MapInfoDrawTypeEnumTextOrderedList = new List<MapInfoDrawTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(MapInfoDrawTypeEnum)).Count(); i < count; i++)
            {
                MapInfoDrawTypeEnumTextOrderedList.Add(new MapInfoDrawTypeEnumTextOrdered() { MapInfoDrawType = (MapInfoDrawTypeEnum)i, MapInfoDrawTypeText = GetEnumText_MapInfoDrawTypeEnum((MapInfoDrawTypeEnum)i) });
            }

            MapInfoDrawTypeEnumTextOrderedList = (from c in MapInfoDrawTypeEnumTextOrderedList
                                              orderby c.MapInfoDrawTypeText
                                              select c).ToList();

            return MapInfoDrawTypeEnumTextOrderedList;
        }
        public List<MikeBoundaryConditionLevelOrVelocityEnumTextOrdered> GetMikeBoundaryConditionLevelOrVelocityEnumTextOrderedList()
        {
            List<MikeBoundaryConditionLevelOrVelocityEnumTextOrdered> MikeBoundaryConditionLevelOrVelocityEnumTextOrderedList = new List<MikeBoundaryConditionLevelOrVelocityEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(MikeBoundaryConditionLevelOrVelocityEnum)).Count(); i < count; i++)
            {
                MikeBoundaryConditionLevelOrVelocityEnumTextOrderedList.Add(new MikeBoundaryConditionLevelOrVelocityEnumTextOrdered() { MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)i, MikeBoundaryConditionLevelOrVelocityText = GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum((MikeBoundaryConditionLevelOrVelocityEnum)i) });
            }

            MikeBoundaryConditionLevelOrVelocityEnumTextOrderedList = (from c in MikeBoundaryConditionLevelOrVelocityEnumTextOrderedList
                                              orderby c.MikeBoundaryConditionLevelOrVelocityText
                                              select c).ToList();

            return MikeBoundaryConditionLevelOrVelocityEnumTextOrderedList;
        }
        public List<MikeScenarioSpecialResultKMLTypeEnumTextOrdered> GetMikeScenarioSpecialResultKMLTypeEnumTextOrderedList()
        {
            List<MikeScenarioSpecialResultKMLTypeEnumTextOrdered> MikeScenarioSpecialResultKMLTypeEnumTextOrderedList = new List<MikeScenarioSpecialResultKMLTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(MikeScenarioSpecialResultKMLTypeEnum)).Count(); i < count; i++)
            {
                MikeScenarioSpecialResultKMLTypeEnumTextOrderedList.Add(new MikeScenarioSpecialResultKMLTypeEnumTextOrdered() { MikeScenarioSpecialResultKMLType = (MikeScenarioSpecialResultKMLTypeEnum)i, MikeScenarioSpecialResultKMLTypeText = GetEnumText_MikeScenarioSpecialResultKMLTypeEnum((MikeScenarioSpecialResultKMLTypeEnum)i) });
            }

            MikeScenarioSpecialResultKMLTypeEnumTextOrderedList = (from c in MikeScenarioSpecialResultKMLTypeEnumTextOrderedList
                                              orderby c.MikeScenarioSpecialResultKMLTypeText
                                              select c).ToList();

            return MikeScenarioSpecialResultKMLTypeEnumTextOrderedList;
        }
        public List<MWQMSiteLatestClassificationEnumTextOrdered> GetMWQMSiteLatestClassificationEnumTextOrderedList()
        {
            List<MWQMSiteLatestClassificationEnumTextOrdered> MWQMSiteLatestClassificationEnumTextOrderedList = new List<MWQMSiteLatestClassificationEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(MWQMSiteLatestClassificationEnum)).Count(); i < count; i++)
            {
                MWQMSiteLatestClassificationEnumTextOrderedList.Add(new MWQMSiteLatestClassificationEnumTextOrdered() { MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)i, MWQMSiteLatestClassificationText = GetEnumText_MWQMSiteLatestClassificationEnum((MWQMSiteLatestClassificationEnum)i) });
            }

            MWQMSiteLatestClassificationEnumTextOrderedList = (from c in MWQMSiteLatestClassificationEnumTextOrderedList
                                              orderby c.MWQMSiteLatestClassificationText
                                              select c).ToList();

            return MWQMSiteLatestClassificationEnumTextOrderedList;
        }
        public List<PolSourceInactiveReasonEnumTextOrdered> GetPolSourceInactiveReasonEnumTextOrderedList()
        {
            List<PolSourceInactiveReasonEnumTextOrdered> PolSourceInactiveReasonEnumTextOrderedList = new List<PolSourceInactiveReasonEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(PolSourceInactiveReasonEnum)).Count(); i < count; i++)
            {
                PolSourceInactiveReasonEnumTextOrderedList.Add(new PolSourceInactiveReasonEnumTextOrdered() { PolSourceInactiveReason = (PolSourceInactiveReasonEnum)i, PolSourceInactiveReasonText = GetEnumText_PolSourceInactiveReasonEnum((PolSourceInactiveReasonEnum)i) });
            }

            PolSourceInactiveReasonEnumTextOrderedList = (from c in PolSourceInactiveReasonEnumTextOrderedList
                                              orderby c.PolSourceInactiveReasonText
                                              select c).ToList();

            return PolSourceInactiveReasonEnumTextOrderedList;
        }
        public List<PolSourceIssueRiskEnumTextOrdered> GetPolSourceIssueRiskEnumTextOrderedList()
        {
            List<PolSourceIssueRiskEnumTextOrdered> PolSourceIssueRiskEnumTextOrderedList = new List<PolSourceIssueRiskEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(PolSourceIssueRiskEnum)).Count(); i < count; i++)
            {
                PolSourceIssueRiskEnumTextOrderedList.Add(new PolSourceIssueRiskEnumTextOrdered() { PolSourceIssueRisk = (PolSourceIssueRiskEnum)i, PolSourceIssueRiskText = GetEnumText_PolSourceIssueRiskEnum((PolSourceIssueRiskEnum)i) });
            }

            PolSourceIssueRiskEnumTextOrderedList = (from c in PolSourceIssueRiskEnumTextOrderedList
                                              orderby c.PolSourceIssueRiskText
                                              select c).ToList();

            return PolSourceIssueRiskEnumTextOrderedList;
        }
        public List<PositionEnumTextOrdered> GetPositionEnumTextOrderedList()
        {
            List<PositionEnumTextOrdered> PositionEnumTextOrderedList = new List<PositionEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(PositionEnum)).Count(); i < count; i++)
            {
                PositionEnumTextOrderedList.Add(new PositionEnumTextOrdered() { Position = (PositionEnum)i, PositionText = GetEnumText_PositionEnum((PositionEnum)i) });
            }

            PositionEnumTextOrderedList = (from c in PositionEnumTextOrderedList
                                              orderby c.PositionText
                                              select c).ToList();

            return PositionEnumTextOrderedList;
        }
        public List<PreliminaryTreatmentTypeEnumTextOrdered> GetPreliminaryTreatmentTypeEnumTextOrderedList()
        {
            List<PreliminaryTreatmentTypeEnumTextOrdered> PreliminaryTreatmentTypeEnumTextOrderedList = new List<PreliminaryTreatmentTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(PreliminaryTreatmentTypeEnum)).Count(); i < count; i++)
            {
                PreliminaryTreatmentTypeEnumTextOrderedList.Add(new PreliminaryTreatmentTypeEnumTextOrdered() { PreliminaryTreatmentType = (PreliminaryTreatmentTypeEnum)i, PreliminaryTreatmentTypeText = GetEnumText_PreliminaryTreatmentTypeEnum((PreliminaryTreatmentTypeEnum)i) });
            }

            PreliminaryTreatmentTypeEnumTextOrderedList = (from c in PreliminaryTreatmentTypeEnumTextOrderedList
                                              orderby c.PreliminaryTreatmentTypeText
                                              select c).ToList();

            return PreliminaryTreatmentTypeEnumTextOrderedList;
        }
        public List<PrimaryTreatmentTypeEnumTextOrdered> GetPrimaryTreatmentTypeEnumTextOrderedList()
        {
            List<PrimaryTreatmentTypeEnumTextOrdered> PrimaryTreatmentTypeEnumTextOrderedList = new List<PrimaryTreatmentTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(PrimaryTreatmentTypeEnum)).Count(); i < count; i++)
            {
                PrimaryTreatmentTypeEnumTextOrderedList.Add(new PrimaryTreatmentTypeEnumTextOrdered() { PrimaryTreatmentType = (PrimaryTreatmentTypeEnum)i, PrimaryTreatmentTypeText = GetEnumText_PrimaryTreatmentTypeEnum((PrimaryTreatmentTypeEnum)i) });
            }

            PrimaryTreatmentTypeEnumTextOrderedList = (from c in PrimaryTreatmentTypeEnumTextOrderedList
                                              orderby c.PrimaryTreatmentTypeText
                                              select c).ToList();

            return PrimaryTreatmentTypeEnumTextOrderedList;
        }
        public List<ReportConditionEnumTextOrdered> GetReportConditionEnumTextOrderedList()
        {
            List<ReportConditionEnumTextOrdered> ReportConditionEnumTextOrderedList = new List<ReportConditionEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportConditionEnum)).Count(); i < count; i++)
            {
                ReportConditionEnumTextOrderedList.Add(new ReportConditionEnumTextOrdered() { ReportCondition = (ReportConditionEnum)i, ReportConditionText = GetEnumText_ReportConditionEnum((ReportConditionEnum)i) });
            }

            ReportConditionEnumTextOrderedList = (from c in ReportConditionEnumTextOrderedList
                                              orderby c.ReportConditionText
                                              select c).ToList();

            return ReportConditionEnumTextOrderedList;
        }
        public List<ReportFieldTypeEnumTextOrdered> GetReportFieldTypeEnumTextOrderedList()
        {
            List<ReportFieldTypeEnumTextOrdered> ReportFieldTypeEnumTextOrderedList = new List<ReportFieldTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportFieldTypeEnum)).Count(); i < count; i++)
            {
                ReportFieldTypeEnumTextOrderedList.Add(new ReportFieldTypeEnumTextOrdered() { ReportFieldType = (ReportFieldTypeEnum)i, ReportFieldTypeText = GetEnumText_ReportFieldTypeEnum((ReportFieldTypeEnum)i) });
            }

            ReportFieldTypeEnumTextOrderedList = (from c in ReportFieldTypeEnumTextOrderedList
                                              orderby c.ReportFieldTypeText
                                              select c).ToList();

            return ReportFieldTypeEnumTextOrderedList;
        }
        public List<ReportFileTypeEnumTextOrdered> GetReportFileTypeEnumTextOrderedList()
        {
            List<ReportFileTypeEnumTextOrdered> ReportFileTypeEnumTextOrderedList = new List<ReportFileTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportFileTypeEnum)).Count(); i < count; i++)
            {
                ReportFileTypeEnumTextOrderedList.Add(new ReportFileTypeEnumTextOrdered() { ReportFileType = (ReportFileTypeEnum)i, ReportFileTypeText = GetEnumText_ReportFileTypeEnum((ReportFileTypeEnum)i) });
            }

            ReportFileTypeEnumTextOrderedList = (from c in ReportFileTypeEnumTextOrderedList
                                              orderby c.ReportFileTypeText
                                              select c).ToList();

            return ReportFileTypeEnumTextOrderedList;
        }
        public List<ReportFormatingDateEnumTextOrdered> GetReportFormatingDateEnumTextOrderedList()
        {
            List<ReportFormatingDateEnumTextOrdered> ReportFormatingDateEnumTextOrderedList = new List<ReportFormatingDateEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportFormatingDateEnum)).Count(); i < count; i++)
            {
                ReportFormatingDateEnumTextOrderedList.Add(new ReportFormatingDateEnumTextOrdered() { ReportFormatingDate = (ReportFormatingDateEnum)i, ReportFormatingDateText = GetEnumText_ReportFormatingDateEnum((ReportFormatingDateEnum)i) });
            }

            ReportFormatingDateEnumTextOrderedList = (from c in ReportFormatingDateEnumTextOrderedList
                                              orderby c.ReportFormatingDateText
                                              select c).ToList();

            return ReportFormatingDateEnumTextOrderedList;
        }
        public List<ReportFormatingNumberEnumTextOrdered> GetReportFormatingNumberEnumTextOrderedList()
        {
            List<ReportFormatingNumberEnumTextOrdered> ReportFormatingNumberEnumTextOrderedList = new List<ReportFormatingNumberEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportFormatingNumberEnum)).Count(); i < count; i++)
            {
                ReportFormatingNumberEnumTextOrderedList.Add(new ReportFormatingNumberEnumTextOrdered() { ReportFormatingNumber = (ReportFormatingNumberEnum)i, ReportFormatingNumberText = GetEnumText_ReportFormatingNumberEnum((ReportFormatingNumberEnum)i) });
            }

            ReportFormatingNumberEnumTextOrderedList = (from c in ReportFormatingNumberEnumTextOrderedList
                                              orderby c.ReportFormatingNumberText
                                              select c).ToList();

            return ReportFormatingNumberEnumTextOrderedList;
        }
        public List<ReportGenerateObjectsKeywordEnumTextOrdered> GetReportGenerateObjectsKeywordEnumTextOrderedList()
        {
            List<ReportGenerateObjectsKeywordEnumTextOrdered> ReportGenerateObjectsKeywordEnumTextOrderedList = new List<ReportGenerateObjectsKeywordEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportGenerateObjectsKeywordEnum)).Count(); i < count; i++)
            {
                ReportGenerateObjectsKeywordEnumTextOrderedList.Add(new ReportGenerateObjectsKeywordEnumTextOrdered() { ReportGenerateObjectsKeyword = (ReportGenerateObjectsKeywordEnum)i, ReportGenerateObjectsKeywordText = GetEnumText_ReportGenerateObjectsKeywordEnum((ReportGenerateObjectsKeywordEnum)i) });
            }

            ReportGenerateObjectsKeywordEnumTextOrderedList = (from c in ReportGenerateObjectsKeywordEnumTextOrderedList
                                              orderby c.ReportGenerateObjectsKeywordText
                                              select c).ToList();

            return ReportGenerateObjectsKeywordEnumTextOrderedList;
        }
        public List<ReportSortingEnumTextOrdered> GetReportSortingEnumTextOrderedList()
        {
            List<ReportSortingEnumTextOrdered> ReportSortingEnumTextOrderedList = new List<ReportSortingEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportSortingEnum)).Count(); i < count; i++)
            {
                ReportSortingEnumTextOrderedList.Add(new ReportSortingEnumTextOrdered() { ReportSorting = (ReportSortingEnum)i, ReportSortingText = GetEnumText_ReportSortingEnum((ReportSortingEnum)i) });
            }

            ReportSortingEnumTextOrderedList = (from c in ReportSortingEnumTextOrderedList
                                              orderby c.ReportSortingText
                                              select c).ToList();

            return ReportSortingEnumTextOrderedList;
        }
        public List<ReportTreeNodeSubTypeEnumTextOrdered> GetReportTreeNodeSubTypeEnumTextOrderedList()
        {
            List<ReportTreeNodeSubTypeEnumTextOrdered> ReportTreeNodeSubTypeEnumTextOrderedList = new List<ReportTreeNodeSubTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportTreeNodeSubTypeEnum)).Count(); i < count; i++)
            {
                ReportTreeNodeSubTypeEnumTextOrderedList.Add(new ReportTreeNodeSubTypeEnumTextOrdered() { ReportTreeNodeSubType = (ReportTreeNodeSubTypeEnum)i, ReportTreeNodeSubTypeText = GetEnumText_ReportTreeNodeSubTypeEnum((ReportTreeNodeSubTypeEnum)i) });
            }

            ReportTreeNodeSubTypeEnumTextOrderedList = (from c in ReportTreeNodeSubTypeEnumTextOrderedList
                                              orderby c.ReportTreeNodeSubTypeText
                                              select c).ToList();

            return ReportTreeNodeSubTypeEnumTextOrderedList;
        }
        public List<ReportTreeNodeTypeEnumTextOrdered> GetReportTreeNodeTypeEnumTextOrderedList()
        {
            List<ReportTreeNodeTypeEnumTextOrdered> ReportTreeNodeTypeEnumTextOrderedList = new List<ReportTreeNodeTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ReportTreeNodeTypeEnum)).Count(); i < count; i++)
            {
                ReportTreeNodeTypeEnumTextOrderedList.Add(new ReportTreeNodeTypeEnumTextOrdered() { ReportTreeNodeType = (ReportTreeNodeTypeEnum)i, ReportTreeNodeTypeText = GetEnumText_ReportTreeNodeTypeEnum((ReportTreeNodeTypeEnum)i) });
            }

            ReportTreeNodeTypeEnumTextOrderedList = (from c in ReportTreeNodeTypeEnumTextOrderedList
                                              orderby c.ReportTreeNodeTypeText
                                              select c).ToList();

            return ReportTreeNodeTypeEnumTextOrderedList;
        }
        public List<SameDayNextDayEnumTextOrdered> GetSameDayNextDayEnumTextOrderedList()
        {
            List<SameDayNextDayEnumTextOrdered> SameDayNextDayEnumTextOrderedList = new List<SameDayNextDayEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(SameDayNextDayEnum)).Count(); i < count; i++)
            {
                SameDayNextDayEnumTextOrderedList.Add(new SameDayNextDayEnumTextOrdered() { SameDayNextDay = (SameDayNextDayEnum)i, SameDayNextDayText = GetEnumText_SameDayNextDayEnum((SameDayNextDayEnum)i) });
            }

            SameDayNextDayEnumTextOrderedList = (from c in SameDayNextDayEnumTextOrderedList
                                              orderby c.SameDayNextDayText
                                              select c).ToList();

            return SameDayNextDayEnumTextOrderedList;
        }
        public List<SampleMatrixEnumTextOrdered> GetSampleMatrixEnumTextOrderedList()
        {
            List<SampleMatrixEnumTextOrdered> SampleMatrixEnumTextOrderedList = new List<SampleMatrixEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(SampleMatrixEnum)).Count(); i < count; i++)
            {
                SampleMatrixEnumTextOrderedList.Add(new SampleMatrixEnumTextOrdered() { SampleMatrix = (SampleMatrixEnum)i, SampleMatrixText = GetEnumText_SampleMatrixEnum((SampleMatrixEnum)i) });
            }

            SampleMatrixEnumTextOrderedList = (from c in SampleMatrixEnumTextOrderedList
                                              orderby c.SampleMatrixText
                                              select c).ToList();

            return SampleMatrixEnumTextOrderedList;
        }
        public List<SampleStatusEnumTextOrdered> GetSampleStatusEnumTextOrderedList()
        {
            List<SampleStatusEnumTextOrdered> SampleStatusEnumTextOrderedList = new List<SampleStatusEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(SampleStatusEnum)).Count(); i < count; i++)
            {
                SampleStatusEnumTextOrderedList.Add(new SampleStatusEnumTextOrdered() { SampleStatus = (SampleStatusEnum)i, SampleStatusText = GetEnumText_SampleStatusEnum((SampleStatusEnum)i) });
            }

            SampleStatusEnumTextOrderedList = (from c in SampleStatusEnumTextOrderedList
                                              orderby c.SampleStatusText
                                              select c).ToList();

            return SampleStatusEnumTextOrderedList;
        }
        public List<SampleTypeEnumTextOrdered> GetSampleTypeEnumTextOrderedList()
        {
            List<SampleTypeEnumTextOrdered> SampleTypeEnumTextOrderedList = new List<SampleTypeEnumTextOrdered>();

            for (int i = 101, count = Enum.GetNames(typeof(SampleTypeEnum)).Count() + 100; i < count; i++)
            {
                SampleTypeEnumTextOrderedList.Add(new SampleTypeEnumTextOrdered() { SampleType = (SampleTypeEnum)i, SampleTypeText = GetEnumText_SampleTypeEnum((SampleTypeEnum)i) });
            }

            SampleTypeEnumTextOrderedList = (from c in SampleTypeEnumTextOrderedList
                                              orderby c.SampleTypeText
                                              select c).ToList();

            return SampleTypeEnumTextOrderedList;
        }
        public List<SamplingPlanTypeEnumTextOrdered> GetSamplingPlanTypeEnumTextOrderedList()
        {
            List<SamplingPlanTypeEnumTextOrdered> SamplingPlanTypeEnumTextOrderedList = new List<SamplingPlanTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(SamplingPlanTypeEnum)).Count(); i < count; i++)
            {
                SamplingPlanTypeEnumTextOrderedList.Add(new SamplingPlanTypeEnumTextOrdered() { SamplingPlanType = (SamplingPlanTypeEnum)i, SamplingPlanTypeText = GetEnumText_SamplingPlanTypeEnum((SamplingPlanTypeEnum)i) });
            }

            SamplingPlanTypeEnumTextOrderedList = (from c in SamplingPlanTypeEnumTextOrderedList
                                              orderby c.SamplingPlanTypeText
                                              select c).ToList();

            return SamplingPlanTypeEnumTextOrderedList;
        }
        public List<ScenarioStatusEnumTextOrdered> GetScenarioStatusEnumTextOrderedList()
        {
            List<ScenarioStatusEnumTextOrdered> ScenarioStatusEnumTextOrderedList = new List<ScenarioStatusEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(ScenarioStatusEnum)).Count(); i < count; i++)
            {
                ScenarioStatusEnumTextOrderedList.Add(new ScenarioStatusEnumTextOrdered() { ScenarioStatus = (ScenarioStatusEnum)i, ScenarioStatusText = GetEnumText_ScenarioStatusEnum((ScenarioStatusEnum)i) });
            }

            ScenarioStatusEnumTextOrderedList = (from c in ScenarioStatusEnumTextOrderedList
                                              orderby c.ScenarioStatusText
                                              select c).ToList();

            return ScenarioStatusEnumTextOrderedList;
        }
        public List<SearchTagEnumTextOrdered> GetSearchTagEnumTextOrderedList()
        {
            List<SearchTagEnumTextOrdered> SearchTagEnumTextOrderedList = new List<SearchTagEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(SearchTagEnum)).Count(); i < count; i++)
            {
                SearchTagEnumTextOrderedList.Add(new SearchTagEnumTextOrdered() { SearchTag = (SearchTagEnum)i, SearchTagText = GetEnumText_SearchTagEnum((SearchTagEnum)i) });
            }

            SearchTagEnumTextOrderedList = (from c in SearchTagEnumTextOrderedList
                                              orderby c.SearchTagText
                                              select c).ToList();

            return SearchTagEnumTextOrderedList;
        }
        public List<SecondaryTreatmentTypeEnumTextOrdered> GetSecondaryTreatmentTypeEnumTextOrderedList()
        {
            List<SecondaryTreatmentTypeEnumTextOrdered> SecondaryTreatmentTypeEnumTextOrderedList = new List<SecondaryTreatmentTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(SecondaryTreatmentTypeEnum)).Count(); i < count; i++)
            {
                SecondaryTreatmentTypeEnumTextOrderedList.Add(new SecondaryTreatmentTypeEnumTextOrdered() { SecondaryTreatmentType = (SecondaryTreatmentTypeEnum)i, SecondaryTreatmentTypeText = GetEnumText_SecondaryTreatmentTypeEnum((SecondaryTreatmentTypeEnum)i) });
            }

            SecondaryTreatmentTypeEnumTextOrderedList = (from c in SecondaryTreatmentTypeEnumTextOrderedList
                                              orderby c.SecondaryTreatmentTypeText
                                              select c).ToList();

            return SecondaryTreatmentTypeEnumTextOrderedList;
        }
        public List<SpecialTableTypeEnumTextOrdered> GetSpecialTableTypeEnumTextOrderedList()
        {
            List<SpecialTableTypeEnumTextOrdered> SpecialTableTypeEnumTextOrderedList = new List<SpecialTableTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(SpecialTableTypeEnum)).Count(); i < count; i++)
            {
                SpecialTableTypeEnumTextOrderedList.Add(new SpecialTableTypeEnumTextOrdered() { SpecialTableType = (SpecialTableTypeEnum)i, SpecialTableTypeText = GetEnumText_SpecialTableTypeEnum((SpecialTableTypeEnum)i) });
            }

            SpecialTableTypeEnumTextOrderedList = (from c in SpecialTableTypeEnumTextOrderedList
                                              orderby c.SpecialTableTypeText
                                              select c).ToList();

            return SpecialTableTypeEnumTextOrderedList;
        }
        public List<StorageDataTypeEnumTextOrdered> GetStorageDataTypeEnumTextOrderedList()
        {
            List<StorageDataTypeEnumTextOrdered> StorageDataTypeEnumTextOrderedList = new List<StorageDataTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(StorageDataTypeEnum)).Count(); i < count; i++)
            {
                StorageDataTypeEnumTextOrderedList.Add(new StorageDataTypeEnumTextOrdered() { StorageDataType = (StorageDataTypeEnum)i, StorageDataTypeText = GetEnumText_StorageDataTypeEnum((StorageDataTypeEnum)i) });
            }

            StorageDataTypeEnumTextOrderedList = (from c in StorageDataTypeEnumTextOrderedList
                                              orderby c.StorageDataTypeText
                                              select c).ToList();

            return StorageDataTypeEnumTextOrderedList;
        }
        public List<StreetTypeEnumTextOrdered> GetStreetTypeEnumTextOrderedList()
        {
            List<StreetTypeEnumTextOrdered> StreetTypeEnumTextOrderedList = new List<StreetTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(StreetTypeEnum)).Count(); i < count; i++)
            {
                StreetTypeEnumTextOrderedList.Add(new StreetTypeEnumTextOrdered() { StreetType = (StreetTypeEnum)i, StreetTypeText = GetEnumText_StreetTypeEnum((StreetTypeEnum)i) });
            }

            StreetTypeEnumTextOrderedList = (from c in StreetTypeEnumTextOrderedList
                                              orderby c.StreetTypeText
                                              select c).ToList();

            return StreetTypeEnumTextOrderedList;
        }
        public List<TelTypeEnumTextOrdered> GetTelTypeEnumTextOrderedList()
        {
            List<TelTypeEnumTextOrdered> TelTypeEnumTextOrderedList = new List<TelTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(TelTypeEnum)).Count(); i < count; i++)
            {
                TelTypeEnumTextOrderedList.Add(new TelTypeEnumTextOrdered() { TelType = (TelTypeEnum)i, TelTypeText = GetEnumText_TelTypeEnum((TelTypeEnum)i) });
            }

            TelTypeEnumTextOrderedList = (from c in TelTypeEnumTextOrderedList
                                              orderby c.TelTypeText
                                              select c).ToList();

            return TelTypeEnumTextOrderedList;
        }
        public List<TertiaryTreatmentTypeEnumTextOrdered> GetTertiaryTreatmentTypeEnumTextOrderedList()
        {
            List<TertiaryTreatmentTypeEnumTextOrdered> TertiaryTreatmentTypeEnumTextOrderedList = new List<TertiaryTreatmentTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(TertiaryTreatmentTypeEnum)).Count(); i < count; i++)
            {
                TertiaryTreatmentTypeEnumTextOrderedList.Add(new TertiaryTreatmentTypeEnumTextOrdered() { TertiaryTreatmentType = (TertiaryTreatmentTypeEnum)i, TertiaryTreatmentTypeText = GetEnumText_TertiaryTreatmentTypeEnum((TertiaryTreatmentTypeEnum)i) });
            }

            TertiaryTreatmentTypeEnumTextOrderedList = (from c in TertiaryTreatmentTypeEnumTextOrderedList
                                              orderby c.TertiaryTreatmentTypeText
                                              select c).ToList();

            return TertiaryTreatmentTypeEnumTextOrderedList;
        }
        public List<TideDataTypeEnumTextOrdered> GetTideDataTypeEnumTextOrderedList()
        {
            List<TideDataTypeEnumTextOrdered> TideDataTypeEnumTextOrderedList = new List<TideDataTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(TideDataTypeEnum)).Count(); i < count; i++)
            {
                TideDataTypeEnumTextOrderedList.Add(new TideDataTypeEnumTextOrdered() { TideDataType = (TideDataTypeEnum)i, TideDataTypeText = GetEnumText_TideDataTypeEnum((TideDataTypeEnum)i) });
            }

            TideDataTypeEnumTextOrderedList = (from c in TideDataTypeEnumTextOrderedList
                                              orderby c.TideDataTypeText
                                              select c).ToList();

            return TideDataTypeEnumTextOrderedList;
        }
        public List<TideTextEnumTextOrdered> GetTideTextEnumTextOrderedList()
        {
            List<TideTextEnumTextOrdered> TideTextEnumTextOrderedList = new List<TideTextEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(TideTextEnum)).Count(); i < count; i++)
            {
                TideTextEnumTextOrderedList.Add(new TideTextEnumTextOrdered() { TideText = (TideTextEnum)i, TideTextText = GetEnumText_TideTextEnum((TideTextEnum)i) });
            }

            TideTextEnumTextOrderedList = (from c in TideTextEnumTextOrderedList
                                              orderby c.TideTextText
                                              select c).ToList();

            return TideTextEnumTextOrderedList;
        }
        public List<TranslationStatusEnumTextOrdered> GetTranslationStatusEnumTextOrderedList()
        {
            List<TranslationStatusEnumTextOrdered> TranslationStatusEnumTextOrderedList = new List<TranslationStatusEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(TranslationStatusEnum)).Count(); i < count; i++)
            {
                TranslationStatusEnumTextOrderedList.Add(new TranslationStatusEnumTextOrdered() { TranslationStatus = (TranslationStatusEnum)i, TranslationStatusText = GetEnumText_TranslationStatusEnum((TranslationStatusEnum)i) });
            }

            TranslationStatusEnumTextOrderedList = (from c in TranslationStatusEnumTextOrderedList
                                              orderby c.TranslationStatusText
                                              select c).ToList();

            return TranslationStatusEnumTextOrderedList;
        }
        public List<TreatmentTypeEnumTextOrdered> GetTreatmentTypeEnumTextOrderedList()
        {
            List<TreatmentTypeEnumTextOrdered> TreatmentTypeEnumTextOrderedList = new List<TreatmentTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(TreatmentTypeEnum)).Count(); i < count; i++)
            {
                TreatmentTypeEnumTextOrderedList.Add(new TreatmentTypeEnumTextOrdered() { TreatmentType = (TreatmentTypeEnum)i, TreatmentTypeText = GetEnumText_TreatmentTypeEnum((TreatmentTypeEnum)i) });
            }

            TreatmentTypeEnumTextOrderedList = (from c in TreatmentTypeEnumTextOrderedList
                                              orderby c.TreatmentTypeText
                                              select c).ToList();

            return TreatmentTypeEnumTextOrderedList;
        }
        public List<TVAuthEnumTextOrdered> GetTVAuthEnumTextOrderedList()
        {
            List<TVAuthEnumTextOrdered> TVAuthEnumTextOrderedList = new List<TVAuthEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(TVAuthEnum)).Count(); i < count; i++)
            {
                TVAuthEnumTextOrderedList.Add(new TVAuthEnumTextOrdered() { TVAuth = (TVAuthEnum)i, TVAuthText = GetEnumText_TVAuthEnum((TVAuthEnum)i) });
            }

            TVAuthEnumTextOrderedList = (from c in TVAuthEnumTextOrderedList
                                              orderby c.TVAuthText
                                              select c).ToList();

            return TVAuthEnumTextOrderedList;
        }
        public List<TVTypeEnumTextOrdered> GetTVTypeEnumTextOrderedList()
        {
            List<TVTypeEnumTextOrdered> TVTypeEnumTextOrderedList = new List<TVTypeEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(TVTypeEnum)).Count(); i < count; i++)
            {
                TVTypeEnumTextOrderedList.Add(new TVTypeEnumTextOrdered() { TVType = (TVTypeEnum)i, TVTypeText = GetEnumText_TVTypeEnum((TVTypeEnum)i) });
            }

            TVTypeEnumTextOrderedList = (from c in TVTypeEnumTextOrderedList
                                              orderby c.TVTypeText
                                              select c).ToList();

            return TVTypeEnumTextOrderedList;
        }
        public List<WebTideDataSetEnumTextOrdered> GetWebTideDataSetEnumTextOrderedList()
        {
            List<WebTideDataSetEnumTextOrdered> WebTideDataSetEnumTextOrderedList = new List<WebTideDataSetEnumTextOrdered>();

            for (int i = 1, count = Enum.GetNames(typeof(WebTideDataSetEnum)).Count(); i < count; i++)
            {
                WebTideDataSetEnumTextOrderedList.Add(new WebTideDataSetEnumTextOrdered() { WebTideDataSet = (WebTideDataSetEnum)i, WebTideDataSetText = GetEnumText_WebTideDataSetEnum((WebTideDataSetEnum)i) });
            }

            WebTideDataSetEnumTextOrderedList = (from c in WebTideDataSetEnumTextOrderedList
                                              orderby c.WebTideDataSetText
                                              select c).ToList();

            return WebTideDataSetEnumTextOrderedList;
        }

        #endregion Function Get Enum Text Ordered

        #region Enum CheckOK
        public string AddressTypeOK(AddressTypeEnum? addressType)
        {
            if (addressType == null)
                return "";

            switch ((AddressTypeEnum)addressType)
            {
                case AddressTypeEnum.Error:
                case AddressTypeEnum.Mailing:
                case AddressTypeEnum.Shipping:
                case AddressTypeEnum.Civic:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AddressType);
            }
        }
        public string AerationTypeOK(AerationTypeEnum? aerationType)
        {
            if (aerationType == null)
                return "";

            switch ((AerationTypeEnum)aerationType)
            {
                case AerationTypeEnum.Error:
                case AerationTypeEnum.MechanicalAirLines:
                case AerationTypeEnum.MechanicalSurfaceMixers:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AerationType);
            }
        }
        public string AlarmSystemTypeOK(AlarmSystemTypeEnum? alarmSystemType)
        {
            if (alarmSystemType == null)
                return "";

            switch ((AlarmSystemTypeEnum)alarmSystemType)
            {
                case AlarmSystemTypeEnum.Error:
                case AlarmSystemTypeEnum.SCADA:
                case AlarmSystemTypeEnum.None:
                case AlarmSystemTypeEnum.OnlyVisualLight:
                case AlarmSystemTypeEnum.SCADAAndLight:
                case AlarmSystemTypeEnum.PagerAndLight:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AlarmSystemType);
            }
        }
        public string AnalysisCalculationTypeOK(AnalysisCalculationTypeEnum? analysisCalculationType)
        {
            if (analysisCalculationType == null)
                return "";

            switch ((AnalysisCalculationTypeEnum)analysisCalculationType)
            {
                case AnalysisCalculationTypeEnum.Error:
                case AnalysisCalculationTypeEnum.AllAllAll:
                case AnalysisCalculationTypeEnum.WetAllAll:
                case AnalysisCalculationTypeEnum.DryAllAll:
                case AnalysisCalculationTypeEnum.WetWetAll:
                case AnalysisCalculationTypeEnum.DryDryAll:
                case AnalysisCalculationTypeEnum.WetDryAll:
                case AnalysisCalculationTypeEnum.DryWetAll:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalysisCalculationType);
            }
        }
        public string AnalysisReportExportCommandOK(AnalysisReportExportCommandEnum? analysisReportExportCommand)
        {
            if (analysisReportExportCommand == null)
                return "";

            switch ((AnalysisReportExportCommandEnum)analysisReportExportCommand)
            {
                case AnalysisReportExportCommandEnum.Error:
                case AnalysisReportExportCommandEnum.Report:
                case AnalysisReportExportCommandEnum.Excel:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalysisReportExportCommand);
            }
        }
        public string AnalyzeMethodOK(AnalyzeMethodEnum? analyzeMethod)
        {
            if (analyzeMethod == null)
                return "";

            switch ((AnalyzeMethodEnum)analyzeMethod)
            {
                case AnalyzeMethodEnum.Error:
                case AnalyzeMethodEnum.MF:
                case AnalyzeMethodEnum.ZZ_510Q:
                case AnalyzeMethodEnum.ZZ_509Q:
                case AnalyzeMethodEnum.ZZ_0:
                case AnalyzeMethodEnum.ZZ_525Q:
                case AnalyzeMethodEnum.MPN:
                case AnalyzeMethodEnum.ZZ_0Q:
                case AnalyzeMethodEnum.AnalyzeMethod8:
                case AnalyzeMethodEnum.AnalyzeMethod9:
                case AnalyzeMethodEnum.AnalyzeMethod10:
                case AnalyzeMethodEnum.AnalyzeMethod11:
                case AnalyzeMethodEnum.AnalyzeMethod12:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalyzeMethod);
            }
        }
        public string AppTaskCommandOK(AppTaskCommandEnum? appTaskCommand)
        {
            if (appTaskCommand == null)
                return "";

            switch ((AppTaskCommandEnum)appTaskCommand)
            {
                case AppTaskCommandEnum.Error:
                case AppTaskCommandEnum.GenerateWebTide:
                case AppTaskCommandEnum.MikeScenarioAskToRun:
                case AppTaskCommandEnum.MikeScenarioImport:
                case AppTaskCommandEnum.MikeScenarioOtherFileImport:
                case AppTaskCommandEnum.MikeScenarioRunning:
                case AppTaskCommandEnum.MikeScenarioToCancel:
                case AppTaskCommandEnum.MikeScenarioWaitingToRun:
                case AppTaskCommandEnum.SetupWebTide:
                case AppTaskCommandEnum.UpdateClimateSiteInformation:
                case AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyFromStartDateToEndDate:
                case AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate:
                case AppTaskCommandEnum.CreateFCForm:
                case AppTaskCommandEnum.CreateSamplingPlanSamplingPlanTextFile:
                case AppTaskCommandEnum.CreateDocumentFromTemplate:
                case AppTaskCommandEnum.GetClimateSitesDataForRunsOfYear:
                case AppTaskCommandEnum.CreateWebTideDataWLAtFirstNode:
                case AppTaskCommandEnum.ExportEmailDistributionLists:
                case AppTaskCommandEnum.ExportAnalysisToExcel:
                case AppTaskCommandEnum.CreateDocumentFromParameters:
                case AppTaskCommandEnum.CreateDocxPDF:
                case AppTaskCommandEnum.CreateXlsxPDF:
                case AppTaskCommandEnum.OpenDataCSVOfMWQMSites:
                case AppTaskCommandEnum.OpenDataKMZOfMWQMSites:
                case AppTaskCommandEnum.OpenDataXlsxOfMWQMSitesAndSamples:
                case AppTaskCommandEnum.OpenDataCSVOfMWQMSamples:
                case AppTaskCommandEnum.GetAllPrecipitationForYear:
                case AppTaskCommandEnum.FillRunPrecipByClimateSitePriorityForYear:
                case AppTaskCommandEnum.FindMissingPrecipForProvince:
                case AppTaskCommandEnum.ExportToArcGIS:
                case AppTaskCommandEnum.GenerateClassificationForCSSPWebToolsVisualization:
                case AppTaskCommandEnum.GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization:
                case AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSites:
                case AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSamples:
                case AppTaskCommandEnum.ProvinceToolsCreateClassificationInputsKML:
                case AppTaskCommandEnum.ProvinceToolsCreateGroupingInputsKML:
                case AppTaskCommandEnum.ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML:
                case AppTaskCommandEnum.UpdateHydrometricSiteInformation:
                case AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate:
                case AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate:
                case AppTaskCommandEnum.GetHydrometricSitesDataForRunsOfYear:
                case AppTaskCommandEnum.GetAllDischargesForYear:
                case AppTaskCommandEnum.FillRunDischargesByHydrometricSitePriorityForYear:
                case AppTaskCommandEnum.FindMissingDischargesForProvince:
                case AppTaskCommandEnum.LoadHydrometricDataValue:
                case AppTaskCommandEnum.GenerateKMLFileClassificationForCSSPWebToolsVisualization:
                case AppTaskCommandEnum.ProvinceToolsGenerateStats:
                case AppTaskCommandEnum.MikeScenarioPrepareResults:
                case AppTaskCommandEnum.ClimateSiteLoadCoCoRaHSData:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AppTaskCommand);
            }
        }
        public string AppTaskStatusOK(AppTaskStatusEnum? appTaskStatus)
        {
            if (appTaskStatus == null)
                return "";

            switch ((AppTaskStatusEnum)appTaskStatus)
            {
                case AppTaskStatusEnum.Error:
                case AppTaskStatusEnum.Created:
                case AppTaskStatusEnum.Running:
                case AppTaskStatusEnum.Completed:
                case AppTaskStatusEnum.Cancelled:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AppTaskStatus);
            }
        }
        public string BeaufortScaleOK(BeaufortScaleEnum? beaufortScale)
        {
            if (beaufortScale == null)
                return "";

            switch ((BeaufortScaleEnum)beaufortScale)
            {
                case BeaufortScaleEnum.Error:
                case BeaufortScaleEnum.Calm:
                case BeaufortScaleEnum.LightAir:
                case BeaufortScaleEnum.LightBreeze:
                case BeaufortScaleEnum.GentleBreeze:
                case BeaufortScaleEnum.ModerateBreeze:
                case BeaufortScaleEnum.FreshBreeze:
                case BeaufortScaleEnum.StrongBreeze:
                case BeaufortScaleEnum.HighWind_ModerateGale_NearGale:
                case BeaufortScaleEnum.Gale_FreshGale:
                case BeaufortScaleEnum.Strong_SevereGale:
                case BeaufortScaleEnum.Storm_WholeGale:
                case BeaufortScaleEnum.ViolentStorm:
                case BeaufortScaleEnum.HurricaneForce:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.BeaufortScale);
            }
        }
        public string BoxModelResultTypeOK(BoxModelResultTypeEnum? boxModelResultType)
        {
            if (boxModelResultType == null)
                return "";

            switch ((BoxModelResultTypeEnum)boxModelResultType)
            {
                case BoxModelResultTypeEnum.Error:
                case BoxModelResultTypeEnum.Dilution:
                case BoxModelResultTypeEnum.NoDecayUntreated:
                case BoxModelResultTypeEnum.NoDecayPreDisinfection:
                case BoxModelResultTypeEnum.DecayUntreated:
                case BoxModelResultTypeEnum.DecayPreDisinfection:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.BoxModelResultType);
            }
        }
        public string ClassificationTypeOK(ClassificationTypeEnum? classificationType)
        {
            if (classificationType == null)
                return "";

            switch ((ClassificationTypeEnum)classificationType)
            {
                case ClassificationTypeEnum.Error:
                case ClassificationTypeEnum.Approved:
                case ClassificationTypeEnum.Restricted:
                case ClassificationTypeEnum.Prohibited:
                case ClassificationTypeEnum.ConditionallyApproved:
                case ClassificationTypeEnum.ConditionallyRestricted:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ClassificationType);
            }
        }
        public string CollectionSystemTypeOK(CollectionSystemTypeEnum? collectionSystemType)
        {
            if (collectionSystemType == null)
                return "";

            switch ((CollectionSystemTypeEnum)collectionSystemType)
            {
                case CollectionSystemTypeEnum.Error:
                case CollectionSystemTypeEnum.CompletelySeparated:
                case CollectionSystemTypeEnum.CompletelyCombined:
                case CollectionSystemTypeEnum.Combined90Separated10:
                case CollectionSystemTypeEnum.Combined80Separated20:
                case CollectionSystemTypeEnum.Combined70Separated30:
                case CollectionSystemTypeEnum.Combined60Separated40:
                case CollectionSystemTypeEnum.Combined50Separated50:
                case CollectionSystemTypeEnum.Combined40Separated60:
                case CollectionSystemTypeEnum.Combined30Separated70:
                case CollectionSystemTypeEnum.Combined20Separated80:
                case CollectionSystemTypeEnum.Combined10Separated90:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CollectionSystemType);
            }
        }
        public string ContactTitleOK(ContactTitleEnum? contactTitle)
        {
            if (contactTitle == null)
                return "";

            switch ((ContactTitleEnum)contactTitle)
            {
                case ContactTitleEnum.Error:
                case ContactTitleEnum.DirectorGeneral:
                case ContactTitleEnum.DirectorPublicWorks:
                case ContactTitleEnum.Superintendent:
                case ContactTitleEnum.Engineer:
                case ContactTitleEnum.Foreman:
                case ContactTitleEnum.Operator:
                case ContactTitleEnum.FacilitiesManager:
                case ContactTitleEnum.Supervisor:
                case ContactTitleEnum.Technician:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ContactTitle);
            }
        }
        public string CSSPWQInputSheetTypeOK(CSSPWQInputSheetTypeEnum? cSSPWQInputSheetType)
        {
            if (cSSPWQInputSheetType == null)
                return "";

            switch ((CSSPWQInputSheetTypeEnum)cSSPWQInputSheetType)
            {
                case CSSPWQInputSheetTypeEnum.Error:
                case CSSPWQInputSheetTypeEnum.A1:
                case CSSPWQInputSheetTypeEnum.LTB:
                case CSSPWQInputSheetTypeEnum.EC:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CSSPWQInputSheetType);
            }
        }
        public string CSSPWQInputTypeOK(CSSPWQInputTypeEnum? cSSPWQInputType)
        {
            if (cSSPWQInputType == null)
                return "";

            switch ((CSSPWQInputTypeEnum)cSSPWQInputType)
            {
                case CSSPWQInputTypeEnum.Error:
                case CSSPWQInputTypeEnum.Subsector:
                case CSSPWQInputTypeEnum.Municipality:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CSSPWQInputType);
            }
        }
        public string DailyOrHourlyDataOK(DailyOrHourlyDataEnum? dailyOrHourlyData)
        {
            if (dailyOrHourlyData == null)
                return "";

            switch ((DailyOrHourlyDataEnum)dailyOrHourlyData)
            {
                case DailyOrHourlyDataEnum.Error:
                case DailyOrHourlyDataEnum.Daily:
                case DailyOrHourlyDataEnum.Hourly:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DailyOrHourlyData);
            }
        }
        public string DisinfectionTypeOK(DisinfectionTypeEnum? disinfectionType)
        {
            if (disinfectionType == null)
                return "";

            switch ((DisinfectionTypeEnum)disinfectionType)
            {
                case DisinfectionTypeEnum.Error:
                case DisinfectionTypeEnum.None:
                case DisinfectionTypeEnum.UV:
                case DisinfectionTypeEnum.ChlorinationNoDechlorination:
                case DisinfectionTypeEnum.ChlorinationWithDechlorination:
                case DisinfectionTypeEnum.UVSeasonal:
                case DisinfectionTypeEnum.ChlorinationNoDechlorinationSeasonal:
                case DisinfectionTypeEnum.ChlorinationWithDechlorinationSeasonal:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DisinfectionType);
            }
        }
        public string DrogueTypeOK(DrogueTypeEnum? drogueType)
        {
            if (drogueType == null)
                return "";

            switch ((DrogueTypeEnum)drogueType)
            {
                case DrogueTypeEnum.Error:
                case DrogueTypeEnum.SmallDrogue:
                case DrogueTypeEnum.LargeDrogue:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DrogueType);
            }
        }
        public string EmailTypeOK(EmailTypeEnum? emailType)
        {
            if (emailType == null)
                return "";

            switch ((EmailTypeEnum)emailType)
            {
                case EmailTypeEnum.Error:
                case EmailTypeEnum.Personal:
                case EmailTypeEnum.Work:
                case EmailTypeEnum.Personal2:
                case EmailTypeEnum.Work2:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.EmailType);
            }
        }
        public string ExcelExportShowDataTypeOK(ExcelExportShowDataTypeEnum? excelExportShowDataType)
        {
            if (excelExportShowDataType == null)
                return "";

            switch ((ExcelExportShowDataTypeEnum)excelExportShowDataType)
            {
                case ExcelExportShowDataTypeEnum.Error:
                case ExcelExportShowDataTypeEnum.FecalColiform:
                case ExcelExportShowDataTypeEnum.Temperature:
                case ExcelExportShowDataTypeEnum.Salinity:
                case ExcelExportShowDataTypeEnum.P90:
                case ExcelExportShowDataTypeEnum.GemetricMean:
                case ExcelExportShowDataTypeEnum.Median:
                case ExcelExportShowDataTypeEnum.PercOfP90Over43:
                case ExcelExportShowDataTypeEnum.PercOfP90Over260:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ExcelExportShowDataType);
            }
        }
        public string FacilityTypeOK(FacilityTypeEnum? facilityType)
        {
            if (facilityType == null)
                return "";

            switch ((FacilityTypeEnum)facilityType)
            {
                case FacilityTypeEnum.Error:
                case FacilityTypeEnum.Lagoon:
                case FacilityTypeEnum.Plant:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FacilityType);
            }
        }
        public string FilePurposeOK(FilePurposeEnum? filePurpose)
        {
            if (filePurpose == null)
                return "";

            switch ((FilePurposeEnum)filePurpose)
            {
                case FilePurposeEnum.Error:
                case FilePurposeEnum.MikeInput:
                case FilePurposeEnum.MikeInputMDF:
                case FilePurposeEnum.MikeResultDFSU:
                case FilePurposeEnum.MikeResultKMZ:
                case FilePurposeEnum.Information:
                case FilePurposeEnum.Image:
                case FilePurposeEnum.Picture:
                case FilePurposeEnum.ReportGenerated:
                case FilePurposeEnum.TemplateGenerated:
                case FilePurposeEnum.GeneratedFCForm:
                case FilePurposeEnum.Template:
                case FilePurposeEnum.Map:
                case FilePurposeEnum.Analysis:
                case FilePurposeEnum.OpenData:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FilePurpose);
            }
        }
        public string FileStatusOK(FileStatusEnum? fileStatus)
        {
            if (fileStatus == null)
                return "";

            switch ((FileStatusEnum)fileStatus)
            {
                case FileStatusEnum.Error:
                case FileStatusEnum.Changed:
                case FileStatusEnum.Sent:
                case FileStatusEnum.Accepted:
                case FileStatusEnum.Rejected:
                case FileStatusEnum.Fail:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FileStatus);
            }
        }
        public string FileTypeOK(FileTypeEnum? fileType)
        {
            if (fileType == null)
                return "";

            switch ((FileTypeEnum)fileType)
            {
                case FileTypeEnum.Error:
                case FileTypeEnum.DFS0:
                case FileTypeEnum.DFS1:
                case FileTypeEnum.DFSU:
                case FileTypeEnum.KMZ:
                case FileTypeEnum.LOG:
                case FileTypeEnum.M21FM:
                case FileTypeEnum.M3FM:
                case FileTypeEnum.MDF:
                case FileTypeEnum.MESH:
                case FileTypeEnum.XLSX:
                case FileTypeEnum.DOCX:
                case FileTypeEnum.PDF:
                case FileTypeEnum.JPG:
                case FileTypeEnum.JPEG:
                case FileTypeEnum.GIF:
                case FileTypeEnum.PNG:
                case FileTypeEnum.HTML:
                case FileTypeEnum.TXT:
                case FileTypeEnum.XYZ:
                case FileTypeEnum.KML:
                case FileTypeEnum.CSV:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FileType);
            }
        }
        public string InfrastructureTypeOK(InfrastructureTypeEnum? infrastructureType)
        {
            if (infrastructureType == null)
                return "";

            switch ((InfrastructureTypeEnum)infrastructureType)
            {
                case InfrastructureTypeEnum.Error:
                case InfrastructureTypeEnum.WWTP:
                case InfrastructureTypeEnum.LiftStation:
                case InfrastructureTypeEnum.Other:
                case InfrastructureTypeEnum.SeeOtherMunicipality:
                case InfrastructureTypeEnum.LineOverflow:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.InfrastructureType);
            }
        }
        public string KMZActionOK(KMZActionEnum? kMZAction)
        {
            if (kMZAction == null)
                return "";

            switch ((KMZActionEnum)kMZAction)
            {
                case KMZActionEnum.Error:
                case KMZActionEnum.DoNothing:
                case KMZActionEnum.GenerateKMZContourAnimation:
                case KMZActionEnum.GenerateKMZContourLimit:
                case KMZActionEnum.GenerateKMZCurrentAnimation:
                case KMZActionEnum.GenerateKMZCurrentMaximum:
                case KMZActionEnum.GenerateKMZMesh:
                case KMZActionEnum.GenerateKMZStudyArea:
                case KMZActionEnum.GenerateKMZBoundaryConditionNodes:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.KMZAction);
            }
        }
        public string LaboratoryOK(LaboratoryEnum? laboratory)
        {
            if (laboratory == null)
                return "";

            switch ((LaboratoryEnum)laboratory)
            {
                case LaboratoryEnum.Error:
                case LaboratoryEnum.ZZ_0:
                case LaboratoryEnum.ZZ_1:
                case LaboratoryEnum.ZZ_2:
                case LaboratoryEnum.ZZ_3:
                case LaboratoryEnum.ZZ_4:
                case LaboratoryEnum.ZZ_1Q:
                case LaboratoryEnum.ZZ_2Q:
                case LaboratoryEnum.ZZ_3Q:
                case LaboratoryEnum.ZZ_4Q:
                case LaboratoryEnum.ZZ_5Q:
                case LaboratoryEnum.ZZ_11BC:
                case LaboratoryEnum.ZZ_12BC:
                case LaboratoryEnum.ZZ_13BC:
                case LaboratoryEnum.ZZ_14BC:
                case LaboratoryEnum.ZZ_15BC:
                case LaboratoryEnum.ZZ_16BC:
                case LaboratoryEnum.ZZ_17BC:
                case LaboratoryEnum.ZZ_18BC:
                case LaboratoryEnum.MonctonEnvironmentCanada:
                case LaboratoryEnum.BIOEnvironmentCanada:
                case LaboratoryEnum.EasternCharlotteWaterwayLaboratory:
                case LaboratoryEnum.InstitutDeRechercheSurLesZonesCotieres:
                case LaboratoryEnum.CentreDeRechercheSurLesAliments:
                case LaboratoryEnum.CaraquetMobileLaboratoryEnvironmentCanada:
                case LaboratoryEnum.MaxxamAnalyticsBedford:
                case LaboratoryEnum.MaxxamAnalyticsSydney:
                case LaboratoryEnum.PEIAnalyticalLaboratory:
                case LaboratoryEnum.NLMobileLaboratory:
                case LaboratoryEnum.AvalonLaboratoriesInc:
                case LaboratoryEnum.Maxxam:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Laboratory);
            }
        }
        public string LabSheetStatusOK(LabSheetStatusEnum? labSheetStatus)
        {
            if (labSheetStatus == null)
                return "";

            switch ((LabSheetStatusEnum)labSheetStatus)
            {
                case LabSheetStatusEnum.Error:
                case LabSheetStatusEnum.Created:
                case LabSheetStatusEnum.Transferred:
                case LabSheetStatusEnum.Accepted:
                case LabSheetStatusEnum.Rejected:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LabSheetStatus);
            }
        }
        public string LabSheetTypeOK(LabSheetTypeEnum? labSheetType)
        {
            if (labSheetType == null)
                return "";

            switch ((LabSheetTypeEnum)labSheetType)
            {
                case LabSheetTypeEnum.Error:
                case LabSheetTypeEnum.A1:
                case LabSheetTypeEnum.LTB:
                case LabSheetTypeEnum.EC:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LabSheetType);
            }
        }
        public string LanguageOK(LanguageEnum? language)
        {
            if (language == null)
                return "";

            switch ((LanguageEnum)language)
            {
                case LanguageEnum.Error:
                case LanguageEnum.en:
                case LanguageEnum.fr:
                case LanguageEnum.enAndfr:
                case LanguageEnum.es:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Language);
            }
        }
        public string LogCommandOK(LogCommandEnum? logCommand)
        {
            if (logCommand == null)
                return "";

            switch ((LogCommandEnum)logCommand)
            {
                case LogCommandEnum.Error:
                case LogCommandEnum.Add:
                case LogCommandEnum.Change:
                case LogCommandEnum.Delete:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LogCommand);
            }
        }
        public string MapInfoDrawTypeOK(MapInfoDrawTypeEnum? mapInfoDrawType)
        {
            if (mapInfoDrawType == null)
                return "";

            switch ((MapInfoDrawTypeEnum)mapInfoDrawType)
            {
                case MapInfoDrawTypeEnum.Error:
                case MapInfoDrawTypeEnum.Point:
                case MapInfoDrawTypeEnum.Polyline:
                case MapInfoDrawTypeEnum.Polygon:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MapInfoDrawType);
            }
        }
        public string MikeBoundaryConditionLevelOrVelocityOK(MikeBoundaryConditionLevelOrVelocityEnum? mikeBoundaryConditionLevelOrVelocity)
        {
            if (mikeBoundaryConditionLevelOrVelocity == null)
                return "";

            switch ((MikeBoundaryConditionLevelOrVelocityEnum)mikeBoundaryConditionLevelOrVelocity)
            {
                case MikeBoundaryConditionLevelOrVelocityEnum.Error:
                case MikeBoundaryConditionLevelOrVelocityEnum.Level:
                case MikeBoundaryConditionLevelOrVelocityEnum.Velocity:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocity);
            }
        }
        public string MikeScenarioSpecialResultKMLTypeOK(MikeScenarioSpecialResultKMLTypeEnum? mikeScenarioSpecialResultKMLType)
        {
            if (mikeScenarioSpecialResultKMLType == null)
                return "";

            switch ((MikeScenarioSpecialResultKMLTypeEnum)mikeScenarioSpecialResultKMLType)
            {
                case MikeScenarioSpecialResultKMLTypeEnum.Error:
                case MikeScenarioSpecialResultKMLTypeEnum.Mesh:
                case MikeScenarioSpecialResultKMLTypeEnum.StudyArea:
                case MikeScenarioSpecialResultKMLTypeEnum.BoundaryConditions:
                case MikeScenarioSpecialResultKMLTypeEnum.PollutionLimit:
                case MikeScenarioSpecialResultKMLTypeEnum.PollutionAnimation:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MikeScenarioSpecialResultKMLType);
            }
        }
        public string MWQMSiteLatestClassificationOK(MWQMSiteLatestClassificationEnum? mWQMSiteLatestClassification)
        {
            if (mWQMSiteLatestClassification == null)
                return "";

            switch ((MWQMSiteLatestClassificationEnum)mWQMSiteLatestClassification)
            {
                case MWQMSiteLatestClassificationEnum.Error:
                case MWQMSiteLatestClassificationEnum.Approved:
                case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
                case MWQMSiteLatestClassificationEnum.Restricted:
                case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
                case MWQMSiteLatestClassificationEnum.Prohibited:
                case MWQMSiteLatestClassificationEnum.Unclassified:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MWQMSiteLatestClassification);
            }
        }
        public string PolSourceInactiveReasonOK(PolSourceInactiveReasonEnum? polSourceInactiveReason)
        {
            if (polSourceInactiveReason == null)
                return "";

            switch ((PolSourceInactiveReasonEnum)polSourceInactiveReason)
            {
                case PolSourceInactiveReasonEnum.Error:
                case PolSourceInactiveReasonEnum.Abandoned:
                case PolSourceInactiveReasonEnum.Closed:
                case PolSourceInactiveReasonEnum.Removed:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PolSourceInactiveReason);
            }
        }
        public string PolSourceIssueRiskOK(PolSourceIssueRiskEnum? polSourceIssueRisk)
        {
            if (polSourceIssueRisk == null)
                return "";

            switch ((PolSourceIssueRiskEnum)polSourceIssueRisk)
            {
                case PolSourceIssueRiskEnum.Error:
                case PolSourceIssueRiskEnum.LowRisk:
                case PolSourceIssueRiskEnum.ModerateRisk:
                case PolSourceIssueRiskEnum.HighRisk:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PolSourceIssueRisk);
            }
        }
        public string PositionOK(PositionEnum? position)
        {
            if (position == null)
                return "";

            switch ((PositionEnum)position)
            {
                case PositionEnum.Error:
                case PositionEnum.LeftBottom:
                case PositionEnum.RightBottom:
                case PositionEnum.LeftTop:
                case PositionEnum.RightTop:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Position);
            }
        }
        public string PreliminaryTreatmentTypeOK(PreliminaryTreatmentTypeEnum? preliminaryTreatmentType)
        {
            if (preliminaryTreatmentType == null)
                return "";

            switch ((PreliminaryTreatmentTypeEnum)preliminaryTreatmentType)
            {
                case PreliminaryTreatmentTypeEnum.Error:
                case PreliminaryTreatmentTypeEnum.NotApplicable:
                case PreliminaryTreatmentTypeEnum.BarScreen:
                case PreliminaryTreatmentTypeEnum.Grinder:
                case PreliminaryTreatmentTypeEnum.MechanicalScreening:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PreliminaryTreatmentType);
            }
        }
        public string PrimaryTreatmentTypeOK(PrimaryTreatmentTypeEnum? primaryTreatmentType)
        {
            if (primaryTreatmentType == null)
                return "";

            switch ((PrimaryTreatmentTypeEnum)primaryTreatmentType)
            {
                case PrimaryTreatmentTypeEnum.Error:
                case PrimaryTreatmentTypeEnum.NotApplicable:
                case PrimaryTreatmentTypeEnum.Sedimentation:
                case PrimaryTreatmentTypeEnum.ChemicalCoagulation:
                case PrimaryTreatmentTypeEnum.Filtration:
                case PrimaryTreatmentTypeEnum.PrimaryClarification:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PrimaryTreatmentType);
            }
        }
        public string ReportConditionOK(ReportConditionEnum? reportCondition)
        {
            if (reportCondition == null)
                return "";

            switch ((ReportConditionEnum)reportCondition)
            {
                case ReportConditionEnum.Error:
                case ReportConditionEnum.ReportConditionTrue:
                case ReportConditionEnum.ReportConditionFalse:
                case ReportConditionEnum.ReportConditionContain:
                case ReportConditionEnum.ReportConditionStart:
                case ReportConditionEnum.ReportConditionEnd:
                case ReportConditionEnum.ReportConditionBigger:
                case ReportConditionEnum.ReportConditionSmaller:
                case ReportConditionEnum.ReportConditionEqual:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportCondition);
            }
        }
        public string ReportFieldTypeOK(ReportFieldTypeEnum? reportFieldType)
        {
            if (reportFieldType == null)
                return "";

            switch ((ReportFieldTypeEnum)reportFieldType)
            {
                case ReportFieldTypeEnum.Error:
                case ReportFieldTypeEnum.NumberWhole:
                case ReportFieldTypeEnum.NumberWithDecimal:
                case ReportFieldTypeEnum.DateAndTime:
                case ReportFieldTypeEnum.Text:
                case ReportFieldTypeEnum.TrueOrFalse:
                case ReportFieldTypeEnum.FilePurpose:
                case ReportFieldTypeEnum.FileType:
                case ReportFieldTypeEnum.TranslationStatus:
                case ReportFieldTypeEnum.BoxModelResultType:
                case ReportFieldTypeEnum.InfrastructureType:
                case ReportFieldTypeEnum.FacilityType:
                case ReportFieldTypeEnum.AerationType:
                case ReportFieldTypeEnum.PreliminaryTreatmentType:
                case ReportFieldTypeEnum.PrimaryTreatmentType:
                case ReportFieldTypeEnum.SecondaryTreatmentType:
                case ReportFieldTypeEnum.TertiaryTreatmentType:
                case ReportFieldTypeEnum.TreatmentType:
                case ReportFieldTypeEnum.DisinfectionType:
                case ReportFieldTypeEnum.CollectionSystemType:
                case ReportFieldTypeEnum.AlarmSystemType:
                case ReportFieldTypeEnum.ScenarioStatus:
                case ReportFieldTypeEnum.StorageDataType:
                case ReportFieldTypeEnum.Language:
                case ReportFieldTypeEnum.SampleType:
                case ReportFieldTypeEnum.BeaufortScale:
                case ReportFieldTypeEnum.AnalyzeMethod:
                case ReportFieldTypeEnum.SampleMatrix:
                case ReportFieldTypeEnum.Laboratory:
                case ReportFieldTypeEnum.SampleStatus:
                case ReportFieldTypeEnum.SamplingPlanType:
                case ReportFieldTypeEnum.LabSheetSampleType:
                case ReportFieldTypeEnum.LabSheetType:
                case ReportFieldTypeEnum.LabSheetStatus:
                case ReportFieldTypeEnum.PolSourceInactiveReason:
                case ReportFieldTypeEnum.PolSourceObsInfo:
                case ReportFieldTypeEnum.AddressType:
                case ReportFieldTypeEnum.StreetType:
                case ReportFieldTypeEnum.ContactTitle:
                case ReportFieldTypeEnum.EmailType:
                case ReportFieldTypeEnum.TelType:
                case ReportFieldTypeEnum.TideText:
                case ReportFieldTypeEnum.TideDataType:
                case ReportFieldTypeEnum.SpecialTableType:
                case ReportFieldTypeEnum.MWQMSiteLatestClassification:
                case ReportFieldTypeEnum.PolSourceIssueRisk:
                case ReportFieldTypeEnum.MikeScenarioSpecialResultKMLType:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFieldType);
            }
        }
        public string ReportFileTypeOK(ReportFileTypeEnum? reportFileType)
        {
            if (reportFileType == null)
                return "";

            switch ((ReportFileTypeEnum)reportFileType)
            {
                case ReportFileTypeEnum.Error:
                case ReportFileTypeEnum.CSV:
                case ReportFileTypeEnum.Word:
                case ReportFileTypeEnum.Excel:
                case ReportFileTypeEnum.KML:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFileType);
            }
        }
        public string ReportFormatingDateOK(ReportFormatingDateEnum? reportFormatingDate)
        {
            if (reportFormatingDate == null)
                return "";

            switch ((ReportFormatingDateEnum)reportFormatingDate)
            {
                case ReportFormatingDateEnum.Error:
                case ReportFormatingDateEnum.ReportFormatingDateYearOnly:
                case ReportFormatingDateEnum.ReportFormatingDateMonthDecimalOnly:
                case ReportFormatingDateEnum.ReportFormatingDateMonthShortTextOnly:
                case ReportFormatingDateEnum.ReportFormatingDateMonthFullTextOnly:
                case ReportFormatingDateEnum.ReportFormatingDateDayOnly:
                case ReportFormatingDateEnum.ReportFormatingDateHourOnly:
                case ReportFormatingDateEnum.ReportFormatingDateMinuteOnly:
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthDecimalDay:
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthShortTextDay:
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthFullTextDay:
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthDecimalDayHourMinute:
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthShortTextDayHourMinute:
                case ReportFormatingDateEnum.ReportFormatingDateYearMonthFullTextDayHourMinute:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFormatingDate);
            }
        }
        public string ReportFormatingNumberOK(ReportFormatingNumberEnum? reportFormatingNumber)
        {
            if (reportFormatingNumber == null)
                return "";

            switch ((ReportFormatingNumberEnum)reportFormatingNumber)
            {
                case ReportFormatingNumberEnum.Error:
                case ReportFormatingNumberEnum.ReportFormatingNumber0Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumber1Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumber2Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumber3Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumber4Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumber5Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumber6Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific0Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific1Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific2Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific3Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific4Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific5Decimal:
                case ReportFormatingNumberEnum.ReportFormatingNumberScientific6Decimal:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFormatingNumber);
            }
        }
        public string ReportGenerateObjectsKeywordOK(ReportGenerateObjectsKeywordEnum? reportGenerateObjectsKeyword)
        {
            if (reportGenerateObjectsKeyword == null)
                return "";

            switch ((ReportGenerateObjectsKeywordEnum)reportGenerateObjectsKeyword)
            {
                case ReportGenerateObjectsKeywordEnum.Error:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_RE_EVALUATION_COVER_PAGE:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_ALL:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_WET:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_DRY:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_DATA_AVAILABILITY:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_SITES_BY_YEAR:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_RUNS_BY_YEAR:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_SAMPLES_BY_YEAR:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_FC_TABLE:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_SALINITY_TABLE:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_TEMPERATURE_TABLE:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_SITES:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_SITES_COMPACT:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITIES:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_MAP:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_CONTACTS:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_DETAIL:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_ECCC_AND_SWCP_LOGO:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_CSSP_LOGO:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_LOCATION_OF_SURVEY_AREA_MAP:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_CURRENT_CLASSIFICATION_AND_SAMPLING_LOCATION_MAP:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_RECOMMENDED_CLASSIFICATION_MAP:
                case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_LOCATIONS_MAP:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportGenerateObjectsKeyword);
            }
        }
        public string ReportSortingOK(ReportSortingEnum? reportSorting)
        {
            if (reportSorting == null)
                return "";

            switch ((ReportSortingEnum)reportSorting)
            {
                case ReportSortingEnum.Error:
                case ReportSortingEnum.ReportSortingAscending:
                case ReportSortingEnum.ReportSortingDescending:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportSorting);
            }
        }
        public string ReportTreeNodeSubTypeOK(ReportTreeNodeSubTypeEnum? reportTreeNodeSubType)
        {
            if (reportTreeNodeSubType == null)
                return "";

            switch ((ReportTreeNodeSubTypeEnum)reportTreeNodeSubType)
            {
                case ReportTreeNodeSubTypeEnum.Error:
                case ReportTreeNodeSubTypeEnum.TableSelectable:
                case ReportTreeNodeSubTypeEnum.Field:
                case ReportTreeNodeSubTypeEnum.FieldsHolder:
                case ReportTreeNodeSubTypeEnum.TableNotSelectable:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportTreeNodeSubType);
            }
        }
        public string ReportTreeNodeTypeOK(ReportTreeNodeTypeEnum? reportTreeNodeType)
        {
            if (reportTreeNodeType == null)
                return "";

            switch ((ReportTreeNodeTypeEnum)reportTreeNodeType)
            {
                case ReportTreeNodeTypeEnum.Error:
                case ReportTreeNodeTypeEnum.ReportRootType:
                case ReportTreeNodeTypeEnum.ReportCountryType:
                case ReportTreeNodeTypeEnum.ReportProvinceType:
                case ReportTreeNodeTypeEnum.ReportAreaType:
                case ReportTreeNodeTypeEnum.ReportSectorType:
                case ReportTreeNodeTypeEnum.ReportSubsectorType:
                case ReportTreeNodeTypeEnum.ReportMWQMSiteType:
                case ReportTreeNodeTypeEnum.ReportMWQMRunType:
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteType:
                case ReportTreeNodeTypeEnum.ReportMunicipalityType:
                case ReportTreeNodeTypeEnum.ReportRootFileType:
                case ReportTreeNodeTypeEnum.ReportInfrastructureType:
                case ReportTreeNodeTypeEnum.ReportBoxModelType:
                case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioType:
                case ReportTreeNodeTypeEnum.ReportMikeScenarioType:
                case ReportTreeNodeTypeEnum.ReportMikeSourceType:
                case ReportTreeNodeTypeEnum.ReportMWQMSiteSampleType:
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteObsType:
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteObsIssueType:
                case ReportTreeNodeTypeEnum.ReportMikeScenarioGeneralParameterType:
                case ReportTreeNodeTypeEnum.ReportMunicipalityContactType:
                case ReportTreeNodeTypeEnum.ReportConditionType:
                case ReportTreeNodeTypeEnum.ReportStatisticType:
                case ReportTreeNodeTypeEnum.ReportFieldsType:
                case ReportTreeNodeTypeEnum.ReportFieldType:
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteAddressType:
                case ReportTreeNodeTypeEnum.ReportMunicipalityContactTelType:
                case ReportTreeNodeTypeEnum.ReportMunicipalityContactEmailType:
                case ReportTreeNodeTypeEnum.ReportBoxModelResultType:
                case ReportTreeNodeTypeEnum.ReportClimateSiteType:
                case ReportTreeNodeTypeEnum.ReportClimateSiteDataType:
                case ReportTreeNodeTypeEnum.ReportHydrometricSiteType:
                case ReportTreeNodeTypeEnum.ReportHydrometricSiteDataType:
                case ReportTreeNodeTypeEnum.ReportHydrometricSiteRatingCurveType:
                case ReportTreeNodeTypeEnum.ReportHydrometricSiteRatingCurveValueType:
                case ReportTreeNodeTypeEnum.ReportInfrastructureAddressType:
                case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetType:
                case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetDetailType:
                case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetTubeMPNDetailType:
                case ReportTreeNodeTypeEnum.ReportMWQMRunSampleType:
                case ReportTreeNodeTypeEnum.ReportCountryFileType:
                case ReportTreeNodeTypeEnum.ReportProvinceFileType:
                case ReportTreeNodeTypeEnum.ReportAreaFileType:
                case ReportTreeNodeTypeEnum.ReportSectorFileType:
                case ReportTreeNodeTypeEnum.ReportSubsectorFileType:
                case ReportTreeNodeTypeEnum.ReportMWQMSiteFileType:
                case ReportTreeNodeTypeEnum.ReportMWQMRunFileType:
                case ReportTreeNodeTypeEnum.ReportPolSourceSiteFileType:
                case ReportTreeNodeTypeEnum.ReportMunicipalityFileType:
                case ReportTreeNodeTypeEnum.ReportInfrastructureFileType:
                case ReportTreeNodeTypeEnum.ReportMikeScenarioFileType:
                case ReportTreeNodeTypeEnum.ReportMikeSourceStartEndType:
                case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetType:
                case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetDetailType:
                case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetTubeMPNDetailType:
                case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetType:
                case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetDetailType:
                case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetTubeMPNDetailType:
                case ReportTreeNodeTypeEnum.ReportSamplingPlanType:
                case ReportTreeNodeTypeEnum.ReportSamplingPlanSubsectorType:
                case ReportTreeNodeTypeEnum.ReportSamplingPlanSubsectorSiteType:
                case ReportTreeNodeTypeEnum.ReportMikeBoundaryConditionType:
                case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioAmbientType:
                case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioResultType:
                case ReportTreeNodeTypeEnum.ReportMPNLookupType:
                case ReportTreeNodeTypeEnum.ReportMWQMSiteStartAndEndType:
                case ReportTreeNodeTypeEnum.ReportSubsectorTideSiteType:
                case ReportTreeNodeTypeEnum.ReportSubsectorTideSiteDataType:
                case ReportTreeNodeTypeEnum.ReportOrderType:
                case ReportTreeNodeTypeEnum.ReportFormatType:
                case ReportTreeNodeTypeEnum.ReportMunicipalityContactAddressType:
                case ReportTreeNodeTypeEnum.ReportSubsectorClimateSiteType:
                case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteType:
                case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteDataType:
                case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteRatingCurveType:
                case ReportTreeNodeTypeEnum.ReportSubsectorClimateSiteDataType:
                case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteRatingCurveValueType:
                case ReportTreeNodeTypeEnum.ReportSubsectorSpecialTableType:
                case ReportTreeNodeTypeEnum.ReportMikeScenarioSpecialResultKMLType:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportTreeNodeType);
            }
        }
        public string SameDayNextDayOK(SameDayNextDayEnum? sameDayNextDay)
        {
            if (sameDayNextDay == null)
                return "";

            switch ((SameDayNextDayEnum)sameDayNextDay)
            {
                case SameDayNextDayEnum.Error:
                case SameDayNextDayEnum.SameDay:
                case SameDayNextDayEnum.NextDay:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SameDayNextDay);
            }
        }
        public string SampleMatrixOK(SampleMatrixEnum? sampleMatrix)
        {
            if (sampleMatrix == null)
                return "";

            switch ((SampleMatrixEnum)sampleMatrix)
            {
                case SampleMatrixEnum.Error:
                case SampleMatrixEnum.W:
                case SampleMatrixEnum.S:
                case SampleMatrixEnum.B:
                case SampleMatrixEnum.MPNQ:
                case SampleMatrixEnum.SampleMatrix5:
                case SampleMatrixEnum.SampleMatrix6:
                case SampleMatrixEnum.Water:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleMatrix);
            }
        }
        public string SampleStatusOK(SampleStatusEnum? sampleStatus)
        {
            if (sampleStatus == null)
                return "";

            switch ((SampleStatusEnum)sampleStatus)
            {
                case SampleStatusEnum.Error:
                case SampleStatusEnum.Active:
                case SampleStatusEnum.Archived:
                case SampleStatusEnum.SampleStatus3:
                case SampleStatusEnum.SampleStatus4:
                case SampleStatusEnum.SampleStatus5:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleStatus);
            }
        }
        public string SampleTypeOK(SampleTypeEnum? sampleType)
        {
            if (sampleType == null)
                return "";

            switch ((SampleTypeEnum)sampleType)
            {
                case SampleTypeEnum.Error:
                case SampleTypeEnum.DailyDuplicate:
                case SampleTypeEnum.Infrastructure:
                case SampleTypeEnum.IntertechDuplicate:
                case SampleTypeEnum.IntertechRead:
                case SampleTypeEnum.RainCMP:
                case SampleTypeEnum.RainRun:
                case SampleTypeEnum.ReopeningEmergencyRain:
                case SampleTypeEnum.ReopeningSpill:
                case SampleTypeEnum.Routine:
                case SampleTypeEnum.Sanitary:
                case SampleTypeEnum.Study:
                case SampleTypeEnum.Sediment:
                case SampleTypeEnum.Bivalve:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleType);
            }
        }
        public string SamplingPlanTypeOK(SamplingPlanTypeEnum? samplingPlanType)
        {
            if (samplingPlanType == null)
                return "";

            switch ((SamplingPlanTypeEnum)samplingPlanType)
            {
                case SamplingPlanTypeEnum.Error:
                case SamplingPlanTypeEnum.Subsector:
                case SamplingPlanTypeEnum.Municipality:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SamplingPlanType);
            }
        }
        public string ScenarioStatusOK(ScenarioStatusEnum? scenarioStatus)
        {
            if (scenarioStatus == null)
                return "";

            switch ((ScenarioStatusEnum)scenarioStatus)
            {
                case ScenarioStatusEnum.Error:
                case ScenarioStatusEnum.Normal:
                case ScenarioStatusEnum.Copying:
                case ScenarioStatusEnum.Copied:
                case ScenarioStatusEnum.Changing:
                case ScenarioStatusEnum.Changed:
                case ScenarioStatusEnum.AskToRun:
                case ScenarioStatusEnum.Running:
                case ScenarioStatusEnum.Completed:
                case ScenarioStatusEnum.Cancelled:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ScenarioStatus);
            }
        }
        public string SearchTagOK(SearchTagEnum? searchTag)
        {
            if (searchTag == null)
                return "";

            switch ((SearchTagEnum)searchTag)
            {
                case SearchTagEnum.Error:
                case SearchTagEnum.c:
                case SearchTagEnum.e:
                case SearchTagEnum.t:
                case SearchTagEnum.fi:
                case SearchTagEnum.fp:
                case SearchTagEnum.frg:
                case SearchTagEnum.ftg:
                case SearchTagEnum.fpdf:
                case SearchTagEnum.fdocx:
                case SearchTagEnum.fxlsx:
                case SearchTagEnum.fkmz:
                case SearchTagEnum.fxyz:
                case SearchTagEnum.fdfs:
                case SearchTagEnum.fmike:
                case SearchTagEnum.fmdf:
                case SearchTagEnum.fm21fm:
                case SearchTagEnum.fm3fm:
                case SearchTagEnum.fmesh:
                case SearchTagEnum.flog:
                case SearchTagEnum.ftxt:
                case SearchTagEnum.m:
                case SearchTagEnum.p:
                case SearchTagEnum.ms:
                case SearchTagEnum.cs:
                case SearchTagEnum.hs:
                case SearchTagEnum.ts:
                case SearchTagEnum.ww:
                case SearchTagEnum.ls:
                case SearchTagEnum.st:
                case SearchTagEnum.ps:
                case SearchTagEnum.a:
                case SearchTagEnum.s:
                case SearchTagEnum.ss:
                case SearchTagEnum.u:
                case SearchTagEnum.notag:
                case SearchTagEnum.fcsv:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SearchTag);
            }
        }
        public string SecondaryTreatmentTypeOK(SecondaryTreatmentTypeEnum? secondaryTreatmentType)
        {
            if (secondaryTreatmentType == null)
                return "";

            switch ((SecondaryTreatmentTypeEnum)secondaryTreatmentType)
            {
                case SecondaryTreatmentTypeEnum.Error:
                case SecondaryTreatmentTypeEnum.NotApplicable:
                case SecondaryTreatmentTypeEnum.RotatingBiologicalContactor:
                case SecondaryTreatmentTypeEnum.TricklingFilters:
                case SecondaryTreatmentTypeEnum.SequencingBatchReactor:
                case SecondaryTreatmentTypeEnum.OxidationDitch:
                case SecondaryTreatmentTypeEnum.ExtendedAeration:
                case SecondaryTreatmentTypeEnum.ContactStabilization:
                case SecondaryTreatmentTypeEnum.PhysicalChemicalProcesses:
                case SecondaryTreatmentTypeEnum.MovingBedBioReactor:
                case SecondaryTreatmentTypeEnum.BiologicalAearatedFilters:
                case SecondaryTreatmentTypeEnum.AeratedSubmergedBioFilmReactor:
                case SecondaryTreatmentTypeEnum.IntegratedFixedFilmActivatedSludge:
                case SecondaryTreatmentTypeEnum.ActivatedSludge:
                case SecondaryTreatmentTypeEnum.ExtendedActivatedSludge:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SecondaryTreatmentType);
            }
        }
        public string SpecialTableTypeOK(SpecialTableTypeEnum? specialTableType)
        {
            if (specialTableType == null)
                return "";

            switch ((SpecialTableTypeEnum)specialTableType)
            {
                case SpecialTableTypeEnum.Error:
                case SpecialTableTypeEnum.FCDensitiesTable:
                case SpecialTableTypeEnum.SalinityTable:
                case SpecialTableTypeEnum.TemperatureTable:
                case SpecialTableTypeEnum.GeometricMeanTable:
                case SpecialTableTypeEnum.MedianTable:
                case SpecialTableTypeEnum.P90Table:
                case SpecialTableTypeEnum.PercentOver43Table:
                case SpecialTableTypeEnum.PercentOver260Table:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SpecialTableType);
            }
        }
        public string StorageDataTypeOK(StorageDataTypeEnum? storageDataType)
        {
            if (storageDataType == null)
                return "";

            switch ((StorageDataTypeEnum)storageDataType)
            {
                case StorageDataTypeEnum.Error:
                case StorageDataTypeEnum.Archived:
                case StorageDataTypeEnum.Forcasted:
                case StorageDataTypeEnum.Observed:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.StorageDataType);
            }
        }
        public string StreetTypeOK(StreetTypeEnum? streetType)
        {
            if (streetType == null)
                return "";

            switch ((StreetTypeEnum)streetType)
            {
                case StreetTypeEnum.Error:
                case StreetTypeEnum.Street:
                case StreetTypeEnum.Road:
                case StreetTypeEnum.Avenue:
                case StreetTypeEnum.Crescent:
                case StreetTypeEnum.Court:
                case StreetTypeEnum.Alley:
                case StreetTypeEnum.Drive:
                case StreetTypeEnum.Blvd:
                case StreetTypeEnum.Route:
                case StreetTypeEnum.Lane:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.StreetType);
            }
        }
        public string TelTypeOK(TelTypeEnum? telType)
        {
            if (telType == null)
                return "";

            switch ((TelTypeEnum)telType)
            {
                case TelTypeEnum.Error:
                case TelTypeEnum.Personal:
                case TelTypeEnum.Work:
                case TelTypeEnum.Mobile:
                case TelTypeEnum.Personal2:
                case TelTypeEnum.Work2:
                case TelTypeEnum.Mobile2:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TelType);
            }
        }
        public string TertiaryTreatmentTypeOK(TertiaryTreatmentTypeEnum? tertiaryTreatmentType)
        {
            if (tertiaryTreatmentType == null)
                return "";

            switch ((TertiaryTreatmentTypeEnum)tertiaryTreatmentType)
            {
                case TertiaryTreatmentTypeEnum.Error:
                case TertiaryTreatmentTypeEnum.NotApplicable:
                case TertiaryTreatmentTypeEnum.Adsorption:
                case TertiaryTreatmentTypeEnum.Flocculation:
                case TertiaryTreatmentTypeEnum.MembraneFiltration:
                case TertiaryTreatmentTypeEnum.IonExchange:
                case TertiaryTreatmentTypeEnum.ReverseOsmosis:
                case TertiaryTreatmentTypeEnum.BiologicalNutrientRemoval:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TertiaryTreatmentType);
            }
        }
        public string TideDataTypeOK(TideDataTypeEnum? tideDataType)
        {
            if (tideDataType == null)
                return "";

            switch ((TideDataTypeEnum)tideDataType)
            {
                case TideDataTypeEnum.Error:
                case TideDataTypeEnum.Min15:
                case TideDataTypeEnum.Min60:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TideDataType);
            }
        }
        public string TideTextOK(TideTextEnum? tideText)
        {
            if (tideText == null)
                return "";

            switch ((TideTextEnum)tideText)
            {
                case TideTextEnum.Error:
                case TideTextEnum.LowTide:
                case TideTextEnum.LowTideFalling:
                case TideTextEnum.LowTideRising:
                case TideTextEnum.MidTide:
                case TideTextEnum.MidTideFalling:
                case TideTextEnum.MidTideRising:
                case TideTextEnum.HighTide:
                case TideTextEnum.HighTideFalling:
                case TideTextEnum.HighTideRising:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TideText);
            }
        }
        public string TranslationStatusOK(TranslationStatusEnum? translationStatus)
        {
            if (translationStatus == null)
                return "";

            switch ((TranslationStatusEnum)translationStatus)
            {
                case TranslationStatusEnum.Error:
                case TranslationStatusEnum.NotTranslated:
                case TranslationStatusEnum.ElectronicallyTranslated:
                case TranslationStatusEnum.Translated:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TranslationStatus);
            }
        }
        public string TreatmentTypeOK(TreatmentTypeEnum? treatmentType)
        {
            if (treatmentType == null)
                return "";

            switch ((TreatmentTypeEnum)treatmentType)
            {
                case TreatmentTypeEnum.Error:
                case TreatmentTypeEnum.ActivatedSludge:
                case TreatmentTypeEnum.ActivatedSludgeWithBiofilter:
                case TreatmentTypeEnum.LagoonNoAeration1Cell:
                case TreatmentTypeEnum.LagoonNoAeration2Cell:
                case TreatmentTypeEnum.LagoonNoAeration3Cell:
                case TreatmentTypeEnum.LagoonNoAeration4Cell:
                case TreatmentTypeEnum.LagoonNoAeration5Cell:
                case TreatmentTypeEnum.LagoonWithAeration1Cell:
                case TreatmentTypeEnum.LagoonWithAeration2Cell:
                case TreatmentTypeEnum.LagoonWithAeration3Cell:
                case TreatmentTypeEnum.LagoonWithAeration4Cell:
                case TreatmentTypeEnum.LagoonWithAeration5Cell:
                case TreatmentTypeEnum.LagoonWithAeration6Cell:
                case TreatmentTypeEnum.StabalizingPondOnly:
                case TreatmentTypeEnum.OxidationDitchOnly:
                case TreatmentTypeEnum.CirculatingFluidizedBed:
                case TreatmentTypeEnum.TricklingFilter:
                case TreatmentTypeEnum.RecirculatingSandFilter:
                case TreatmentTypeEnum.TrashRackRakeOnly:
                case TreatmentTypeEnum.SepticTank:
                case TreatmentTypeEnum.Secondary:
                case TreatmentTypeEnum.Tertiary:
                case TreatmentTypeEnum.VolumeFermenter:
                case TreatmentTypeEnum.BioFilmReactor:
                case TreatmentTypeEnum.BioGreen:
                case TreatmentTypeEnum.BioDisks:
                case TreatmentTypeEnum.ChemicalPrimary:
                case TreatmentTypeEnum.Chromoglass:
                case TreatmentTypeEnum.Primary:
                case TreatmentTypeEnum.SequencingBatchReactor:
                case TreatmentTypeEnum.PeatSystem:
                case TreatmentTypeEnum.Physicochimique:
                case TreatmentTypeEnum.RotatingBiologicalContactor:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TreatmentType);
            }
        }
        public string TVAuthOK(TVAuthEnum? tVAuth)
        {
            if (tVAuth == null)
                return "";

            switch ((TVAuthEnum)tVAuth)
            {
                case TVAuthEnum.Error:
                case TVAuthEnum.NoAccess:
                case TVAuthEnum.Read:
                case TVAuthEnum.Write:
                case TVAuthEnum.Create:
                case TVAuthEnum.Delete:
                case TVAuthEnum.Admin:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TVAuth);
            }
        }
        public string TVTypeOK(TVTypeEnum? tVType)
        {
            if (tVType == null)
                return "";

            switch ((TVTypeEnum)tVType)
            {
                case TVTypeEnum.Error:
                case TVTypeEnum.Root:
                case TVTypeEnum.Address:
                case TVTypeEnum.Area:
                case TVTypeEnum.ClimateSite:
                case TVTypeEnum.Contact:
                case TVTypeEnum.Country:
                case TVTypeEnum.Email:
                case TVTypeEnum.File:
                case TVTypeEnum.HydrometricSite:
                case TVTypeEnum.Infrastructure:
                case TVTypeEnum.MikeBoundaryConditionWebTide:
                case TVTypeEnum.MikeBoundaryConditionMesh:
                case TVTypeEnum.MikeScenario:
                case TVTypeEnum.MikeSource:
                case TVTypeEnum.Municipality:
                case TVTypeEnum.MWQMSite:
                case TVTypeEnum.PolSourceSite:
                case TVTypeEnum.Province:
                case TVTypeEnum.Sector:
                case TVTypeEnum.Subsector:
                case TVTypeEnum.Tel:
                case TVTypeEnum.TideSite:
                case TVTypeEnum.MWQMSiteSample:
                case TVTypeEnum.WasteWaterTreatmentPlant:
                case TVTypeEnum.LiftStation:
                case TVTypeEnum.Spill:
                case TVTypeEnum.BoxModel:
                case TVTypeEnum.VisualPlumesScenario:
                case TVTypeEnum.Outfall:
                case TVTypeEnum.OtherInfrastructure:
                case TVTypeEnum.MWQMRun:
                case TVTypeEnum.NoDepuration:
                case TVTypeEnum.Failed:
                case TVTypeEnum.Passed:
                case TVTypeEnum.NoData:
                case TVTypeEnum.LessThan10:
                case TVTypeEnum.MeshNode:
                case TVTypeEnum.WebTideNode:
                case TVTypeEnum.SamplingPlan:
                case TVTypeEnum.SeeOtherMunicipality:
                case TVTypeEnum.LineOverflow:
                case TVTypeEnum.BoxModelInputs:
                case TVTypeEnum.BoxModelResults:
                case TVTypeEnum.ClimateSiteInfo:
                case TVTypeEnum.ClimateSiteData:
                case TVTypeEnum.HydrometricSiteInfo:
                case TVTypeEnum.HydrometricSiteData:
                case TVTypeEnum.InfrastructureInfo:
                case TVTypeEnum.LabSheetInfo:
                case TVTypeEnum.LabSheetDetailInfo:
                case TVTypeEnum.MapInfo:
                case TVTypeEnum.MapInfoPoint:
                case TVTypeEnum.MikeSourceStartEndInfo:
                case TVTypeEnum.MWQMLookupMPNInfo:
                case TVTypeEnum.SamplingPlanInfo:
                case TVTypeEnum.SamplingPlanSubsectorInfo:
                case TVTypeEnum.SamplingPlanSubsectorSiteInfo:
                case TVTypeEnum.MWQMSiteStartEndInfo:
                case TVTypeEnum.MWQMSubsectorInfo:
                case TVTypeEnum.PolSourceSiteInfo:
                case TVTypeEnum.PolSourceSiteObsInfo:
                case TVTypeEnum.HydrometricRatingCurveInfo:
                case TVTypeEnum.HydrometricRatingCurveDataInfo:
                case TVTypeEnum.TideLocationInfo:
                case TVTypeEnum.TideSiteDataInfo:
                case TVTypeEnum.UseOfSite:
                case TVTypeEnum.VisualPlumesScenarioInfo:
                case TVTypeEnum.VisualPlumesScenarioAmbient:
                case TVTypeEnum.VisualPlumesScenarioResults:
                case TVTypeEnum.TotalFile:
                case TVTypeEnum.MikeSourceIsRiver:
                case TVTypeEnum.MikeSourceIncluded:
                case TVTypeEnum.MikeSourceNotIncluded:
                case TVTypeEnum.RainExceedance:
                case TVTypeEnum.EmailDistributionList:
                case TVTypeEnum.OpenData:
                case TVTypeEnum.ProvinceTools:
                case TVTypeEnum.Classification:
                case TVTypeEnum.Approved:
                case TVTypeEnum.Restricted:
                case TVTypeEnum.Prohibited:
                case TVTypeEnum.ConditionallyApproved:
                case TVTypeEnum.ConditionallyRestricted:
                case TVTypeEnum.OpenDataNational:
                case TVTypeEnum.PolSourceSiteMikeScenario:
                case TVTypeEnum.SubsectorTools:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TVType);
            }
        }
        public string WebTideDataSetOK(WebTideDataSetEnum? webTideDataSet)
        {
            if (webTideDataSet == null)
                return "";

            switch ((WebTideDataSetEnum)webTideDataSet)
            {
                case WebTideDataSetEnum.Error:
                case WebTideDataSetEnum.arctic9:
                case WebTideDataSetEnum.brador:
                case WebTideDataSetEnum.HRglobal:
                case WebTideDataSetEnum.h3o:
                case WebTideDataSetEnum.hudson:
                case WebTideDataSetEnum.ne_pac4:
                case WebTideDataSetEnum.nwatl:
                case WebTideDataSetEnum.QuatsinoModel14:
                case WebTideDataSetEnum.sshelf:
                case WebTideDataSetEnum.flood:
                case WebTideDataSetEnum.vigf8:
                    return "";
                default:
                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.WebTideDataSet);
            }
        }

        #endregion Enum CheckOK

    }
}
