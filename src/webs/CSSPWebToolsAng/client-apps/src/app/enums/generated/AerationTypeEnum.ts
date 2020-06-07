/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

export enum AerationTypeEnum {
    MechanicalAirLines = 1,
    MechanicalSurfaceMixers = 2,
}

export function AerationTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Ligne d\'air méchanique' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Mélangeurs de surface mécaniques' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Mechanical Air Lines' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Mechanical Surface Mixers' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AerationTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    AerationTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}