/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularModelsGenerated\bin\Debug\netcoreapp3.1\AngularModelsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { TVTypeEnum } from '../../enums/generated/TVTypeEnum';

export class TVItem extends LastUpdate {
    IsActive: boolean;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    ParentID?: number;
    TVItemID: number;
    TVLevel: number;
    TVPath: string;
    TVType: TVTypeEnum;
}