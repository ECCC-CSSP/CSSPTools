/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularModelsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.model';
import { ChangeTracker } from './ChangeTracker.model';
import { DbContextId } from './DbContextId.model';
import { DatabaseFacade } from './DatabaseFacade.model';
import { IModel } from './IModel.model';
import { DbSet`1 } from './DbSet`1.model';

export class ApplicationDbContext extends LastUpdate {
    ChangeTracker: ChangeTracker;
    ContextId: DbContextId;
    Database: DatabaseFacade;
    Model: IModel;
    RoleClaims: DbSet`1;
    Roles: DbSet`1;
    UserClaims: DbSet`1;
    UserLogins: DbSet`1;
    UserRoles: DbSet`1;
    Users: DbSet`1;
    UserTokens: DbSet`1;
}
