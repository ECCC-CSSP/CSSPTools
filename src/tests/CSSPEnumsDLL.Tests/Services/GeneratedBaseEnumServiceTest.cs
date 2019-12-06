using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod]
        public void BaseEnumService_GetEnumText_AddressTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AddressTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AddressTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AddressTypeEnum((AddressTypeEnum)i);
        
                    switch ((AddressTypeEnum)i)
                    {
                        case AddressTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AddressTypeEnum.Mailing:
                            Assert.AreEqual(BaseEnumServiceRes.AddressTypeEnumMailing, retStr);
                            break;
                        case AddressTypeEnum.Shipping:
                            Assert.AreEqual(BaseEnumServiceRes.AddressTypeEnumShipping, retStr);
                            break;
                        case AddressTypeEnum.Civic:
                            Assert.AreEqual(BaseEnumServiceRes.AddressTypeEnumCivic, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_AerationTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AerationTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AerationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AerationTypeEnum((AerationTypeEnum)i);
        
                    switch ((AerationTypeEnum)i)
                    {
                        case AerationTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AerationTypeEnum.MechanicalAirLines:
                            Assert.AreEqual(BaseEnumServiceRes.AerationTypeEnumMechanicalAirLines, retStr);
                            break;
                        case AerationTypeEnum.MechanicalSurfaceMixers:
                            Assert.AreEqual(BaseEnumServiceRes.AerationTypeEnumMechanicalSurfaceMixers, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_AlarmSystemTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AlarmSystemTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AlarmSystemTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AlarmSystemTypeEnum((AlarmSystemTypeEnum)i);
        
                    switch ((AlarmSystemTypeEnum)i)
                    {
                        case AlarmSystemTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AlarmSystemTypeEnum.SCADA:
                            Assert.AreEqual(BaseEnumServiceRes.AlarmSystemTypeEnumSCADA, retStr);
                            break;
                        case AlarmSystemTypeEnum.None:
                            Assert.AreEqual(BaseEnumServiceRes.AlarmSystemTypeEnumNone, retStr);
                            break;
                        case AlarmSystemTypeEnum.OnlyVisualLight:
                            Assert.AreEqual(BaseEnumServiceRes.AlarmSystemTypeEnumOnlyVisualLight, retStr);
                            break;
                        case AlarmSystemTypeEnum.SCADAAndLight:
                            Assert.AreEqual(BaseEnumServiceRes.AlarmSystemTypeEnumSCADAAndLight, retStr);
                            break;
                        case AlarmSystemTypeEnum.PagerAndLight:
                            Assert.AreEqual(BaseEnumServiceRes.AlarmSystemTypeEnumPagerAndLight, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_AnalysisCalculationTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AnalysisCalculationTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AnalysisCalculationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AnalysisCalculationTypeEnum((AnalysisCalculationTypeEnum)i);
        
                    switch ((AnalysisCalculationTypeEnum)i)
                    {
                        case AnalysisCalculationTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.AllAllAll:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisCalculationTypeEnumAllAllAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.WetAllAll:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisCalculationTypeEnumWetAllAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.DryAllAll:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisCalculationTypeEnumDryAllAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.WetWetAll:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisCalculationTypeEnumWetWetAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.DryDryAll:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisCalculationTypeEnumDryDryAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.WetDryAll:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisCalculationTypeEnumWetDryAll, retStr);
                            break;
                        case AnalysisCalculationTypeEnum.DryWetAll:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisCalculationTypeEnumDryWetAll, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_AnalysisReportExportCommandEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AnalysisReportExportCommandEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AnalysisReportExportCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AnalysisReportExportCommandEnum((AnalysisReportExportCommandEnum)i);
        
                    switch ((AnalysisReportExportCommandEnum)i)
                    {
                        case AnalysisReportExportCommandEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AnalysisReportExportCommandEnum.Report:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisReportExportCommandEnumReport, retStr);
                            break;
                        case AnalysisReportExportCommandEnum.Excel:
                            Assert.AreEqual(BaseEnumServiceRes.AnalysisReportExportCommandEnumExcel, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_AnalyzeMethodEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AnalyzeMethodEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AnalyzeMethodEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AnalyzeMethodEnum((AnalyzeMethodEnum)i);
        
                    switch ((AnalyzeMethodEnum)i)
                    {
                        case AnalyzeMethodEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AnalyzeMethodEnum.MF:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumMF, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_510Q:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumZZ_510Q, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_509Q:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumZZ_509Q, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_0:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumZZ_0, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_525Q:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumZZ_525Q, retStr);
                            break;
                        case AnalyzeMethodEnum.MPN:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumMPN, retStr);
                            break;
                        case AnalyzeMethodEnum.ZZ_0Q:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumZZ_0Q, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod8:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod8, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod9:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod9, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod10:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod10, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod11:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod11, retStr);
                            break;
                        case AnalyzeMethodEnum.AnalyzeMethod12:
                            Assert.AreEqual(BaseEnumServiceRes.AnalyzeMethodEnumAnalyzeMethod12, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_AppTaskCommandEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AppTaskCommandEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AppTaskCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AppTaskCommandEnum((AppTaskCommandEnum)i);
        
                    switch ((AppTaskCommandEnum)i)
                    {
                        case AppTaskCommandEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AppTaskCommandEnum.GenerateWebTide:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumGenerateWebTide, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioAskToRun:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioAskToRun, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioImport:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioImport, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioOtherFileImport:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioOtherFileImport, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioRunning:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioRunning, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioToCancel:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioToCancel, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioWaitingToRun:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioWaitingToRun, retStr);
                            break;
                        case AppTaskCommandEnum.SetupWebTide:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumSetupWebTide, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateClimateSiteInformation:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteInformation, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyFromStartDateToEndDate:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteDailyAndHourlyFromStartDateToEndDate, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumUpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate, retStr);
                            break;
                        case AppTaskCommandEnum.CreateFCForm:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumCreateFCForm, retStr);
                            break;
                        case AppTaskCommandEnum.CreateSamplingPlanSamplingPlanTextFile:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumCreateSamplingPlanSamplingPlanTextFile, retStr);
                            break;
                        case AppTaskCommandEnum.CreateDocumentFromTemplate:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumCreateDocumentFromTemplate, retStr);
                            break;
                        case AppTaskCommandEnum.GetClimateSitesDataForRunsOfYear:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumGetClimateSitesDataForRunsOfYear, retStr);
                            break;
                        case AppTaskCommandEnum.CreateWebTideDataWLAtFirstNode:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumCreateWebTideDataWLAtFirstNode, retStr);
                            break;
                        case AppTaskCommandEnum.ExportEmailDistributionLists:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumExportEmailDistributionLists, retStr);
                            break;
                        case AppTaskCommandEnum.ExportAnalysisToExcel:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumExportAnalysisToExcel, retStr);
                            break;
                        case AppTaskCommandEnum.CreateDocumentFromParameters:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumCreateDocumentFromParameters, retStr);
                            break;
                        case AppTaskCommandEnum.CreateDocxPDF:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumCreateDocxPDF, retStr);
                            break;
                        case AppTaskCommandEnum.CreateXlsxPDF:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumCreateXlsxPDF, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataCSVOfMWQMSites:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVOfMWQMSites, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataKMZOfMWQMSites:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumOpenDataKMZOfMWQMSites, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataXlsxOfMWQMSitesAndSamples:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumOpenDataXlsxOfMWQMSitesAndSamples, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataCSVOfMWQMSamples:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVOfMWQMSamples, retStr);
                            break;
                        case AppTaskCommandEnum.GetAllPrecipitationForYear:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumGetAllPrecipitationForYear, retStr);
                            break;
                        case AppTaskCommandEnum.FillRunPrecipByClimateSitePriorityForYear:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumFillRunPrecipByClimateSitePriorityForYear, retStr);
                            break;
                        case AppTaskCommandEnum.FindMissingPrecipForProvince:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumFindMissingPrecipForProvince, retStr);
                            break;
                        case AppTaskCommandEnum.ExportToArcGIS:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumExportToArcGIS, retStr);
                            break;
                        case AppTaskCommandEnum.GenerateClassificationForCSSPWebToolsVisualization:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumGenerateClassificationForCSSPWebToolsVisualization, retStr);
                            break;
                        case AppTaskCommandEnum.GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumGenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSites:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVNationalOfMWQMSites, retStr);
                            break;
                        case AppTaskCommandEnum.OpenDataCSVNationalOfMWQMSamples:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumOpenDataCSVNationalOfMWQMSamples, retStr);
                            break;
                        case AppTaskCommandEnum.ProvinceToolsCreateClassificationInputsKML:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateClassificationInputsKML, retStr);
                            break;
                        case AppTaskCommandEnum.ProvinceToolsCreateGroupingInputsKML:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateGroupingInputsKML, retStr);
                            break;
                        case AppTaskCommandEnum.ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsCreateMWQMSitesAndPolSourceSitesKML, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateHydrometricSiteInformation:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteInformation, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate, retStr);
                            break;
                        case AppTaskCommandEnum.UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumUpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate, retStr);
                            break;
                        case AppTaskCommandEnum.GetHydrometricSitesDataForRunsOfYear:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumGetHydrometricSitesDataForRunsOfYear, retStr);
                            break;
                        case AppTaskCommandEnum.GetAllDischargesForYear:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumGetAllDischargesForYear, retStr);
                            break;
                        case AppTaskCommandEnum.FillRunDischargesByHydrometricSitePriorityForYear:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumFillRunDischargesByHydrometricSitePriorityForYear, retStr);
                            break;
                        case AppTaskCommandEnum.FindMissingDischargesForProvince:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumFindMissingDischargesForProvince, retStr);
                            break;
                        case AppTaskCommandEnum.LoadHydrometricDataValue:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumLoadHydrometricDataValue, retStr);
                            break;
                        case AppTaskCommandEnum.GenerateKMLFileClassificationForCSSPWebToolsVisualization:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumGenerateKMLFileClassificationForCSSPWebToolsVisualization, retStr);
                            break;
                        case AppTaskCommandEnum.ProvinceToolsGenerateStats:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumProvinceToolsGenerateStats, retStr);
                            break;
                        case AppTaskCommandEnum.MikeScenarioPrepareResults:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumMikeScenarioPrepareResults, retStr);
                            break;
                        case AppTaskCommandEnum.ClimateSiteLoadCoCoRaHSData:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskCommandEnumClimateSiteLoadCoCoRaHSData, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_AppTaskStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_AppTaskStatusEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(AppTaskStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_AppTaskStatusEnum((AppTaskStatusEnum)i);
        
                    switch ((AppTaskStatusEnum)i)
                    {
                        case AppTaskStatusEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case AppTaskStatusEnum.Created:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskStatusEnumCreated, retStr);
                            break;
                        case AppTaskStatusEnum.Running:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskStatusEnumRunning, retStr);
                            break;
                        case AppTaskStatusEnum.Completed:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskStatusEnumCompleted, retStr);
                            break;
                        case AppTaskStatusEnum.Cancelled:
                            Assert.AreEqual(BaseEnumServiceRes.AppTaskStatusEnumCancelled, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_BeaufortScaleEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_BeaufortScaleEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(BeaufortScaleEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_BeaufortScaleEnum((BeaufortScaleEnum)i);
        
                    switch ((BeaufortScaleEnum)i)
                    {
                        case BeaufortScaleEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case BeaufortScaleEnum.Calm:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumCalm, retStr);
                            break;
                        case BeaufortScaleEnum.LightAir:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumLightAir, retStr);
                            break;
                        case BeaufortScaleEnum.LightBreeze:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumLightBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.GentleBreeze:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumGentleBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.ModerateBreeze:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumModerateBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.FreshBreeze:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumFreshBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.StrongBreeze:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumStrongBreeze, retStr);
                            break;
                        case BeaufortScaleEnum.HighWind_ModerateGale_NearGale:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumHighWind_ModerateGale_NearGale, retStr);
                            break;
                        case BeaufortScaleEnum.Gale_FreshGale:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumGale_FreshGale, retStr);
                            break;
                        case BeaufortScaleEnum.Strong_SevereGale:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumStrong_SevereGale, retStr);
                            break;
                        case BeaufortScaleEnum.Storm_WholeGale:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumStorm_WholeGale, retStr);
                            break;
                        case BeaufortScaleEnum.ViolentStorm:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumViolentStorm, retStr);
                            break;
                        case BeaufortScaleEnum.HurricaneForce:
                            Assert.AreEqual(BaseEnumServiceRes.BeaufortScaleEnumHurricaneForce, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_BoxModelResultTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_BoxModelResultTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(BoxModelResultTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_BoxModelResultTypeEnum((BoxModelResultTypeEnum)i);
        
                    switch ((BoxModelResultTypeEnum)i)
                    {
                        case BoxModelResultTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case BoxModelResultTypeEnum.Dilution:
                            Assert.AreEqual(BaseEnumServiceRes.BoxModelResultTypeEnumDilution, retStr);
                            break;
                        case BoxModelResultTypeEnum.NoDecayUntreated:
                            Assert.AreEqual(BaseEnumServiceRes.BoxModelResultTypeEnumNoDecayUntreated, retStr);
                            break;
                        case BoxModelResultTypeEnum.NoDecayPreDisinfection:
                            Assert.AreEqual(BaseEnumServiceRes.BoxModelResultTypeEnumNoDecayPreDisinfection, retStr);
                            break;
                        case BoxModelResultTypeEnum.DecayUntreated:
                            Assert.AreEqual(BaseEnumServiceRes.BoxModelResultTypeEnumDecayUntreated, retStr);
                            break;
                        case BoxModelResultTypeEnum.DecayPreDisinfection:
                            Assert.AreEqual(BaseEnumServiceRes.BoxModelResultTypeEnumDecayPreDisinfection, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ClassificationTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ClassificationTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ClassificationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ClassificationTypeEnum((ClassificationTypeEnum)i);
        
                    switch ((ClassificationTypeEnum)i)
                    {
                        case ClassificationTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ClassificationTypeEnum.Approved:
                            Assert.AreEqual(BaseEnumServiceRes.ClassificationTypeEnumApproved, retStr);
                            break;
                        case ClassificationTypeEnum.Restricted:
                            Assert.AreEqual(BaseEnumServiceRes.ClassificationTypeEnumRestricted, retStr);
                            break;
                        case ClassificationTypeEnum.Prohibited:
                            Assert.AreEqual(BaseEnumServiceRes.ClassificationTypeEnumProhibited, retStr);
                            break;
                        case ClassificationTypeEnum.ConditionallyApproved:
                            Assert.AreEqual(BaseEnumServiceRes.ClassificationTypeEnumConditionallyApproved, retStr);
                            break;
                        case ClassificationTypeEnum.ConditionallyRestricted:
                            Assert.AreEqual(BaseEnumServiceRes.ClassificationTypeEnumConditionallyRestricted, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_CollectionSystemTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_CollectionSystemTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(CollectionSystemTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_CollectionSystemTypeEnum((CollectionSystemTypeEnum)i);
        
                    switch ((CollectionSystemTypeEnum)i)
                    {
                        case CollectionSystemTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case CollectionSystemTypeEnum.CompletelySeparated:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCompletelySeparated, retStr);
                            break;
                        case CollectionSystemTypeEnum.CompletelyCombined:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCompletelyCombined, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined90Separated10:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined90Separated10, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined80Separated20:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined80Separated20, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined70Separated30:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined70Separated30, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined60Separated40:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined60Separated40, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined50Separated50:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined50Separated50, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined40Separated60:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined40Separated60, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined30Separated70:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined30Separated70, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined20Separated80:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined20Separated80, retStr);
                            break;
                        case CollectionSystemTypeEnum.Combined10Separated90:
                            Assert.AreEqual(BaseEnumServiceRes.CollectionSystemTypeEnumCombined10Separated90, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ContactTitleEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ContactTitleEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ContactTitleEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ContactTitleEnum((ContactTitleEnum)i);
        
                    switch ((ContactTitleEnum)i)
                    {
                        case ContactTitleEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ContactTitleEnum.DirectorGeneral:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumDirectorGeneral, retStr);
                            break;
                        case ContactTitleEnum.DirectorPublicWorks:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumDirectorPublicWorks, retStr);
                            break;
                        case ContactTitleEnum.Superintendent:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumSuperintendent, retStr);
                            break;
                        case ContactTitleEnum.Engineer:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumEngineer, retStr);
                            break;
                        case ContactTitleEnum.Foreman:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumForeman, retStr);
                            break;
                        case ContactTitleEnum.Operator:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumOperator, retStr);
                            break;
                        case ContactTitleEnum.FacilitiesManager:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumFacilitiesManager, retStr);
                            break;
                        case ContactTitleEnum.Supervisor:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumSupervisor, retStr);
                            break;
                        case ContactTitleEnum.Technician:
                            Assert.AreEqual(BaseEnumServiceRes.ContactTitleEnumTechnician, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_CSSPWQInputSheetTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_CSSPWQInputSheetTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(CSSPWQInputSheetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_CSSPWQInputSheetTypeEnum((CSSPWQInputSheetTypeEnum)i);
        
                    switch ((CSSPWQInputSheetTypeEnum)i)
                    {
                        case CSSPWQInputSheetTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case CSSPWQInputSheetTypeEnum.A1:
                            Assert.AreEqual(BaseEnumServiceRes.CSSPWQInputSheetTypeEnumA1, retStr);
                            break;
                        case CSSPWQInputSheetTypeEnum.LTB:
                            Assert.AreEqual(BaseEnumServiceRes.CSSPWQInputSheetTypeEnumLTB, retStr);
                            break;
                        case CSSPWQInputSheetTypeEnum.EC:
                            Assert.AreEqual(BaseEnumServiceRes.CSSPWQInputSheetTypeEnumEC, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_CSSPWQInputTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_CSSPWQInputTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(CSSPWQInputTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_CSSPWQInputTypeEnum((CSSPWQInputTypeEnum)i);
        
                    switch ((CSSPWQInputTypeEnum)i)
                    {
                        case CSSPWQInputTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case CSSPWQInputTypeEnum.Subsector:
                            Assert.AreEqual(BaseEnumServiceRes.CSSPWQInputTypeEnumSubsector, retStr);
                            break;
                        case CSSPWQInputTypeEnum.Municipality:
                            Assert.AreEqual(BaseEnumServiceRes.CSSPWQInputTypeEnumMunicipality, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_DailyOrHourlyDataEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_DailyOrHourlyDataEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(DailyOrHourlyDataEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_DailyOrHourlyDataEnum((DailyOrHourlyDataEnum)i);
        
                    switch ((DailyOrHourlyDataEnum)i)
                    {
                        case DailyOrHourlyDataEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case DailyOrHourlyDataEnum.Daily:
                            Assert.AreEqual(BaseEnumServiceRes.DailyOrHourlyDataEnumDaily, retStr);
                            break;
                        case DailyOrHourlyDataEnum.Hourly:
                            Assert.AreEqual(BaseEnumServiceRes.DailyOrHourlyDataEnumHourly, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_DisinfectionTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_DisinfectionTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(DisinfectionTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_DisinfectionTypeEnum((DisinfectionTypeEnum)i);
        
                    switch ((DisinfectionTypeEnum)i)
                    {
                        case DisinfectionTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case DisinfectionTypeEnum.None:
                            Assert.AreEqual(BaseEnumServiceRes.DisinfectionTypeEnumNone, retStr);
                            break;
                        case DisinfectionTypeEnum.UV:
                            Assert.AreEqual(BaseEnumServiceRes.DisinfectionTypeEnumUV, retStr);
                            break;
                        case DisinfectionTypeEnum.ChlorinationNoDechlorination:
                            Assert.AreEqual(BaseEnumServiceRes.DisinfectionTypeEnumChlorinationNoDechlorination, retStr);
                            break;
                        case DisinfectionTypeEnum.ChlorinationWithDechlorination:
                            Assert.AreEqual(BaseEnumServiceRes.DisinfectionTypeEnumChlorinationWithDechlorination, retStr);
                            break;
                        case DisinfectionTypeEnum.UVSeasonal:
                            Assert.AreEqual(BaseEnumServiceRes.DisinfectionTypeEnumUVSeasonal, retStr);
                            break;
                        case DisinfectionTypeEnum.ChlorinationNoDechlorinationSeasonal:
                            Assert.AreEqual(BaseEnumServiceRes.DisinfectionTypeEnumChlorinationNoDechlorinationSeasonal, retStr);
                            break;
                        case DisinfectionTypeEnum.ChlorinationWithDechlorinationSeasonal:
                            Assert.AreEqual(BaseEnumServiceRes.DisinfectionTypeEnumChlorinationWithDechlorinationSeasonal, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_DrogueTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_DrogueTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(DrogueTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_DrogueTypeEnum((DrogueTypeEnum)i);
        
                    switch ((DrogueTypeEnum)i)
                    {
                        case DrogueTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case DrogueTypeEnum.SmallDrogue:
                            Assert.AreEqual(BaseEnumServiceRes.DrogueTypeEnumSmallDrogue, retStr);
                            break;
                        case DrogueTypeEnum.LargeDrogue:
                            Assert.AreEqual(BaseEnumServiceRes.DrogueTypeEnumLargeDrogue, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_EmailTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_EmailTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(EmailTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_EmailTypeEnum((EmailTypeEnum)i);
        
                    switch ((EmailTypeEnum)i)
                    {
                        case EmailTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case EmailTypeEnum.Personal:
                            Assert.AreEqual(BaseEnumServiceRes.EmailTypeEnumPersonal, retStr);
                            break;
                        case EmailTypeEnum.Work:
                            Assert.AreEqual(BaseEnumServiceRes.EmailTypeEnumWork, retStr);
                            break;
                        case EmailTypeEnum.Personal2:
                            Assert.AreEqual(BaseEnumServiceRes.EmailTypeEnumPersonal2, retStr);
                            break;
                        case EmailTypeEnum.Work2:
                            Assert.AreEqual(BaseEnumServiceRes.EmailTypeEnumWork2, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ExcelExportShowDataTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ExcelExportShowDataTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ExcelExportShowDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ExcelExportShowDataTypeEnum((ExcelExportShowDataTypeEnum)i);
        
                    switch ((ExcelExportShowDataTypeEnum)i)
                    {
                        case ExcelExportShowDataTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.FecalColiform:
                            Assert.AreEqual(BaseEnumServiceRes.ExcelExportShowDataTypeEnumFecalColiform, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.Temperature:
                            Assert.AreEqual(BaseEnumServiceRes.ExcelExportShowDataTypeEnumTemperature, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.Salinity:
                            Assert.AreEqual(BaseEnumServiceRes.ExcelExportShowDataTypeEnumSalinity, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.P90:
                            Assert.AreEqual(BaseEnumServiceRes.ExcelExportShowDataTypeEnumP90, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.GemetricMean:
                            Assert.AreEqual(BaseEnumServiceRes.ExcelExportShowDataTypeEnumGemetricMean, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.Median:
                            Assert.AreEqual(BaseEnumServiceRes.ExcelExportShowDataTypeEnumMedian, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.PercOfP90Over43:
                            Assert.AreEqual(BaseEnumServiceRes.ExcelExportShowDataTypeEnumPercOfP90Over43, retStr);
                            break;
                        case ExcelExportShowDataTypeEnum.PercOfP90Over260:
                            Assert.AreEqual(BaseEnumServiceRes.ExcelExportShowDataTypeEnumPercOfP90Over260, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_FacilityTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_FacilityTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(FacilityTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_FacilityTypeEnum((FacilityTypeEnum)i);
        
                    switch ((FacilityTypeEnum)i)
                    {
                        case FacilityTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case FacilityTypeEnum.Lagoon:
                            Assert.AreEqual(BaseEnumServiceRes.FacilityTypeEnumLagoon, retStr);
                            break;
                        case FacilityTypeEnum.Plant:
                            Assert.AreEqual(BaseEnumServiceRes.FacilityTypeEnumPlant, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_FilePurposeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_FilePurposeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(FilePurposeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_FilePurposeEnum((FilePurposeEnum)i);
        
                    switch ((FilePurposeEnum)i)
                    {
                        case FilePurposeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case FilePurposeEnum.MikeInput:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumMikeInput, retStr);
                            break;
                        case FilePurposeEnum.MikeInputMDF:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumMikeInputMDF, retStr);
                            break;
                        case FilePurposeEnum.MikeResultDFSU:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumMikeResultDFSU, retStr);
                            break;
                        case FilePurposeEnum.MikeResultKMZ:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumMikeResultKMZ, retStr);
                            break;
                        case FilePurposeEnum.Information:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumInformation, retStr);
                            break;
                        case FilePurposeEnum.Image:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumImage, retStr);
                            break;
                        case FilePurposeEnum.Picture:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumPicture, retStr);
                            break;
                        case FilePurposeEnum.ReportGenerated:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumReportGenerated, retStr);
                            break;
                        case FilePurposeEnum.TemplateGenerated:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumTemplateGenerated, retStr);
                            break;
                        case FilePurposeEnum.GeneratedFCForm:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumGeneratedFCForm, retStr);
                            break;
                        case FilePurposeEnum.Template:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumTemplate, retStr);
                            break;
                        case FilePurposeEnum.Map:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumMap, retStr);
                            break;
                        case FilePurposeEnum.Analysis:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumAnalysis, retStr);
                            break;
                        case FilePurposeEnum.OpenData:
                            Assert.AreEqual(BaseEnumServiceRes.FilePurposeEnumOpenData, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_FileStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_FileStatusEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(FileStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_FileStatusEnum((FileStatusEnum)i);
        
                    switch ((FileStatusEnum)i)
                    {
                        case FileStatusEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case FileStatusEnum.Changed:
                            Assert.AreEqual(BaseEnumServiceRes.FileStatusEnumChanged, retStr);
                            break;
                        case FileStatusEnum.Sent:
                            Assert.AreEqual(BaseEnumServiceRes.FileStatusEnumSent, retStr);
                            break;
                        case FileStatusEnum.Accepted:
                            Assert.AreEqual(BaseEnumServiceRes.FileStatusEnumAccepted, retStr);
                            break;
                        case FileStatusEnum.Rejected:
                            Assert.AreEqual(BaseEnumServiceRes.FileStatusEnumRejected, retStr);
                            break;
                        case FileStatusEnum.Fail:
                            Assert.AreEqual(BaseEnumServiceRes.FileStatusEnumFail, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_FileTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_FileTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(FileTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_FileTypeEnum((FileTypeEnum)i);
        
                    switch ((FileTypeEnum)i)
                    {
                        case FileTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case FileTypeEnum.DFS0:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumDFS0, retStr);
                            break;
                        case FileTypeEnum.DFS1:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumDFS1, retStr);
                            break;
                        case FileTypeEnum.DFSU:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumDFSU, retStr);
                            break;
                        case FileTypeEnum.KMZ:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumKMZ, retStr);
                            break;
                        case FileTypeEnum.LOG:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumLOG, retStr);
                            break;
                        case FileTypeEnum.M21FM:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumM21FM, retStr);
                            break;
                        case FileTypeEnum.M3FM:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumM3FM, retStr);
                            break;
                        case FileTypeEnum.MDF:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumMDF, retStr);
                            break;
                        case FileTypeEnum.MESH:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumMESH, retStr);
                            break;
                        case FileTypeEnum.XLSX:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumXLSX, retStr);
                            break;
                        case FileTypeEnum.DOCX:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumDOCX, retStr);
                            break;
                        case FileTypeEnum.PDF:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumPDF, retStr);
                            break;
                        case FileTypeEnum.JPG:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumJPG, retStr);
                            break;
                        case FileTypeEnum.JPEG:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumJPEG, retStr);
                            break;
                        case FileTypeEnum.GIF:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumGIF, retStr);
                            break;
                        case FileTypeEnum.PNG:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumPNG, retStr);
                            break;
                        case FileTypeEnum.HTML:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumHTML, retStr);
                            break;
                        case FileTypeEnum.TXT:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumTXT, retStr);
                            break;
                        case FileTypeEnum.XYZ:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumXYZ, retStr);
                            break;
                        case FileTypeEnum.KML:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumKML, retStr);
                            break;
                        case FileTypeEnum.CSV:
                            Assert.AreEqual(BaseEnumServiceRes.FileTypeEnumCSV, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_InfrastructureTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_InfrastructureTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(InfrastructureTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_InfrastructureTypeEnum((InfrastructureTypeEnum)i);
        
                    switch ((InfrastructureTypeEnum)i)
                    {
                        case InfrastructureTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case InfrastructureTypeEnum.WWTP:
                            Assert.AreEqual(BaseEnumServiceRes.InfrastructureTypeEnumWWTP, retStr);
                            break;
                        case InfrastructureTypeEnum.LiftStation:
                            Assert.AreEqual(BaseEnumServiceRes.InfrastructureTypeEnumLiftStation, retStr);
                            break;
                        case InfrastructureTypeEnum.Other:
                            Assert.AreEqual(BaseEnumServiceRes.InfrastructureTypeEnumOther, retStr);
                            break;
                        case InfrastructureTypeEnum.SeeOtherMunicipality:
                            Assert.AreEqual(BaseEnumServiceRes.InfrastructureTypeEnumSeeOtherMunicipality, retStr);
                            break;
                        case InfrastructureTypeEnum.LineOverflow:
                            Assert.AreEqual(BaseEnumServiceRes.InfrastructureTypeEnumLineOverflow, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_KMZActionEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_KMZActionEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(KMZActionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_KMZActionEnum((KMZActionEnum)i);
        
                    switch ((KMZActionEnum)i)
                    {
                        case KMZActionEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case KMZActionEnum.DoNothing:
                            Assert.AreEqual(BaseEnumServiceRes.KMZActionEnumDoNothing, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZContourAnimation:
                            Assert.AreEqual(BaseEnumServiceRes.KMZActionEnumGenerateKMZContourAnimation, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZContourLimit:
                            Assert.AreEqual(BaseEnumServiceRes.KMZActionEnumGenerateKMZContourLimit, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZCurrentAnimation:
                            Assert.AreEqual(BaseEnumServiceRes.KMZActionEnumGenerateKMZCurrentAnimation, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZCurrentMaximum:
                            Assert.AreEqual(BaseEnumServiceRes.KMZActionEnumGenerateKMZCurrentMaximum, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZMesh:
                            Assert.AreEqual(BaseEnumServiceRes.KMZActionEnumGenerateKMZMesh, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZStudyArea:
                            Assert.AreEqual(BaseEnumServiceRes.KMZActionEnumGenerateKMZStudyArea, retStr);
                            break;
                        case KMZActionEnum.GenerateKMZBoundaryConditionNodes:
                            Assert.AreEqual(BaseEnumServiceRes.KMZActionEnumGenerateKMZBoundaryConditionNodes, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_LaboratoryEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LaboratoryEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LaboratoryEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LaboratoryEnum((LaboratoryEnum)i);
        
                    switch ((LaboratoryEnum)i)
                    {
                        case LaboratoryEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LaboratoryEnum.ZZ_0:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_0, retStr);
                            break;
                        case LaboratoryEnum.ZZ_1:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_1, retStr);
                            break;
                        case LaboratoryEnum.ZZ_2:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_2, retStr);
                            break;
                        case LaboratoryEnum.ZZ_3:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_3, retStr);
                            break;
                        case LaboratoryEnum.ZZ_4:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_4, retStr);
                            break;
                        case LaboratoryEnum.ZZ_1Q:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_1Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_2Q:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_2Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_3Q:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_3Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_4Q:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_4Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_5Q:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_5Q, retStr);
                            break;
                        case LaboratoryEnum.ZZ_11BC:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_11BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_12BC:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_12BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_13BC:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_13BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_14BC:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_14BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_15BC:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_15BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_16BC:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_16BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_17BC:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_17BC, retStr);
                            break;
                        case LaboratoryEnum.ZZ_18BC:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumZZ_18BC, retStr);
                            break;
                        case LaboratoryEnum.MonctonEnvironmentCanada:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumMonctonEnvironmentCanada, retStr);
                            break;
                        case LaboratoryEnum.BIOEnvironmentCanada:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumBIOEnvironmentCanada, retStr);
                            break;
                        case LaboratoryEnum.EasternCharlotteWaterwayLaboratory:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumEasternCharlotteWaterwayLaboratory, retStr);
                            break;
                        case LaboratoryEnum.InstitutDeRechercheSurLesZonesCotieres:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumInstitutDeRechercheSurLesZonesCotieres, retStr);
                            break;
                        case LaboratoryEnum.CentreDeRechercheSurLesAliments:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumCentreDeRechercheSurLesAliments, retStr);
                            break;
                        case LaboratoryEnum.CaraquetMobileLaboratoryEnvironmentCanada:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumCaraquetMobileLaboratoryEnvironmentCanada, retStr);
                            break;
                        case LaboratoryEnum.MaxxamAnalyticsBedford:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumMaxxamAnalyticsBedford, retStr);
                            break;
                        case LaboratoryEnum.MaxxamAnalyticsSydney:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumMaxxamAnalyticsSydney, retStr);
                            break;
                        case LaboratoryEnum.PEIAnalyticalLaboratory:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumPEIAnalyticalLaboratory, retStr);
                            break;
                        case LaboratoryEnum.NLMobileLaboratory:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumNLMobileLaboratory, retStr);
                            break;
                        case LaboratoryEnum.AvalonLaboratoriesInc:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumAvalonLaboratoriesInc, retStr);
                            break;
                        case LaboratoryEnum.Maxxam:
                            Assert.AreEqual(BaseEnumServiceRes.LaboratoryEnumMaxxam, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_LabSheetStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LabSheetStatusEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LabSheetStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LabSheetStatusEnum((LabSheetStatusEnum)i);
        
                    switch ((LabSheetStatusEnum)i)
                    {
                        case LabSheetStatusEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LabSheetStatusEnum.Created:
                            Assert.AreEqual(BaseEnumServiceRes.LabSheetStatusEnumCreated, retStr);
                            break;
                        case LabSheetStatusEnum.Transferred:
                            Assert.AreEqual(BaseEnumServiceRes.LabSheetStatusEnumTransferred, retStr);
                            break;
                        case LabSheetStatusEnum.Accepted:
                            Assert.AreEqual(BaseEnumServiceRes.LabSheetStatusEnumAccepted, retStr);
                            break;
                        case LabSheetStatusEnum.Rejected:
                            Assert.AreEqual(BaseEnumServiceRes.LabSheetStatusEnumRejected, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_LabSheetTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LabSheetTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LabSheetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LabSheetTypeEnum((LabSheetTypeEnum)i);
        
                    switch ((LabSheetTypeEnum)i)
                    {
                        case LabSheetTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LabSheetTypeEnum.A1:
                            Assert.AreEqual(BaseEnumServiceRes.LabSheetTypeEnumA1, retStr);
                            break;
                        case LabSheetTypeEnum.LTB:
                            Assert.AreEqual(BaseEnumServiceRes.LabSheetTypeEnumLTB, retStr);
                            break;
                        case LabSheetTypeEnum.EC:
                            Assert.AreEqual(BaseEnumServiceRes.LabSheetTypeEnumEC, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_LanguageEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LanguageEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LanguageEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LanguageEnum((LanguageEnum)i);
        
                    switch ((LanguageEnum)i)
                    {
                        case LanguageEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LanguageEnum.en:
                            Assert.AreEqual(BaseEnumServiceRes.LanguageEnumen, retStr);
                            break;
                        case LanguageEnum.fr:
                            Assert.AreEqual(BaseEnumServiceRes.LanguageEnumfr, retStr);
                            break;
                        case LanguageEnum.enAndfr:
                            Assert.AreEqual(BaseEnumServiceRes.LanguageEnumenAndfr, retStr);
                            break;
                        case LanguageEnum.es:
                            Assert.AreEqual(BaseEnumServiceRes.LanguageEnumes, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_LogCommandEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_LogCommandEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(LogCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_LogCommandEnum((LogCommandEnum)i);
        
                    switch ((LogCommandEnum)i)
                    {
                        case LogCommandEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case LogCommandEnum.Add:
                            Assert.AreEqual(BaseEnumServiceRes.LogCommandEnumAdd, retStr);
                            break;
                        case LogCommandEnum.Change:
                            Assert.AreEqual(BaseEnumServiceRes.LogCommandEnumChange, retStr);
                            break;
                        case LogCommandEnum.Delete:
                            Assert.AreEqual(BaseEnumServiceRes.LogCommandEnumDelete, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_MapInfoDrawTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_MapInfoDrawTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(MapInfoDrawTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_MapInfoDrawTypeEnum((MapInfoDrawTypeEnum)i);
        
                    switch ((MapInfoDrawTypeEnum)i)
                    {
                        case MapInfoDrawTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case MapInfoDrawTypeEnum.Point:
                            Assert.AreEqual(BaseEnumServiceRes.MapInfoDrawTypeEnumPoint, retStr);
                            break;
                        case MapInfoDrawTypeEnum.Polyline:
                            Assert.AreEqual(BaseEnumServiceRes.MapInfoDrawTypeEnumPolyline, retStr);
                            break;
                        case MapInfoDrawTypeEnum.Polygon:
                            Assert.AreEqual(BaseEnumServiceRes.MapInfoDrawTypeEnumPolygon, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(MikeBoundaryConditionLevelOrVelocityEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_MikeBoundaryConditionLevelOrVelocityEnum((MikeBoundaryConditionLevelOrVelocityEnum)i);
        
                    switch ((MikeBoundaryConditionLevelOrVelocityEnum)i)
                    {
                        case MikeBoundaryConditionLevelOrVelocityEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case MikeBoundaryConditionLevelOrVelocityEnum.Level:
                            Assert.AreEqual(BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocityEnumLevel, retStr);
                            break;
                        case MikeBoundaryConditionLevelOrVelocityEnum.Velocity:
                            Assert.AreEqual(BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocityEnumVelocity, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_MikeScenarioSpecialResultKMLTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_MikeScenarioSpecialResultKMLTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(MikeScenarioSpecialResultKMLTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_MikeScenarioSpecialResultKMLTypeEnum((MikeScenarioSpecialResultKMLTypeEnum)i);
        
                    switch ((MikeScenarioSpecialResultKMLTypeEnum)i)
                    {
                        case MikeScenarioSpecialResultKMLTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.Mesh:
                            Assert.AreEqual(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumMesh, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.StudyArea:
                            Assert.AreEqual(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumStudyArea, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.BoundaryConditions:
                            Assert.AreEqual(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumBoundaryConditions, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.PollutionLimit:
                            Assert.AreEqual(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumPollutionLimit, retStr);
                            break;
                        case MikeScenarioSpecialResultKMLTypeEnum.PollutionAnimation:
                            Assert.AreEqual(BaseEnumServiceRes.MikeScenarioSpecialResultKMLTypeEnumPollutionAnimation, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_MWQMSiteLatestClassificationEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_MWQMSiteLatestClassificationEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(MWQMSiteLatestClassificationEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_MWQMSiteLatestClassificationEnum((MWQMSiteLatestClassificationEnum)i);
        
                    switch ((MWQMSiteLatestClassificationEnum)i)
                    {
                        case MWQMSiteLatestClassificationEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.Approved:
                            Assert.AreEqual(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumApproved, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.ConditionallyApproved:
                            Assert.AreEqual(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumConditionallyApproved, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.Restricted:
                            Assert.AreEqual(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumRestricted, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.ConditionallyRestricted:
                            Assert.AreEqual(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumConditionallyRestricted, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.Prohibited:
                            Assert.AreEqual(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumProhibited, retStr);
                            break;
                        case MWQMSiteLatestClassificationEnum.Unclassified:
                            Assert.AreEqual(BaseEnumServiceRes.MWQMSiteLatestClassificationEnumUnclassified, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_PolSourceInactiveReasonEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PolSourceInactiveReasonEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PolSourceInactiveReasonEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PolSourceInactiveReasonEnum((PolSourceInactiveReasonEnum)i);
        
                    switch ((PolSourceInactiveReasonEnum)i)
                    {
                        case PolSourceInactiveReasonEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PolSourceInactiveReasonEnum.Abandoned:
                            Assert.AreEqual(BaseEnumServiceRes.PolSourceInactiveReasonEnumAbandoned, retStr);
                            break;
                        case PolSourceInactiveReasonEnum.Closed:
                            Assert.AreEqual(BaseEnumServiceRes.PolSourceInactiveReasonEnumClosed, retStr);
                            break;
                        case PolSourceInactiveReasonEnum.Removed:
                            Assert.AreEqual(BaseEnumServiceRes.PolSourceInactiveReasonEnumRemoved, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_PolSourceIssueRiskEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PolSourceIssueRiskEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PolSourceIssueRiskEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PolSourceIssueRiskEnum((PolSourceIssueRiskEnum)i);
        
                    switch ((PolSourceIssueRiskEnum)i)
                    {
                        case PolSourceIssueRiskEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PolSourceIssueRiskEnum.LowRisk:
                            Assert.AreEqual(BaseEnumServiceRes.PolSourceIssueRiskEnumLowRisk, retStr);
                            break;
                        case PolSourceIssueRiskEnum.ModerateRisk:
                            Assert.AreEqual(BaseEnumServiceRes.PolSourceIssueRiskEnumModerateRisk, retStr);
                            break;
                        case PolSourceIssueRiskEnum.HighRisk:
                            Assert.AreEqual(BaseEnumServiceRes.PolSourceIssueRiskEnumHighRisk, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_PositionEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PositionEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PositionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PositionEnum((PositionEnum)i);
        
                    switch ((PositionEnum)i)
                    {
                        case PositionEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PositionEnum.LeftBottom:
                            Assert.AreEqual(BaseEnumServiceRes.PositionEnumLeftBottom, retStr);
                            break;
                        case PositionEnum.RightBottom:
                            Assert.AreEqual(BaseEnumServiceRes.PositionEnumRightBottom, retStr);
                            break;
                        case PositionEnum.LeftTop:
                            Assert.AreEqual(BaseEnumServiceRes.PositionEnumLeftTop, retStr);
                            break;
                        case PositionEnum.RightTop:
                            Assert.AreEqual(BaseEnumServiceRes.PositionEnumRightTop, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_PreliminaryTreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PreliminaryTreatmentTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PreliminaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PreliminaryTreatmentTypeEnum((PreliminaryTreatmentTypeEnum)i);
        
                    switch ((PreliminaryTreatmentTypeEnum)i)
                    {
                        case PreliminaryTreatmentTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PreliminaryTreatmentTypeEnum.NotApplicable:
                            Assert.AreEqual(BaseEnumServiceRes.PreliminaryTreatmentTypeEnumNotApplicable, retStr);
                            break;
                        case PreliminaryTreatmentTypeEnum.BarScreen:
                            Assert.AreEqual(BaseEnumServiceRes.PreliminaryTreatmentTypeEnumBarScreen, retStr);
                            break;
                        case PreliminaryTreatmentTypeEnum.Grinder:
                            Assert.AreEqual(BaseEnumServiceRes.PreliminaryTreatmentTypeEnumGrinder, retStr);
                            break;
                        case PreliminaryTreatmentTypeEnum.MechanicalScreening:
                            Assert.AreEqual(BaseEnumServiceRes.PreliminaryTreatmentTypeEnumMechanicalScreening, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_PrimaryTreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_PrimaryTreatmentTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(PrimaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_PrimaryTreatmentTypeEnum((PrimaryTreatmentTypeEnum)i);
        
                    switch ((PrimaryTreatmentTypeEnum)i)
                    {
                        case PrimaryTreatmentTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.NotApplicable:
                            Assert.AreEqual(BaseEnumServiceRes.PrimaryTreatmentTypeEnumNotApplicable, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.Sedimentation:
                            Assert.AreEqual(BaseEnumServiceRes.PrimaryTreatmentTypeEnumSedimentation, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.ChemicalCoagulation:
                            Assert.AreEqual(BaseEnumServiceRes.PrimaryTreatmentTypeEnumChemicalCoagulation, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.Filtration:
                            Assert.AreEqual(BaseEnumServiceRes.PrimaryTreatmentTypeEnumFiltration, retStr);
                            break;
                        case PrimaryTreatmentTypeEnum.PrimaryClarification:
                            Assert.AreEqual(BaseEnumServiceRes.PrimaryTreatmentTypeEnumPrimaryClarification, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportConditionEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportConditionEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportConditionEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportConditionEnum((ReportConditionEnum)i);
        
                    switch ((ReportConditionEnum)i)
                    {
                        case ReportConditionEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionTrue:
                            Assert.AreEqual(BaseEnumServiceRes.ReportConditionEnumReportConditionTrue, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionFalse:
                            Assert.AreEqual(BaseEnumServiceRes.ReportConditionEnumReportConditionFalse, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionContain:
                            Assert.AreEqual(BaseEnumServiceRes.ReportConditionEnumReportConditionContain, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionStart:
                            Assert.AreEqual(BaseEnumServiceRes.ReportConditionEnumReportConditionStart, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionEnd:
                            Assert.AreEqual(BaseEnumServiceRes.ReportConditionEnumReportConditionEnd, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionBigger:
                            Assert.AreEqual(BaseEnumServiceRes.ReportConditionEnumReportConditionBigger, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionSmaller:
                            Assert.AreEqual(BaseEnumServiceRes.ReportConditionEnumReportConditionSmaller, retStr);
                            break;
                        case ReportConditionEnum.ReportConditionEqual:
                            Assert.AreEqual(BaseEnumServiceRes.ReportConditionEnumReportConditionEqual, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportFieldTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportFieldTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportFieldTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportFieldTypeEnum((ReportFieldTypeEnum)i);
        
                    switch ((ReportFieldTypeEnum)i)
                    {
                        case ReportFieldTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportFieldTypeEnum.NumberWhole:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumNumberWhole, retStr);
                            break;
                        case ReportFieldTypeEnum.NumberWithDecimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumNumberWithDecimal, retStr);
                            break;
                        case ReportFieldTypeEnum.DateAndTime:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumDateAndTime, retStr);
                            break;
                        case ReportFieldTypeEnum.Text:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumText, retStr);
                            break;
                        case ReportFieldTypeEnum.TrueOrFalse:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumTrueOrFalse, retStr);
                            break;
                        case ReportFieldTypeEnum.FilePurpose:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumFilePurpose, retStr);
                            break;
                        case ReportFieldTypeEnum.FileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumFileType, retStr);
                            break;
                        case ReportFieldTypeEnum.TranslationStatus:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumTranslationStatus, retStr);
                            break;
                        case ReportFieldTypeEnum.BoxModelResultType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumBoxModelResultType, retStr);
                            break;
                        case ReportFieldTypeEnum.InfrastructureType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumInfrastructureType, retStr);
                            break;
                        case ReportFieldTypeEnum.FacilityType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumFacilityType, retStr);
                            break;
                        case ReportFieldTypeEnum.AerationType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumAerationType, retStr);
                            break;
                        case ReportFieldTypeEnum.PreliminaryTreatmentType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumPreliminaryTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.PrimaryTreatmentType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumPrimaryTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.SecondaryTreatmentType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumSecondaryTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.TertiaryTreatmentType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumTertiaryTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.TreatmentType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumTreatmentType, retStr);
                            break;
                        case ReportFieldTypeEnum.DisinfectionType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumDisinfectionType, retStr);
                            break;
                        case ReportFieldTypeEnum.CollectionSystemType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumCollectionSystemType, retStr);
                            break;
                        case ReportFieldTypeEnum.AlarmSystemType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumAlarmSystemType, retStr);
                            break;
                        case ReportFieldTypeEnum.ScenarioStatus:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumScenarioStatus, retStr);
                            break;
                        case ReportFieldTypeEnum.StorageDataType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumStorageDataType, retStr);
                            break;
                        case ReportFieldTypeEnum.Language:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumLanguage, retStr);
                            break;
                        case ReportFieldTypeEnum.SampleType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumSampleType, retStr);
                            break;
                        case ReportFieldTypeEnum.BeaufortScale:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumBeaufortScale, retStr);
                            break;
                        case ReportFieldTypeEnum.AnalyzeMethod:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumAnalyzeMethod, retStr);
                            break;
                        case ReportFieldTypeEnum.SampleMatrix:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumSampleMatrix, retStr);
                            break;
                        case ReportFieldTypeEnum.Laboratory:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumLaboratory, retStr);
                            break;
                        case ReportFieldTypeEnum.SampleStatus:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumSampleStatus, retStr);
                            break;
                        case ReportFieldTypeEnum.SamplingPlanType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumSamplingPlanType, retStr);
                            break;
                        case ReportFieldTypeEnum.LabSheetSampleType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumLabSheetSampleType, retStr);
                            break;
                        case ReportFieldTypeEnum.LabSheetType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumLabSheetType, retStr);
                            break;
                        case ReportFieldTypeEnum.LabSheetStatus:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumLabSheetStatus, retStr);
                            break;
                        case ReportFieldTypeEnum.PolSourceInactiveReason:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumPolSourceInactiveReason, retStr);
                            break;
                        case ReportFieldTypeEnum.PolSourceObsInfo:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumPolSourceObsInfo, retStr);
                            break;
                        case ReportFieldTypeEnum.AddressType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumAddressType, retStr);
                            break;
                        case ReportFieldTypeEnum.StreetType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumStreetType, retStr);
                            break;
                        case ReportFieldTypeEnum.ContactTitle:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumContactTitle, retStr);
                            break;
                        case ReportFieldTypeEnum.EmailType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumEmailType, retStr);
                            break;
                        case ReportFieldTypeEnum.TelType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumTelType, retStr);
                            break;
                        case ReportFieldTypeEnum.TideText:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumTideText, retStr);
                            break;
                        case ReportFieldTypeEnum.TideDataType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumTideDataType, retStr);
                            break;
                        case ReportFieldTypeEnum.SpecialTableType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumSpecialTableType, retStr);
                            break;
                        case ReportFieldTypeEnum.MWQMSiteLatestClassification:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumMWQMSiteLatestClassification, retStr);
                            break;
                        case ReportFieldTypeEnum.PolSourceIssueRisk:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumPolSourceIssueRisk, retStr);
                            break;
                        case ReportFieldTypeEnum.MikeScenarioSpecialResultKMLType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFieldTypeEnumMikeScenarioSpecialResultKMLType, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportFileTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportFileTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportFileTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportFileTypeEnum((ReportFileTypeEnum)i);
        
                    switch ((ReportFileTypeEnum)i)
                    {
                        case ReportFileTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportFileTypeEnum.CSV:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFileTypeEnumCSV, retStr);
                            break;
                        case ReportFileTypeEnum.Word:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFileTypeEnumWord, retStr);
                            break;
                        case ReportFileTypeEnum.Excel:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFileTypeEnumExcel, retStr);
                            break;
                        case ReportFileTypeEnum.KML:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFileTypeEnumKML, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportFormatingDateEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportFormatingDateEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportFormatingDateEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportFormatingDateEnum((ReportFormatingDateEnum)i);
        
                    switch ((ReportFormatingDateEnum)i)
                    {
                        case ReportFormatingDateEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearOnly:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateMonthDecimalOnly:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthDecimalOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateMonthShortTextOnly:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthShortTextOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateMonthFullTextOnly:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMonthFullTextOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateDayOnly:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateDayOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateHourOnly:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateHourOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateMinuteOnly:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateMinuteOnly, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthDecimalDay:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthDecimalDay, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthShortTextDay:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthShortTextDay, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthFullTextDay:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthFullTextDay, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthDecimalDayHourMinute:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthDecimalDayHourMinute, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthShortTextDayHourMinute:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthShortTextDayHourMinute, retStr);
                            break;
                        case ReportFormatingDateEnum.ReportFormatingDateYearMonthFullTextDayHourMinute:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingDateEnumReportFormatingDateYearMonthFullTextDayHourMinute, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportFormatingNumberEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportFormatingNumberEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportFormatingNumberEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportFormatingNumberEnum((ReportFormatingNumberEnum)i);
        
                    switch ((ReportFormatingNumberEnum)i)
                    {
                        case ReportFormatingNumberEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber0Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber0Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber1Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber1Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber2Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber2Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber3Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber3Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber4Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber4Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber5Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber5Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumber6Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumber6Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific0Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific0Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific1Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific1Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific2Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific2Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific3Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific3Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific4Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific4Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific5Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific5Decimal, retStr);
                            break;
                        case ReportFormatingNumberEnum.ReportFormatingNumberScientific6Decimal:
                            Assert.AreEqual(BaseEnumServiceRes.ReportFormatingNumberEnumReportFormatingNumberScientific6Decimal, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportGenerateObjectsKeywordEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportGenerateObjectsKeywordEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportGenerateObjectsKeywordEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportGenerateObjectsKeywordEnum((ReportGenerateObjectsKeywordEnum)i);
        
                    switch ((ReportGenerateObjectsKeywordEnum)i)
                    {
                        case ReportGenerateObjectsKeywordEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_RE_EVALUATION_COVER_PAGE:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_RE_EVALUATION_COVER_PAGE, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_ALL:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_ALL, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_WET:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_WET, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_FC_SUMMARY_STAT_DRY:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_FC_SUMMARY_STAT_DRY, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_DATA_AVAILABILITY:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_DATA_AVAILABILITY, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_SITES_BY_YEAR:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_SITES_BY_YEAR, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_RUNS_BY_YEAR:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_RUNS_BY_YEAR, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_NUMBER_OF_SAMPLES_BY_YEAR:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_NUMBER_OF_SAMPLES_BY_YEAR, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_FC_TABLE:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_FC_TABLE, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_SALINITY_TABLE:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_SALINITY_TABLE, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MWQM_SITES_TEMPERATURE_TABLE:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MWQM_SITES_TEMPERATURE_TABLE, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_SITES:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_SITES, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_SITES_COMPACT:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_SITES_COMPACT, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITIES:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITIES, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_MAP:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_MAP, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_CONTACTS:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_CONTACTS, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_DETAIL:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_MUNICIPALITY_INFRASTRUCTURE_DETAIL, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_ECCC_AND_SWCP_LOGO:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_ECCC_AND_SWCP_LOGO, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_CSSP_LOGO:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_CSSP_LOGO, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_LOCATION_OF_SURVEY_AREA_MAP:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_LOCATION_OF_SURVEY_AREA_MAP, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_CURRENT_CLASSIFICATION_AND_SAMPLING_LOCATION_MAP:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_CURRENT_CLASSIFICATION_AND_SAMPLING_LOCATION_MAP, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_RECOMMENDED_CLASSIFICATION_MAP:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_RECOMMENDED_CLASSIFICATION_MAP, retStr);
                            break;
                        case ReportGenerateObjectsKeywordEnum.SUBSECTOR_POLLUTION_SOURCE_LOCATIONS_MAP:
                            Assert.AreEqual(BaseEnumServiceRes.ReportGenerateObjectsKeywordEnumSUBSECTOR_POLLUTION_SOURCE_LOCATIONS_MAP, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportSortingEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportSortingEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportSortingEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportSortingEnum((ReportSortingEnum)i);
        
                    switch ((ReportSortingEnum)i)
                    {
                        case ReportSortingEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportSortingEnum.ReportSortingAscending:
                            Assert.AreEqual(BaseEnumServiceRes.ReportSortingEnumReportSortingAscending, retStr);
                            break;
                        case ReportSortingEnum.ReportSortingDescending:
                            Assert.AreEqual(BaseEnumServiceRes.ReportSortingEnumReportSortingDescending, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportTreeNodeSubTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportTreeNodeSubTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportTreeNodeSubTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportTreeNodeSubTypeEnum((ReportTreeNodeSubTypeEnum)i);
        
                    switch ((ReportTreeNodeSubTypeEnum)i)
                    {
                        case ReportTreeNodeSubTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportTreeNodeSubTypeEnum.TableSelectable:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeSubTypeEnumTableSelectable, retStr);
                            break;
                        case ReportTreeNodeSubTypeEnum.Field:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeSubTypeEnumField, retStr);
                            break;
                        case ReportTreeNodeSubTypeEnum.FieldsHolder:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeSubTypeEnumFieldsHolder, retStr);
                            break;
                        case ReportTreeNodeSubTypeEnum.TableNotSelectable:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeSubTypeEnumTableNotSelectable, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ReportTreeNodeTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ReportTreeNodeTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ReportTreeNodeTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ReportTreeNodeTypeEnum((ReportTreeNodeTypeEnum)i);
        
                    switch ((ReportTreeNodeTypeEnum)i)
                    {
                        case ReportTreeNodeTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportRootType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportRootType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportCountryType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportCountryType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportProvinceType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportProvinceType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportAreaType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportAreaType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSectorType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSectorType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMSiteType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportRootFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportRootFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportInfrastructureType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportBoxModelType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportBoxModelType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeScenarioType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeSourceType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeSourceType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMSiteSampleType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteSampleType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteObsType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteObsType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteObsIssueType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteObsIssueType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeScenarioGeneralParameterType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioGeneralParameterType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityContactType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportConditionType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportConditionType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportStatisticType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportStatisticType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportFieldsType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFieldsType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportFieldType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFieldType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteAddressType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteAddressType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityContactTelType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactTelType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityContactEmailType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactEmailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportBoxModelResultType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportBoxModelResultType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportClimateSiteType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportClimateSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportClimateSiteDataType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportClimateSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportHydrometricSiteType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportHydrometricSiteDataType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportHydrometricSiteRatingCurveType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteRatingCurveType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportHydrometricSiteRatingCurveValueType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportHydrometricSiteRatingCurveValueType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportInfrastructureAddressType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureAddressType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetDetailType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorLabSheetTubeMPNDetailType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorLabSheetTubeMPNDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunSampleType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunSampleType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportCountryFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportCountryFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportProvinceFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportProvinceFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportAreaFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportAreaFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSectorFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSectorFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMSiteFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportPolSourceSiteFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportPolSourceSiteFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportInfrastructureFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportInfrastructureFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeScenarioFileType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioFileType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeSourceStartEndType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeSourceStartEndType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetDetailType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMRunLabSheetTubeMPNDetailType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMRunLabSheetTubeMPNDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetDetailType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanLabSheetTubeMPNDetailType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanLabSheetTubeMPNDetailType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanSubsectorType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanSubsectorType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSamplingPlanSubsectorSiteType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSamplingPlanSubsectorSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeBoundaryConditionType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeBoundaryConditionType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioAmbientType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioAmbientType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportVisualPlumesScenarioResultType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportVisualPlumesScenarioResultType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMPNLookupType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMPNLookupType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMWQMSiteStartAndEndType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMWQMSiteStartAndEndType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorTideSiteType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorTideSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorTideSiteDataType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorTideSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportOrderType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportOrderType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportFormatType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportFormatType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMunicipalityContactAddressType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMunicipalityContactAddressType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorClimateSiteType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorClimateSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteDataType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteRatingCurveType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteRatingCurveType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorClimateSiteDataType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorClimateSiteDataType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorHydrometricSiteRatingCurveValueType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorHydrometricSiteRatingCurveValueType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportSubsectorSpecialTableType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportSubsectorSpecialTableType, retStr);
                            break;
                        case ReportTreeNodeTypeEnum.ReportMikeScenarioSpecialResultKMLType:
                            Assert.AreEqual(BaseEnumServiceRes.ReportTreeNodeTypeEnumReportMikeScenarioSpecialResultKMLType, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_SameDayNextDayEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SameDayNextDayEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SameDayNextDayEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SameDayNextDayEnum((SameDayNextDayEnum)i);
        
                    switch ((SameDayNextDayEnum)i)
                    {
                        case SameDayNextDayEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SameDayNextDayEnum.SameDay:
                            Assert.AreEqual(BaseEnumServiceRes.SameDayNextDayEnumSameDay, retStr);
                            break;
                        case SameDayNextDayEnum.NextDay:
                            Assert.AreEqual(BaseEnumServiceRes.SameDayNextDayEnumNextDay, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_SampleMatrixEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SampleMatrixEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SampleMatrixEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SampleMatrixEnum((SampleMatrixEnum)i);
        
                    switch ((SampleMatrixEnum)i)
                    {
                        case SampleMatrixEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SampleMatrixEnum.W:
                            Assert.AreEqual(BaseEnumServiceRes.SampleMatrixEnumW, retStr);
                            break;
                        case SampleMatrixEnum.S:
                            Assert.AreEqual(BaseEnumServiceRes.SampleMatrixEnumS, retStr);
                            break;
                        case SampleMatrixEnum.B:
                            Assert.AreEqual(BaseEnumServiceRes.SampleMatrixEnumB, retStr);
                            break;
                        case SampleMatrixEnum.MPNQ:
                            Assert.AreEqual(BaseEnumServiceRes.SampleMatrixEnumMPNQ, retStr);
                            break;
                        case SampleMatrixEnum.SampleMatrix5:
                            Assert.AreEqual(BaseEnumServiceRes.SampleMatrixEnumSampleMatrix5, retStr);
                            break;
                        case SampleMatrixEnum.SampleMatrix6:
                            Assert.AreEqual(BaseEnumServiceRes.SampleMatrixEnumSampleMatrix6, retStr);
                            break;
                        case SampleMatrixEnum.Water:
                            Assert.AreEqual(BaseEnumServiceRes.SampleMatrixEnumWater, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_SampleStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SampleStatusEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SampleStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SampleStatusEnum((SampleStatusEnum)i);
        
                    switch ((SampleStatusEnum)i)
                    {
                        case SampleStatusEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SampleStatusEnum.Active:
                            Assert.AreEqual(BaseEnumServiceRes.SampleStatusEnumActive, retStr);
                            break;
                        case SampleStatusEnum.Archived:
                            Assert.AreEqual(BaseEnumServiceRes.SampleStatusEnumArchived, retStr);
                            break;
                        case SampleStatusEnum.SampleStatus3:
                            Assert.AreEqual(BaseEnumServiceRes.SampleStatusEnumSampleStatus3, retStr);
                            break;
                        case SampleStatusEnum.SampleStatus4:
                            Assert.AreEqual(BaseEnumServiceRes.SampleStatusEnumSampleStatus4, retStr);
                            break;
                        case SampleStatusEnum.SampleStatus5:
                            Assert.AreEqual(BaseEnumServiceRes.SampleStatusEnumSampleStatus5, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_SampleTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SampleTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SampleTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SampleTypeEnum((SampleTypeEnum)i);
        
                    switch ((SampleTypeEnum)i)
                    {
                        case SampleTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SampleTypeEnum.DailyDuplicate:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumDailyDuplicate, retStr);
                            break;
                        case SampleTypeEnum.Infrastructure:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumInfrastructure, retStr);
                            break;
                        case SampleTypeEnum.IntertechDuplicate:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumIntertechDuplicate, retStr);
                            break;
                        case SampleTypeEnum.IntertechRead:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumIntertechRead, retStr);
                            break;
                        case SampleTypeEnum.RainCMP:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumRainCMP, retStr);
                            break;
                        case SampleTypeEnum.RainRun:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumRainRun, retStr);
                            break;
                        case SampleTypeEnum.ReopeningEmergencyRain:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumReopeningEmergencyRain, retStr);
                            break;
                        case SampleTypeEnum.ReopeningSpill:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumReopeningSpill, retStr);
                            break;
                        case SampleTypeEnum.Routine:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumRoutine, retStr);
                            break;
                        case SampleTypeEnum.Sanitary:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumSanitary, retStr);
                            break;
                        case SampleTypeEnum.Study:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumStudy, retStr);
                            break;
                        case SampleTypeEnum.Sediment:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumSediment, retStr);
                            break;
                        case SampleTypeEnum.Bivalve:
                            Assert.AreEqual(BaseEnumServiceRes.SampleTypeEnumBivalve, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_SamplingPlanTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SamplingPlanTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SamplingPlanTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SamplingPlanTypeEnum((SamplingPlanTypeEnum)i);
        
                    switch ((SamplingPlanTypeEnum)i)
                    {
                        case SamplingPlanTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SamplingPlanTypeEnum.Subsector:
                            Assert.AreEqual(BaseEnumServiceRes.SamplingPlanTypeEnumSubsector, retStr);
                            break;
                        case SamplingPlanTypeEnum.Municipality:
                            Assert.AreEqual(BaseEnumServiceRes.SamplingPlanTypeEnumMunicipality, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_ScenarioStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_ScenarioStatusEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(ScenarioStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_ScenarioStatusEnum((ScenarioStatusEnum)i);
        
                    switch ((ScenarioStatusEnum)i)
                    {
                        case ScenarioStatusEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case ScenarioStatusEnum.Normal:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumNormal, retStr);
                            break;
                        case ScenarioStatusEnum.Copying:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumCopying, retStr);
                            break;
                        case ScenarioStatusEnum.Copied:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumCopied, retStr);
                            break;
                        case ScenarioStatusEnum.Changing:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumChanging, retStr);
                            break;
                        case ScenarioStatusEnum.Changed:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumChanged, retStr);
                            break;
                        case ScenarioStatusEnum.AskToRun:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumAskToRun, retStr);
                            break;
                        case ScenarioStatusEnum.Running:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumRunning, retStr);
                            break;
                        case ScenarioStatusEnum.Completed:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumCompleted, retStr);
                            break;
                        case ScenarioStatusEnum.Cancelled:
                            Assert.AreEqual(BaseEnumServiceRes.ScenarioStatusEnumCancelled, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_SearchTagEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SearchTagEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SearchTagEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SearchTagEnum((SearchTagEnum)i);
        
                    switch ((SearchTagEnum)i)
                    {
                        case SearchTagEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SearchTagEnum.c:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumc, retStr);
                            break;
                        case SearchTagEnum.e:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnume, retStr);
                            break;
                        case SearchTagEnum.t:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumt, retStr);
                            break;
                        case SearchTagEnum.fi:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfi, retStr);
                            break;
                        case SearchTagEnum.fp:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfp, retStr);
                            break;
                        case SearchTagEnum.frg:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfrg, retStr);
                            break;
                        case SearchTagEnum.ftg:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumftg, retStr);
                            break;
                        case SearchTagEnum.fpdf:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfpdf, retStr);
                            break;
                        case SearchTagEnum.fdocx:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfdocx, retStr);
                            break;
                        case SearchTagEnum.fxlsx:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfxlsx, retStr);
                            break;
                        case SearchTagEnum.fkmz:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfkmz, retStr);
                            break;
                        case SearchTagEnum.fxyz:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfxyz, retStr);
                            break;
                        case SearchTagEnum.fdfs:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfdfs, retStr);
                            break;
                        case SearchTagEnum.fmike:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfmike, retStr);
                            break;
                        case SearchTagEnum.fmdf:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfmdf, retStr);
                            break;
                        case SearchTagEnum.fm21fm:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfm21fm, retStr);
                            break;
                        case SearchTagEnum.fm3fm:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfm3fm, retStr);
                            break;
                        case SearchTagEnum.fmesh:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfmesh, retStr);
                            break;
                        case SearchTagEnum.flog:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumflog, retStr);
                            break;
                        case SearchTagEnum.ftxt:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumftxt, retStr);
                            break;
                        case SearchTagEnum.m:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumm, retStr);
                            break;
                        case SearchTagEnum.p:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnump, retStr);
                            break;
                        case SearchTagEnum.ms:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumms, retStr);
                            break;
                        case SearchTagEnum.cs:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumcs, retStr);
                            break;
                        case SearchTagEnum.hs:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumhs, retStr);
                            break;
                        case SearchTagEnum.ts:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumts, retStr);
                            break;
                        case SearchTagEnum.ww:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumww, retStr);
                            break;
                        case SearchTagEnum.ls:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumls, retStr);
                            break;
                        case SearchTagEnum.st:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumst, retStr);
                            break;
                        case SearchTagEnum.ps:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumps, retStr);
                            break;
                        case SearchTagEnum.a:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnuma, retStr);
                            break;
                        case SearchTagEnum.s:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnums, retStr);
                            break;
                        case SearchTagEnum.ss:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumss, retStr);
                            break;
                        case SearchTagEnum.u:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumu, retStr);
                            break;
                        case SearchTagEnum.notag:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumnotag, retStr);
                            break;
                        case SearchTagEnum.fcsv:
                            Assert.AreEqual(BaseEnumServiceRes.SearchTagEnumfcsv, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_SecondaryTreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SecondaryTreatmentTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SecondaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SecondaryTreatmentTypeEnum((SecondaryTreatmentTypeEnum)i);
        
                    switch ((SecondaryTreatmentTypeEnum)i)
                    {
                        case SecondaryTreatmentTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.NotApplicable:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumNotApplicable, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.RotatingBiologicalContactor:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumRotatingBiologicalContactor, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.TricklingFilters:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumTricklingFilters, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.SequencingBatchReactor:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumSequencingBatchReactor, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.OxidationDitch:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumOxidationDitch, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.ExtendedAeration:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumExtendedAeration, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.ContactStabilization:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumContactStabilization, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.PhysicalChemicalProcesses:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumPhysicalChemicalProcesses, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.MovingBedBioReactor:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumMovingBedBioReactor, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.BiologicalAearatedFilters:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumBiologicalAearatedFilters, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.AeratedSubmergedBioFilmReactor:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumAeratedSubmergedBioFilmReactor, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.IntegratedFixedFilmActivatedSludge:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumIntegratedFixedFilmActivatedSludge, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.ActivatedSludge:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumActivatedSludge, retStr);
                            break;
                        case SecondaryTreatmentTypeEnum.ExtendedActivatedSludge:
                            Assert.AreEqual(BaseEnumServiceRes.SecondaryTreatmentTypeEnumExtendedActivatedSludge, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_SpecialTableTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_SpecialTableTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(SpecialTableTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_SpecialTableTypeEnum((SpecialTableTypeEnum)i);
        
                    switch ((SpecialTableTypeEnum)i)
                    {
                        case SpecialTableTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case SpecialTableTypeEnum.FCDensitiesTable:
                            Assert.AreEqual(BaseEnumServiceRes.SpecialTableTypeEnumFCDensitiesTable, retStr);
                            break;
                        case SpecialTableTypeEnum.SalinityTable:
                            Assert.AreEqual(BaseEnumServiceRes.SpecialTableTypeEnumSalinityTable, retStr);
                            break;
                        case SpecialTableTypeEnum.TemperatureTable:
                            Assert.AreEqual(BaseEnumServiceRes.SpecialTableTypeEnumTemperatureTable, retStr);
                            break;
                        case SpecialTableTypeEnum.GeometricMeanTable:
                            Assert.AreEqual(BaseEnumServiceRes.SpecialTableTypeEnumGeometricMeanTable, retStr);
                            break;
                        case SpecialTableTypeEnum.MedianTable:
                            Assert.AreEqual(BaseEnumServiceRes.SpecialTableTypeEnumMedianTable, retStr);
                            break;
                        case SpecialTableTypeEnum.P90Table:
                            Assert.AreEqual(BaseEnumServiceRes.SpecialTableTypeEnumP90Table, retStr);
                            break;
                        case SpecialTableTypeEnum.PercentOver43Table:
                            Assert.AreEqual(BaseEnumServiceRes.SpecialTableTypeEnumPercentOver43Table, retStr);
                            break;
                        case SpecialTableTypeEnum.PercentOver260Table:
                            Assert.AreEqual(BaseEnumServiceRes.SpecialTableTypeEnumPercentOver260Table, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_StorageDataTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_StorageDataTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(StorageDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_StorageDataTypeEnum((StorageDataTypeEnum)i);
        
                    switch ((StorageDataTypeEnum)i)
                    {
                        case StorageDataTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case StorageDataTypeEnum.Archived:
                            Assert.AreEqual(BaseEnumServiceRes.StorageDataTypeEnumArchived, retStr);
                            break;
                        case StorageDataTypeEnum.Forcasted:
                            Assert.AreEqual(BaseEnumServiceRes.StorageDataTypeEnumForcasted, retStr);
                            break;
                        case StorageDataTypeEnum.Observed:
                            Assert.AreEqual(BaseEnumServiceRes.StorageDataTypeEnumObserved, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_StreetTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_StreetTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(StreetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_StreetTypeEnum((StreetTypeEnum)i);
        
                    switch ((StreetTypeEnum)i)
                    {
                        case StreetTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case StreetTypeEnum.Street:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumStreet, retStr);
                            break;
                        case StreetTypeEnum.Road:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumRoad, retStr);
                            break;
                        case StreetTypeEnum.Avenue:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumAvenue, retStr);
                            break;
                        case StreetTypeEnum.Crescent:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumCrescent, retStr);
                            break;
                        case StreetTypeEnum.Court:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumCourt, retStr);
                            break;
                        case StreetTypeEnum.Alley:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumAlley, retStr);
                            break;
                        case StreetTypeEnum.Drive:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumDrive, retStr);
                            break;
                        case StreetTypeEnum.Blvd:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumBlvd, retStr);
                            break;
                        case StreetTypeEnum.Route:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumRoute, retStr);
                            break;
                        case StreetTypeEnum.Lane:
                            Assert.AreEqual(BaseEnumServiceRes.StreetTypeEnumLane, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_TelTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TelTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TelTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TelTypeEnum((TelTypeEnum)i);
        
                    switch ((TelTypeEnum)i)
                    {
                        case TelTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TelTypeEnum.Personal:
                            Assert.AreEqual(BaseEnumServiceRes.TelTypeEnumPersonal, retStr);
                            break;
                        case TelTypeEnum.Work:
                            Assert.AreEqual(BaseEnumServiceRes.TelTypeEnumWork, retStr);
                            break;
                        case TelTypeEnum.Mobile:
                            Assert.AreEqual(BaseEnumServiceRes.TelTypeEnumMobile, retStr);
                            break;
                        case TelTypeEnum.Personal2:
                            Assert.AreEqual(BaseEnumServiceRes.TelTypeEnumPersonal2, retStr);
                            break;
                        case TelTypeEnum.Work2:
                            Assert.AreEqual(BaseEnumServiceRes.TelTypeEnumWork2, retStr);
                            break;
                        case TelTypeEnum.Mobile2:
                            Assert.AreEqual(BaseEnumServiceRes.TelTypeEnumMobile2, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_TertiaryTreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TertiaryTreatmentTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TertiaryTreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TertiaryTreatmentTypeEnum((TertiaryTreatmentTypeEnum)i);
        
                    switch ((TertiaryTreatmentTypeEnum)i)
                    {
                        case TertiaryTreatmentTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.NotApplicable:
                            Assert.AreEqual(BaseEnumServiceRes.TertiaryTreatmentTypeEnumNotApplicable, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.Adsorption:
                            Assert.AreEqual(BaseEnumServiceRes.TertiaryTreatmentTypeEnumAdsorption, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.Flocculation:
                            Assert.AreEqual(BaseEnumServiceRes.TertiaryTreatmentTypeEnumFlocculation, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.MembraneFiltration:
                            Assert.AreEqual(BaseEnumServiceRes.TertiaryTreatmentTypeEnumMembraneFiltration, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.IonExchange:
                            Assert.AreEqual(BaseEnumServiceRes.TertiaryTreatmentTypeEnumIonExchange, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.ReverseOsmosis:
                            Assert.AreEqual(BaseEnumServiceRes.TertiaryTreatmentTypeEnumReverseOsmosis, retStr);
                            break;
                        case TertiaryTreatmentTypeEnum.BiologicalNutrientRemoval:
                            Assert.AreEqual(BaseEnumServiceRes.TertiaryTreatmentTypeEnumBiologicalNutrientRemoval, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_TideDataTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TideDataTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TideDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TideDataTypeEnum((TideDataTypeEnum)i);
        
                    switch ((TideDataTypeEnum)i)
                    {
                        case TideDataTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TideDataTypeEnum.Min15:
                            Assert.AreEqual(BaseEnumServiceRes.TideDataTypeEnumMin15, retStr);
                            break;
                        case TideDataTypeEnum.Min60:
                            Assert.AreEqual(BaseEnumServiceRes.TideDataTypeEnumMin60, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_TideTextEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TideTextEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TideTextEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TideTextEnum((TideTextEnum)i);
        
                    switch ((TideTextEnum)i)
                    {
                        case TideTextEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TideTextEnum.LowTide:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumLowTide, retStr);
                            break;
                        case TideTextEnum.LowTideFalling:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumLowTideFalling, retStr);
                            break;
                        case TideTextEnum.LowTideRising:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumLowTideRising, retStr);
                            break;
                        case TideTextEnum.MidTide:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumMidTide, retStr);
                            break;
                        case TideTextEnum.MidTideFalling:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumMidTideFalling, retStr);
                            break;
                        case TideTextEnum.MidTideRising:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumMidTideRising, retStr);
                            break;
                        case TideTextEnum.HighTide:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumHighTide, retStr);
                            break;
                        case TideTextEnum.HighTideFalling:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumHighTideFalling, retStr);
                            break;
                        case TideTextEnum.HighTideRising:
                            Assert.AreEqual(BaseEnumServiceRes.TideTextEnumHighTideRising, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_TranslationStatusEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TranslationStatusEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TranslationStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TranslationStatusEnum((TranslationStatusEnum)i);
        
                    switch ((TranslationStatusEnum)i)
                    {
                        case TranslationStatusEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TranslationStatusEnum.NotTranslated:
                            Assert.AreEqual(BaseEnumServiceRes.TranslationStatusEnumNotTranslated, retStr);
                            break;
                        case TranslationStatusEnum.ElectronicallyTranslated:
                            Assert.AreEqual(BaseEnumServiceRes.TranslationStatusEnumElectronicallyTranslated, retStr);
                            break;
                        case TranslationStatusEnum.Translated:
                            Assert.AreEqual(BaseEnumServiceRes.TranslationStatusEnumTranslated, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_TreatmentTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TreatmentTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TreatmentTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TreatmentTypeEnum((TreatmentTypeEnum)i);
        
                    switch ((TreatmentTypeEnum)i)
                    {
                        case TreatmentTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TreatmentTypeEnum.ActivatedSludge:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumActivatedSludge, retStr);
                            break;
                        case TreatmentTypeEnum.ActivatedSludgeWithBiofilter:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumActivatedSludgeWithBiofilter, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration1Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration1Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration2Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration2Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration3Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration3Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration4Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration4Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonNoAeration5Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonNoAeration5Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration1Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration1Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration2Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration2Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration3Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration3Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration4Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration4Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration5Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration5Cell, retStr);
                            break;
                        case TreatmentTypeEnum.LagoonWithAeration6Cell:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumLagoonWithAeration6Cell, retStr);
                            break;
                        case TreatmentTypeEnum.StabalizingPondOnly:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumStabalizingPondOnly, retStr);
                            break;
                        case TreatmentTypeEnum.OxidationDitchOnly:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumOxidationDitchOnly, retStr);
                            break;
                        case TreatmentTypeEnum.CirculatingFluidizedBed:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumCirculatingFluidizedBed, retStr);
                            break;
                        case TreatmentTypeEnum.TricklingFilter:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumTricklingFilter, retStr);
                            break;
                        case TreatmentTypeEnum.RecirculatingSandFilter:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumRecirculatingSandFilter, retStr);
                            break;
                        case TreatmentTypeEnum.TrashRackRakeOnly:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumTrashRackRakeOnly, retStr);
                            break;
                        case TreatmentTypeEnum.SepticTank:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumSepticTank, retStr);
                            break;
                        case TreatmentTypeEnum.Secondary:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumSecondary, retStr);
                            break;
                        case TreatmentTypeEnum.Tertiary:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumTertiary, retStr);
                            break;
                        case TreatmentTypeEnum.VolumeFermenter:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumVolumeFermenter, retStr);
                            break;
                        case TreatmentTypeEnum.BioFilmReactor:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumBioFilmReactor, retStr);
                            break;
                        case TreatmentTypeEnum.BioGreen:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumBioGreen, retStr);
                            break;
                        case TreatmentTypeEnum.BioDisks:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumBioDisks, retStr);
                            break;
                        case TreatmentTypeEnum.ChemicalPrimary:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumChemicalPrimary, retStr);
                            break;
                        case TreatmentTypeEnum.Chromoglass:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumChromoglass, retStr);
                            break;
                        case TreatmentTypeEnum.Primary:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumPrimary, retStr);
                            break;
                        case TreatmentTypeEnum.SequencingBatchReactor:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumSequencingBatchReactor, retStr);
                            break;
                        case TreatmentTypeEnum.PeatSystem:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumPeatSystem, retStr);
                            break;
                        case TreatmentTypeEnum.Physicochimique:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumPhysicochimique, retStr);
                            break;
                        case TreatmentTypeEnum.RotatingBiologicalContactor:
                            Assert.AreEqual(BaseEnumServiceRes.TreatmentTypeEnumRotatingBiologicalContactor, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_TVAuthEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TVAuthEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TVAuthEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TVAuthEnum((TVAuthEnum)i);
        
                    switch ((TVAuthEnum)i)
                    {
                        case TVAuthEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TVAuthEnum.NoAccess:
                            Assert.AreEqual(BaseEnumServiceRes.TVAuthEnumNoAccess, retStr);
                            break;
                        case TVAuthEnum.Read:
                            Assert.AreEqual(BaseEnumServiceRes.TVAuthEnumRead, retStr);
                            break;
                        case TVAuthEnum.Write:
                            Assert.AreEqual(BaseEnumServiceRes.TVAuthEnumWrite, retStr);
                            break;
                        case TVAuthEnum.Create:
                            Assert.AreEqual(BaseEnumServiceRes.TVAuthEnumCreate, retStr);
                            break;
                        case TVAuthEnum.Delete:
                            Assert.AreEqual(BaseEnumServiceRes.TVAuthEnumDelete, retStr);
                            break;
                        case TVAuthEnum.Admin:
                            Assert.AreEqual(BaseEnumServiceRes.TVAuthEnumAdmin, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_TVTypeEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_TVTypeEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(TVTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_TVTypeEnum((TVTypeEnum)i);
        
                    switch ((TVTypeEnum)i)
                    {
                        case TVTypeEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case TVTypeEnum.Root:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumRoot, retStr);
                            break;
                        case TVTypeEnum.Address:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumAddress, retStr);
                            break;
                        case TVTypeEnum.Area:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumArea, retStr);
                            break;
                        case TVTypeEnum.ClimateSite:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumClimateSite, retStr);
                            break;
                        case TVTypeEnum.Contact:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumContact, retStr);
                            break;
                        case TVTypeEnum.Country:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumCountry, retStr);
                            break;
                        case TVTypeEnum.Email:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumEmail, retStr);
                            break;
                        case TVTypeEnum.File:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumFile, retStr);
                            break;
                        case TVTypeEnum.HydrometricSite:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumHydrometricSite, retStr);
                            break;
                        case TVTypeEnum.Infrastructure:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumInfrastructure, retStr);
                            break;
                        case TVTypeEnum.MikeBoundaryConditionWebTide:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMikeBoundaryConditionWebTide, retStr);
                            break;
                        case TVTypeEnum.MikeBoundaryConditionMesh:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMikeBoundaryConditionMesh, retStr);
                            break;
                        case TVTypeEnum.MikeScenario:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMikeScenario, retStr);
                            break;
                        case TVTypeEnum.MikeSource:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMikeSource, retStr);
                            break;
                        case TVTypeEnum.Municipality:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMunicipality, retStr);
                            break;
                        case TVTypeEnum.MWQMSite:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMWQMSite, retStr);
                            break;
                        case TVTypeEnum.PolSourceSite:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumPolSourceSite, retStr);
                            break;
                        case TVTypeEnum.Province:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumProvince, retStr);
                            break;
                        case TVTypeEnum.Sector:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSector, retStr);
                            break;
                        case TVTypeEnum.Subsector:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSubsector, retStr);
                            break;
                        case TVTypeEnum.Tel:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumTel, retStr);
                            break;
                        case TVTypeEnum.TideSite:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumTideSite, retStr);
                            break;
                        case TVTypeEnum.MWQMSiteSample:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMWQMSiteSample, retStr);
                            break;
                        case TVTypeEnum.WasteWaterTreatmentPlant:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumWasteWaterTreatmentPlant, retStr);
                            break;
                        case TVTypeEnum.LiftStation:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumLiftStation, retStr);
                            break;
                        case TVTypeEnum.Spill:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSpill, retStr);
                            break;
                        case TVTypeEnum.BoxModel:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumBoxModel, retStr);
                            break;
                        case TVTypeEnum.VisualPlumesScenario:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumVisualPlumesScenario, retStr);
                            break;
                        case TVTypeEnum.Outfall:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumOutfall, retStr);
                            break;
                        case TVTypeEnum.OtherInfrastructure:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumOtherInfrastructure, retStr);
                            break;
                        case TVTypeEnum.MWQMRun:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMWQMRun, retStr);
                            break;
                        case TVTypeEnum.NoDepuration:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumNoDepuration, retStr);
                            break;
                        case TVTypeEnum.Failed:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumFailed, retStr);
                            break;
                        case TVTypeEnum.Passed:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumPassed, retStr);
                            break;
                        case TVTypeEnum.NoData:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumNoData, retStr);
                            break;
                        case TVTypeEnum.LessThan10:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumLessThan10, retStr);
                            break;
                        case TVTypeEnum.MeshNode:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMeshNode, retStr);
                            break;
                        case TVTypeEnum.WebTideNode:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumWebTideNode, retStr);
                            break;
                        case TVTypeEnum.SamplingPlan:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSamplingPlan, retStr);
                            break;
                        case TVTypeEnum.SeeOtherMunicipality:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSeeOtherMunicipality, retStr);
                            break;
                        case TVTypeEnum.LineOverflow:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumLineOverflow, retStr);
                            break;
                        case TVTypeEnum.BoxModelInputs:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumBoxModelInputs, retStr);
                            break;
                        case TVTypeEnum.BoxModelResults:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumBoxModelResults, retStr);
                            break;
                        case TVTypeEnum.ClimateSiteInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumClimateSiteInfo, retStr);
                            break;
                        case TVTypeEnum.ClimateSiteData:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumClimateSiteData, retStr);
                            break;
                        case TVTypeEnum.HydrometricSiteInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumHydrometricSiteInfo, retStr);
                            break;
                        case TVTypeEnum.HydrometricSiteData:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumHydrometricSiteData, retStr);
                            break;
                        case TVTypeEnum.InfrastructureInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumInfrastructureInfo, retStr);
                            break;
                        case TVTypeEnum.LabSheetInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumLabSheetInfo, retStr);
                            break;
                        case TVTypeEnum.LabSheetDetailInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumLabSheetDetailInfo, retStr);
                            break;
                        case TVTypeEnum.MapInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMapInfo, retStr);
                            break;
                        case TVTypeEnum.MapInfoPoint:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMapInfoPoint, retStr);
                            break;
                        case TVTypeEnum.MikeSourceStartEndInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMikeSourceStartEndInfo, retStr);
                            break;
                        case TVTypeEnum.MWQMLookupMPNInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMWQMLookupMPNInfo, retStr);
                            break;
                        case TVTypeEnum.SamplingPlanInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSamplingPlanInfo, retStr);
                            break;
                        case TVTypeEnum.SamplingPlanSubsectorInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSamplingPlanSubsectorInfo, retStr);
                            break;
                        case TVTypeEnum.SamplingPlanSubsectorSiteInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSamplingPlanSubsectorSiteInfo, retStr);
                            break;
                        case TVTypeEnum.MWQMSiteStartEndInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMWQMSiteStartEndInfo, retStr);
                            break;
                        case TVTypeEnum.MWQMSubsectorInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMWQMSubsectorInfo, retStr);
                            break;
                        case TVTypeEnum.PolSourceSiteInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumPolSourceSiteInfo, retStr);
                            break;
                        case TVTypeEnum.PolSourceSiteObsInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumPolSourceSiteObsInfo, retStr);
                            break;
                        case TVTypeEnum.HydrometricRatingCurveInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumHydrometricRatingCurveInfo, retStr);
                            break;
                        case TVTypeEnum.HydrometricRatingCurveDataInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumHydrometricRatingCurveDataInfo, retStr);
                            break;
                        case TVTypeEnum.TideLocationInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumTideLocationInfo, retStr);
                            break;
                        case TVTypeEnum.TideSiteDataInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumTideSiteDataInfo, retStr);
                            break;
                        case TVTypeEnum.UseOfSite:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumUseOfSite, retStr);
                            break;
                        case TVTypeEnum.VisualPlumesScenarioInfo:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioInfo, retStr);
                            break;
                        case TVTypeEnum.VisualPlumesScenarioAmbient:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioAmbient, retStr);
                            break;
                        case TVTypeEnum.VisualPlumesScenarioResults:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumVisualPlumesScenarioResults, retStr);
                            break;
                        case TVTypeEnum.TotalFile:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumTotalFile, retStr);
                            break;
                        case TVTypeEnum.MikeSourceIsRiver:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMikeSourceIsRiver, retStr);
                            break;
                        case TVTypeEnum.MikeSourceIncluded:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMikeSourceIncluded, retStr);
                            break;
                        case TVTypeEnum.MikeSourceNotIncluded:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumMikeSourceNotIncluded, retStr);
                            break;
                        case TVTypeEnum.RainExceedance:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumRainExceedance, retStr);
                            break;
                        case TVTypeEnum.EmailDistributionList:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumEmailDistributionList, retStr);
                            break;
                        case TVTypeEnum.OpenData:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumOpenData, retStr);
                            break;
                        case TVTypeEnum.ProvinceTools:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumProvinceTools, retStr);
                            break;
                        case TVTypeEnum.Classification:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumClassification, retStr);
                            break;
                        case TVTypeEnum.Approved:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumApproved, retStr);
                            break;
                        case TVTypeEnum.Restricted:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumRestricted, retStr);
                            break;
                        case TVTypeEnum.Prohibited:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumProhibited, retStr);
                            break;
                        case TVTypeEnum.ConditionallyApproved:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumConditionallyApproved, retStr);
                            break;
                        case TVTypeEnum.ConditionallyRestricted:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumConditionallyRestricted, retStr);
                            break;
                        case TVTypeEnum.OpenDataNational:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumOpenDataNational, retStr);
                            break;
                        case TVTypeEnum.PolSourceSiteMikeScenario:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumPolSourceSiteMikeScenario, retStr);
                            break;
                        case TVTypeEnum.SubsectorTools:
                            Assert.AreEqual(BaseEnumServiceRes.TVTypeEnumSubsectorTools, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_GetEnumText_WebTideDataSetEnum_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);
        
                string retStr = baseEnumService.GetEnumText_WebTideDataSetEnum(null);
                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
        
                for (int i = 0, count = Enum.GetNames(typeof(WebTideDataSetEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.GetEnumText_WebTideDataSetEnum((WebTideDataSetEnum)i);
        
                    switch ((WebTideDataSetEnum)i)
                    {
                        case WebTideDataSetEnum.Error:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                        case WebTideDataSetEnum.arctic9:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumarctic9, retStr);
                            break;
                        case WebTideDataSetEnum.brador:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumbrador, retStr);
                            break;
                        case WebTideDataSetEnum.HRglobal:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumHRglobal, retStr);
                            break;
                        case WebTideDataSetEnum.h3o:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumh3o, retStr);
                            break;
                        case WebTideDataSetEnum.hudson:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumhudson, retStr);
                            break;
                        case WebTideDataSetEnum.ne_pac4:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumne_pac4, retStr);
                            break;
                        case WebTideDataSetEnum.nwatl:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumnwatl, retStr);
                            break;
                        case WebTideDataSetEnum.QuatsinoModel14:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumQuatsinoModel14, retStr);
                            break;
                        case WebTideDataSetEnum.sshelf:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumsshelf, retStr);
                            break;
                        case WebTideDataSetEnum.flood:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumflood, retStr);
                            break;
                        case WebTideDataSetEnum.vigf8:
                            Assert.AreEqual(BaseEnumServiceRes.WebTideDataSetEnumvigf8, retStr);
                            break;
                        default:
                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);
                            break;
                    }
                }
            }
        }

        #endregion Testing Methods GetEnumText public

        #region Testing Methods Check OK public
        [TestMethod]
        public void BaseEnumService_AddressTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AddressTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AddressTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AddressTypeOK((AddressTypeEnum)i);

                    switch ((AddressTypeEnum)i)
                    {
                        case AddressTypeEnum.Error:
                        case AddressTypeEnum.Mailing:
                        case AddressTypeEnum.Shipping:
                        case AddressTypeEnum.Civic:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AddressType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_AerationTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AerationTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AerationTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AerationTypeOK((AerationTypeEnum)i);

                    switch ((AerationTypeEnum)i)
                    {
                        case AerationTypeEnum.Error:
                        case AerationTypeEnum.MechanicalAirLines:
                        case AerationTypeEnum.MechanicalSurfaceMixers:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AerationType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_AlarmSystemTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AlarmSystemTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AlarmSystemType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_AnalysisCalculationTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AnalysisCalculationTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalysisCalculationType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_AnalysisReportExportCommandOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AnalysisReportExportCommandOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(AnalysisReportExportCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.AnalysisReportExportCommandOK((AnalysisReportExportCommandEnum)i);

                    switch ((AnalysisReportExportCommandEnum)i)
                    {
                        case AnalysisReportExportCommandEnum.Error:
                        case AnalysisReportExportCommandEnum.Report:
                        case AnalysisReportExportCommandEnum.Excel:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalysisReportExportCommand), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_AnalyzeMethodOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AnalyzeMethodOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AnalyzeMethod), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_AppTaskCommandOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AppTaskCommandOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AppTaskCommand), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_AppTaskStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.AppTaskStatusOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.AppTaskStatus), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_BeaufortScaleOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.BeaufortScaleOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.BeaufortScale), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_BoxModelResultTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.BoxModelResultTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.BoxModelResultType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ClassificationTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ClassificationTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ClassificationType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_CollectionSystemTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.CollectionSystemTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CollectionSystemType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ContactTitleOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ContactTitleOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ContactTitle), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_CSSPWQInputSheetTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.CSSPWQInputSheetTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(CSSPWQInputSheetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.CSSPWQInputSheetTypeOK((CSSPWQInputSheetTypeEnum)i);

                    switch ((CSSPWQInputSheetTypeEnum)i)
                    {
                        case CSSPWQInputSheetTypeEnum.Error:
                        case CSSPWQInputSheetTypeEnum.A1:
                        case CSSPWQInputSheetTypeEnum.LTB:
                        case CSSPWQInputSheetTypeEnum.EC:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CSSPWQInputSheetType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_CSSPWQInputTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.CSSPWQInputTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(CSSPWQInputTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.CSSPWQInputTypeOK((CSSPWQInputTypeEnum)i);

                    switch ((CSSPWQInputTypeEnum)i)
                    {
                        case CSSPWQInputTypeEnum.Error:
                        case CSSPWQInputTypeEnum.Subsector:
                        case CSSPWQInputTypeEnum.Municipality:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.CSSPWQInputType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_DailyOrHourlyDataOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.DailyOrHourlyDataOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(DailyOrHourlyDataEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.DailyOrHourlyDataOK((DailyOrHourlyDataEnum)i);

                    switch ((DailyOrHourlyDataEnum)i)
                    {
                        case DailyOrHourlyDataEnum.Error:
                        case DailyOrHourlyDataEnum.Daily:
                        case DailyOrHourlyDataEnum.Hourly:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DailyOrHourlyData), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_DisinfectionTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.DisinfectionTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DisinfectionType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_DrogueTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.DrogueTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(DrogueTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.DrogueTypeOK((DrogueTypeEnum)i);

                    switch ((DrogueTypeEnum)i)
                    {
                        case DrogueTypeEnum.Error:
                        case DrogueTypeEnum.SmallDrogue:
                        case DrogueTypeEnum.LargeDrogue:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.DrogueType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_EmailTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.EmailTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.EmailType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ExcelExportShowDataTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ExcelExportShowDataTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ExcelExportShowDataType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_FacilityTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.FacilityTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(FacilityTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.FacilityTypeOK((FacilityTypeEnum)i);

                    switch ((FacilityTypeEnum)i)
                    {
                        case FacilityTypeEnum.Error:
                        case FacilityTypeEnum.Lagoon:
                        case FacilityTypeEnum.Plant:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FacilityType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_FilePurposeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.FilePurposeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FilePurpose), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_FileStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.FileStatusOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FileStatus), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_FileTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.FileTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.FileType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_InfrastructureTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.InfrastructureTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.InfrastructureType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_KMZActionOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.KMZActionOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.KMZAction), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_LaboratoryOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LaboratoryOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Laboratory), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_LabSheetStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LabSheetStatusOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LabSheetStatus), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_LabSheetTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LabSheetTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(LabSheetTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.LabSheetTypeOK((LabSheetTypeEnum)i);

                    switch ((LabSheetTypeEnum)i)
                    {
                        case LabSheetTypeEnum.Error:
                        case LabSheetTypeEnum.A1:
                        case LabSheetTypeEnum.LTB:
                        case LabSheetTypeEnum.EC:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LabSheetType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_LanguageOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LanguageOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Language), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_LogCommandOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.LogCommandOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(LogCommandEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.LogCommandOK((LogCommandEnum)i);

                    switch ((LogCommandEnum)i)
                    {
                        case LogCommandEnum.Error:
                        case LogCommandEnum.Add:
                        case LogCommandEnum.Change:
                        case LogCommandEnum.Delete:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.LogCommand), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_MapInfoDrawTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.MapInfoDrawTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(MapInfoDrawTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.MapInfoDrawTypeOK((MapInfoDrawTypeEnum)i);

                    switch ((MapInfoDrawTypeEnum)i)
                    {
                        case MapInfoDrawTypeEnum.Error:
                        case MapInfoDrawTypeEnum.Point:
                        case MapInfoDrawTypeEnum.Polyline:
                        case MapInfoDrawTypeEnum.Polygon:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MapInfoDrawType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_MikeBoundaryConditionLevelOrVelocityOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.MikeBoundaryConditionLevelOrVelocityOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(MikeBoundaryConditionLevelOrVelocityEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.MikeBoundaryConditionLevelOrVelocityOK((MikeBoundaryConditionLevelOrVelocityEnum)i);

                    switch ((MikeBoundaryConditionLevelOrVelocityEnum)i)
                    {
                        case MikeBoundaryConditionLevelOrVelocityEnum.Error:
                        case MikeBoundaryConditionLevelOrVelocityEnum.Level:
                        case MikeBoundaryConditionLevelOrVelocityEnum.Velocity:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MikeBoundaryConditionLevelOrVelocity), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_MikeScenarioSpecialResultKMLTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.MikeScenarioSpecialResultKMLTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MikeScenarioSpecialResultKMLType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_MWQMSiteLatestClassificationOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.MWQMSiteLatestClassificationOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.MWQMSiteLatestClassification), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_PolSourceInactiveReasonOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PolSourceInactiveReasonOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(PolSourceInactiveReasonEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.PolSourceInactiveReasonOK((PolSourceInactiveReasonEnum)i);

                    switch ((PolSourceInactiveReasonEnum)i)
                    {
                        case PolSourceInactiveReasonEnum.Error:
                        case PolSourceInactiveReasonEnum.Abandoned:
                        case PolSourceInactiveReasonEnum.Closed:
                        case PolSourceInactiveReasonEnum.Removed:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PolSourceInactiveReason), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_PolSourceIssueRiskOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PolSourceIssueRiskOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(PolSourceIssueRiskEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.PolSourceIssueRiskOK((PolSourceIssueRiskEnum)i);

                    switch ((PolSourceIssueRiskEnum)i)
                    {
                        case PolSourceIssueRiskEnum.Error:
                        case PolSourceIssueRiskEnum.LowRisk:
                        case PolSourceIssueRiskEnum.ModerateRisk:
                        case PolSourceIssueRiskEnum.HighRisk:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PolSourceIssueRisk), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_PositionOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PositionOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.Position), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_PreliminaryTreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PreliminaryTreatmentTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PreliminaryTreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_PrimaryTreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.PrimaryTreatmentTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.PrimaryTreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportConditionOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportConditionOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportCondition), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportFieldTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportFieldTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFieldType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportFileTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportFileTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFileType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportFormatingDateOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportFormatingDateOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFormatingDate), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportFormatingNumberOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportFormatingNumberOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportFormatingNumber), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportGenerateObjectsKeywordOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportGenerateObjectsKeywordOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportGenerateObjectsKeyword), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportSortingOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportSortingOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(ReportSortingEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.ReportSortingOK((ReportSortingEnum)i);

                    switch ((ReportSortingEnum)i)
                    {
                        case ReportSortingEnum.Error:
                        case ReportSortingEnum.ReportSortingAscending:
                        case ReportSortingEnum.ReportSortingDescending:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportSorting), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportTreeNodeSubTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportTreeNodeSubTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportTreeNodeSubType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ReportTreeNodeTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ReportTreeNodeTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ReportTreeNodeType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_SameDayNextDayOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SameDayNextDayOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SameDayNextDayEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SameDayNextDayOK((SameDayNextDayEnum)i);

                    switch ((SameDayNextDayEnum)i)
                    {
                        case SameDayNextDayEnum.Error:
                        case SameDayNextDayEnum.SameDay:
                        case SameDayNextDayEnum.NextDay:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SameDayNextDay), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_SampleMatrixOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SampleMatrixOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleMatrix), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_SampleStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SampleStatusOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleStatus), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_SampleTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SampleTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SampleType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_SamplingPlanTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SamplingPlanTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(SamplingPlanTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.SamplingPlanTypeOK((SamplingPlanTypeEnum)i);

                    switch ((SamplingPlanTypeEnum)i)
                    {
                        case SamplingPlanTypeEnum.Error:
                        case SamplingPlanTypeEnum.Subsector:
                        case SamplingPlanTypeEnum.Municipality:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SamplingPlanType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_ScenarioStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.ScenarioStatusOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.ScenarioStatus), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_SearchTagOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SearchTagOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SearchTag), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_SecondaryTreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SecondaryTreatmentTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SecondaryTreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_SpecialTableTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.SpecialTableTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.SpecialTableType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_StorageDataTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.StorageDataTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(StorageDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.StorageDataTypeOK((StorageDataTypeEnum)i);

                    switch ((StorageDataTypeEnum)i)
                    {
                        case StorageDataTypeEnum.Error:
                        case StorageDataTypeEnum.Archived:
                        case StorageDataTypeEnum.Forcasted:
                        case StorageDataTypeEnum.Observed:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.StorageDataType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_StreetTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.StreetTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.StreetType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_TelTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TelTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TelType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_TertiaryTreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TertiaryTreatmentTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TertiaryTreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_TideDataTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TideDataTypeOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TideDataTypeEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TideDataTypeOK((TideDataTypeEnum)i);

                    switch ((TideDataTypeEnum)i)
                    {
                        case TideDataTypeEnum.Error:
                        case TideDataTypeEnum.Min15:
                        case TideDataTypeEnum.Min60:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TideDataType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_TideTextOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TideTextOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TideText), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_TranslationStatusOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TranslationStatusOK(null);
                Assert.AreEqual("", retStr);

                for (int i = 0, count = Enum.GetNames(typeof(TranslationStatusEnum)).Length; i < count; i++)
                {
                    retStr = baseEnumService.TranslationStatusOK((TranslationStatusEnum)i);

                    switch ((TranslationStatusEnum)i)
                    {
                        case TranslationStatusEnum.Error:
                        case TranslationStatusEnum.NotTranslated:
                        case TranslationStatusEnum.ElectronicallyTranslated:
                        case TranslationStatusEnum.Translated:
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TranslationStatus), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_TreatmentTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TreatmentTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TreatmentType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_TVAuthOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TVAuthOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TVAuth), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_TVTypeOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.TVTypeOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.TVType), retStr);
                            break;
                    }
                }
            }
        }
        [TestMethod]
        public void BaseEnumService_WebTideDataSetOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(culture);

                string retStr = baseEnumService.WebTideDataSetOK(null);
                Assert.AreEqual("", retStr);

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
                            Assert.AreEqual("", retStr);
                            break;
                        default:
                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes.WebTideDataSet), retStr);
                            break;
                    }
                }
            }
        }

        #endregion Testing Methods Check OK public
    }
}
