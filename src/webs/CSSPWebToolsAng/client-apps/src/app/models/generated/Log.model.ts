/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularModelsGenerated\bin\Debug\netcoreapp3.1\AngularModelsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { LogCommandEnum } from '../../enums/generated/LogCommandEnum';

export class Log extends LastUpdate {
    ID: number;
    Information: string;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    LogCommand: LogCommandEnum;
    LogID: number;
    TableName: string;
}