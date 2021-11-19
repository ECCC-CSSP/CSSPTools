/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { TVAuthEnum } from 'src/app/enums/generated/TVAuthEnum';
import { TVTypeEnum } from 'src/app/enums/generated/TVTypeEnum';

export class TVTypeUserAuthorization extends LastUpdate {
    ContactTVItemID: number;
    DBCommand: DBCommandEnum;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    TVAuth: TVAuthEnum;
    TVType: TVTypeEnum;
    TVTypeUserAuthorizationID: number;
}
