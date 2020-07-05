/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp5.0\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum SiteTypeEnum {
    Climate = 1,
    Hydrometric = 2,
    Tide = 3,
}

export function SiteTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Climate (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Hydrometric (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Tide (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Climate' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Hydrometric' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Tide' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SiteTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    SiteTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
