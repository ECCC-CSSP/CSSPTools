/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum MapInfoDrawTypeEnum {
    Point = 1,
    Polyline = 2,
    Polygon = 3,
}

export function MapInfoDrawTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Point (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Polyline (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Polygon (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Point' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Polyline' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Polygon' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function MapInfoDrawTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    MapInfoDrawTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
