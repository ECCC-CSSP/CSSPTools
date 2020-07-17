/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularModelsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { DateTimeOffset } from './DateTimeOffset.model';

export class ApplicationUser extends LastUpdate {
    AccessFailedCount: number;
    ConcurrencyStamp: string;
    Email: string;
    EmailConfirmed: boolean;
    Id: string;
    LockoutEnabled: boolean;
    LockoutEnd?: DateTimeOffset;
    NormalizedEmail: string;
    NormalizedUserName: string;
    PasswordHash: string;
    PhoneNumber: string;
    PhoneNumberConfirmed: boolean;
    SecurityStamp: string;
    TwoFactorEnabled: boolean;
    UserName: string;
}
