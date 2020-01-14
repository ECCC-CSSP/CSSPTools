using System;
using Xunit;
using CSSPEnumsDLL.Tests.SetupInfo;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;
using CSSPEnumsDLL.Enums;

namespace CSSPEnumsDLL.Tests.Services
{
    public partial class BaseEnumServiceTest : SetupData
    {

        #region Testing Methods GetEnumText public
        [Fact]
        public void BaseEnumService_GetEnumText_AddressTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AddressTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AddressTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AddressTypeEnum((AddressTypeEnum)i);
        
                    switch ((AddressTypeEnum)i)
                    {
                        case AddressTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AddressTypeEnum.Mailing:
                            Assert.Equal(BaseEnumServiceRes.AddressTypeEnumMailing, retStr);
                            break;
                        case AddressTypeEnum.Shipping:
                            Assert.Equal(BaseEnumServiceRes.AddressTypeEnumShipping, retStr);
                            break;
                        case AddressTypeEnum.Civic:
                            Assert.Equal(BaseEnumServiceRes.AddressTypeEnumCivic, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_AerationTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AerationTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AerationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AerationTypeEnum((AerationTypeEnum)i);
        
                    switch ((AerationTypeEnum)i)
                    {
                        case AerationTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AerationTypeEnum.MechanicalAirLines:
                            Assert.Equal(BaseEnumServiceRes.AerationTypeEnumMechanicalAirLines, retStr);
                            break;
                        case AerationTypeEnum.MechanicalSurfaceMixers:
                            Assert.Equal(BaseEnumServiceRes.AerationTypeEnumMechanicalSurfaceMixers, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_AlarmSystemTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AlarmSystemTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AlarmSystemTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AlarmSystemTypeEnum((AlarmSystemTypeEnum)i);
        
                    switch ((AlarmSystemTypeEnum)i)
                    {
                        case AlarmSystemTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AlarmSystemTypeEnum.SCADA:
                            Assert.Equal(BaseEnumServiceRes.AlarmSystemTypeEnumSCADA, retStr);
                            break;
                        case AlarmSystemTypeEnum.None:
                            Assert.Equal(BaseEnumServiceRes.AlarmSystemTypeEnumNone, retStr);
                            break;
                        case AlarmSystemTypeEnum.OnlyVisualLight:
                            Assert.Equal(BaseEnumServiceRes.AlarmSystemTypeEnumOnlyVisualLight, retStr);
                            break;
                        case AlarmSystemTypeEnum.SCADAAndLight:
                            Assert.Equal(BaseEnumServiceRes.AlarmSystemTypeEnumSCADAAndLight, retStr);
                            break;
                        case AlarmSystemTypeEnum.PagerAndLight:
                            Assert.Equal(BaseEnumServiceRes.AlarmSystemTypeEnumPagerAndLight, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_AnalysisCalculationTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AnalysisCalculationTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AnalysisCalculationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AnalysisCalculationTypeEnum((AnalysisCalculationTypeEnum)i);
        
                    switch ((AnalysisCalculationTypeEnum)i)
                    {
                        case AnalysisCalculationTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.AllAllAll:
                            Assert.Equal(BaseEnumServiceRes.AnalysisCalculationTypeEnumAllAllAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.WetAllAll:
                            Assert.Equal(BaseEnumServiceRes.AnalysisCalculationTypeEnumWetAllAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.DryAllAll:
                            Assert.Equal(BaseEnumServiceRes.AnalysisCalculationTypeEnumDryAllAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.WetWetAll:
                            Assert.Equal(BaseEnumServiceRes.AnalysisCalculationTypeEnumWetWetAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.DryDryAll:
                            Assert.Equal(BaseEnumServiceRes.AnalysisCalculationTypeEnumDryDryAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.WetDryAll:
                            Assert.Equal(BaseEnumServiceRes.AnalysisCalculationTypeEnumWetDryAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.DryWetAll:
                            Assert.Equal(BaseEnumServiceRes.AnalysisCalculationTypeEnumDryWetAll, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_AnalysisReportExportCommandEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AnalysisReportExportCommandEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AnalysisReportExportCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AnalysisReportExportCommandEnum((AnalysisReportExportCommandEnum)i);
        
                    switch ((AnalysisReportExportCommandEnum)i)
                    {
                        case AnalysisReportExportCommandEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AnalysisReportExportCommandEnum.Report:
                            Assert.Equal(BaseEnumServiceRes.AnalysisReportExportCommandEnumReport, retStr);
                            break;
                        case AnalysisReportExportCommandEnum.Excel:
                            Assert.Equal(BaseEnumServiceRes.AnalysisReportExportCommandEnumExcel, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_AnalyzeMethodEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AnalyzeMethodEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AnalyzeMethodEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AnalyzeMethodEnum((AnalyzeMethodEnum)i);
        
                    switch ((AnalyzeMethodEnum)i)
                    {
                        case AnalyzeMethodEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AnalyzeMethodEnum.MF:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumMF, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_510Q:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumZZ_510Q, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_509Q:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumZZ_509Q, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_0:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumZZ_0, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_525Q:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumZZ_525Q, retStr);
                            break;
                        case AnalyzeMethodEnum.MPN:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumMPN, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_0Q:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumZZ_0Q, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod8:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod8, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod9:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod9, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod10:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod10, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod11:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod11, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod12:
                            Assert.Equal(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod12, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_AppTaskCommandEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AppTaskCommandEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AppTaskCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AppTaskCommandEnum((AppTaskCommandEnum)i);
        
                    switch ((AppTaskCommandEnum)i)
                    {
                        case AppTaskCommandEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AppTaskCommandEnum.GenerateWebTide:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumGenerateWebTide, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioAskToRun:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioAskToRun, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioImport:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioImport, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioOtherFileImport:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioOtherFileImport, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioRunning:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioRunning, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioToCancel:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioToCancel, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioWaitingToRun:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioWaitingToRun, retStr);
                            break;
                        case AppTaskCommandEnum.SetupWebTide:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumSetupWebTide, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateClimateSiteInformation:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteInformation, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyFromStartDateToEndDate:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteDailyAndHourlyFromStartDateToEndDate, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate, retStr);
                            break;
                        case AppTaskCommandEnum.CreateFCForm:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumCreateFCForm, retStr);
                            break;
                        case AppTaskCommandEnum.CreateSamplingPlanSamplingPlanTextFile:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumCreateSamplingPlanSamplingPlanTextFile, retStr);
                            break;
                        case AppTaskCommandEnum.CreateDocumentFromTemplate:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumCreateDocumentFromTemplate, retStr);
                            break;
                        case AppTaskCommandEnum.GetClimateSitesDataForRunsOfYear:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumGetClimateSitesDataForRunsOfYear, retStr);
                            break;
                        case AppTaskCommandEnum.CreateWebTideDataWLAtFirstNode:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumCreateWebTideDataWLAtFirstNode, retStr);
                            break;
                        case AppTaskCommandEnum.ExportEmailDistributionLists:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumExportEmailDistributionLists, retStr);
                            break;
                        case AppTaskCommandEnum.ExportAnalysisToExcel:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumExportAnalysisToExcel, retStr);
                            break;
                        case AppTaskCommandEnum.CreateDocumentFromParameters:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumCreateDocumentFromParameters, retStr);
                            break;
                        case AppTaskCommandEnum.CreateDocxPDF:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumCreateDocxPDF, retStr);
                            break;
                        case AppTaskCommandEnum.CreateXlsxPDF:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumCreateXlsxPDF, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataCSVOfMWQMSites:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVOfMWQMSites, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataKMZOfMWQMSites:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumOpenDataKMZOfMWQMSites, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataXlsxOfMWQMSitesAndSamples:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumOpenDataXlsxOfMWQMSitesAndSamples, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataCSVOfMWQMSamples:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVOfMWQMSamples, retStr);
                            break;
                        case AppTaskCommandEnum.GetAllPrecipitationForYear:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumGetAllPrecipitationForYear, retStr);
                            break;
                        case AppTaskCommandEnum.FillRunPrecipByClimateSitePriorityForYear:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumFillRunPrecipByClimateSitePriorityForYear, retStr);
                            break;
                        case AppTaskCommandEnum.FindMissingPrecipForProvince:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumFindMissingPrecipForProvince, retStr);
                            break;
                        case AppTaskCommandEnum.ExportToArcGIS:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumExportToArcGIS, retStr);
                            break;
                        case AppTaskCommandEnum.GenerateClassificationForCSSPWebToolsVisualization:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumGenerateClassificationForCSSPWebToolsVisualization, retStr);
                            break;
                        case AppTaskCommandEnum.GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumGenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSites:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVNationalOfMWQMSites, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSamples:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVNationalOfMWQMSamples, retStr);
                            break;
                        case AppTaskCommandEnum.ProvinceToolsCreateClassificationInputsKML:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateClassificationInputsKML, retStr);
                            break;
                        case AppTaskCommandEnum.ProvinceToolsCreateGroupingInputsKML:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateGroupingInputsKML, retStr);
                            break;
                        case AppTaskCommandEnum.ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateMWQMSitesAndPolSourceSitesKML, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateHydrometricSiteInformation:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteInformation, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate, retStr);
                            break;
                        case AppTaskCommandEnum.GetHydrometricSitesDataForRunsOfYear:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumGetHydrometricSitesDataForRunsOfYear, retStr);
                            break;
                        case AppTaskCommandEnum.GetAllDischargesForYear:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumGetAllDischargesForYear, retStr);
                            break;
                        case AppTaskCommandEnum.FillRunDischargesByHydrometricSitePriorityForYear:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumFillRunDischargesByHydrometricSitePriorityForYear, retStr);
                            break;
                        case AppTaskCommandEnum.FindMissingDischargesForProvince:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumFindMissingDischargesForProvince, retStr);
                            break;
                        case AppTaskCommandEnum.LoadHydrometricDataValue:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumLoadHydrometricDataValue, retStr);
                            break;
                        case AppTaskCommandEnum.GenerateKMLFileClassificationForCSSPWebToolsVisualization:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumGenerateKMLFileClassificationForCSSPWebToolsVisualization, retStr);
                            break;
                        case AppTaskCommandEnum.ProvinceToolsGenerateStats:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsGenerateStats, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioPrepareResults:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioPrepareResults, retStr);
                            break;
                        case AppTaskCommandEnum.ClimateSiteLoadCoCoRaHSData:
                            Assert.Equal(BaseEnumServiceRes.AppTaskCommandEnumClimateSiteLoadCoCoRaHSData, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_AppTaskStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AppTaskStatusEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AppTaskStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AppTaskStatusEnum((AppTaskStatusEnum)i);
        
                    switch ((AppTaskStatusEnum)i)
                    {
                        case AppTaskStatusEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AppTaskStatusEnum.Created:
                            Assert.Equal(BaseEnumServiceRes.AppTaskStatusEnumCreated, retStr);
                            break;
                        case AppTaskStatusEnum.Running:
                            Assert.Equal(BaseEnumServiceRes.AppTaskStatusEnumRunning, retStr);
                            break;
                        case AppTaskStatusEnum.Completed:
                            Assert.Equal(BaseEnumServiceRes.AppTaskStatusEnumCompleted, retStr);
                            break;
                        case AppTaskStatusEnum.Cancelled:
                            Assert.Equal(BaseEnumServiceRes.AppTaskStatusEnumCancelled, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_BeaufortScaleEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_BeaufortScaleEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(BeaufortScaleEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_BeaufortScaleEnum((BeaufortScaleEnum)i);
        
                    switch ((BeaufortScaleEnum)i)
                    {
                        case BeaufortScaleEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case BeaufortScaleEnum.Calm:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumCalm, retStr);
                            break;
                        case BeaufortScaleEnum.LightAir:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumLightAir, retStr);
                            break;
                        case BeaufortScaleEnum.LightBreeze:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumLightBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.GentleBreeze:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumGentleBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.ModerateBreeze:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumModerateBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.FreshBreeze:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumFreshBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.StrongBreeze:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumStrongBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.HighWind_ModerateGale_NearGale:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumHighWind_ModerateGale_NearGale, retStr);
                            break;
                        case BeaufortScaleEnum.Gale_FreshGale:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumGale_FreshGale, retStr);
                            break;
                        case BeaufortScaleEnum.Strong_SevereGale:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumStrong_SevereGale, retStr);
                            break;
                        case BeaufortScaleEnum.Storm_WholeGale:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumStorm_WholeGale, retStr);
                            break;
                        case BeaufortScaleEnum.ViolentStorm:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumViolentStorm, retStr);
                            break;
                        case BeaufortScaleEnum.HurricaneForce:
                            Assert.Equal(BaseEnumServiceRes.BeaufortScaleEnumHurricaneForce, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_BoxModelResultTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_BoxModelResultTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(BoxModelResultTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_BoxModelResultTypeEnum((BoxModelResultTypeEnum)i);
        
                    switch ((BoxModelResultTypeEnum)i)
                    {
                        case BoxModelResultTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case BoxModelResultTypeEnum.Dilution:
                            Assert.Equal(BaseEnumServiceRes.BoxModelResultTypeEnumDilution, retStr);
                            break;
                        case BoxModelResultTypeEnum.NoDecayUntreated:
                            Assert.Equal(BaseEnumServiceRes.BoxModelResultTypeEnumNoDecayUntreated, retStr);
                            break;
                        case BoxModelResultTypeEnum.NoDecayPreDisinfection:
                            Assert.Equal(BaseEnumServiceRes.BoxModelResultTypeEnumNoDecayPreDisinfection, retStr);
                            break;
                        case BoxModelResultTypeEnum.DecayUntreated:
                            Assert.Equal(BaseEnumServiceRes.BoxModelResultTypeEnumDecayUntreated, retStr);
                            break;
                        case BoxModelResultTypeEnum.DecayPreDisinfection:
                            Assert.Equal(BaseEnumServiceRes.BoxModelResultTypeEnumDecayPreDisinfection, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ClassificationTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ClassificationTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ClassificationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ClassificationTypeEnum((ClassificationTypeEnum)i);
        
                    switch ((ClassificationTypeEnum)i)
                    {
                        case ClassificationTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ClassificationTypeEnum.Approved:
                            Assert.Equal(BaseEnumServiceRes.ClassificationTypeEnumApproved, retStr);
                            break;
                        case ClassificationTypeEnum.Restricted:
                            Assert.Equal(BaseEnumServiceRes.ClassificationTypeEnumRestricted, retStr);
                            break;
                        case ClassificationTypeEnum.Prohibited:
                            Assert.Equal(BaseEnumServiceRes.ClassificationTypeEnumProhibited, retStr);
                            break;
                        case ClassificationTypeEnum.ConditionallyApproved:
                            Assert.Equal(BaseEnumServiceRes.ClassificationTypeEnumConditionallyApproved, retStr);
                            break;
                        case ClassificationTypeEnum.ConditionallyRestricted:
                            Assert.Equal(BaseEnumServiceRes.ClassificationTypeEnumConditionallyRestricted, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_CollectionSystemTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_CollectionSystemTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(CollectionSystemTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_CollectionSystemTypeEnum((CollectionSystemTypeEnum)i);
        
                    switch ((CollectionSystemTypeEnum)i)
                    {
                        case CollectionSystemTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case CollectionSystemTypeEnum.CompletelySeparated:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCompletelySeparated, retStr);
                            break;
                        case CollectionSystemTypeEnum.CompletelyCombined:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCompletelyCombined, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined90Separated10:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined90Separated10, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined80Separated20:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined80Separated20, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined70Separated30:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined70Separated30, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined60Separated40:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined60Separated40, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined50Separated50:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined50Separated50, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined40Separated60:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined40Separated60, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined30Separated70:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined30Separated70, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined20Separated80:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined20Separated80, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined10Separated90:
                            Assert.Equal(BaseEnumServiceRes.CollectionSystemTypeEnumCombined10Separated90, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ContactTitleEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ContactTitleEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ContactTitleEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ContactTitleEnum((ContactTitleEnum)i);
        
                    switch ((ContactTitleEnum)i)
                    {
                        case ContactTitleEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ContactTitleEnum.DirectorGeneral:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumDirectorGeneral, retStr);
                            break;
                        case ContactTitleEnum.DirectorPublicWorks:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumDirectorPublicWorks, retStr);
                            break;
                        case ContactTitleEnum.Superintendent:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumSuperintendent, retStr);
                            break;
                        case ContactTitleEnum.Engineer:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumEngineer, retStr);
                            break;
                        case ContactTitleEnum.Foreman:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumForeman, retStr);
                            break;
                        case ContactTitleEnum.Operator:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumOperator, retStr);
                            break;
                        case ContactTitleEnum.FacilitiesManager:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumFacilitiesManager, retStr);
                            break;
                        case ContactTitleEnum.Supervisor:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumSupervisor, retStr);
                            break;
                        case ContactTitleEnum.Technician:
                            Assert.Equal(BaseEnumServiceRes.ContactTitleEnumTechnician, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_CSSPWQInputSheetTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_CSSPWQInputSheetTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(CSSPWQInputSheetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_CSSPWQInputSheetTypeEnum((CSSPWQInputSheetTypeEnum)i);
        
                    switch ((CSSPWQInputSheetTypeEnum)i)
                    {
                        case CSSPWQInputSheetTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case CSSPWQInputSheetTypeEnum.A1:
                            Assert.Equal(BaseEnumServiceRes.CSSPWQInputSheetTypeEnumA1, retStr);
                            break;
                        case CSSPWQInputSheetTypeEnum.LTB:
                            Assert.Equal(BaseEnumServiceRes.CSSPWQInputSheetTypeEnumLTB, retStr);
                            break;
                        case CSSPWQInputSheetTypeEnum.EC:
                            Assert.Equal(BaseEnumServiceRes.CSSPWQInputSheetTypeEnumEC, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_CSSPWQInputTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_CSSPWQInputTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(CSSPWQInputTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_CSSPWQInputTypeEnum((CSSPWQInputTypeEnum)i);
        
                    switch ((CSSPWQInputTypeEnum)i)
                    {
                        case CSSPWQInputTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case CSSPWQInputTypeEnum.Subsector:
                            Assert.Equal(BaseEnumServiceRes.CSSPWQInputTypeEnumSubsector, retStr);
                            break;
                        case CSSPWQInputTypeEnum.Municipality:
                            Assert.Equal(BaseEnumServiceRes.CSSPWQInputTypeEnumMunicipality, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_DailyOrHourlyDataEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_DailyOrHourlyDataEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(DailyOrHourlyDataEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_DailyOrHourlyDataEnum((DailyOrHourlyDataEnum)i);
        
                    switch ((DailyOrHourlyDataEnum)i)
                    {
                        case DailyOrHourlyDataEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case DailyOrHourlyDataEnum.Daily:
                            Assert.Equal(BaseEnumServiceRes.DailyOrHourlyDataEnumDaily, retStr);
                            break;
                        case DailyOrHourlyDataEnum.Hourly:
                            Assert.Equal(BaseEnumServiceRes.DailyOrHourlyDataEnumHourly, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_DisinfectionTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_DisinfectionTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(DisinfectionTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_DisinfectionTypeEnum((DisinfectionTypeEnum)i);
        
                    switch ((DisinfectionTypeEnum)i)
                    {
                        case DisinfectionTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case DisinfectionTypeEnum.None:
                            Assert.Equal(BaseEnumServiceRes.DisinfectionTypeEnumNone, retStr);
                            break;
                        case DisinfectionTypeEnum.UV:
                            Assert.Equal(BaseEnumServiceRes.DisinfectionTypeEnumUV, retStr);
                            break;
                        case DisinfectionTypeEnum.ChlorinationNoDechlorination:
                            Assert.Equal(BaseEnumServiceRes.DisinfectionTypeEnumChlorinationNoDechlorination, retStr);
                            break;
                        case DisinfectionTypeEnum.ChlorinationWithDechlorination:
                            Assert.Equal(BaseEnumServiceRes.DisinfectionTypeEnumChlorinationWithDechlorination, retStr);
                            break;
                        case DisinfectionTypeEnum.UVSeasonal:
                            Assert.Equal(BaseEnumServiceRes.DisinfectionTypeEnumUVSeasonal, retStr);
                            break;
                        case DisinfectionTypeEnum.ChlorinationNoDechlorinationSeasonal:
                            Assert.Equal(BaseEnumServiceRes.DisinfectionTypeEnumChlorinationNoDechlorinationSeasonal, retStr);
                            break;
                        case DisinfectionTypeEnum.ChlorinationWithDechlorinationSeasonal:
                            Assert.Equal(BaseEnumServiceRes.DisinfectionTypeEnumChlorinationWithDechlorinationSeasonal, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_DrogueTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_DrogueTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(DrogueTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_DrogueTypeEnum((DrogueTypeEnum)i);
        
                    switch ((DrogueTypeEnum)i)
                    {
                        case DrogueTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case DrogueTypeEnum.SmallDrogue:
                            Assert.Equal(BaseEnumServiceRes.DrogueTypeEnumSmallDrogue, retStr);
                            break;
                        case DrogueTypeEnum.LargeDrogue:
                            Assert.Equal(BaseEnumServiceRes.DrogueTypeEnumLargeDrogue, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_EmailTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_EmailTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(EmailTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_EmailTypeEnum((EmailTypeEnum)i);
        
                    switch ((EmailTypeEnum)i)
                    {
                        case EmailTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case EmailTypeEnum.Personal:
                            Assert.Equal(BaseEnumServiceRes.EmailTypeEnumPersonal, retStr);
                            break;
                        case EmailTypeEnum.Work:
                            Assert.Equal(BaseEnumServiceRes.EmailTypeEnumWork, retStr);
                            break;
                        case EmailTypeEnum.Personal2:
                            Assert.Equal(BaseEnumServiceRes.EmailTypeEnumPersonal2, retStr);
                            break;
                        case EmailTypeEnum.Work2:
                            Assert.Equal(BaseEnumServiceRes.EmailTypeEnumWork2, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ExcelExportShowDataTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ExcelExportShowDataTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ExcelExportShowDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ExcelExportShowDataTypeEnum((ExcelExportShowDataTypeEnum)i);
        
                    switch ((ExcelExportShowDataTypeEnum)i)
                    {
                        case ExcelExportShowDataTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.FecalColiform:
                            Assert.Equal(BaseEnumServiceRes.ExcelExportShowDataTypeEnumFecalColiform, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.Temperature:
                            Assert.Equal(BaseEnumServiceRes.ExcelExportShowDataTypeEnumTemperature, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.Salinity:
                            Assert.Equal(BaseEnumServiceRes.ExcelExportShowDataTypeEnumSalinity, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.P90:
                            Assert.Equal(BaseEnumServiceRes.ExcelExportShowDataTypeEnumP90, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.GemetricMean:
                            Assert.Equal(BaseEnumServiceRes.ExcelExportShowDataTypeEnumGemetricMean, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.Median:
                            Assert.Equal(BaseEnumServiceRes.ExcelExportShowDataTypeEnumMedian, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.PercOfP90Over43:
                            Assert.Equal(BaseEnumServiceRes.ExcelExportShowDataTypeEnumPercOfP90Over43, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.PercOfP90Over260:
                            Assert.Equal(BaseEnumServiceRes.ExcelExportShowDataTypeEnumPercOfP90Over260, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_FacilityTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_FacilityTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(FacilityTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_FacilityTypeEnum((FacilityTypeEnum)i);
        
                    switch ((FacilityTypeEnum)i)
                    {
                        case FacilityTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case FacilityTypeEnum.Lagoon:
                            Assert.Equal(BaseEnumServiceRes.FacilityTypeEnumLagoon, retStr);
                            break;
                        case FacilityTypeEnum.Plant:
                            Assert.Equal(BaseEnumServiceRes.FacilityTypeEnumPlant, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_FilePurposeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_FilePurposeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(FilePurposeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_FilePurposeEnum((FilePurposeEnum)i);
        
                    switch ((FilePurposeEnum)i)
                    {
                        case FilePurposeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case FilePurposeEnum.MikeInput:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumMikeInput, retStr);
                            break;
                        case FilePurposeEnum.MikeInputMDF:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumMikeInputMDF, retStr);
                            break;
                        case FilePurposeEnum.MikeResultDFSU:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumMikeResultDFSU, retStr);
                            break;
                        case FilePurposeEnum.MikeResultKMZ:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumMikeResultKMZ, retStr);
                            break;
                        case FilePurposeEnum.Information:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumInformation, retStr);
                            break;
                        case FilePurposeEnum.Image:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumImage, retStr);
                            break;
                        case FilePurposeEnum.Picture:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumPicture, retStr);
                            break;
                        case FilePurposeEnum.ReportGenerated:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumReportGenerated, retStr);
                            break;
                        case FilePurposeEnum.TemplateGenerated:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumTemplateGenerated, retStr);
                            break;
                        case FilePurposeEnum.GeneratedFCForm:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumGeneratedFCForm, retStr);
                            break;
                        case FilePurposeEnum.Template:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumTemplate, retStr);
                            break;
                        case FilePurposeEnum.Map:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumMap, retStr);
                            break;
                        case FilePurposeEnum.Analysis:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumAnalysis, retStr);
                            break;
                        case FilePurposeEnum.OpenData:
                            Assert.Equal(BaseEnumServiceRes.FilePurposeEnumOpenData, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_FileStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_FileStatusEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(FileStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_FileStatusEnum((FileStatusEnum)i);
        
                    switch ((FileStatusEnum)i)
                    {
                        case FileStatusEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case FileStatusEnum.Changed:
                            Assert.Equal(BaseEnumServiceRes.FileStatusEnumChanged, retStr);
                            break;
                        case FileStatusEnum.Sent:
                            Assert.Equal(BaseEnumServiceRes.FileStatusEnumSent, retStr);
                            break;
                        case FileStatusEnum.Accepted:
                            Assert.Equal(BaseEnumServiceRes.FileStatusEnumAccepted, retStr);
                            break;
                        case FileStatusEnum.Rejected:
                            Assert.Equal(BaseEnumServiceRes.FileStatusEnumRejected, retStr);
                            break;
                        case FileStatusEnum.Fail:
                            Assert.Equal(BaseEnumServiceRes.FileStatusEnumFail, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_FileTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_FileTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(FileTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_FileTypeEnum((FileTypeEnum)i);
        
                    switch ((FileTypeEnum)i)
                    {
                        case FileTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case FileTypeEnum.DFS0:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumDFS0, retStr);
                            break;
                        case FileTypeEnum.DFS1:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumDFS1, retStr);
                            break;
                        case FileTypeEnum.DFSU:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumDFSU, retStr);
                            break;
                        case FileTypeEnum.KMZ:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumKMZ, retStr);
                            break;
                        case FileTypeEnum.LOG:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumLOG, retStr);
                            break;
                        case FileTypeEnum.M21FM:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumM21FM, retStr);
                            break;
                        case FileTypeEnum.M3FM:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumM3FM, retStr);
                            break;
                        case FileTypeEnum.MDF:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumMDF, retStr);
                            break;
                        case FileTypeEnum.MESH:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumMESH, retStr);
                            break;
                        case FileTypeEnum.XLSX:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumXLSX, retStr);
                            break;
                        case FileTypeEnum.DOCX:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumDOCX, retStr);
                            break;
                        case FileTypeEnum.PDF:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumPDF, retStr);
                            break;
                        case FileTypeEnum.JPG:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumJPG, retStr);
                            break;
                        case FileTypeEnum.JPEG:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumJPEG, retStr);
                            break;
                        case FileTypeEnum.GIF:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumGIF, retStr);
                            break;
                        case FileTypeEnum.PNG:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumPNG, retStr);
                            break;
                        case FileTypeEnum.HTML:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumHTML, retStr);
                            break;
                        case FileTypeEnum.TXT:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumTXT, retStr);
                            break;
                        case FileTypeEnum.XYZ:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumXYZ, retStr);
                            break;
                        case FileTypeEnum.KML:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumKML, retStr);
                            break;
                        case FileTypeEnum.CSV:
                            Assert.Equal(BaseEnumServiceRes.FileTypeEnumCSV, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_InfrastructureTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_InfrastructureTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(InfrastructureTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_InfrastructureTypeEnum((InfrastructureTypeEnum)i);
        
                    switch ((InfrastructureTypeEnum)i)
                    {
                        case InfrastructureTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case InfrastructureTypeEnum.WWTP:
                            Assert.Equal(BaseEnumServiceRes.InfrastructureTypeEnumWWTP, retStr);
                            break;
                        case InfrastructureTypeEnum.LiftStation:
                            Assert.Equal(BaseEnumServiceRes.InfrastructureTypeEnumLiftStation, retStr);
                            break;
                        case InfrastructureTypeEnum.Other:
                            Assert.Equal(BaseEnumServiceRes.InfrastructureTypeEnumOther, retStr);
                            break;
                        case InfrastructureTypeEnum.SeeOtherMunicipality:
                            Assert.Equal(BaseEnumServiceRes.InfrastructureTypeEnumSeeOtherMunicipality, retStr);
                            break;
                        case InfrastructureTypeEnum.LineOverflow:
                            Assert.Equal(BaseEnumServiceRes.InfrastructureTypeEnumLineOverflow, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_KMZActionEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_KMZActionEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(KMZActionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_KMZActionEnum((KMZActionEnum)i);
        
                    switch ((KMZActionEnum)i)
                    {
                        case KMZActionEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case KMZActionEnum.DoNothing:
                            Assert.Equal(BaseEnumServiceRes.KMZActionEnumDoNothing, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZContourAnimation:
                            Assert.Equal(BaseEnumServiceRes.KMZActionEnumGenerateKMZContourAnimation, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZContourLimit:
                            Assert.Equal(BaseEnumServiceRes.KMZActionEnumGenerateKMZContourLimit, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZCurrentAnimation:
                            Assert.Equal(BaseEnumServiceRes.KMZActionEnumGenerateKMZCurrentAnimation, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZCurrentMaximum:
                            Assert.Equal(BaseEnumServiceRes.KMZActionEnumGenerateKMZCurrentMaximum, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZMesh:
                            Assert.Equal(BaseEnumServiceRes.KMZActionEnumGenerateKMZMesh, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZStudyArea:
                            Assert.Equal(BaseEnumServiceRes.KMZActionEnumGenerateKMZStudyArea, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZBoundaryConditionNodes:
                            Assert.Equal(BaseEnumServiceRes.KMZActionEnumGenerateKMZBoundaryConditionNodes, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_LaboratoryEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LaboratoryEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LaboratoryEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LaboratoryEnum((LaboratoryEnum)i);
        
                    switch ((LaboratoryEnum)i)
                    {
                        case LaboratoryEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LaboratoryEnum.ZZ_0:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_0, retStr);
                            break;
                        case LaboratoryEnum.ZZ_1:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_1, retStr);
                            break;
                        case LaboratoryEnum.ZZ_2:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_2, retStr);
                            break;
                        case LaboratoryEnum.ZZ_3:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_3, retStr);
                            break;
                        case LaboratoryEnum.ZZ_4:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_4, retStr);
                            break;
                        case LaboratoryEnum.ZZ_1Q:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_1Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_2Q:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_2Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_3Q:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_3Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_4Q:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_4Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_5Q:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_5Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_11BC:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_11BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_12BC:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_12BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_13BC:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_13BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_14BC:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_14BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_15BC:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_15BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_16BC:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_16BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_17BC:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_17BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_18BC:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumZZ_18BC, retStr);
                            break;
                        case LaboratoryEnum.MonctonEnvironmentCanada:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumMonctonEnvironmentCanada, retStr);
                            break;
                        case LaboratoryEnum.BIOEnvironmentCanada:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumBIOEnvironmentCanada, retStr);
                            break;
                        case LaboratoryEnum.EasternCharlotteWaterwayLaboratory:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumEasternCharlotteWaterwayLaboratory, retStr);
                            break;
                        case LaboratoryEnum.InstitutDeRechercheSurLesZonesCotieres:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumInstitutDeRechercheSurLesZonesCotieres, retStr);
                            break;
                        case LaboratoryEnum.CentreDeRechercheSurLesAliments:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumCentreDeRechercheSurLesAliments, retStr);
                            break;
                        case LaboratoryEnum.CaraquetMobileLaboratoryEnvironmentCanada:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumCaraquetMobileLaboratoryEnvironmentCanada, retStr);
                            break;
                        case LaboratoryEnum.MaxxamAnalyticsBedford:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumMaxxamAnalyticsBedford, retStr);
                            break;
                        case LaboratoryEnum.MaxxamAnalyticsSydney:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumMaxxamAnalyticsSydney, retStr);
                            break;
                        case LaboratoryEnum.PEIAnalyticalLaboratory:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumPEIAnalyticalLaboratory, retStr);
                            break;
                        case LaboratoryEnum.NLMobileLaboratory:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumNLMobileLaboratory, retStr);
                            break;
                        case LaboratoryEnum.AvalonLaboratoriesInc:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumAvalonLaboratoriesInc, retStr);
                            break;
                        case LaboratoryEnum.Maxxam:
                            Assert.Equal(BaseEnumServiceRes.LaboratoryEnumMaxxam, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_LabSheetStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LabSheetStatusEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LabSheetStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LabSheetStatusEnum((LabSheetStatusEnum)i);
        
                    switch ((LabSheetStatusEnum)i)
                    {
                        case LabSheetStatusEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LabSheetStatusEnum.Created:
                            Assert.Equal(BaseEnumServiceRes.LabSheetStatusEnumCreated, retStr);
                            break;
                        case LabSheetStatusEnum.Transferred:
                            Assert.Equal(BaseEnumServiceRes.LabSheetStatusEnumTransferred, retStr);
                            break;
                        case LabSheetStatusEnum.Accepted:
                            Assert.Equal(BaseEnumServiceRes.LabSheetStatusEnumAccepted, retStr);
                            break;
                        case LabSheetStatusEnum.Rejected:
                            Assert.Equal(BaseEnumServiceRes.LabSheetStatusEnumRejected, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_LabSheetTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LabSheetTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LabSheetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LabSheetTypeEnum((LabSheetTypeEnum)i);
        
                    switch ((LabSheetTypeEnum)i)
                    {
                        case LabSheetTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LabSheetTypeEnum.A1:
                            Assert.Equal(BaseEnumServiceRes.LabSheetTypeEnumA1, retStr);
                            break;
                        case LabSheetTypeEnum.LTB:
                            Assert.Equal(BaseEnumServiceRes.LabSheetTypeEnumLTB, retStr);
                            break;
                        case LabSheetTypeEnum.EC:
                            Assert.Equal(BaseEnumServiceRes.LabSheetTypeEnumEC, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_LanguageEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LanguageEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LanguageEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LanguageEnum((LanguageEnum)i);
        
                    switch ((LanguageEnum)i)
                    {
                        case LanguageEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LanguageEnum.en:
                            Assert.Equal(BaseEnumServiceRes.LanguageEnumen, retStr);
                            break;
                        case LanguageEnum.fr:
                            Assert.Equal(BaseEnumServiceRes.LanguageEnumfr, retStr);
                            break;
                        case LanguageEnum.enAndfr:
                            Assert.Equal(BaseEnumServiceRes.LanguageEnumenAndfr, retStr);
                            break;
                        case LanguageEnum.es:
                            Assert.Equal(BaseEnumServiceRes.LanguageEnumes, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_LogCommandEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LogCommandEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LogCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LogCommandEnum((LogCommandEnum)i);
        
                    switch ((LogCommandEnum)i)
                    {
                        case LogCommandEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LogCommandEnum.Add:
                            Assert.Equal(BaseEnumServiceRes.LogCommandEnumAdd, retStr);
                            break;
                        case LogCommandEnum.Change:
                            Assert.Equal(BaseEnumServiceRes.LogCommandEnumChange, retStr);
                            break;
                        case LogCommandEnum.Delete:
                            Assert.Equal(BaseEnumServiceRes.LogCommandEnumDelete, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_MapInfoDrawTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_MapInfoDrawTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(MapInfoDrawTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_MapInfoDrawTypeEnum((MapInfoDrawTypeEnum)i);
        
                    switch ((MapInfoDrawTypeEnum)i)
                    {
                        case MapInfoDrawTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case MapInfoDrawTypeEnum.Point:
                            Assert.Equal(BaseEnumServiceRes.MapInfoDrawTypeEnumPoint, retStr);
                            break;
                        case MapInfoDrawTypeEnum.Polyline:
                            Assert.Equal(BaseEnumServiceRes.MapInfoDrawTypeEnumPolyline, retStr);
                            break;
                        case MapInfoDrawTypeEnum.Polygon:
                            Assert.Equal(BaseEnumServiceRes.MapInfoDrawTypeEnumPolygon, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(MikeBoundaryConditionLevelOrVelocityEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum((MikeBoundaryConditionLevelOrVelocityEnum)i);
        
                    switch ((MikeBoundaryConditionLevelOrVelocityEnum)i)
                    {
                        case MikeBoundaryConditionLevelOrVelocityEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case MikeBoundaryConditionLevelOrVelocityEnum.Level:
                            Assert.Equal(BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocityEnumLevel, retStr);
                            break;
                        case MikeBoundaryConditionLevelOrVelocityEnum.Velocity:
                            Assert.Equal(BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocityEnumVelocity, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_MikeScenarioSpecialResultKMLTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_MikeScenarioSpecialResultKMLTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(MikeScenarioSpecialResultKMLTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_MikeScenarioSpecialResultKMLTypeEnum((MikeScenarioSpecialResultKMLTypeEnum)i);
        
                    switch ((MikeScenarioSpecialResultKMLTypeEnum)i)
                    {
                        case MikeScenarioSpecialResultKMLTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.Mesh:
                            Assert.Equal(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumMesh, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.StudyArea:
                            Assert.Equal(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumStudyArea, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.BoundaryConditions:
                            Assert.Equal(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumBoundaryConditions, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.PollutionLimit:
                            Assert.Equal(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumPollutionLimit, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.PollutionAnimation:
                            Assert.Equal(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumPollutionAnimation, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_MWQMSiteLatestClassificationEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_MWQMSiteLatestClassificationEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(MWQMSiteLatestClassificationEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_MWQMSiteLatestClassificationEnum((MWQMSiteLatestClassificationEnum)i);
        
                    switch ((MWQMSiteLatestClassificationEnum)i)
                    {
                        case MWQMSiteLatestClassificationEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.Approved:
                            Assert.Equal(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumApproved, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
                            Assert.Equal(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumConditionallyApproved, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.Restricted:
                            Assert.Equal(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumRestricted, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
                            Assert.Equal(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumConditionallyRestricted, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.Prohibited:
                            Assert.Equal(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumProhibited, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.Unclassified:
                            Assert.Equal(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumUnclassified, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_PolSourceInactiveReasonEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PolSourceInactiveReasonEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PolSourceInactiveReasonEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PolSourceInactiveReasonEnum((PolSourceInactiveReasonEnum)i);
        
                    switch ((PolSourceInactiveReasonEnum)i)
                    {
                        case PolSourceInactiveReasonEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PolSourceInactiveReasonEnum.Abandoned:
                            Assert.Equal(BaseEnumServiceRes.PolSourceInactiveReasonEnumAbandoned, retStr);
                            break;
                        case PolSourceInactiveReasonEnum.Closed:
                            Assert.Equal(BaseEnumServiceRes.PolSourceInactiveReasonEnumClosed, retStr);
                            break;
                        case PolSourceInactiveReasonEnum.Removed:
                            Assert.Equal(BaseEnumServiceRes.PolSourceInactiveReasonEnumRemoved, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_PolSourceIssueRiskEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PolSourceIssueRiskEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PolSourceIssueRiskEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PolSourceIssueRiskEnum((PolSourceIssueRiskEnum)i);
        
                    switch ((PolSourceIssueRiskEnum)i)
                    {
                        case PolSourceIssueRiskEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PolSourceIssueRiskEnum.LowRisk:
                            Assert.Equal(BaseEnumServiceRes.PolSourceIssueRiskEnumLowRisk, retStr);
                            break;
                        case PolSourceIssueRiskEnum.ModerateRisk:
                            Assert.Equal(BaseEnumServiceRes.PolSourceIssueRiskEnumModerateRisk, retStr);
                            break;
                        case PolSourceIssueRiskEnum.HighRisk:
                            Assert.Equal(BaseEnumServiceRes.PolSourceIssueRiskEnumHighRisk, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_PositionEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PositionEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PositionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PositionEnum((PositionEnum)i);
        
                    switch ((PositionEnum)i)
                    {
                        case PositionEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PositionEnum.LeftBottom:
                            Assert.Equal(BaseEnumServiceRes.PositionEnumLeftBottom, retStr);
                            break;
                        case PositionEnum.RightBottom:
                            Assert.Equal(BaseEnumServiceRes.PositionEnumRightBottom, retStr);
                            break;
                        case PositionEnum.LeftTop:
                            Assert.Equal(BaseEnumServiceRes.PositionEnumLeftTop, retStr);
                            break;
                        case PositionEnum.RightTop:
                            Assert.Equal(BaseEnumServiceRes.PositionEnumRightTop, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_PreliminaryTreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PreliminaryTreatmentTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PreliminaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PreliminaryTreatmentTypeEnum((PreliminaryTreatmentTypeEnum)i);
        
                    switch ((PreliminaryTreatmentTypeEnum)i)
                    {
                        case PreliminaryTreatmentTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PreliminaryTreatmentTypeEnum.NotApplicable:
                            Assert.Equal(BaseEnumServiceRes.PreliminaryTreatmentTypeEnumNotApplicable, retStr);
                            break;
                        case PreliminaryTreatmentTypeEnum.BarScreen:
                            Assert.Equal(BaseEnumServiceRes.PreliminaryTreatmentTypeEnumBarScreen, retStr);
                            break;
                        case PreliminaryTreatmentTypeEnum.Grinder:
                            Assert.Equal(BaseEnumServiceRes.PreliminaryTreatmentTypeEnumGrinder, retStr);
                            break;
                        case PreliminaryTreatmentTypeEnum.MechanicalScreening:
                            Assert.Equal(BaseEnumServiceRes.PreliminaryTreatmentTypeEnumMechanicalScreening, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_PrimaryTreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PrimaryTreatmentTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PrimaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PrimaryTreatmentTypeEnum((PrimaryTreatmentTypeEnum)i);
        
                    switch ((PrimaryTreatmentTypeEnum)i)
                    {
                        case PrimaryTreatmentTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.NotApplicable:
                            Assert.Equal(BaseEnumServiceRes.PrimaryTreatmentTypeEnumNotApplicable, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.Sedimentation:
                            Assert.Equal(BaseEnumServiceRes.PrimaryTreatmentTypeEnumSedimentation, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.ChemicalCoagulation:
                            Assert.Equal(BaseEnumServiceRes.PrimaryTreatmentTypeEnumChemicalCoagulation, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.Filtration:
                            Assert.Equal(BaseEnumServiceRes.PrimaryTreatmentTypeEnumFiltration, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.PrimaryClarification:
                            Assert.Equal(BaseEnumServiceRes.PrimaryTreatmentTypeEnumPrimaryClarification, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportConditionEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportConditionEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportConditionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportConditionEnum((ReportConditionEnum)i);
        
                    switch ((ReportConditionEnum)i)
                    {
                        case ReportConditionEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionTrue:
                            Assert.Equal(BaseEnumServiceRes.ReportConditionEnumReportConditionTrue, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionFalse:
                            Assert.Equal(BaseEnumServiceRes.ReportConditionEnumReportConditionFalse, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionContain:
                            Assert.Equal(BaseEnumServiceRes.ReportConditionEnumReportConditionContain, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionStart:
                            Assert.Equal(BaseEnumServiceRes.ReportConditionEnumReportConditionStart, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionEnd:
                            Assert.Equal(BaseEnumServiceRes.ReportConditionEnumReportConditionEnd, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionBigger:
                            Assert.Equal(BaseEnumServiceRes.ReportConditionEnumReportConditionBigger, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionSmaller:
                            Assert.Equal(BaseEnumServiceRes.ReportConditionEnumReportConditionSmaller, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionEqual:
                            Assert.Equal(BaseEnumServiceRes.ReportConditionEnumReportConditionEqual, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportFieldTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportFieldTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportFieldTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportFieldTypeEnum((ReportFieldTypeEnum)i);
        
                    switch ((ReportFieldTypeEnum)i)
                    {
                        case ReportFieldTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportFieldTypeEnum.NumberWhole:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumNumberWhole, retStr);
                            break;
                        case ReportFieldTypeEnum.NumberWithDecimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumNumberWithDecimal, retStr);
                            break;
                        case ReportFieldTypeEnum.DateAndTime:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumDateAndTime, retStr);
                            break;
                        case ReportFieldTypeEnum.Text:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumText, retStr);
                            break;
                        case ReportFieldTypeEnum.TrueOrFalse:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumTrueOrFalse, retStr);
                            break;
                        case ReportFieldTypeEnum.FilePurpose:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumFilePurpose, retStr);
                            break;
                        case ReportFieldTypeEnum.FileType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumFileType, retStr);
                            break;
                        case ReportFieldTypeEnum.TranslationStatus:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumTranslationStatus, retStr);
                            break;
                        case ReportFieldTypeEnum.BoxModelResultType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumBoxModelResultType, retStr);
                            break;
                        case ReportFieldTypeEnum.InfrastructureType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumInfrastructureType, retStr);
                            break;
                        case ReportFieldTypeEnum.FacilityType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumFacilityType, retStr);
                            break;
                        case ReportFieldTypeEnum.AerationType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumAerationType, retStr);
                            break;
                        case ReportFieldTypeEnum.PreliminaryTreatmentType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumPreliminaryTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.PrimaryTreatmentType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumPrimaryTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.SecondaryTreatmentType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumSecondaryTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.TertiaryTreatmentType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumTertiaryTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.TreatmentType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.DisinfectionType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumDisinfectionType, retStr);
                            break;
                        case ReportFieldTypeEnum.CollectionSystemType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumCollectionSystemType, retStr);
                            break;
                        case ReportFieldTypeEnum.AlarmSystemType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumAlarmSystemType, retStr);
                            break;
                        case ReportFieldTypeEnum.ScenarioStatus:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumScenarioStatus, retStr);
                            break;
                        case ReportFieldTypeEnum.StorageDataType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumStorageDataType, retStr);
                            break;
                        case ReportFieldTypeEnum.Language:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumLanguage, retStr);
                            break;
                        case ReportFieldTypeEnum.SampleType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumSampleType, retStr);
                            break;
                        case ReportFieldTypeEnum.BeaufortScale:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumBeaufortScale, retStr);
                            break;
                        case ReportFieldTypeEnum.AnalyzeMethod:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumAnalyzeMethod, retStr);
                            break;
                        case ReportFieldTypeEnum.SampleMatrix:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumSampleMatrix, retStr);
                            break;
                        case ReportFieldTypeEnum.Laboratory:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumLaboratory, retStr);
                            break;
                        case ReportFieldTypeEnum.SampleStatus:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumSampleStatus, retStr);
                            break;
                        case ReportFieldTypeEnum.SamplingPlanType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumSamplingPlanType, retStr);
                            break;
                        case ReportFieldTypeEnum.LabSheetSampleType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumLabSheetSampleType, retStr);
                            break;
                        case ReportFieldTypeEnum.LabSheetType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumLabSheetType, retStr);
                            break;
                        case ReportFieldTypeEnum.LabSheetStatus:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumLabSheetStatus, retStr);
                            break;
                        case ReportFieldTypeEnum.PolSourceInactiveReason:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumPolSourceInactiveReason, retStr);
                            break;
                        case ReportFieldTypeEnum.PolSourceObsInfo:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumPolSourceObsInfo, retStr);
                            break;
                        case ReportFieldTypeEnum.AddressType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumAddressType, retStr);
                            break;
                        case ReportFieldTypeEnum.StreetType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumStreetType, retStr);
                            break;
                        case ReportFieldTypeEnum.ContactTitle:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumContactTitle, retStr);
                            break;
                        case ReportFieldTypeEnum.EmailType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumEmailType, retStr);
                            break;
                        case ReportFieldTypeEnum.TelType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumTelType, retStr);
                            break;
                        case ReportFieldTypeEnum.TideText:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumTideText, retStr);
                            break;
                        case ReportFieldTypeEnum.TideDataType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumTideDataType, retStr);
                            break;
                        case ReportFieldTypeEnum.SpecialTableType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumSpecialTableType, retStr);
                            break;
                        case ReportFieldTypeEnum.MWQMSiteLatestClassification:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumMWQMSiteLatestClassification, retStr);
                            break;
                        case ReportFieldTypeEnum.PolSourceIssueRisk:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumPolSourceIssueRisk, retStr);
                            break;
                        case ReportFieldTypeEnum.MikeScenarioSpecialResultKMLType:
                            Assert.Equal(BaseEnumServiceRes.ReportFieldTypeEnumMikeScenarioSpecialResultKMLType, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportFileTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportFileTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportFileTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportFileTypeEnum((ReportFileTypeEnum)i);
        
                    switch ((ReportFileTypeEnum)i)
                    {
                        case ReportFileTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportFileTypeEnum.CSV:
                            Assert.Equal(BaseEnumServiceRes.ReportFileTypeEnumCSV, retStr);
                            break;
                        case ReportFileTypeEnum.Word:
                            Assert.Equal(BaseEnumServiceRes.ReportFileTypeEnumWord, retStr);
                            break;
                        case ReportFileTypeEnum.Excel:
                            Assert.Equal(BaseEnumServiceRes.ReportFileTypeEnumExcel, retStr);
                            break;
                        case ReportFileTypeEnum.KML:
                            Assert.Equal(BaseEnumServiceRes.ReportFileTypeEnumKML, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportFormatingDateEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportFormatingDateEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportFormatingDateEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportFormatingDateEnum((ReportFormatingDateEnum)i);
        
                    switch ((ReportFormatingDateEnum)i)
                    {
                        case ReportFormatingDateEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearOnly:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateMonthDecimalOnly:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthDecimalOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateMonthShortTextOnly:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthShortTextOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateMonthFullTextOnly:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthFullTextOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateDayOnly:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateDayOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateHourOnly:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateHourOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateMinuteOnly:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMinuteOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthDecimalDay:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthDecimalDay, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthShortTextDay:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthShortTextDay, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthFullTextDay:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthFullTextDay, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthDecimalDayHourMinute:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthDecimalDayHourMinute, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthShortTextDayHourMinute:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthShortTextDayHourMinute, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthFullTextDayHourMinute:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthFullTextDayHourMinute, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportFormatingNumberEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportFormatingNumberEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportFormatingNumberEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportFormatingNumberEnum((ReportFormatingNumberEnum)i);
        
                    switch ((ReportFormatingNumberEnum)i)
                    {
                        case ReportFormatingNumberEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber0Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber0Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber1Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber1Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber2Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber2Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber3Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber3Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber4Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber4Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber5Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber5Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber6Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber6Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific0Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific0Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific1Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific1Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific2Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific2Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific3Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific3Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific4Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific4Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific5Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific5Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific6Decimal:
                            Assert.Equal(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific6Decimal, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportGenerateObjectsKeywordEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportGenerateObjectsKeywordEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportGenerateObjectsKeywordEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportGenerateObjectsKeywordEnum((ReportGenerateObjectsKeywordEnum)i);
        
                    switch ((ReportGenerateObjectsKeywordEnum)i)
                    {
                        case ReportGenerateObjectsKeywordEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_RE_EVALUATION_COVER_PAGE:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_RE_EVALUATION_COVER_PAGE, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_ALL:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_ALL, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_WET:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_WET, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_DRY:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_DRY, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_DATA_AVAILABILITY:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_DATA_AVAILABILITY, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_SITES_BY_YEAR:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_SITES_BY_YEAR, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_RUNS_BY_YEAR:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_RUNS_BY_YEAR, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_SAMPLES_BY_YEAR:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_SAMPLES_BY_YEAR, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_FC_TABLE:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_FC_TABLE, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_SALINITY_TABLE:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_SALINITY_TABLE, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_TEMPERATURE_TABLE:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_TEMPERATURE_TABLE, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_SITES:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_SITES, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_SITES_COMPACT:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_SITES_COMPACT, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITIES:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITIES, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_MAP:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_MAP, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_CONTACTS:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_CONTACTS, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_DETAIL:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_DETAIL, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_ECCC_AND_SWCP_LOGO:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_ECCC_AND_SWCP_LOGO, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_CSSP_LOGO:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_CSSP_LOGO, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_LOCATION_OF_SURVEY_AREA_MAP:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_LOCATION_OF_SURVEY_AREA_MAP, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_CURRENT_CLASSIFICATION_AND_SAMPLING_LOCATION_MAP:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_CURRENT_CLASSIFICATION_AND_SAMPLING_LOCATION_MAP, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_RECOMMENDED_CLASSIFICATION_MAP:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_RECOMMENDED_CLASSIFICATION_MAP, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_LOCATIONS_MAP:
                            Assert.Equal(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_LOCATIONS_MAP, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportSortingEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportSortingEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportSortingEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportSortingEnum((ReportSortingEnum)i);
        
                    switch ((ReportSortingEnum)i)
                    {
                        case ReportSortingEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportSortingEnum.ReportSortingAscending:
                            Assert.Equal(BaseEnumServiceRes.ReportSortingEnumReportSortingAscending, retStr);
                            break;
                        case ReportSortingEnum.ReportSortingDescending:
                            Assert.Equal(BaseEnumServiceRes.ReportSortingEnumReportSortingDescending, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportTreeNodeSubTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportTreeNodeSubTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportTreeNodeSubTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportTreeNodeSubTypeEnum((ReportTreeNodeSubTypeEnum)i);
        
                    switch ((ReportTreeNodeSubTypeEnum)i)
                    {
                        case ReportTreeNodeSubTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportTreeNodeSubTypeEnum.TableSelectable:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeSubTypeEnumTableSelectable, retStr);
                            break;
                        case ReportTreeNodeSubTypeEnum.Field:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeSubTypeEnumField, retStr);
                            break;
                        case ReportTreeNodeSubTypeEnum.FieldsHolder:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeSubTypeEnumFieldsHolder, retStr);
                            break;
                        case ReportTreeNodeSubTypeEnum.TableNotSelectable:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeSubTypeEnumTableNotSelectable, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ReportTreeNodeTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportTreeNodeTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportTreeNodeTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportTreeNodeTypeEnum((ReportTreeNodeTypeEnum)i);
        
                    switch ((ReportTreeNodeTypeEnum)i)
                    {
                        case ReportTreeNodeTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportRootType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportRootType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportCountryType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportCountryType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportProvinceType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportProvinceType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportAreaType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportAreaType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSectorType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSectorType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMSiteType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportRootFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportRootFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportInfrastructureType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportBoxModelType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportBoxModelType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeScenarioType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeSourceType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeSourceType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMSiteSampleType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteSampleType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteObsType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteObsType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteObsIssueType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteObsIssueType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeScenarioGeneralParameterType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioGeneralParameterType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityContactType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportConditionType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportConditionType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportStatisticType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportStatisticType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportFieldsType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFieldsType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportFieldType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFieldType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteAddressType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteAddressType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityContactTelType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactTelType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityContactEmailType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactEmailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportBoxModelResultType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportBoxModelResultType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportClimateSiteType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportClimateSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportClimateSiteDataType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportClimateSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportHydrometricSiteType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportHydrometricSiteDataType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportHydrometricSiteRatingCurveType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteRatingCurveType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportHydrometricSiteRatingCurveValueType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteRatingCurveValueType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportInfrastructureAddressType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureAddressType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetDetailType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetTubeMPNDetailType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetTubeMPNDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunSampleType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunSampleType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportCountryFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportCountryFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportProvinceFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportProvinceFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportAreaFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportAreaFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSectorFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSectorFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMSiteFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportInfrastructureFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeScenarioFileType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeSourceStartEndType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeSourceStartEndType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetDetailType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetTubeMPNDetailType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetTubeMPNDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetDetailType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetTubeMPNDetailType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetTubeMPNDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanSubsectorType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanSubsectorType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanSubsectorSiteType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanSubsectorSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeBoundaryConditionType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeBoundaryConditionType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioAmbientType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioAmbientType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioResultType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioResultType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMPNLookupType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMPNLookupType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMSiteStartAndEndType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteStartAndEndType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorTideSiteType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorTideSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorTideSiteDataType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorTideSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportOrderType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportOrderType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportFormatType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFormatType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityContactAddressType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactAddressType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorClimateSiteType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorClimateSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteDataType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteRatingCurveType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteRatingCurveType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorClimateSiteDataType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorClimateSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteRatingCurveValueType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteRatingCurveValueType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorSpecialTableType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorSpecialTableType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeScenarioSpecialResultKMLType:
                            Assert.Equal(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioSpecialResultKMLType, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_SameDayNextDayEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SameDayNextDayEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SameDayNextDayEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SameDayNextDayEnum((SameDayNextDayEnum)i);
        
                    switch ((SameDayNextDayEnum)i)
                    {
                        case SameDayNextDayEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SameDayNextDayEnum.SameDay:
                            Assert.Equal(BaseEnumServiceRes.SameDayNextDayEnumSameDay, retStr);
                            break;
                        case SameDayNextDayEnum.NextDay:
                            Assert.Equal(BaseEnumServiceRes.SameDayNextDayEnumNextDay, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_SampleMatrixEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SampleMatrixEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SampleMatrixEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SampleMatrixEnum((SampleMatrixEnum)i);
        
                    switch ((SampleMatrixEnum)i)
                    {
                        case SampleMatrixEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SampleMatrixEnum.W:
                            Assert.Equal(BaseEnumServiceRes.SampleMatrixEnumW, retStr);
                            break;
                        case SampleMatrixEnum.S:
                            Assert.Equal(BaseEnumServiceRes.SampleMatrixEnumS, retStr);
                            break;
                        case SampleMatrixEnum.B:
                            Assert.Equal(BaseEnumServiceRes.SampleMatrixEnumB, retStr);
                            break;
                        case SampleMatrixEnum.MPNQ:
                            Assert.Equal(BaseEnumServiceRes.SampleMatrixEnumMPNQ, retStr);
                            break;
                        case SampleMatrixEnum.SampleMatrix5:
                            Assert.Equal(BaseEnumServiceRes.SampleMatrixEnumSampleMatrix5, retStr);
                            break;
                        case SampleMatrixEnum.SampleMatrix6:
                            Assert.Equal(BaseEnumServiceRes.SampleMatrixEnumSampleMatrix6, retStr);
                            break;
                        case SampleMatrixEnum.Water:
                            Assert.Equal(BaseEnumServiceRes.SampleMatrixEnumWater, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_SampleStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SampleStatusEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SampleStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SampleStatusEnum((SampleStatusEnum)i);
        
                    switch ((SampleStatusEnum)i)
                    {
                        case SampleStatusEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SampleStatusEnum.Active:
                            Assert.Equal(BaseEnumServiceRes.SampleStatusEnumActive, retStr);
                            break;
                        case SampleStatusEnum.Archived:
                            Assert.Equal(BaseEnumServiceRes.SampleStatusEnumArchived, retStr);
                            break;
                        case SampleStatusEnum.SampleStatus3:
                            Assert.Equal(BaseEnumServiceRes.SampleStatusEnumSampleStatus3, retStr);
                            break;
                        case SampleStatusEnum.SampleStatus4:
                            Assert.Equal(BaseEnumServiceRes.SampleStatusEnumSampleStatus4, retStr);
                            break;
                        case SampleStatusEnum.SampleStatus5:
                            Assert.Equal(BaseEnumServiceRes.SampleStatusEnumSampleStatus5, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_SampleTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SampleTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SampleTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SampleTypeEnum((SampleTypeEnum)i);
        
                    switch ((SampleTypeEnum)i)
                    {
                        case SampleTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SampleTypeEnum.DailyDuplicate:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumDailyDuplicate, retStr);
                            break;
                        case SampleTypeEnum.Infrastructure:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumInfrastructure, retStr);
                            break;
                        case SampleTypeEnum.IntertechDuplicate:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumIntertechDuplicate, retStr);
                            break;
                        case SampleTypeEnum.IntertechRead:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumIntertechRead, retStr);
                            break;
                        case SampleTypeEnum.RainCMP:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumRainCMP, retStr);
                            break;
                        case SampleTypeEnum.RainRun:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumRainRun, retStr);
                            break;
                        case SampleTypeEnum.ReopeningEmergencyRain:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumReopeningEmergencyRain, retStr);
                            break;
                        case SampleTypeEnum.ReopeningSpill:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumReopeningSpill, retStr);
                            break;
                        case SampleTypeEnum.Routine:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumRoutine, retStr);
                            break;
                        case SampleTypeEnum.Sanitary:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumSanitary, retStr);
                            break;
                        case SampleTypeEnum.Study:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumStudy, retStr);
                            break;
                        case SampleTypeEnum.Sediment:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumSediment, retStr);
                            break;
                        case SampleTypeEnum.Bivalve:
                            Assert.Equal(BaseEnumServiceRes.SampleTypeEnumBivalve, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_SamplingPlanTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SamplingPlanTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SamplingPlanTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SamplingPlanTypeEnum((SamplingPlanTypeEnum)i);
        
                    switch ((SamplingPlanTypeEnum)i)
                    {
                        case SamplingPlanTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SamplingPlanTypeEnum.Subsector:
                            Assert.Equal(BaseEnumServiceRes.SamplingPlanTypeEnumSubsector, retStr);
                            break;
                        case SamplingPlanTypeEnum.Municipality:
                            Assert.Equal(BaseEnumServiceRes.SamplingPlanTypeEnumMunicipality, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_ScenarioStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ScenarioStatusEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ScenarioStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ScenarioStatusEnum((ScenarioStatusEnum)i);
        
                    switch ((ScenarioStatusEnum)i)
                    {
                        case ScenarioStatusEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ScenarioStatusEnum.Normal:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumNormal, retStr);
                            break;
                        case ScenarioStatusEnum.Copying:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumCopying, retStr);
                            break;
                        case ScenarioStatusEnum.Copied:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumCopied, retStr);
                            break;
                        case ScenarioStatusEnum.Changing:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumChanging, retStr);
                            break;
                        case ScenarioStatusEnum.Changed:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumChanged, retStr);
                            break;
                        case ScenarioStatusEnum.AskToRun:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumAskToRun, retStr);
                            break;
                        case ScenarioStatusEnum.Running:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumRunning, retStr);
                            break;
                        case ScenarioStatusEnum.Completed:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumCompleted, retStr);
                            break;
                        case ScenarioStatusEnum.Cancelled:
                            Assert.Equal(BaseEnumServiceRes.ScenarioStatusEnumCancelled, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_SearchTagEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SearchTagEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SearchTagEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SearchTagEnum((SearchTagEnum)i);
        
                    switch ((SearchTagEnum)i)
                    {
                        case SearchTagEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SearchTagEnum.c:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumc, retStr);
                            break;
                        case SearchTagEnum.e:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnume, retStr);
                            break;
                        case SearchTagEnum.t:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumt, retStr);
                            break;
                        case SearchTagEnum.fi:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfi, retStr);
                            break;
                        case SearchTagEnum.fp:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfp, retStr);
                            break;
                        case SearchTagEnum.frg:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfrg, retStr);
                            break;
                        case SearchTagEnum.ftg:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumftg, retStr);
                            break;
                        case SearchTagEnum.fpdf:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfpdf, retStr);
                            break;
                        case SearchTagEnum.fdocx:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfdocx, retStr);
                            break;
                        case SearchTagEnum.fxlsx:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfxlsx, retStr);
                            break;
                        case SearchTagEnum.fkmz:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfkmz, retStr);
                            break;
                        case SearchTagEnum.fxyz:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfxyz, retStr);
                            break;
                        case SearchTagEnum.fdfs:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfdfs, retStr);
                            break;
                        case SearchTagEnum.fmike:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfmike, retStr);
                            break;
                        case SearchTagEnum.fmdf:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfmdf, retStr);
                            break;
                        case SearchTagEnum.fm21fm:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfm21fm, retStr);
                            break;
                        case SearchTagEnum.fm3fm:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfm3fm, retStr);
                            break;
                        case SearchTagEnum.fmesh:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfmesh, retStr);
                            break;
                        case SearchTagEnum.flog:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumflog, retStr);
                            break;
                        case SearchTagEnum.ftxt:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumftxt, retStr);
                            break;
                        case SearchTagEnum.m:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumm, retStr);
                            break;
                        case SearchTagEnum.p:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnump, retStr);
                            break;
                        case SearchTagEnum.ms:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumms, retStr);
                            break;
                        case SearchTagEnum.cs:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumcs, retStr);
                            break;
                        case SearchTagEnum.hs:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumhs, retStr);
                            break;
                        case SearchTagEnum.ts:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumts, retStr);
                            break;
                        case SearchTagEnum.ww:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumww, retStr);
                            break;
                        case SearchTagEnum.ls:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumls, retStr);
                            break;
                        case SearchTagEnum.st:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumst, retStr);
                            break;
                        case SearchTagEnum.ps:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumps, retStr);
                            break;
                        case SearchTagEnum.a:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnuma, retStr);
                            break;
                        case SearchTagEnum.s:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnums, retStr);
                            break;
                        case SearchTagEnum.ss:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumss, retStr);
                            break;
                        case SearchTagEnum.u:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumu, retStr);
                            break;
                        case SearchTagEnum.notag:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumnotag, retStr);
                            break;
                        case SearchTagEnum.fcsv:
                            Assert.Equal(BaseEnumServiceRes.SearchTagEnumfcsv, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_SecondaryTreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SecondaryTreatmentTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SecondaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SecondaryTreatmentTypeEnum((SecondaryTreatmentTypeEnum)i);
        
                    switch ((SecondaryTreatmentTypeEnum)i)
                    {
                        case SecondaryTreatmentTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.NotApplicable:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumNotApplicable, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.RotatingBiologicalContactor:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumRotatingBiologicalContactor, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.TricklingFilters:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumTricklingFilters, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.SequencingBatchReactor:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumSequencingBatchReactor, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.OxidationDitch:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumOxidationDitch, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.ExtendedAeration:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumExtendedAeration, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.ContactStabilization:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumContactStabilization, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.PhysicalChemicalProcesses:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumPhysicalChemicalProcesses, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.MovingBedBioReactor:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumMovingBedBioReactor, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.BiologicalAearatedFilters:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumBiologicalAearatedFilters, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.AeratedSubmergedBioFilmReactor:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumAeratedSubmergedBioFilmReactor, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.IntegratedFixedFilmActivatedSludge:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumIntegratedFixedFilmActivatedSludge, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.ActivatedSludge:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumActivatedSludge, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.ExtendedActivatedSludge:
                            Assert.Equal(BaseEnumServiceRes.SecondaryTreatmentTypeEnumExtendedActivatedSludge, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_SpecialTableTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SpecialTableTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SpecialTableTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SpecialTableTypeEnum((SpecialTableTypeEnum)i);
        
                    switch ((SpecialTableTypeEnum)i)
                    {
                        case SpecialTableTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SpecialTableTypeEnum.FCDensitiesTable:
                            Assert.Equal(BaseEnumServiceRes.SpecialTableTypeEnumFCDensitiesTable, retStr);
                            break;
                        case SpecialTableTypeEnum.SalinityTable:
                            Assert.Equal(BaseEnumServiceRes.SpecialTableTypeEnumSalinityTable, retStr);
                            break;
                        case SpecialTableTypeEnum.TemperatureTable:
                            Assert.Equal(BaseEnumServiceRes.SpecialTableTypeEnumTemperatureTable, retStr);
                            break;
                        case SpecialTableTypeEnum.GeometricMeanTable:
                            Assert.Equal(BaseEnumServiceRes.SpecialTableTypeEnumGeometricMeanTable, retStr);
                            break;
                        case SpecialTableTypeEnum.MedianTable:
                            Assert.Equal(BaseEnumServiceRes.SpecialTableTypeEnumMedianTable, retStr);
                            break;
                        case SpecialTableTypeEnum.P90Table:
                            Assert.Equal(BaseEnumServiceRes.SpecialTableTypeEnumP90Table, retStr);
                            break;
                        case SpecialTableTypeEnum.PercentOver43Table:
                            Assert.Equal(BaseEnumServiceRes.SpecialTableTypeEnumPercentOver43Table, retStr);
                            break;
                        case SpecialTableTypeEnum.PercentOver260Table:
                            Assert.Equal(BaseEnumServiceRes.SpecialTableTypeEnumPercentOver260Table, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_StorageDataTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_StorageDataTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(StorageDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_StorageDataTypeEnum((StorageDataTypeEnum)i);
        
                    switch ((StorageDataTypeEnum)i)
                    {
                        case StorageDataTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case StorageDataTypeEnum.Archived:
                            Assert.Equal(BaseEnumServiceRes.StorageDataTypeEnumArchived, retStr);
                            break;
                        case StorageDataTypeEnum.Forcasted:
                            Assert.Equal(BaseEnumServiceRes.StorageDataTypeEnumForcasted, retStr);
                            break;
                        case StorageDataTypeEnum.Observed:
                            Assert.Equal(BaseEnumServiceRes.StorageDataTypeEnumObserved, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_StreetTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_StreetTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(StreetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_StreetTypeEnum((StreetTypeEnum)i);
        
                    switch ((StreetTypeEnum)i)
                    {
                        case StreetTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case StreetTypeEnum.Street:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumStreet, retStr);
                            break;
                        case StreetTypeEnum.Road:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumRoad, retStr);
                            break;
                        case StreetTypeEnum.Avenue:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumAvenue, retStr);
                            break;
                        case StreetTypeEnum.Crescent:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumCrescent, retStr);
                            break;
                        case StreetTypeEnum.Court:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumCourt, retStr);
                            break;
                        case StreetTypeEnum.Alley:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumAlley, retStr);
                            break;
                        case StreetTypeEnum.Drive:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumDrive, retStr);
                            break;
                        case StreetTypeEnum.Blvd:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumBlvd, retStr);
                            break;
                        case StreetTypeEnum.Route:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumRoute, retStr);
                            break;
                        case StreetTypeEnum.Lane:
                            Assert.Equal(BaseEnumServiceRes.StreetTypeEnumLane, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_TelTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TelTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TelTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TelTypeEnum((TelTypeEnum)i);
        
                    switch ((TelTypeEnum)i)
                    {
                        case TelTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TelTypeEnum.Personal:
                            Assert.Equal(BaseEnumServiceRes.TelTypeEnumPersonal, retStr);
                            break;
                        case TelTypeEnum.Work:
                            Assert.Equal(BaseEnumServiceRes.TelTypeEnumWork, retStr);
                            break;
                        case TelTypeEnum.Mobile:
                            Assert.Equal(BaseEnumServiceRes.TelTypeEnumMobile, retStr);
                            break;
                        case TelTypeEnum.Personal2:
                            Assert.Equal(BaseEnumServiceRes.TelTypeEnumPersonal2, retStr);
                            break;
                        case TelTypeEnum.Work2:
                            Assert.Equal(BaseEnumServiceRes.TelTypeEnumWork2, retStr);
                            break;
                        case TelTypeEnum.Mobile2:
                            Assert.Equal(BaseEnumServiceRes.TelTypeEnumMobile2, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_TertiaryTreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TertiaryTreatmentTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TertiaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TertiaryTreatmentTypeEnum((TertiaryTreatmentTypeEnum)i);
        
                    switch ((TertiaryTreatmentTypeEnum)i)
                    {
                        case TertiaryTreatmentTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.NotApplicable:
                            Assert.Equal(BaseEnumServiceRes.TertiaryTreatmentTypeEnumNotApplicable, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.Adsorption:
                            Assert.Equal(BaseEnumServiceRes.TertiaryTreatmentTypeEnumAdsorption, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.Flocculation:
                            Assert.Equal(BaseEnumServiceRes.TertiaryTreatmentTypeEnumFlocculation, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.MembraneFiltration:
                            Assert.Equal(BaseEnumServiceRes.TertiaryTreatmentTypeEnumMembraneFiltration, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.IonExchange:
                            Assert.Equal(BaseEnumServiceRes.TertiaryTreatmentTypeEnumIonExchange, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.ReverseOsmosis:
                            Assert.Equal(BaseEnumServiceRes.TertiaryTreatmentTypeEnumReverseOsmosis, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.BiologicalNutrientRemoval:
                            Assert.Equal(BaseEnumServiceRes.TertiaryTreatmentTypeEnumBiologicalNutrientRemoval, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_TideDataTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TideDataTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TideDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TideDataTypeEnum((TideDataTypeEnum)i);
        
                    switch ((TideDataTypeEnum)i)
                    {
                        case TideDataTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TideDataTypeEnum.Min15:
                            Assert.Equal(BaseEnumServiceRes.TideDataTypeEnumMin15, retStr);
                            break;
                        case TideDataTypeEnum.Min60:
                            Assert.Equal(BaseEnumServiceRes.TideDataTypeEnumMin60, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_TideTextEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TideTextEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TideTextEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TideTextEnum((TideTextEnum)i);
        
                    switch ((TideTextEnum)i)
                    {
                        case TideTextEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TideTextEnum.LowTide:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumLowTide, retStr);
                            break;
                        case TideTextEnum.LowTideFalling:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumLowTideFalling, retStr);
                            break;
                        case TideTextEnum.LowTideRising:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumLowTideRising, retStr);
                            break;
                        case TideTextEnum.MidTide:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumMidTide, retStr);
                            break;
                        case TideTextEnum.MidTideFalling:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumMidTideFalling, retStr);
                            break;
                        case TideTextEnum.MidTideRising:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumMidTideRising, retStr);
                            break;
                        case TideTextEnum.HighTide:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumHighTide, retStr);
                            break;
                        case TideTextEnum.HighTideFalling:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumHighTideFalling, retStr);
                            break;
                        case TideTextEnum.HighTideRising:
                            Assert.Equal(BaseEnumServiceRes.TideTextEnumHighTideRising, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_TranslationStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TranslationStatusEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TranslationStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TranslationStatusEnum((TranslationStatusEnum)i);
        
                    switch ((TranslationStatusEnum)i)
                    {
                        case TranslationStatusEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TranslationStatusEnum.NotTranslated:
                            Assert.Equal(BaseEnumServiceRes.TranslationStatusEnumNotTranslated, retStr);
                            break;
                        case TranslationStatusEnum.ElectronicallyTranslated:
                            Assert.Equal(BaseEnumServiceRes.TranslationStatusEnumElectronicallyTranslated, retStr);
                            break;
                        case TranslationStatusEnum.Translated:
                            Assert.Equal(BaseEnumServiceRes.TranslationStatusEnumTranslated, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_TreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TreatmentTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TreatmentTypeEnum((TreatmentTypeEnum)i);
        
                    switch ((TreatmentTypeEnum)i)
                    {
                        case TreatmentTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TreatmentTypeEnum.ActivatedSludge:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumActivatedSludge, retStr);
                            break;
                        case TreatmentTypeEnum.ActivatedSludgeWithBiofilter:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumActivatedSludgeWithBiofilter, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration1Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration1Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration2Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration2Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration3Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration3Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration4Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration4Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration5Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration5Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration1Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration1Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration2Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration2Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration3Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration3Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration4Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration4Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration5Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration5Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration6Cell:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration6Cell, retStr);
                            break;
                        case TreatmentTypeEnum.StabalizingPondOnly:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumStabalizingPondOnly, retStr);
                            break;
                        case TreatmentTypeEnum.OxidationDitchOnly:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumOxidationDitchOnly, retStr);
                            break;
                        case TreatmentTypeEnum.CirculatingFluidizedBed:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumCirculatingFluidizedBed, retStr);
                            break;
                        case TreatmentTypeEnum.TricklingFilter:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumTricklingFilter, retStr);
                            break;
                        case TreatmentTypeEnum.RecirculatingSandFilter:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumRecirculatingSandFilter, retStr);
                            break;
                        case TreatmentTypeEnum.TrashRackRakeOnly:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumTrashRackRakeOnly, retStr);
                            break;
                        case TreatmentTypeEnum.SepticTank:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumSepticTank, retStr);
                            break;
                        case TreatmentTypeEnum.Secondary:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumSecondary, retStr);
                            break;
                        case TreatmentTypeEnum.Tertiary:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumTertiary, retStr);
                            break;
                        case TreatmentTypeEnum.VolumeFermenter:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumVolumeFermenter, retStr);
                            break;
                        case TreatmentTypeEnum.BioFilmReactor:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumBioFilmReactor, retStr);
                            break;
                        case TreatmentTypeEnum.BioGreen:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumBioGreen, retStr);
                            break;
                        case TreatmentTypeEnum.BioDisks:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumBioDisks, retStr);
                            break;
                        case TreatmentTypeEnum.ChemicalPrimary:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumChemicalPrimary, retStr);
                            break;
                        case TreatmentTypeEnum.Chromoglass:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumChromoglass, retStr);
                            break;
                        case TreatmentTypeEnum.Primary:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumPrimary, retStr);
                            break;
                        case TreatmentTypeEnum.SequencingBatchReactor:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumSequencingBatchReactor, retStr);
                            break;
                        case TreatmentTypeEnum.PeatSystem:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumPeatSystem, retStr);
                            break;
                        case TreatmentTypeEnum.Physicochimique:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumPhysicochimique, retStr);
                            break;
                        case TreatmentTypeEnum.RotatingBiologicalContactor:
                            Assert.Equal(BaseEnumServiceRes.TreatmentTypeEnumRotatingBiologicalContactor, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_TVAuthEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TVAuthEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TVAuthEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TVAuthEnum((TVAuthEnum)i);
        
                    switch ((TVAuthEnum)i)
                    {
                        case TVAuthEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TVAuthEnum.NoAccess:
                            Assert.Equal(BaseEnumServiceRes.TVAuthEnumNoAccess, retStr);
                            break;
                        case TVAuthEnum.Read:
                            Assert.Equal(BaseEnumServiceRes.TVAuthEnumRead, retStr);
                            break;
                        case TVAuthEnum.Write:
                            Assert.Equal(BaseEnumServiceRes.TVAuthEnumWrite, retStr);
                            break;
                        case TVAuthEnum.Create:
                            Assert.Equal(BaseEnumServiceRes.TVAuthEnumCreate, retStr);
                            break;
                        case TVAuthEnum.Delete:
                            Assert.Equal(BaseEnumServiceRes.TVAuthEnumDelete, retStr);
                            break;
                        case TVAuthEnum.Admin:
                            Assert.Equal(BaseEnumServiceRes.TVAuthEnumAdmin, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_TVTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TVTypeEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TVTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TVTypeEnum((TVTypeEnum)i);
        
                    switch ((TVTypeEnum)i)
                    {
                        case TVTypeEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TVTypeEnum.Root:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumRoot, retStr);
                            break;
                        case TVTypeEnum.Address:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumAddress, retStr);
                            break;
                        case TVTypeEnum.Area:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumArea, retStr);
                            break;
                        case TVTypeEnum.ClimateSite:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumClimateSite, retStr);
                            break;
                        case TVTypeEnum.Contact:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumContact, retStr);
                            break;
                        case TVTypeEnum.Country:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumCountry, retStr);
                            break;
                        case TVTypeEnum.Email:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumEmail, retStr);
                            break;
                        case TVTypeEnum.File:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumFile, retStr);
                            break;
                        case TVTypeEnum.HydrometricSite:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumHydrometricSite, retStr);
                            break;
                        case TVTypeEnum.Infrastructure:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumInfrastructure, retStr);
                            break;
                        case TVTypeEnum.MikeBoundaryConditionWebTide:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMikeBoundaryConditionWebTide, retStr);
                            break;
                        case TVTypeEnum.MikeBoundaryConditionMesh:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMikeBoundaryConditionMesh, retStr);
                            break;
                        case TVTypeEnum.MikeScenario:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMikeScenario, retStr);
                            break;
                        case TVTypeEnum.MikeSource:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMikeSource, retStr);
                            break;
                        case TVTypeEnum.Municipality:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMunicipality, retStr);
                            break;
                        case TVTypeEnum.MWQMSite:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMWQMSite, retStr);
                            break;
                        case TVTypeEnum.PolSourceSite:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumPolSourceSite, retStr);
                            break;
                        case TVTypeEnum.Province:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumProvince, retStr);
                            break;
                        case TVTypeEnum.Sector:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSector, retStr);
                            break;
                        case TVTypeEnum.Subsector:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSubsector, retStr);
                            break;
                        case TVTypeEnum.Tel:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumTel, retStr);
                            break;
                        case TVTypeEnum.TideSite:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumTideSite, retStr);
                            break;
                        case TVTypeEnum.MWQMSiteSample:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMWQMSiteSample, retStr);
                            break;
                        case TVTypeEnum.WasteWaterTreatmentPlant:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumWasteWaterTreatmentPlant, retStr);
                            break;
                        case TVTypeEnum.LiftStation:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumLiftStation, retStr);
                            break;
                        case TVTypeEnum.Spill:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSpill, retStr);
                            break;
                        case TVTypeEnum.BoxModel:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumBoxModel, retStr);
                            break;
                        case TVTypeEnum.VisualPlumesScenario:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumVisualPlumesScenario, retStr);
                            break;
                        case TVTypeEnum.Outfall:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumOutfall, retStr);
                            break;
                        case TVTypeEnum.OtherInfrastructure:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumOtherInfrastructure, retStr);
                            break;
                        case TVTypeEnum.MWQMRun:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMWQMRun, retStr);
                            break;
                        case TVTypeEnum.NoDepuration:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumNoDepuration, retStr);
                            break;
                        case TVTypeEnum.Failed:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumFailed, retStr);
                            break;
                        case TVTypeEnum.Passed:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumPassed, retStr);
                            break;
                        case TVTypeEnum.NoData:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumNoData, retStr);
                            break;
                        case TVTypeEnum.LessThan10:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumLessThan10, retStr);
                            break;
                        case TVTypeEnum.MeshNode:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMeshNode, retStr);
                            break;
                        case TVTypeEnum.WebTideNode:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumWebTideNode, retStr);
                            break;
                        case TVTypeEnum.SamplingPlan:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSamplingPlan, retStr);
                            break;
                        case TVTypeEnum.SeeOtherMunicipality:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSeeOtherMunicipality, retStr);
                            break;
                        case TVTypeEnum.LineOverflow:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumLineOverflow, retStr);
                            break;
                        case TVTypeEnum.BoxModelInputs:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumBoxModelInputs, retStr);
                            break;
                        case TVTypeEnum.BoxModelResults:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumBoxModelResults, retStr);
                            break;
                        case TVTypeEnum.ClimateSiteInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumClimateSiteInfo, retStr);
                            break;
                        case TVTypeEnum.ClimateSiteData:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumClimateSiteData, retStr);
                            break;
                        case TVTypeEnum.HydrometricSiteInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumHydrometricSiteInfo, retStr);
                            break;
                        case TVTypeEnum.HydrometricSiteData:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumHydrometricSiteData, retStr);
                            break;
                        case TVTypeEnum.InfrastructureInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumInfrastructureInfo, retStr);
                            break;
                        case TVTypeEnum.LabSheetInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumLabSheetInfo, retStr);
                            break;
                        case TVTypeEnum.LabSheetDetailInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumLabSheetDetailInfo, retStr);
                            break;
                        case TVTypeEnum.MapInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMapInfo, retStr);
                            break;
                        case TVTypeEnum.MapInfoPoint:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMapInfoPoint, retStr);
                            break;
                        case TVTypeEnum.MikeSourceStartEndInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMikeSourceStartEndInfo, retStr);
                            break;
                        case TVTypeEnum.MWQMLookupMPNInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMWQMLookupMPNInfo, retStr);
                            break;
                        case TVTypeEnum.SamplingPlanInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSamplingPlanInfo, retStr);
                            break;
                        case TVTypeEnum.SamplingPlanSubsectorInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSamplingPlanSubsectorInfo, retStr);
                            break;
                        case TVTypeEnum.SamplingPlanSubsectorSiteInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSamplingPlanSubsectorSiteInfo, retStr);
                            break;
                        case TVTypeEnum.MWQMSiteStartEndInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMWQMSiteStartEndInfo, retStr);
                            break;
                        case TVTypeEnum.MWQMSubsectorInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMWQMSubsectorInfo, retStr);
                            break;
                        case TVTypeEnum.PolSourceSiteInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumPolSourceSiteInfo, retStr);
                            break;
                        case TVTypeEnum.PolSourceSiteObsInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumPolSourceSiteObsInfo, retStr);
                            break;
                        case TVTypeEnum.HydrometricRatingCurveInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumHydrometricRatingCurveInfo, retStr);
                            break;
                        case TVTypeEnum.HydrometricRatingCurveDataInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumHydrometricRatingCurveDataInfo, retStr);
                            break;
                        case TVTypeEnum.TideLocationInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumTideLocationInfo, retStr);
                            break;
                        case TVTypeEnum.TideSiteDataInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumTideSiteDataInfo, retStr);
                            break;
                        case TVTypeEnum.UseOfSite:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumUseOfSite, retStr);
                            break;
                        case TVTypeEnum.VisualPlumesScenarioInfo:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioInfo, retStr);
                            break;
                        case TVTypeEnum.VisualPlumesScenarioAmbient:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioAmbient, retStr);
                            break;
                        case TVTypeEnum.VisualPlumesScenarioResults:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioResults, retStr);
                            break;
                        case TVTypeEnum.TotalFile:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumTotalFile, retStr);
                            break;
                        case TVTypeEnum.MikeSourceIsRiver:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMikeSourceIsRiver, retStr);
                            break;
                        case TVTypeEnum.MikeSourceIncluded:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMikeSourceIncluded, retStr);
                            break;
                        case TVTypeEnum.MikeSourceNotIncluded:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumMikeSourceNotIncluded, retStr);
                            break;
                        case TVTypeEnum.RainExceedance:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumRainExceedance, retStr);
                            break;
                        case TVTypeEnum.EmailDistributionList:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumEmailDistributionList, retStr);
                            break;
                        case TVTypeEnum.OpenData:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumOpenData, retStr);
                            break;
                        case TVTypeEnum.ProvinceTools:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumProvinceTools, retStr);
                            break;
                        case TVTypeEnum.Classification:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumClassification, retStr);
                            break;
                        case TVTypeEnum.Approved:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumApproved, retStr);
                            break;
                        case TVTypeEnum.Restricted:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumRestricted, retStr);
                            break;
                        case TVTypeEnum.Prohibited:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumProhibited, retStr);
                            break;
                        case TVTypeEnum.ConditionallyApproved:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumConditionallyApproved, retStr);
                            break;
                        case TVTypeEnum.ConditionallyRestricted:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumConditionallyRestricted, retStr);
                            break;
                        case TVTypeEnum.OpenDataNational:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumOpenDataNational, retStr);
                            break;
                        case TVTypeEnum.PolSourceSiteMikeScenario:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumPolSourceSiteMikeScenario, retStr);
                            break;
                        case TVTypeEnum.SubsectorTools:
                            Assert.Equal(BaseEnumServiceRes.TVTypeEnumSubsectorTools, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_GetEnumText_WebTideDataSetEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_WebTideDataSetEnum(null);
                Assert.Equal(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(WebTideDataSetEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_WebTideDataSetEnum((WebTideDataSetEnum)i);
        
                    switch ((WebTideDataSetEnum)i)
                    {
                        case WebTideDataSetEnum.Error:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case WebTideDataSetEnum.arctic9:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumarctic9, retStr);
                            break;
                        case WebTideDataSetEnum.brador:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumbrador, retStr);
                            break;
                        case WebTideDataSetEnum.HRglobal:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumHRglobal, retStr);
                            break;
                        case WebTideDataSetEnum.h3o:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumh3o, retStr);
                            break;
                        case WebTideDataSetEnum.hudson:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumhudson, retStr);
                            break;
                        case WebTideDataSetEnum.ne_pac4:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumne_pac4, retStr);
                            break;
                        case WebTideDataSetEnum.nwatl:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumnwatl, retStr);
                            break;
                        case WebTideDataSetEnum.QuatsinoModel14:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumQuatsinoModel14, retStr);
                            break;
                        case WebTideDataSetEnum.sshelf:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumsshelf, retStr);
                            break;
                        case WebTideDataSetEnum.flood:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumflood, retStr);
                            break;
                        case WebTideDataSetEnum.vigf8:
                            Assert.Equal(BaseEnumServiceRes.WebTideDataSetEnumvigf8, retStr);
                            break;
                        default:
                            Assert.Equal(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }

        #endregion Testing Methods GetEnumText public

        #region Testing Methods Check OK public
        [Fact]
        public void BaseEnumService_AddressTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AddressTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AddressTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AddressTypeOK((AddressTypeEnum)i);

                    switch ((AddressTypeEnum)i)
                    {
                        case AddressTypeEnum.Error:
                        case AddressTypeEnum.Mailing:
                        case AddressTypeEnum.Shipping:
                        case AddressTypeEnum.Civic:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AddressType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_AerationTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AerationTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AerationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AerationTypeOK((AerationTypeEnum)i);

                    switch ((AerationTypeEnum)i)
                    {
                        case AerationTypeEnum.Error:
                        case AerationTypeEnum.MechanicalAirLines:
                        case AerationTypeEnum.MechanicalSurfaceMixers:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AerationType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_AlarmSystemTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AlarmSystemTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AlarmSystemTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AlarmSystemTypeOK((AlarmSystemTypeEnum)i);

                    switch ((AlarmSystemTypeEnum)i)
                    {
                        case AlarmSystemTypeEnum.Error:
                        case AlarmSystemTypeEnum.SCADA:
                        case AlarmSystemTypeEnum.None:
                        case AlarmSystemTypeEnum.OnlyVisualLight:
                        case AlarmSystemTypeEnum.SCADAAndLight:
                        case AlarmSystemTypeEnum.PagerAndLight:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AlarmSystemType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_AnalysisCalculationTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AnalysisCalculationTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AnalysisCalculationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AnalysisCalculationTypeOK((AnalysisCalculationTypeEnum)i);

                    switch ((AnalysisCalculationTypeEnum)i)
                    {
                        case AnalysisCalculationTypeEnum.Error:
                        case AnalysisCalculationTypeEnum.AllAllAll:
                        case AnalysisCalculationTypeEnum.WetAllAll:
                        case AnalysisCalculationTypeEnum.DryAllAll:
                        case AnalysisCalculationTypeEnum.WetWetAll:
                        case AnalysisCalculationTypeEnum.DryDryAll:
                        case AnalysisCalculationTypeEnum.WetDryAll:
                        case AnalysisCalculationTypeEnum.DryWetAll:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalysisCalculationType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_AnalysisReportExportCommandOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AnalysisReportExportCommandOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AnalysisReportExportCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AnalysisReportExportCommandOK((AnalysisReportExportCommandEnum)i);

                    switch ((AnalysisReportExportCommandEnum)i)
                    {
                        case AnalysisReportExportCommandEnum.Error:
                        case AnalysisReportExportCommandEnum.Report:
                        case AnalysisReportExportCommandEnum.Excel:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalysisReportExportCommand), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_AnalyzeMethodOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AnalyzeMethodOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AnalyzeMethodEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AnalyzeMethodOK((AnalyzeMethodEnum)i);

                    switch ((AnalyzeMethodEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalyzeMethod), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_AppTaskCommandOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AppTaskCommandOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AppTaskCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AppTaskCommandOK((AppTaskCommandEnum)i);

                    switch ((AppTaskCommandEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AppTaskCommand), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_AppTaskStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AppTaskStatusOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AppTaskStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AppTaskStatusOK((AppTaskStatusEnum)i);

                    switch ((AppTaskStatusEnum)i)
                    {
                        case AppTaskStatusEnum.Error:
                        case AppTaskStatusEnum.Created:
                        case AppTaskStatusEnum.Running:
                        case AppTaskStatusEnum.Completed:
                        case AppTaskStatusEnum.Cancelled:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AppTaskStatus), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_BeaufortScaleOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.BeaufortScaleOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(BeaufortScaleEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.BeaufortScaleOK((BeaufortScaleEnum)i);

                    switch ((BeaufortScaleEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.BeaufortScale), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_BoxModelResultTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.BoxModelResultTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(BoxModelResultTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.BoxModelResultTypeOK((BoxModelResultTypeEnum)i);

                    switch ((BoxModelResultTypeEnum)i)
                    {
                        case BoxModelResultTypeEnum.Error:
                        case BoxModelResultTypeEnum.Dilution:
                        case BoxModelResultTypeEnum.NoDecayUntreated:
                        case BoxModelResultTypeEnum.NoDecayPreDisinfection:
                        case BoxModelResultTypeEnum.DecayUntreated:
                        case BoxModelResultTypeEnum.DecayPreDisinfection:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.BoxModelResultType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ClassificationTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ClassificationTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ClassificationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ClassificationTypeOK((ClassificationTypeEnum)i);

                    switch ((ClassificationTypeEnum)i)
                    {
                        case ClassificationTypeEnum.Error:
                        case ClassificationTypeEnum.Approved:
                        case ClassificationTypeEnum.Restricted:
                        case ClassificationTypeEnum.Prohibited:
                        case ClassificationTypeEnum.ConditionallyApproved:
                        case ClassificationTypeEnum.ConditionallyRestricted:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ClassificationType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_CollectionSystemTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.CollectionSystemTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(CollectionSystemTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.CollectionSystemTypeOK((CollectionSystemTypeEnum)i);

                    switch ((CollectionSystemTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CollectionSystemType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ContactTitleOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ContactTitleOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ContactTitleEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ContactTitleOK((ContactTitleEnum)i);

                    switch ((ContactTitleEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ContactTitle), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_CSSPWQInputSheetTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.CSSPWQInputSheetTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(CSSPWQInputSheetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.CSSPWQInputSheetTypeOK((CSSPWQInputSheetTypeEnum)i);

                    switch ((CSSPWQInputSheetTypeEnum)i)
                    {
                        case CSSPWQInputSheetTypeEnum.Error:
                        case CSSPWQInputSheetTypeEnum.A1:
                        case CSSPWQInputSheetTypeEnum.LTB:
                        case CSSPWQInputSheetTypeEnum.EC:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CSSPWQInputSheetType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_CSSPWQInputTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.CSSPWQInputTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(CSSPWQInputTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.CSSPWQInputTypeOK((CSSPWQInputTypeEnum)i);

                    switch ((CSSPWQInputTypeEnum)i)
                    {
                        case CSSPWQInputTypeEnum.Error:
                        case CSSPWQInputTypeEnum.Subsector:
                        case CSSPWQInputTypeEnum.Municipality:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CSSPWQInputType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_DailyOrHourlyDataOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.DailyOrHourlyDataOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(DailyOrHourlyDataEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.DailyOrHourlyDataOK((DailyOrHourlyDataEnum)i);

                    switch ((DailyOrHourlyDataEnum)i)
                    {
                        case DailyOrHourlyDataEnum.Error:
                        case DailyOrHourlyDataEnum.Daily:
                        case DailyOrHourlyDataEnum.Hourly:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DailyOrHourlyData), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_DisinfectionTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.DisinfectionTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(DisinfectionTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.DisinfectionTypeOK((DisinfectionTypeEnum)i);

                    switch ((DisinfectionTypeEnum)i)
                    {
                        case DisinfectionTypeEnum.Error:
                        case DisinfectionTypeEnum.None:
                        case DisinfectionTypeEnum.UV:
                        case DisinfectionTypeEnum.ChlorinationNoDechlorination:
                        case DisinfectionTypeEnum.ChlorinationWithDechlorination:
                        case DisinfectionTypeEnum.UVSeasonal:
                        case DisinfectionTypeEnum.ChlorinationNoDechlorinationSeasonal:
                        case DisinfectionTypeEnum.ChlorinationWithDechlorinationSeasonal:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DisinfectionType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_DrogueTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.DrogueTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(DrogueTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.DrogueTypeOK((DrogueTypeEnum)i);

                    switch ((DrogueTypeEnum)i)
                    {
                        case DrogueTypeEnum.Error:
                        case DrogueTypeEnum.SmallDrogue:
                        case DrogueTypeEnum.LargeDrogue:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DrogueType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_EmailTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.EmailTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(EmailTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.EmailTypeOK((EmailTypeEnum)i);

                    switch ((EmailTypeEnum)i)
                    {
                        case EmailTypeEnum.Error:
                        case EmailTypeEnum.Personal:
                        case EmailTypeEnum.Work:
                        case EmailTypeEnum.Personal2:
                        case EmailTypeEnum.Work2:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.EmailType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ExcelExportShowDataTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ExcelExportShowDataTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ExcelExportShowDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ExcelExportShowDataTypeOK((ExcelExportShowDataTypeEnum)i);

                    switch ((ExcelExportShowDataTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ExcelExportShowDataType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_FacilityTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.FacilityTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(FacilityTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.FacilityTypeOK((FacilityTypeEnum)i);

                    switch ((FacilityTypeEnum)i)
                    {
                        case FacilityTypeEnum.Error:
                        case FacilityTypeEnum.Lagoon:
                        case FacilityTypeEnum.Plant:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FacilityType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_FilePurposeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.FilePurposeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(FilePurposeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.FilePurposeOK((FilePurposeEnum)i);

                    switch ((FilePurposeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FilePurpose), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_FileStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.FileStatusOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(FileStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.FileStatusOK((FileStatusEnum)i);

                    switch ((FileStatusEnum)i)
                    {
                        case FileStatusEnum.Error:
                        case FileStatusEnum.Changed:
                        case FileStatusEnum.Sent:
                        case FileStatusEnum.Accepted:
                        case FileStatusEnum.Rejected:
                        case FileStatusEnum.Fail:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FileStatus), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_FileTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.FileTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(FileTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.FileTypeOK((FileTypeEnum)i);

                    switch ((FileTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FileType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_InfrastructureTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.InfrastructureTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(InfrastructureTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.InfrastructureTypeOK((InfrastructureTypeEnum)i);

                    switch ((InfrastructureTypeEnum)i)
                    {
                        case InfrastructureTypeEnum.Error:
                        case InfrastructureTypeEnum.WWTP:
                        case InfrastructureTypeEnum.LiftStation:
                        case InfrastructureTypeEnum.Other:
                        case InfrastructureTypeEnum.SeeOtherMunicipality:
                        case InfrastructureTypeEnum.LineOverflow:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.InfrastructureType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_KMZActionOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.KMZActionOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(KMZActionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.KMZActionOK((KMZActionEnum)i);

                    switch ((KMZActionEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.KMZAction), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_LaboratoryOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LaboratoryOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(LaboratoryEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.LaboratoryOK((LaboratoryEnum)i);

                    switch ((LaboratoryEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Laboratory), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_LabSheetStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LabSheetStatusOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(LabSheetStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.LabSheetStatusOK((LabSheetStatusEnum)i);

                    switch ((LabSheetStatusEnum)i)
                    {
                        case LabSheetStatusEnum.Error:
                        case LabSheetStatusEnum.Created:
                        case LabSheetStatusEnum.Transferred:
                        case LabSheetStatusEnum.Accepted:
                        case LabSheetStatusEnum.Rejected:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LabSheetStatus), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_LabSheetTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LabSheetTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(LabSheetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.LabSheetTypeOK((LabSheetTypeEnum)i);

                    switch ((LabSheetTypeEnum)i)
                    {
                        case LabSheetTypeEnum.Error:
                        case LabSheetTypeEnum.A1:
                        case LabSheetTypeEnum.LTB:
                        case LabSheetTypeEnum.EC:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LabSheetType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_LanguageOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LanguageOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(LanguageEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.LanguageOK((LanguageEnum)i);

                    switch ((LanguageEnum)i)
                    {
                        case LanguageEnum.Error:
                        case LanguageEnum.en:
                        case LanguageEnum.fr:
                        case LanguageEnum.enAndfr:
                        case LanguageEnum.es:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Language), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_LogCommandOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LogCommandOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(LogCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.LogCommandOK((LogCommandEnum)i);

                    switch ((LogCommandEnum)i)
                    {
                        case LogCommandEnum.Error:
                        case LogCommandEnum.Add:
                        case LogCommandEnum.Change:
                        case LogCommandEnum.Delete:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LogCommand), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_MapInfoDrawTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.MapInfoDrawTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(MapInfoDrawTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.MapInfoDrawTypeOK((MapInfoDrawTypeEnum)i);

                    switch ((MapInfoDrawTypeEnum)i)
                    {
                        case MapInfoDrawTypeEnum.Error:
                        case MapInfoDrawTypeEnum.Point:
                        case MapInfoDrawTypeEnum.Polyline:
                        case MapInfoDrawTypeEnum.Polygon:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MapInfoDrawType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_MikeBoundaryConditionLevelOrVelocityOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.MikeBoundaryConditionLevelOrVelocityOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(MikeBoundaryConditionLevelOrVelocityEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.MikeBoundaryConditionLevelOrVelocityOK((MikeBoundaryConditionLevelOrVelocityEnum)i);

                    switch ((MikeBoundaryConditionLevelOrVelocityEnum)i)
                    {
                        case MikeBoundaryConditionLevelOrVelocityEnum.Error:
                        case MikeBoundaryConditionLevelOrVelocityEnum.Level:
                        case MikeBoundaryConditionLevelOrVelocityEnum.Velocity:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocity), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_MikeScenarioSpecialResultKMLTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.MikeScenarioSpecialResultKMLTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(MikeScenarioSpecialResultKMLTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.MikeScenarioSpecialResultKMLTypeOK((MikeScenarioSpecialResultKMLTypeEnum)i);

                    switch ((MikeScenarioSpecialResultKMLTypeEnum)i)
                    {
                        case MikeScenarioSpecialResultKMLTypeEnum.Error:
                        case MikeScenarioSpecialResultKMLTypeEnum.Mesh:
                        case MikeScenarioSpecialResultKMLTypeEnum.StudyArea:
                        case MikeScenarioSpecialResultKMLTypeEnum.BoundaryConditions:
                        case MikeScenarioSpecialResultKMLTypeEnum.PollutionLimit:
                        case MikeScenarioSpecialResultKMLTypeEnum.PollutionAnimation:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MikeScenarioSpecialResultKMLType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_MWQMSiteLatestClassificationOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.MWQMSiteLatestClassificationOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(MWQMSiteLatestClassificationEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.MWQMSiteLatestClassificationOK((MWQMSiteLatestClassificationEnum)i);

                    switch ((MWQMSiteLatestClassificationEnum)i)
                    {
                        case MWQMSiteLatestClassificationEnum.Error:
                        case MWQMSiteLatestClassificationEnum.Approved:
                        case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
                        case MWQMSiteLatestClassificationEnum.Restricted:
                        case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
                        case MWQMSiteLatestClassificationEnum.Prohibited:
                        case MWQMSiteLatestClassificationEnum.Unclassified:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MWQMSiteLatestClassification), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_PolSourceInactiveReasonOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PolSourceInactiveReasonOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(PolSourceInactiveReasonEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.PolSourceInactiveReasonOK((PolSourceInactiveReasonEnum)i);

                    switch ((PolSourceInactiveReasonEnum)i)
                    {
                        case PolSourceInactiveReasonEnum.Error:
                        case PolSourceInactiveReasonEnum.Abandoned:
                        case PolSourceInactiveReasonEnum.Closed:
                        case PolSourceInactiveReasonEnum.Removed:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PolSourceInactiveReason), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_PolSourceIssueRiskOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PolSourceIssueRiskOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(PolSourceIssueRiskEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.PolSourceIssueRiskOK((PolSourceIssueRiskEnum)i);

                    switch ((PolSourceIssueRiskEnum)i)
                    {
                        case PolSourceIssueRiskEnum.Error:
                        case PolSourceIssueRiskEnum.LowRisk:
                        case PolSourceIssueRiskEnum.ModerateRisk:
                        case PolSourceIssueRiskEnum.HighRisk:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PolSourceIssueRisk), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_PositionOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PositionOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(PositionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.PositionOK((PositionEnum)i);

                    switch ((PositionEnum)i)
                    {
                        case PositionEnum.Error:
                        case PositionEnum.LeftBottom:
                        case PositionEnum.RightBottom:
                        case PositionEnum.LeftTop:
                        case PositionEnum.RightTop:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Position), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_PreliminaryTreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PreliminaryTreatmentTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(PreliminaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.PreliminaryTreatmentTypeOK((PreliminaryTreatmentTypeEnum)i);

                    switch ((PreliminaryTreatmentTypeEnum)i)
                    {
                        case PreliminaryTreatmentTypeEnum.Error:
                        case PreliminaryTreatmentTypeEnum.NotApplicable:
                        case PreliminaryTreatmentTypeEnum.BarScreen:
                        case PreliminaryTreatmentTypeEnum.Grinder:
                        case PreliminaryTreatmentTypeEnum.MechanicalScreening:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PreliminaryTreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_PrimaryTreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PrimaryTreatmentTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(PrimaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.PrimaryTreatmentTypeOK((PrimaryTreatmentTypeEnum)i);

                    switch ((PrimaryTreatmentTypeEnum)i)
                    {
                        case PrimaryTreatmentTypeEnum.Error:
                        case PrimaryTreatmentTypeEnum.NotApplicable:
                        case PrimaryTreatmentTypeEnum.Sedimentation:
                        case PrimaryTreatmentTypeEnum.ChemicalCoagulation:
                        case PrimaryTreatmentTypeEnum.Filtration:
                        case PrimaryTreatmentTypeEnum.PrimaryClarification:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PrimaryTreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportConditionOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportConditionOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportConditionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportConditionOK((ReportConditionEnum)i);

                    switch ((ReportConditionEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportCondition), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportFieldTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportFieldTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportFieldTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportFieldTypeOK((ReportFieldTypeEnum)i);

                    switch ((ReportFieldTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFieldType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportFileTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportFileTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportFileTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportFileTypeOK((ReportFileTypeEnum)i);

                    switch ((ReportFileTypeEnum)i)
                    {
                        case ReportFileTypeEnum.Error:
                        case ReportFileTypeEnum.CSV:
                        case ReportFileTypeEnum.Word:
                        case ReportFileTypeEnum.Excel:
                        case ReportFileTypeEnum.KML:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFileType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportFormatingDateOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportFormatingDateOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportFormatingDateEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportFormatingDateOK((ReportFormatingDateEnum)i);

                    switch ((ReportFormatingDateEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFormatingDate), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportFormatingNumberOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportFormatingNumberOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportFormatingNumberEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportFormatingNumberOK((ReportFormatingNumberEnum)i);

                    switch ((ReportFormatingNumberEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFormatingNumber), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportGenerateObjectsKeywordOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportGenerateObjectsKeywordOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportGenerateObjectsKeywordEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportGenerateObjectsKeywordOK((ReportGenerateObjectsKeywordEnum)i);

                    switch ((ReportGenerateObjectsKeywordEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportGenerateObjectsKeyword), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportSortingOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportSortingOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportSortingEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportSortingOK((ReportSortingEnum)i);

                    switch ((ReportSortingEnum)i)
                    {
                        case ReportSortingEnum.Error:
                        case ReportSortingEnum.ReportSortingAscending:
                        case ReportSortingEnum.ReportSortingDescending:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportSorting), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportTreeNodeSubTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportTreeNodeSubTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportTreeNodeSubTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportTreeNodeSubTypeOK((ReportTreeNodeSubTypeEnum)i);

                    switch ((ReportTreeNodeSubTypeEnum)i)
                    {
                        case ReportTreeNodeSubTypeEnum.Error:
                        case ReportTreeNodeSubTypeEnum.TableSelectable:
                        case ReportTreeNodeSubTypeEnum.Field:
                        case ReportTreeNodeSubTypeEnum.FieldsHolder:
                        case ReportTreeNodeSubTypeEnum.TableNotSelectable:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportTreeNodeSubType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ReportTreeNodeTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportTreeNodeTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportTreeNodeTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportTreeNodeTypeOK((ReportTreeNodeTypeEnum)i);

                    switch ((ReportTreeNodeTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportTreeNodeType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_SameDayNextDayOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SameDayNextDayOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SameDayNextDayEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SameDayNextDayOK((SameDayNextDayEnum)i);

                    switch ((SameDayNextDayEnum)i)
                    {
                        case SameDayNextDayEnum.Error:
                        case SameDayNextDayEnum.SameDay:
                        case SameDayNextDayEnum.NextDay:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SameDayNextDay), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_SampleMatrixOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SampleMatrixOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SampleMatrixEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SampleMatrixOK((SampleMatrixEnum)i);

                    switch ((SampleMatrixEnum)i)
                    {
                        case SampleMatrixEnum.Error:
                        case SampleMatrixEnum.W:
                        case SampleMatrixEnum.S:
                        case SampleMatrixEnum.B:
                        case SampleMatrixEnum.MPNQ:
                        case SampleMatrixEnum.SampleMatrix5:
                        case SampleMatrixEnum.SampleMatrix6:
                        case SampleMatrixEnum.Water:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleMatrix), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_SampleStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SampleStatusOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SampleStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SampleStatusOK((SampleStatusEnum)i);

                    switch ((SampleStatusEnum)i)
                    {
                        case SampleStatusEnum.Error:
                        case SampleStatusEnum.Active:
                        case SampleStatusEnum.Archived:
                        case SampleStatusEnum.SampleStatus3:
                        case SampleStatusEnum.SampleStatus4:
                        case SampleStatusEnum.SampleStatus5:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleStatus), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_SampleTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SampleTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SampleTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SampleTypeOK((SampleTypeEnum)i);

                    switch ((SampleTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_SamplingPlanTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SamplingPlanTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SamplingPlanTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SamplingPlanTypeOK((SamplingPlanTypeEnum)i);

                    switch ((SamplingPlanTypeEnum)i)
                    {
                        case SamplingPlanTypeEnum.Error:
                        case SamplingPlanTypeEnum.Subsector:
                        case SamplingPlanTypeEnum.Municipality:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SamplingPlanType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_ScenarioStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ScenarioStatusOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ScenarioStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ScenarioStatusOK((ScenarioStatusEnum)i);

                    switch ((ScenarioStatusEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ScenarioStatus), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_SearchTagOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SearchTagOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SearchTagEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SearchTagOK((SearchTagEnum)i);

                    switch ((SearchTagEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SearchTag), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_SecondaryTreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SecondaryTreatmentTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SecondaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SecondaryTreatmentTypeOK((SecondaryTreatmentTypeEnum)i);

                    switch ((SecondaryTreatmentTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SecondaryTreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_SpecialTableTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SpecialTableTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SpecialTableTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SpecialTableTypeOK((SpecialTableTypeEnum)i);

                    switch ((SpecialTableTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SpecialTableType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_StorageDataTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.StorageDataTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(StorageDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.StorageDataTypeOK((StorageDataTypeEnum)i);

                    switch ((StorageDataTypeEnum)i)
                    {
                        case StorageDataTypeEnum.Error:
                        case StorageDataTypeEnum.Archived:
                        case StorageDataTypeEnum.Forcasted:
                        case StorageDataTypeEnum.Observed:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.StorageDataType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_StreetTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.StreetTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(StreetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.StreetTypeOK((StreetTypeEnum)i);

                    switch ((StreetTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.StreetType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_TelTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TelTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TelTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TelTypeOK((TelTypeEnum)i);

                    switch ((TelTypeEnum)i)
                    {
                        case TelTypeEnum.Error:
                        case TelTypeEnum.Personal:
                        case TelTypeEnum.Work:
                        case TelTypeEnum.Mobile:
                        case TelTypeEnum.Personal2:
                        case TelTypeEnum.Work2:
                        case TelTypeEnum.Mobile2:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TelType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_TertiaryTreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TertiaryTreatmentTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TertiaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TertiaryTreatmentTypeOK((TertiaryTreatmentTypeEnum)i);

                    switch ((TertiaryTreatmentTypeEnum)i)
                    {
                        case TertiaryTreatmentTypeEnum.Error:
                        case TertiaryTreatmentTypeEnum.NotApplicable:
                        case TertiaryTreatmentTypeEnum.Adsorption:
                        case TertiaryTreatmentTypeEnum.Flocculation:
                        case TertiaryTreatmentTypeEnum.MembraneFiltration:
                        case TertiaryTreatmentTypeEnum.IonExchange:
                        case TertiaryTreatmentTypeEnum.ReverseOsmosis:
                        case TertiaryTreatmentTypeEnum.BiologicalNutrientRemoval:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TertiaryTreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_TideDataTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TideDataTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TideDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TideDataTypeOK((TideDataTypeEnum)i);

                    switch ((TideDataTypeEnum)i)
                    {
                        case TideDataTypeEnum.Error:
                        case TideDataTypeEnum.Min15:
                        case TideDataTypeEnum.Min60:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TideDataType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_TideTextOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TideTextOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TideTextEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TideTextOK((TideTextEnum)i);

                    switch ((TideTextEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TideText), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_TranslationStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TranslationStatusOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TranslationStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TranslationStatusOK((TranslationStatusEnum)i);

                    switch ((TranslationStatusEnum)i)
                    {
                        case TranslationStatusEnum.Error:
                        case TranslationStatusEnum.NotTranslated:
                        case TranslationStatusEnum.ElectronicallyTranslated:
                        case TranslationStatusEnum.Translated:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TranslationStatus), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_TreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TreatmentTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TreatmentTypeOK((TreatmentTypeEnum)i);

                    switch ((TreatmentTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_TVAuthOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TVAuthOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TVAuthEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TVAuthOK((TVAuthEnum)i);

                    switch ((TVAuthEnum)i)
                    {
                        case TVAuthEnum.Error:
                        case TVAuthEnum.NoAccess:
                        case TVAuthEnum.Read:
                        case TVAuthEnum.Write:
                        case TVAuthEnum.Create:
                        case TVAuthEnum.Delete:
                        case TVAuthEnum.Admin:
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TVAuth), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_TVTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TVTypeOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TVTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TVTypeOK((TVTypeEnum)i);

                    switch ((TVTypeEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TVType), retStr);
                            break;
                    }
                }
            }
        }
        [Fact]
        public void BaseEnumService_WebTideDataSetOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.WebTideDataSetOK(null);
                Assert.Equal("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(WebTideDataSetEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.WebTideDataSetOK((WebTideDataSetEnum)i);

                    switch ((WebTideDataSetEnum)i)
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
                            Assert.Equal("", retStr);
                            break;
                        default:
                            Assert.Equal(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.WebTideDataSet), retStr);
                            break;
                    }
                }
            }
        }

        #endregion Testing Methods Check OK public
    }
}
