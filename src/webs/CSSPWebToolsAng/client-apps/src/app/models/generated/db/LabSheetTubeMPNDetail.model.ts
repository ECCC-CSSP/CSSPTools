/*
 * Auto generated from C:\CSSPTools\src\codegen\GenerateAngularCSSPDBModels\bin\Debug\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';
import { SampleTypeEnum } from 'src/app/enums/generated/SampleTypeEnum';

export class LabSheetTubeMPNDetail extends LastUpdate {
    DBCommand: DBCommandEnum;
    LabSheetDetailID: number;
    LabSheetTubeMPNDetailID: number;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    MPN?: number;
    MWQMSiteTVItemID: number;
    Ordinal: number;
    ProcessedBy: string;
    Salinity?: number;
    SampleDateTime?: Date;
    SampleType: SampleTypeEnum;
    SiteComment: string;
    Temperature?: number;
    Tube0_1?: number;
    Tube1_0?: number;
    Tube10?: number;
}
