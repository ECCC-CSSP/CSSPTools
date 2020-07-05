/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum LabSheetStatusEnum {
    Created = 1,
    Transferred = 2,
    Accepted = 3,
    Rejected = 4,
}

export function LabSheetStatusEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Created (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Transferred (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepté' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Created' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Transferred' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepted' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function LabSheetStatusEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    LabSheetStatusEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
