/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum AppTaskCommandEnum {
    GenerateWebTide = 1,
    MikeScenarioAskToRun = 2,
    MikeScenarioImport = 3,
    MikeScenarioOtherFileImport = 4,
    MikeScenarioRunning = 5,
    MikeScenarioToCancel = 6,
    MikeScenarioWaitingToRun = 7,
    SetupWebTide = 8,
    UpdateClimateSiteInformation = 9,
    UpdateClimateSiteDailyAndHourlyFromStartDateToEndDate = 10,
    UpdateClimateSiteDailyAndHourlyForSubsectorFromStartDateToEndDate = 11,
    CreateFCForm = 12,
    CreateSamplingPlanSamplingPlanTextFile = 13,
    CreateDocumentFromTemplate = 14,
    GetClimateSitesDataForRunsOfYear = 15,
    CreateWebTideDataWLAtFirstNode = 16,
    ExportEmailDistributionLists = 17,
    ExportAnalysisToExcel = 18,
    CreateDocumentFromParameters = 19,
    CreateDocxPDF = 20,
    CreateXlsxPDF = 21,
    OpenDataCSVOfMWQMSites = 22,
    OpenDataKMZOfMWQMSites = 23,
    OpenDataXlsxOfMWQMSitesAndSamples = 24,
    OpenDataCSVOfMWQMSamples = 25,
    GetAllPrecipitationForYear = 26,
    FillRunPrecipByClimateSitePriorityForYear = 27,
    FindMissingPrecipForProvince = 28,
    ExportToArcGIS = 29,
    GenerateClassificationForCSSPWebToolsVisualization = 30,
    GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization = 31,
    OpenDataCSVNationalOfMWQMSites = 32,
    OpenDataCSVNationalOfMWQMSamples = 33,
    ProvinceToolsCreateClassificationInputsKML = 34,
    ProvinceToolsCreateGroupingInputsKML = 35,
    ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML = 36,
    UpdateHydrometricSiteInformation = 37,
    UpdateHydrometricSiteDailyAndHourlyFromStartDateToEndDate = 38,
    UpdateHydrometricSiteDailyAndHourlyForSubsectorFromStartDateToEndDate = 39,
    GetHydrometricSitesDataForRunsOfYear = 40,
    GetAllDischargesForYear = 41,
    FillRunDischargesByHydrometricSitePriorityForYear = 42,
    FindMissingDischargesForProvince = 43,
    LoadHydrometricDataValue = 44,
    GenerateKMLFileClassificationForCSSPWebToolsVisualization = 45,
    ProvinceToolsGenerateStats = 46,
    MikeScenarioPrepareResults = 47,
    ClimateSiteLoadCoCoRaHSData = 48,
}

export function GetAppTaskCommandEnum(): typeof AppTaskCommandEnum
{
  return AppTaskCommandEnum;
}

