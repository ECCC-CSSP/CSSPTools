/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';

export class HydrometricSite extends LastUpdate {
    Description: string;
    DrainageArea_km2?: number;
    Elevation_m?: number;
    EndDate_Local?: Date;
    FedSiteNumber: string;
    HasDischarge?: boolean;
    HasLevel?: boolean;
    HasRatingCurve?: boolean;
    HydrometricSiteID: number;
    HydrometricSiteName: string;
    HydrometricSiteTVItemID: number;
    IsActive?: boolean;
    IsNatural?: boolean;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    Province: string;
    QuebecSiteNumber: string;
    RealTime?: boolean;
    RHBN?: boolean;
    Sediment?: boolean;
    StartDate_Local?: Date;
    TimeOffset_hour?: number;
}