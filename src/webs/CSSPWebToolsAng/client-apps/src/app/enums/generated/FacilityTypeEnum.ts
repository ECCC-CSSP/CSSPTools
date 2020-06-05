/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum FacilityTypeEnum {
    Lagoon = 1,
    Plant = 2,
}

export function FacilityTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Lagoon (fr)' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Plant (fr)' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Lagoon' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Plant' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
