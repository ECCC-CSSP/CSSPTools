/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

export enum SamplingPlanTypeEnum {
    Subsector = 1,
    Municipality = 2,
}

export function SamplingPlanTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsector (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Municipality (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsector' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Municipality' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SamplingPlanTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    SamplingPlanTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
