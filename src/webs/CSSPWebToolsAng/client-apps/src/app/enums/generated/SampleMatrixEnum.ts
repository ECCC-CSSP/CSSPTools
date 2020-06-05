/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum SampleMatrixEnum {
    W = 1,
    S = 2,
    B = 3,
    MPNQ = 4,
    SampleMatrix5 = 5,
    SampleMatrix6 = 6,
    Water = 7,
}

export function SampleMatrixEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'W (fr)' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'S (fr)' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'B (fr)' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'MPNQ (fr)' });
       enumTextOrderedList.push({ EnumID: 5, EnumText: 'Sample Matrix 5 (fr)' });
       enumTextOrderedList.push({ EnumID: 6, EnumText: 'Sample Matrix 6 (fr)' });
       enumTextOrderedList.push({ EnumID: 7, EnumText: 'Water (fr)' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'W' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'S' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'B' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'MPNQ' });
       enumTextOrderedList.push({ EnumID: 5, EnumText: 'Sample Matrix 5' });
       enumTextOrderedList.push({ EnumID: 6, EnumText: 'Sample Matrix 6' });
       enumTextOrderedList.push({ EnumID: 7, EnumText: 'Water' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
