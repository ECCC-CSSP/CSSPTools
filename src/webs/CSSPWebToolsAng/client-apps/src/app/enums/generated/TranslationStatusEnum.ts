/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum TranslationStatusEnum {
    NotTranslated = 1,
    ElectronicallyTranslated = 2,
    Translated = 3,
}

export function TranslationStatusEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not Translated (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Electronically Translated (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Translated (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not Translated' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Electronically Translated' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Translated' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function TranslationStatusEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    TranslationStatusEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
