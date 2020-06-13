/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum AnalysisReportExportCommandEnum {
    Report = 1,
    Excel = 2,
}

export function AnalysisReportExportCommandEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Rapport' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Excel' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Report' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Excel' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AnalysisReportExportCommandEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    AnalysisReportExportCommandEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
