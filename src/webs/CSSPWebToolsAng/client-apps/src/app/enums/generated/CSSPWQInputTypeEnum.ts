/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum CSSPWQInputTypeEnum {
    Subsector = 1,
    Municipality = 2,
}

export function CSSPWQInputTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsector (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Municipality (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsector' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Municipality' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function CSSPWQInputTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    CSSPWQInputTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
