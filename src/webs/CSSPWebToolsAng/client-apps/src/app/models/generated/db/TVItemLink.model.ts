/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

export class TVItemLink extends LastUpdate {
    DBCommand: DBCommandEnum;
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
