/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum LabSheetTypeEnum {
    A1 = 1,
    LTB = 2,
    EC = 3,
}

export function LabSheetTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'A1' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'LTB' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'EC' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'A1' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'LTB' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'EC' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function LabSheetTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    LabSheetTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
