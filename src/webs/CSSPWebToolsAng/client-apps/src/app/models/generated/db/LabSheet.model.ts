/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { LabSheetStatusEnum } from 'src/app/enums/generated/LabSheetStatusEnum';
import { LabSheetTypeEnum } from 'src/app/enums/generated/LabSheetTypeEnum';
import { SampleTypeEnum } from 'src/app/enums/generated/SampleTypeEnum';
import { SamplingPlanTypeEnum } from 'src/app/enums/generated/SamplingPlanTypeEnum';

export class LabSheet extends LastUpdate {
    AcceptedOrRejectedByContactTVItemID?: number;
    AcceptedOrRejectedDateTime?: Date;
    Day: number;
    DBCommand: DBCommandEnum;
    FileContent: string;
    FileLastModifiedDate_Local: Date;
    FileName: string;
    LabSheetID: number;
    LabSheetStatus: LabSheetStatusEnum;
    LabSheetType: LabSheetTypeEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    Month: number;
    MWQMRunTVItemID?: number;
    OtherServerLabSheetID: number;
    RejectReason: string;
    RunNumber: number;
    SampleType: SampleTypeEnum;
    SamplingPlanID: number;
    SamplingPlanName: string;
    SamplingPlanType: SamplingPlanTypeEnum;
    SubsectorTVItemID: number;
    Year: number;
}
