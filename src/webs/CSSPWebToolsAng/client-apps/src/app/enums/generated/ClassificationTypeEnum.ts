/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum ClassificationTypeEnum {
    Approved = 1,
    Restricted = 2,
    Prohibited = 3,
    ConditionallyApproved = 4,
    ConditionallyRestricted = 5,
}

export function ClassificationTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Agréé' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Restreint' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Interdit' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Agréé sous condition' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Restreint sous condition' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Approved' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Restricted' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Prohibited' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Conditionally Approved' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Conditionally Restricted' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ClassificationTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    ClassificationTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
