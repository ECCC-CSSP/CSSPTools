/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularModelsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { StorageDataTypeEnum } from '../../enums/generated/StorageDataTypeEnum';

export class HydrometricDataValue extends LastUpdate {
    DateTime_Local: Date;
    Discharge_m3_s?: number;
    DischargeEntered_m3_s?: number;
    HasBeenRead: boolean;
    HourlyValues: string;
    HydrometricDataValueID: number;
    HydrometricSiteID: number;
    Keep: boolean;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    Level_m?: number;
    StorageDataType: StorageDataTypeEnum;
}
