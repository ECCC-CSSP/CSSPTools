/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularInterfacesGenerated\bin\Debug\netcoreapp3.1\AngularInterfacesGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.interface';
import { TVTypeEnum } from '../../enums/generated/TVTypeEnum';

export interface TVItemLink extends LastUpdate {
    EndDateTime_Local?: Date;
    FromTVItemID: number;
    FromTVType: TVTypeEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    Ordinal: number;
    ParentTVItemLinkID?: number;
    StartDateTime_Local?: Date;
    ToTVItemID: number;
    ToTVType: TVTypeEnum;
    TVItemLinkID: number;
    TVLevel: number;
    TVPath: string;
}
