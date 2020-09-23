/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';

export enum ReportFileTypeEnum {
    CSV = 1,
    Word = 2,
    Excel = 3,
    KML = 4,
}

export function ReportFileTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Comma Seperated Values (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Word (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Excel (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Google Earth' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Comma Seperated Values' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Word' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Excel' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Google Earth' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ReportFileTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    ReportFileTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
