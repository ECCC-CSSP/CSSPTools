/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

export enum PositionEnum {
    LeftBottom = 1,
    RightBottom = 2,
    LeftTop = 3,
    RightTop = 4,
}

export function PositionEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Left Bottom (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Right Bottom (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Left Top (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Right Top (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Left Bottom' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Right Bottom' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Left Top' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Right Top' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function PositionEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    PositionEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}