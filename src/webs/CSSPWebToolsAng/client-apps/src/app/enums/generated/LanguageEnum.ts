/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';

export enum LanguageEnum {
    en = 1,
    fr = 2,
    enAndfr = 3,
    es = 4,
}

export function LanguageEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'en' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'fr' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'enAndfr' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'es' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'en' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'fr' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'enAndfr' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'es' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function LanguageEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    LanguageEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
