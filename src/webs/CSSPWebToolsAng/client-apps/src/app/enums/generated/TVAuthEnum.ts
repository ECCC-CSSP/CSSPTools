/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum TVAuthEnum {
    NoAccess = 1,
    Read = 2,
    Write = 3,
    Create = 4,
    Delete = 5,
    Admin = 6,
}

export function TVAuthEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'No access (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Read (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Write (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Create (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Delete (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Admin (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'No access' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Read' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Write' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Create' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Delete' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Admin' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function TVAuthEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    TVAuthEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
