/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ReportTreeNodeTypeEnum {
    ReportRootType = 1,
    ReportCountryType = 2,
    ReportProvinceType = 3,
    ReportAreaType = 4,
    ReportSectorType = 5,
    ReportSubsectorType = 6,
    ReportMWQMSiteType = 7,
    ReportMWQMRunType = 8,
    ReportPolSourceSiteType = 9,
    ReportMunicipalityType = 10,
    ReportRootFileType = 11,
    ReportInfrastructureType = 12,
    ReportBoxModelType = 13,
    ReportVisualPlumesScenarioType = 14,
    ReportMikeScenarioType = 15,
    ReportMikeSourceType = 16,
    ReportMWQMSiteSampleType = 17,
    ReportPolSourceSiteObsType = 18,
    ReportPolSourceSiteObsIssueType = 19,
    ReportMikeScenarioGeneralParameterType = 20,
    ReportMunicipalityContactType = 21,
    ReportConditionType = 22,
    ReportStatisticType = 23,
    ReportFieldsType = 24,
    ReportFieldType = 25,
    ReportPolSourceSiteAddressType = 26,
    ReportMunicipalityContactTelType = 27,
    ReportMunicipalityContactEmailType = 28,
    ReportBoxModelResultType = 29,
    ReportClimateSiteType = 30,
    ReportClimateSiteDataType = 31,
    ReportHydrometricSiteType = 32,
    ReportHydrometricSiteDataType = 33,
    ReportHydrometricSiteRatingCurveType = 34,
    ReportHydrometricSiteRatingCurveValueType = 35,
    ReportInfrastructureAddressType = 36,
    ReportSubsectorLabSheetType = 37,
    ReportSubsectorLabSheetDetailType = 38,
    ReportSubsectorLabSheetTubeMPNDetailType = 39,
    ReportMWQMRunSampleType = 40,
    ReportCountryFileType = 41,
    ReportProvinceFileType = 42,
    ReportAreaFileType = 43,
    ReportSectorFileType = 44,
    ReportSubsectorFileType = 45,
    ReportMWQMSiteFileType = 46,
    ReportMWQMRunFileType = 47,
    ReportPolSourceSiteFileType = 48,
    ReportMunicipalityFileType = 49,
    ReportInfrastructureFileType = 50,
    ReportMikeScenarioFileType = 51,
    ReportMikeSourceStartEndType = 52,
    ReportMWQMRunLabSheetType = 53,
    ReportMWQMRunLabSheetDetailType = 54,
    ReportMWQMRunLabSheetTubeMPNDetailType = 55,
    ReportSamplingPlanLabSheetType = 56,
    ReportSamplingPlanLabSheetDetailType = 57,
    ReportSamplingPlanLabSheetTubeMPNDetailType = 58,
    ReportSamplingPlanType = 59,
    ReportSamplingPlanSubsectorType = 60,
    ReportSamplingPlanSubsectorSiteType = 61,
    ReportMikeBoundaryConditionType = 62,
    ReportVisualPlumesScenarioAmbientType = 63,
    ReportVisualPlumesScenarioResultType = 64,
    ReportMPNLookupType = 65,
    ReportMWQMSiteStartAndEndType = 66,
    ReportSubsectorTideSiteType = 67,
    ReportSubsectorTideSiteDataType = 68,
    ReportOrderType = 69,
    ReportFormatType = 70,
    ReportMunicipalityContactAddressType = 71,
    ReportSubsectorClimateSiteType = 72,
    ReportSubsectorHydrometricSiteType = 73,
    ReportSubsectorHydrometricSiteDataType = 74,
    ReportSubsectorHydrometricSiteRatingCurveType = 75,
    ReportSubsectorClimateSiteDataType = 76,
    ReportSubsectorHydrometricSiteRatingCurveValueType = 77,
    ReportSubsectorSpecialTableType = 78,
    ReportMikeScenarioSpecialResultKMLType = 79,
}

export function GetReportTreeNodeTypeEnum(): typeof ReportTreeNodeTypeEnum
{
  return ReportTreeNodeTypeEnum;
}

export function ReportTreeNodeTypeEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'ReportRootType' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'ReportCountryType' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'ReportProvinceType' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'ReportAreaType' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'ReportSectorType' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'ReportSubsectorType' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'ReportMWQMSiteType' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'ReportMWQMRunType' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'ReportPolSourceSiteType' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'ReportMunicipalityType' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'ReportRootFileType' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'ReportInfrastructureType' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'ReportBoxModelType' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'ReportVisualPlumesScenarioType' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'ReportMikeScenarioType' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'ReportMikeSourceType' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'ReportMWQMSiteSampleType' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'ReportPolSourceSiteObsType' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'ReportPolSourceSiteObsIssueType' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'ReportMikeScenarioGeneralParameterType' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'ReportMunicipalityContactType' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'ReportConditionType' });
        enumTextOrderedList.push({ EnumID: 23, EnumText: 'ReportStatisticType' });
        enumTextOrderedList.push({ EnumID: 24, EnumText: 'ReportFieldsType' });
        enumTextOrderedList.push({ EnumID: 25, EnumText: 'ReportFieldType' });
        enumTextOrderedList.push({ EnumID: 26, EnumText: 'ReportPolSourceSiteAddressType' });
        enumTextOrderedList.push({ EnumID: 27, EnumText: 'ReportMunicipalityContactTelType' });
        enumTextOrderedList.push({ EnumID: 28, EnumText: 'ReportMunicipalityContactEmailType' });
        enumTextOrderedList.push({ EnumID: 29, EnumText: 'ReportBoxModelResultType' });
        enumTextOrderedList.push({ EnumID: 30, EnumText: 'ReportClimateSiteType' });
        enumTextOrderedList.push({ EnumID: 31, EnumText: 'ReportClimateSiteDataType' });
        enumTextOrderedList.push({ EnumID: 32, EnumText: 'ReportHydrometricSiteType' });
        enumTextOrderedList.push({ EnumID: 33, EnumText: 'ReportHydrometricSiteDataType' });
        enumTextOrderedList.push({ EnumID: 34, EnumText: 'ReportHydrometricSiteRatingCurveType' });
        enumTextOrderedList.push({ EnumID: 35, EnumText: 'ReportHydrometricSiteRatingCurveValueType' });
        enumTextOrderedList.push({ EnumID: 36, EnumText: 'ReportInfrastructureAddressType' });
        enumTextOrderedList.push({ EnumID: 37, EnumText: 'ReportSubsectorLabSheetType' });
        enumTextOrderedList.push({ EnumID: 38, EnumText: 'ReportSubsectorLabSheetDetailType' });
        enumTextOrderedList.push({ EnumID: 39, EnumText: 'ReportSubsectorLabSheetTubeMPNDetailType' });
        enumTextOrderedList.push({ EnumID: 40, EnumText: 'ReportMWQMRunSampleType' });
        enumTextOrderedList.push({ EnumID: 41, EnumText: 'ReportCountryFileType' });
        enumTextOrderedList.push({ EnumID: 42, EnumText: 'ReportProvinceFileType' });
        enumTextOrderedList.push({ EnumID: 43, EnumText: 'ReportAreaFileType' });
        enumTextOrderedList.push({ EnumID: 44, EnumText: 'ReportSectorFileType' });
        enumTextOrderedList.push({ EnumID: 45, EnumText: 'ReportSubsectorFileType' });
        enumTextOrderedList.push({ EnumID: 46, EnumText: 'ReportMWQMSiteFileType' });
        enumTextOrderedList.push({ EnumID: 47, EnumText: 'ReportMWQMRunFileType' });
        enumTextOrderedList.push({ EnumID: 48, EnumText: 'ReportPolSourceSiteFileType' });
        enumTextOrderedList.push({ EnumID: 49, EnumText: 'ReportMunicipalityFileType' });
        enumTextOrderedList.push({ EnumID: 50, EnumText: 'ReportInfrastructureFileType' });
        enumTextOrderedList.push({ EnumID: 51, EnumText: 'ReportMikeScenarioFileType' });
        enumTextOrderedList.push({ EnumID: 52, EnumText: 'ReportMikeSourceStartEndType' });
        enumTextOrderedList.push({ EnumID: 53, EnumText: 'ReportMWQMRunLabSheetType' });
        enumTextOrderedList.push({ EnumID: 54, EnumText: 'ReportMWQMRunLabSheetDetailType' });
        enumTextOrderedList.push({ EnumID: 55, EnumText: 'ReportMWQMRunLabSheetTubeMPNDetailType' });
        enumTextOrderedList.push({ EnumID: 56, EnumText: 'ReportSamplingPlanLabSheetType' });
        enumTextOrderedList.push({ EnumID: 57, EnumText: 'ReportSamplingPlanLabSheetDetailType' });
        enumTextOrderedList.push({ EnumID: 58, EnumText: 'ReportSamplingPlanLabSheetTubeMPNDetailType' });
        enumTextOrderedList.push({ EnumID: 59, EnumText: 'ReportSamplingPlanType' });
        enumTextOrderedList.push({ EnumID: 60, EnumText: 'ReportSamplingPlanSubsectorType' });
        enumTextOrderedList.push({ EnumID: 61, EnumText: 'ReportSamplingPlanSubsectorSiteType' });
        enumTextOrderedList.push({ EnumID: 62, EnumText: 'ReportMikeBoundaryConditionType' });
        enumTextOrderedList.push({ EnumID: 63, EnumText: 'ReportVisualPlumesScenarioAmbientType' });
        enumTextOrderedList.push({ EnumID: 64, EnumText: 'ReportVisualPlumesScenarioResultType' });
        enumTextOrderedList.push({ EnumID: 65, EnumText: 'ReportMPNLookupType' });
        enumTextOrderedList.push({ EnumID: 66, EnumText: 'ReportMWQMSiteStartAndEndType' });
        enumTextOrderedList.push({ EnumID: 67, EnumText: 'SubsectorTideSiteType' });
        enumTextOrderedList.push({ EnumID: 68, EnumText: 'SubsectorTideSiteDataType' });
        enumTextOrderedList.push({ EnumID: 69, EnumText: 'ReportOrderType' });
        enumTextOrderedList.push({ EnumID: 70, EnumText: 'ReportFormatType' });
        enumTextOrderedList.push({ EnumID: 71, EnumText: 'ReportMunicipalityContactAddressType' });
        enumTextOrderedList.push({ EnumID: 72, EnumText: 'SubsectorClimateSiteType' });
        enumTextOrderedList.push({ EnumID: 73, EnumText: 'SubsectorHydrometricSiteType' });
        enumTextOrderedList.push({ EnumID: 74, EnumText: 'SubsectorHydrometricSiteDataType' });
        enumTextOrderedList.push({ EnumID: 75, EnumText: 'SubsectorHydrometricSiteRatingCurveType' });
        enumTextOrderedList.push({ EnumID: 76, EnumText: 'SubsectorClimateSiteDataType' });
        enumTextOrderedList.push({ EnumID: 77, EnumText: 'SubsectorHydrometricSiteRatingCurveValueType' });
        enumTextOrderedList.push({ EnumID: 78, EnumText: 'ReportSubsectorSpecialTableType' });
        enumTextOrderedList.push({ EnumID: 79, EnumText: 'Type de résultat spécial du scénario MIKE raport (KML) ' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'ReportRootType' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'ReportCountryType' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'ReportProvinceType' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'ReportAreaType' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'ReportSectorType' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'ReportSubsectorType' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'ReportMWQMSiteType' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'ReportMWQMRunType' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'ReportPolSourceSiteType' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'ReportMunicipalityType' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'ReportRootFileType' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'ReportInfrastructureType' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'ReportBoxModelType' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'ReportVisualPlumesScenarioType' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'ReportMikeScenarioType' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'ReportMikeSourceType' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'ReportMWQMSiteSampleType' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'ReportPolSourceSiteObsType' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'ReportPolSourceSiteObsIssueType' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'ReportMikeScenarioGeneralParameterType' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'ReportMunicipalityContactType' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'ReportConditionType' });
        enumTextOrderedList.push({ EnumID: 23, EnumText: 'ReportStatisticType' });
        enumTextOrderedList.push({ EnumID: 24, EnumText: 'ReportFieldsType' });
        enumTextOrderedList.push({ EnumID: 25, EnumText: 'ReportFieldType' });
        enumTextOrderedList.push({ EnumID: 26, EnumText: 'ReportPolSourceSiteAddressType' });
        enumTextOrderedList.push({ EnumID: 27, EnumText: 'ReportMunicipalityContactTelType' });
        enumTextOrderedList.push({ EnumID: 28, EnumText: 'ReportMunicipalityContactEmailType' });
        enumTextOrderedList.push({ EnumID: 29, EnumText: 'ReportBoxModelResultType' });
        enumTextOrderedList.push({ EnumID: 30, EnumText: 'ReportClimateSiteType' });
        enumTextOrderedList.push({ EnumID: 31, EnumText: 'ReportClimateSiteDataType' });
        enumTextOrderedList.push({ EnumID: 32, EnumText: 'ReportHydrometricSiteType' });
        enumTextOrderedList.push({ EnumID: 33, EnumText: 'ReportHydrometricSiteDataType' });
        enumTextOrderedList.push({ EnumID: 34, EnumText: 'ReportHydrometricSiteRatingCurveType' });
        enumTextOrderedList.push({ EnumID: 35, EnumText: 'ReportHydrometricSiteRatingCurveValueType' });
        enumTextOrderedList.push({ EnumID: 36, EnumText: 'ReportInfrastructureAddressType' });
        enumTextOrderedList.push({ EnumID: 37, EnumText: 'ReportSubsectorLabSheetType' });
        enumTextOrderedList.push({ EnumID: 38, EnumText: 'ReportSubsectorLabSheetDetailType' });
        enumTextOrderedList.push({ EnumID: 39, EnumText: 'ReportSubsectorLabSheetTubeMPNDetailType' });
        enumTextOrderedList.push({ EnumID: 40, EnumText: 'ReportMWQMRunSampleType' });
        enumTextOrderedList.push({ EnumID: 41, EnumText: 'ReportCountryFileType' });
        enumTextOrderedList.push({ EnumID: 42, EnumText: 'ReportProvinceFileType' });
        enumTextOrderedList.push({ EnumID: 43, EnumText: 'ReportAreaFileType' });
        enumTextOrderedList.push({ EnumID: 44, EnumText: 'ReportSectorFileType' });
        enumTextOrderedList.push({ EnumID: 45, EnumText: 'ReportSubsectorFileType' });
        enumTextOrderedList.push({ EnumID: 46, EnumText: 'ReportMWQMSiteFileType' });
        enumTextOrderedList.push({ EnumID: 47, EnumText: 'ReportMWQMRunFileType' });
        enumTextOrderedList.push({ EnumID: 48, EnumText: 'ReportPolSourceSiteFileType' });
        enumTextOrderedList.push({ EnumID: 49, EnumText: 'ReportMunicipalityFileType' });
        enumTextOrderedList.push({ EnumID: 50, EnumText: 'ReportInfrastructureFileType' });
        enumTextOrderedList.push({ EnumID: 51, EnumText: 'ReportMikeScenarioFileType' });
        enumTextOrderedList.push({ EnumID: 52, EnumText: 'ReportMikeSourceStartEndType' });
        enumTextOrderedList.push({ EnumID: 53, EnumText: 'ReportMWQMRunLabSheetType' });
        enumTextOrderedList.push({ EnumID: 54, EnumText: 'ReportMWQMRunLabSheetDetailType' });
        enumTextOrderedList.push({ EnumID: 55, EnumText: 'ReportMWQMRunLabSheetTubeMPNDetailType' });
        enumTextOrderedList.push({ EnumID: 56, EnumText: 'ReportSamplingPlanLabSheetType' });
        enumTextOrderedList.push({ EnumID: 57, EnumText: 'ReportSamplingPlanLabSheetDetailType' });
        enumTextOrderedList.push({ EnumID: 58, EnumText: 'ReportSamplingPlanLabSheetTubeMPNDetailType' });
        enumTextOrderedList.push({ EnumID: 59, EnumText: 'ReportSamplingPlanType' });
        enumTextOrderedList.push({ EnumID: 60, EnumText: 'ReportSamplingPlanSubsectorType' });
        enumTextOrderedList.push({ EnumID: 61, EnumText: 'ReportSamplingPlanSubsectorSiteType' });
        enumTextOrderedList.push({ EnumID: 62, EnumText: 'ReportMikeBoundaryConditionType' });
        enumTextOrderedList.push({ EnumID: 63, EnumText: 'ReportVisualPlumesScenarioAmbientType' });
        enumTextOrderedList.push({ EnumID: 64, EnumText: 'ReportVisualPlumesScenarioResultType' });
        enumTextOrderedList.push({ EnumID: 65, EnumText: 'ReportMPNLookupType' });
        enumTextOrderedList.push({ EnumID: 66, EnumText: 'ReportMWQMSiteStartAndEndType' });
        enumTextOrderedList.push({ EnumID: 67, EnumText: 'SubsectorTideSiteType' });
        enumTextOrderedList.push({ EnumID: 68, EnumText: 'SubsectorTideSiteDataType' });
        enumTextOrderedList.push({ EnumID: 69, EnumText: 'ReportOrderType' });
        enumTextOrderedList.push({ EnumID: 70, EnumText: 'ReportFormatType' });
        enumTextOrderedList.push({ EnumID: 71, EnumText: 'ReportMunicipalityContactAddressType' });
        enumTextOrderedList.push({ EnumID: 72, EnumText: 'SubsectorClimateSiteType' });
        enumTextOrderedList.push({ EnumID: 73, EnumText: 'SubsectorHydrometricSiteType' });
        enumTextOrderedList.push({ EnumID: 74, EnumText: 'SubsectorHydrometricSiteDataType' });
        enumTextOrderedList.push({ EnumID: 75, EnumText: 'SubsectorHydrometricSiteRatingCurveType' });
        enumTextOrderedList.push({ EnumID: 76, EnumText: 'SubsectorClimateSiteDataType' });
        enumTextOrderedList.push({ EnumID: 77, EnumText: 'SubsectorHydrometricSiteRatingCurveValueType' });
        enumTextOrderedList.push({ EnumID: 78, EnumText: 'ReportSubsectorSpecialTableType' });
        enumTextOrderedList.push({ EnumID: 79, EnumText: 'ReportMikeScenarioSpecialResultKMLType' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ReportTreeNodeTypeEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    ReportTreeNodeTypeEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
