/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ReportFieldTypeEnum {
    NumberWhole = 1,
    NumberWithDecimal = 2,
    DateAndTime = 3,
    Text = 4,
    TrueOrFalse = 5,
    FilePurpose = 6,
    FileType = 7,
    TranslationStatus = 8,
    BoxModelResultType = 9,
    InfrastructureType = 10,
    FacilityType = 11,
    AerationType = 12,
    PreliminaryTreatmentType = 13,
    PrimaryTreatmentType = 14,
    SecondaryTreatmentType = 15,
    TertiaryTreatmentType = 16,
    TreatmentType = 17,
    DisinfectionType = 18,
    CollectionSystemType = 19,
    AlarmSystemType = 20,
    ScenarioStatus = 21,
    StorageDataType = 22,
    Language = 23,
    SampleType = 24,
    BeaufortScale = 25,
    AnalyzeMethod = 26,
    SampleMatrix = 27,
    Laboratory = 28,
    SampleStatus = 29,
    SamplingPlanType = 30,
    LabSheetSampleType = 31,
    LabSheetType = 32,
    LabSheetStatus = 33,
    PolSourceInactiveReason = 34,
    PolSourceObsInfo = 35,
    AddressType = 36,
    StreetType = 37,
    ContactTitle = 38,
    EmailType = 39,
    TelType = 40,
    TideText = 41,
    TideDataType = 42,
    SpecialTableType = 43,
    MWQMSiteLatestClassification = 44,
    PolSourceIssueRisk = 45,
    MikeScenarioSpecialResultKMLType = 46,
}

export function GetReportFieldTypeEnum(): typeof ReportFieldTypeEnum
{
  return ReportFieldTypeEnum;
}

