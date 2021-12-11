/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net6.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { StorageDataTypeEnum } from 'src/app/enums/generated/StorageDataTypeEnum';
import { TideDataTypeEnum } from 'src/app/enums/generated/TideDataTypeEnum';
import { TideTextEnum } from 'src/app/enums/generated/TideTextEnum';

export class TideDataValue extends LastUpdate {
    DateTime_Local: Date;
    DBCommand: DBCommandEnum;
    Depth_m: number;
    Keep: boolean;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    StorageDataType: StorageDataTypeEnum;
    TideDataType: TideDataTypeEnum;
    TideDataValueID: number;
    TideEnd?: TideTextEnum;
    TideSiteTVItemID: number;
    TideStart?: TideTextEnum;
    UVelocity_m_s: number;
    VVelocity_m_s: number;
}
