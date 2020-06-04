/*
 * Auto generated from C:\CSSPTools\src\codegen\AngularInterfacesGenerated\bin\Debug\netcoreapp3.1\AngularInterfacesGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from './LastUpdate.interface';
import { TVTypeEnum } from '../../enums/generated/TVTypeEnum';

export interface UseOfSite extends LastUpdate {
    EndYear?: number;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    Ordinal: number;
    Param1?: number;
    Param2?: number;
    Param3?: number;
    Param4?: number;
    SiteTVItemID: number;
    StartYear: number;
    SubsectorTVItemID: number;
    TVType: TVTypeEnum;
    UseEquation?: boolean;
    UseOfSiteID: number;
    UseWeight?: boolean;
    Weight_perc?: number;
}