export function ReportFieldTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'NumberWhole' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'NumberWithDecimal' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'DateAndTime' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Text' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'TrueOrFalse' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'FilePurpose' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'FileType' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'TranslationStatus' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'BoxModelResultType' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'InfrastructureType' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'FacilityType' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'AerationType' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'PreliminaryTreatmentType' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'PrimaryTreatmentType' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'SecondaryTreatmentType' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'TertiaryTreatmentType' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'TreatmentType' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'DisinfectionType' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'CollectionSystemType' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'AlarmSystemType' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'ScenarioStatus' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'StorageDataType' });
        enumTextOrderedList.push({ EnumID: 23, EnumText: 'Language' });
        enumTextOrderedList.push({ EnumID: 24, EnumText: 'SampleType' });
        enumTextOrderedList.push({ EnumID: 25, EnumText: 'BeaufortScale' });
        enumTextOrderedList.push({ EnumID: 26, EnumText: 'AnalyzeMethod' });
        enumTextOrderedList.push({ EnumID: 27, EnumText: 'SampleMatrix' });
        enumTextOrderedList.push({ EnumID: 28, EnumText: 'Laboratory' });
        enumTextOrderedList.push({ EnumID: 29, EnumText: 'SampleStatus' });
        enumTextOrderedList.push({ EnumID: 30, EnumText: 'SamplingPlanType' });
        enumTextOrderedList.push({ EnumID: 31, EnumText: 'LabSheetSampleType' });
        enumTextOrderedList.push({ EnumID: 32, EnumText: 'LabSheetType' });
        enumTextOrderedList.push({ EnumID: 33, EnumText: 'LabSheetStatus' });
        enumTextOrderedList.push({ EnumID: 34, EnumText: 'PolSourceInactiveReason' });
        enumTextOrderedList.push({ EnumID: 35, EnumText: 'PolSourceObsInfo' });
        enumTextOrderedList.push({ EnumID: 36, EnumText: 'AddressType' });
        enumTextOrderedList.push({ EnumID: 37, EnumText: 'StreetType' });
        enumTextOrderedList.push({ EnumID: 38, EnumText: 'ContactTitle' });
        enumTextOrderedList.push({ EnumID: 39, EnumText: 'EmailType' });
        enumTextOrderedList.push({ EnumID: 40, EnumText: 'TelType' });
        enumTextOrderedList.push({ EnumID: 41, EnumText: 'TideText' });
        enumTextOrderedList.push({ EnumID: 42, EnumText: 'TideDataType' });
        enumTextOrderedList.push({ EnumID: 43, EnumText: 'SpecialTableType' });
        enumTextOrderedList.push({ EnumID: 44, EnumText: 'MWQMSiteLatestClassification' });
        enumTextOrderedList.push({ EnumID: 45, EnumText: 'PolSourceIssueRisk' });
        enumTextOrderedList.push({ EnumID: 46, EnumText: 'Type de résultat spécial du scénario MIKE (KML)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'NumberWhole' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'NumberWithDecimal' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'DateAndTime' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Text' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'TrueOrFalse' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'FilePurpose' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'FileType' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'TranslationStatus' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'BoxModelResultType' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'InfrastructureType' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'FacilityType' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'AerationType' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'PreliminaryTreatmentType' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'PrimaryTreatmentType' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'SecondaryTreatmentType' });
        enumTextOrderedList.push({ EnumID: 16, EnumText: 'TertiaryTreatmentType' });
        enumTextOrderedList.push({ EnumID: 17, EnumText: 'TreatmentType' });
        enumTextOrderedList.push({ EnumID: 18, EnumText: 'DisinfectionType' });
        enumTextOrderedList.push({ EnumID: 19, EnumText: 'CollectionSystemType' });
        enumTextOrderedList.push({ EnumID: 20, EnumText: 'AlarmSystemType' });
        enumTextOrderedList.push({ EnumID: 21, EnumText: 'ScenarioStatus' });
        enumTextOrderedList.push({ EnumID: 22, EnumText: 'StorageDataType' });
        enumTextOrderedList.push({ EnumID: 23, EnumText: 'Language' });
        enumTextOrderedList.push({ EnumID: 24, EnumText: 'SampleType' });
        enumTextOrderedList.push({ EnumID: 25, EnumText: 'BeaufortScale' });
        enumTextOrderedList.push({ EnumID: 26, EnumText: 'AnalyzeMethod' });
        enumTextOrderedList.push({ EnumID: 27, EnumText: 'SampleMatrix' });
        enumTextOrderedList.push({ EnumID: 28, EnumText: 'Laboratory' });
        enumTextOrderedList.push({ EnumID: 29, EnumText: 'SampleStatus' });
        enumTextOrderedList.push({ EnumID: 30, EnumText: 'SamplingPlanType' });
        enumTextOrderedList.push({ EnumID: 31, EnumText: 'LabSheetSampleType' });
        enumTextOrderedList.push({ EnumID: 32, EnumText: 'LabSheetType' });
        enumTextOrderedList.push({ EnumID: 33, EnumText: 'LabSheetStatus' });
        enumTextOrderedList.push({ EnumID: 34, EnumText: 'PolSourceInactiveReason' });
        enumTextOrderedList.push({ EnumID: 35, EnumText: 'PolSourceObsInfo' });
        enumTextOrderedList.push({ EnumID: 36, EnumText: 'AddressType' });
        enumTextOrderedList.push({ EnumID: 37, EnumText: 'StreetType' });
        enumTextOrderedList.push({ EnumID: 38, EnumText: 'ContactTitle' });
        enumTextOrderedList.push({ EnumID: 39, EnumText: 'EmailType' });
        enumTextOrderedList.push({ EnumID: 40, EnumText: 'TelType' });
        enumTextOrderedList.push({ EnumID: 41, EnumText: 'TideText' });
        enumTextOrderedList.push({ EnumID: 42, EnumText: 'TideDataType' });
        enumTextOrderedList.push({ EnumID: 43, EnumText: 'SpecialTableType' });
        enumTextOrderedList.push({ EnumID: 44, EnumText: 'MWQMSiteLatestClassification' });
        enumTextOrderedList.push({ EnumID: 45, EnumText: 'PolSourceIssueRisk' });
        enumTextOrderedList.push({ EnumID: 46, EnumText: 'MikeScenarioSpecialResultKMLType' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ReportFieldTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let ReportFieldTypeEnumText: string;
    ReportFieldTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            ReportFieldTypeEnumText = e.EnumText;
            return false;
        }
    });

    return ReportFieldTypeEnumText;
}
