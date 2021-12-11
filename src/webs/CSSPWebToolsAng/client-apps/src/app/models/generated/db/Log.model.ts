/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net6.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { LogCommandEnum } from 'src/app/enums/generated/LogCommandEnum';

export class Log extends LastUpdate {
    DBCommand: DBCommandEnum;
    ID: number;
    Information: string;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    LogCommand: LogCommandEnum;
    LogID: number;
    TableName: string;
}
