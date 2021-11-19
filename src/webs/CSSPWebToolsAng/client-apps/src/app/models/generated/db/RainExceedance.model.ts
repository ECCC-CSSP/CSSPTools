/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';

export class RainExceedance extends LastUpdate {
    DBCommand: DBCommandEnum;
    EndDay: number;
    EndMonth: number;
    IsActive: boolean;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    OnlyStaffEmailDistributionListID?: number;
    RainExceedanceID: number;
    RainExceedanceTVItemID: number;
    RainMaximum_mm: number;
    StakeholdersEmailDistributionListID?: number;
    StartDay: number;
    StartMonth: number;
}
