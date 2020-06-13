/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum EntityQueryTypeEnum {
    AsNoTracking = 1,
    WithTracking = 2,
}

export function EntityQueryTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'As no tracking (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'With tracking (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'As no tracking' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'With tracking' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function EntityQueryTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    EntityQueryTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
