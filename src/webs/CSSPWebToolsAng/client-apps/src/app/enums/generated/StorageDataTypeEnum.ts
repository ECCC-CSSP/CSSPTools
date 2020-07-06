/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum StorageDataTypeEnum {
    Archived = 1,
    Forcasted = 2,
    Observed = 3,
}

export function StorageDataTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Archived (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Forcasted (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Observed (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Archived' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Forcasted' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Observed' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function StorageDataTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    StorageDataTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
