/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum AppTaskStatusEnum {
    Created = 1,
    Running = 2,
    Completed = 3,
    Cancelled = 4,
}

export function AppTaskStatusEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Créé' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'En traitement' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Terminé' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Annulé' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Created' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Running' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Completed' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Cancelled' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AppTaskStatusEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    AppTaskStatusEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
