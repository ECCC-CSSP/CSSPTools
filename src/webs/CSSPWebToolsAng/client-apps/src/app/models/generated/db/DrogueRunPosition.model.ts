/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net6.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';

export class DrogueRunPosition extends LastUpdate {
    CalculatedDirection_deg: number;
    CalculatedSpeed_m_s: number;
    DBCommand: DBCommandEnum;
    DrogueRunID: number;
    DrogueRunPositionID: number;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    Ordinal: number;
    StepDateTime_Local: Date;
    StepLat: number;
    StepLng: number;
}
