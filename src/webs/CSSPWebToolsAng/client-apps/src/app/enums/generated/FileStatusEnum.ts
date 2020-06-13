/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum FileStatusEnum {
    Changed = 1,
    Sent = 2,
    Accepted = 3,
    Rejected = 4,
    Fail = 5,
}

export function FileStatusEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Changed (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Sent (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepté' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Fail (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Changed' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Sent' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepted' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Fail' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function FileStatusEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    FileStatusEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
