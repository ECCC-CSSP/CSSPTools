/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum ActionDBTypeEnum {
    Create = 1,
    Read = 2,
    Update = 3,
    Delete = 4,
}

export function ActionDBTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Créer' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Lire' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Mettre à jour' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Effacer' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Create' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Read' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Update' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Delete' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ActionDBTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    ActionDBTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
