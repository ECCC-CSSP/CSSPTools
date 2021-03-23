/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { ContactTitleEnum } from 'src/app/enums/generated/ContactTitleEnum';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';

export class Contact extends LastUpdate {
    AccessFailedCount?: number;
    CellNumber: string;
    CellNumberConfirmed?: boolean;
    ContactID: number;
    ContactTitle?: ContactTitleEnum;
    ContactTVItemID: number;
    DBCommand: DBCommandEnum;
    Disabled: boolean;
    EmailValidated: boolean;
    FirstName: string;
    GoogleMapKeyHash: string;
    HasInternetConnection?: boolean;
    Id: string;
    Initial: string;
    IsAdmin: boolean;
    IsLoggedIn?: boolean;
    IsNew: boolean;
    LastName: string;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    LoginEmail: string;
    PasswordHash: string;
    SamplingPlanner_ProvincesTVItemID: string;
    Token: string;
    WebName: string;
}