export function AppTaskCommandEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Generate Web Tide (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'MIKE Scenario Ask To Run (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'MIKE Scenario Import (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'MIKEScenario Other File Import (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'MIKE Scenario Running (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'MIKE Scenario To Cancel (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'MIKE Scenario Waiting To Run (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Setup Web Tide (fr)' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Update Climate Site Informatiion (fr)' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Update Climate Site Daily And Hourly From Start Date To End Date (fr)' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Update Climate Site Daily And Hourly For Subsector From Start Date To End Date (fr)' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Fecal Coliform Form (fr)' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'Create MWQM Plan Sampling Plan Text file (fr)' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'Create file from template (fr)' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'Get climate sites data for runs of year (fr)' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'Creation de données WebTide (niveau d\'eau) au premier noeud' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'Exporter liste de distribution' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'Exporter l\'analyse en format Excel' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'Créer document à partir de paramètres' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'Create Docx PDF' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'Create Xlsx PDF' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'Open Data CSV of MWQM Sites (fr)' });
        enumTextOrderedList.push({ EnumID: 23, EnumText: 'Open Data KMZ of MWQM Sites (fr)' });
        enumTextOrderedList.push({ EnumID: 24, EnumText: 'Open Data Xlsx Of MWQM Sites And Samples (fr)' });
        enumTextOrderedList.push({ EnumID: 25, EnumText: 'Open Data CSV of MWQM Samples (fr)' });
        enumTextOrderedList.push({ EnumID: 26, EnumText: 'Get all precipitation for year (fr)' });
        enumTextOrderedList.push({ EnumID: 27, EnumText: 'Fill run precip by climate site priority for year (fr)' });
        enumTextOrderedList.push({ EnumID: 28, EnumText: 'Find missing precip for province (fr)' });
        enumTextOrderedList.push({ EnumID: 29, EnumText: 'Export to Arc GIS (fr)' });
        enumTextOrderedList.push({ EnumID: 30, EnumText: 'Generate classification for CSSPWebTools visualization (fr)' });
        enumTextOrderedList.push({ EnumID: 31, EnumText: 'Generate links between MWQM Sites and Pollution Source Sites for CSSPWebTools visualization (fr)' });
        enumTextOrderedList.push({ EnumID: 32, EnumText: 'Open Data CSV national of MWQM Sites (fr)' });
        enumTextOrderedList.push({ EnumID: 33, EnumText: 'Open Data CSV national of MWQM Samples (fr)' });
        enumTextOrderedList.push({ EnumID: 34, EnumText: 'Province tools create classification inputs KML (fr)' });
        enumTextOrderedList.push({ EnumID: 35, EnumText: 'Province tools create grouping inputs KML (fr)' });
        enumTextOrderedList.push({ EnumID: 36, EnumText: 'Province tools create MWQM Sites and Pollution Source Sites KML' });
        enumTextOrderedList.push({ EnumID: 37, EnumText: 'Update Hydrometric Site Information (fr)' });
        enumTextOrderedList.push({ EnumID: 38, EnumText: 'Update Hydrometric Site Daily And Hourly From Start Date To End Date (fr)' });
        enumTextOrderedList.push({ EnumID: 39, EnumText: 'Update Hydrometric Site Daily And Hourly For Subsector From Start Date To End Date (fr)' });
        enumTextOrderedList.push({ EnumID: 40, EnumText: 'Get Hydrometric Sites Data For Runs Of Year (fr)' });
        enumTextOrderedList.push({ EnumID: 41, EnumText: 'Get All Discharges For Year (fr)' });
        enumTextOrderedList.push({ EnumID: 42, EnumText: 'Fill Run Discharges By Hydrometric Site Priority For Year (fr)' });
        enumTextOrderedList.push({ EnumID: 43, EnumText: 'Find Missing Discharges For Province (fr)' });
        enumTextOrderedList.push({ EnumID: 44, EnumText: 'Load hydrometric data value (fr)' });
        enumTextOrderedList.push({ EnumID: 45, EnumText: 'Generate KML file classification for CSSPWebTools visualization (fr)' });
        enumTextOrderedList.push({ EnumID: 46, EnumText: 'Province Tools Generate Stats (fr)' });
        enumTextOrderedList.push({ EnumID: 47, EnumText: 'MIKE Scenario Prepare Results (fr)' });
        enumTextOrderedList.push({ EnumID: 48, EnumText: 'Climate Site Load CoCoRaHS Data (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Generate Web Tide' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'MIKE Scenario Ask To Run' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'MIKE Scenario Import' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'MIKEScenario Other File Import' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'MIKE Scenario Running' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'MIKE Scenario To Cancel' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'MIKE Scenario Waiting To Run' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Setup Web Tide' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Update Climate Site Information' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Update Climate Site Daily And Hourly From Start Date To End Date' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Update Climate Site Daily And Hourly For Subsector From Start Date To End Date' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Fecal Coliform Form' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'Create MWQM Plan Sampling Plan Text file' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'Create file from template' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'Get climate sites data for runs of year' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'Create WebTide data (water level) at first node' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'Export email distribution lists' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'Export analysis to Excel' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'Create document from parameters' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'Create Docx PDF' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'Create Xlsx PDF' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'Open Data CSV of MWQM Sites' });
        enumTextOrderedList.push({ EnumID: 23, EnumText: 'Open Data KMZ of MWQM Sites' });
        enumTextOrderedList.push({ EnumID: 24, EnumText: 'Open Data Xlsx Of MWQM Sites And Samples' });
        enumTextOrderedList.push({ EnumID: 25, EnumText: 'Open Data CSV of MWQM Samples' });
        enumTextOrderedList.push({ EnumID: 26, EnumText: 'Get all precipitation for year' });
        enumTextOrderedList.push({ EnumID: 27, EnumText: 'Fill run precip by climate site priority for year' });
        enumTextOrderedList.push({ EnumID: 28, EnumText: 'Find missing precip for province' });
        enumTextOrderedList.push({ EnumID: 29, EnumText: 'Export to Arc GIS' });
        enumTextOrderedList.push({ EnumID: 30, EnumText: 'Generate classification for CSSPWebTools visualization' });
        enumTextOrderedList.push({ EnumID: 31, EnumText: 'Generate links between MWQM Sites and Pollution Source Sites for CSSPWebTools visualization' });
        enumTextOrderedList.push({ EnumID: 32, EnumText: 'Open Data CSV national of MWQM Sites' });
        enumTextOrderedList.push({ EnumID: 33, EnumText: 'Open Data CSV national of MWQM Samples' });
        enumTextOrderedList.push({ EnumID: 34, EnumText: 'Province tools create classification inputs KML' });
        enumTextOrderedList.push({ EnumID: 35, EnumText: 'Province tools create grouping inputs KML' });
        enumTextOrderedList.push({ EnumID: 36, EnumText: 'Province tools create MWQM Sites and Pollution Source Sites KML' });
        enumTextOrderedList.push({ EnumID: 37, EnumText: 'Update Hydrometric Site Information' });
        enumTextOrderedList.push({ EnumID: 38, EnumText: 'Update Hydrometric Site Daily And Hourly From Start Date To End Date' });
        enumTextOrderedList.push({ EnumID: 39, EnumText: 'Update Hydrometric Site Daily And Hourly For Subsector From Start Date To End Date' });
        enumTextOrderedList.push({ EnumID: 40, EnumText: 'Get Hydrometric Sites Data For Runs Of Year' });
        enumTextOrderedList.push({ EnumID: 41, EnumText: 'Get All Discharges For Year' });
        enumTextOrderedList.push({ EnumID: 42, EnumText: 'Fill Run Discharges By Hydrometric Site Priority For Year' });
        enumTextOrderedList.push({ EnumID: 43, EnumText: 'Find Missing Discharges For Province' });
        enumTextOrderedList.push({ EnumID: 44, EnumText: 'Load hydrometric data value' });
        enumTextOrderedList.push({ EnumID: 45, EnumText: 'Generate KML file classification for CSSPWebTools visualization' });
        enumTextOrderedList.push({ EnumID: 46, EnumText: 'Province Tools Generate Stats' });
        enumTextOrderedList.push({ EnumID: 47, EnumText: 'MIKE Scenario Prepare Results' });
        enumTextOrderedList.push({ EnumID: 48, EnumText: 'Climate Site Load CoCoRaHS Data' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AppTaskCommandEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    AppTaskCommandEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
