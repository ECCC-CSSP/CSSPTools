/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularModelsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { AnalyzeMethodEnum } from '../../enums/generated/AnalyzeMethodEnum';
import { LaboratoryEnum } from '../../enums/generated/LaboratoryEnum';
import { LabSheetTypeEnum } from '../../enums/generated/LabSheetTypeEnum';
import { SampleMatrixEnum } from '../../enums/generated/SampleMatrixEnum';
import { SampleTypeEnum } from '../../enums/generated/SampleTypeEnum';
import { SamplingPlanTypeEnum } from '../../enums/generated/SamplingPlanTypeEnum';

export class SamplingPlan extends LastUpdate {
    AccessCode: string;
    AnalyzeMethodDefault?: AnalyzeMethodEnum;
    ApprovalCode: string;
    BackupDirectory: string;
    CreatorTVItemID: number;
    DailyDuplicatePrecisionCriteria: number;
    ForGroupName: string;
    IncludeLaboratoryQAQC: boolean;
    IntertechDuplicatePrecisionCriteria: number;
    IsActive: boolean;
    LaboratoryDefault?: LaboratoryEnum;
    LabSheetType: LabSheetTypeEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    ProvinceTVItemID: number;
    SampleMatrixDefault?: SampleMatrixEnum;
    SampleType: SampleTypeEnum;
    SamplingPlanFileTVItemID?: number;
    SamplingPlanID: number;
    SamplingPlanName: string;
    SamplingPlanType: SamplingPlanTypeEnum;
    Year: number;
}
