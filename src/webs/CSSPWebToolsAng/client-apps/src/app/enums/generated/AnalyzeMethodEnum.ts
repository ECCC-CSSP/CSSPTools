/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp5.0\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum AnalyzeMethodEnum {
    MF = 1,
    ZZ_510Q = 2,
    ZZ_509Q = 3,
    ZZ_0 = 4,
    ZZ_525Q = 5,
    MPN = 6,
    ZZ_0Q = 7,
    AnalyzeMethod8 = 8,
    AnalyzeMethod9 = 9,
    AnalyzeMethod10 = 10,
    AnalyzeMethod11 = 11,
    AnalyzeMethod12 = 12,
}

export function AnalyzeMethodEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'MF' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'ZZ_510Q' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'ZZ_509Q' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'ZZ_0' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'ZZ_525Q' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'MPN' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'ZZ_0Q' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Méthode analytique 8' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Méthode analytique 9' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Méthode analytique 10 ' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Méthode analytique 11' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Méthode analytique 12 ' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'MF' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'ZZ_510Q' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'ZZ_509Q' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'ZZ_0' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'ZZ_525Q' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'MPN' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'ZZ_0Q' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'AnalyzeMethod8' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'AnalyzeMethod9' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'AnalyzeMethod10' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'AnalyzeMethod11' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'AnalyzeMethod12' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AnalyzeMethodEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    AnalyzeMethodEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
