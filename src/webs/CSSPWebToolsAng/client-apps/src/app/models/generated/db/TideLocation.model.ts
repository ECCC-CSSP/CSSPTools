/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';

export class TideLocation extends LastUpdate {
    DBCommand: DBCommandEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    Lat: number;
    Lng: number;
    Name: string;
    Prov: string;
    sid: number;
    TideLocationID: number;
    Zone: number;
}
