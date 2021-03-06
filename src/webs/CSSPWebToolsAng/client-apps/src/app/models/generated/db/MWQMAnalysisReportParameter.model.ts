/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularCSSPDBModels.exe
 *
 * Do not edit this file.
 *
 */

import { LastUpdate } from 'src/app/models/generated/db/LastUpdate.model';
import { AnalysisCalculationTypeEnum } from 'src/app/enums/generated/AnalysisCalculationTypeEnum';
import { AnalysisReportExportCommandEnum } from 'src/app/enums/generated/AnalysisReportExportCommandEnum';
import { DBCommandEnum } from 'src/app/enums/generated/DBCommandEnum';

export class MWQMAnalysisReportParameter extends LastUpdate {
    AnalysisCalculationType: AnalysisCalculationTypeEnum;
    AnalysisName: string;
    AnalysisReportYear?: number;
    Command: AnalysisReportExportCommandEnum;
    DBCommand: DBCommandEnum;
    DryLimit24h: number;
    DryLimit48h: number;
    DryLimit72h: number;
    DryLimit96h: number;
    EndDate: Date;
    ExcelTVFileTVItemID?: number;
    FullYear: boolean;
    LastUpdateContactTVItemID: number;
    LastUpdateDate_UTC: Date;
    MidRangeNumberOfDays: number;
    MWQMAnalysisReportParameterID: number;
    NumberOfRuns: number;
    RunsToOmit: string;
    SalinityHighlightDeviationFromAverage: number;
    ShortRangeNumberOfDays: number;
    ShowDataTypes: string;
    StartDate: Date;
    SubsectorTVItemID: number;
    WetLimit24h: number;
    WetLimit48h: number;
    WetLimit72h: number;
    WetLimit96h: number;
}
