/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum ReportTreeNodeSubTypeEnum {
    TableSelectable = 1,
    Field = 2,
    FieldsHolder = 3,
    TableNotSelectable = 4,
}

export function ReportTreeNodeSubTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'TableSelectable' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Field' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'FieldsHolder' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'TableNotSelectable' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'TableSelectable' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Field' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'FieldsHolder' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'TableNotSelectable' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ReportTreeNodeSubTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    ReportTreeNodeSubTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
