/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum DisinfectionTypeEnum {
    None = 1,
    UV = 2,
    ChlorinationNoDechlorination = 3,
    ChlorinationWithDechlorination = 4,
    UVSeasonal = 5,
    ChlorinationNoDechlorinationSeasonal = 6,
    ChlorinationWithDechlorinationSeasonal = 7,
}

export function DisinfectionTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Aucun' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'UV ' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'Chlorination No Dechlorination (fr)' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'Chlorination With Dechlorination (fr)' });
       enumTextOrderedList.push({ EnumID: 5, EnumText: 'UV Seasonal (fr)' });
       enumTextOrderedList.push({ EnumID: 6, EnumText: 'Chlorination No Dechlorination Seasonal (fr)' });
       enumTextOrderedList.push({ EnumID: 7, EnumText: 'Chlorination With Dechlorination Seasonal (fr)' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'None' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'UV' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'Chlorination No Dechlorination' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'Chlorination With Dechlorination' });
       enumTextOrderedList.push({ EnumID: 5, EnumText: 'UV Seasonal' });
       enumTextOrderedList.push({ EnumID: 6, EnumText: 'Chlorination No Dechlorination Seasonal' });
       enumTextOrderedList.push({ EnumID: 7, EnumText: 'Chlorination With Dechlorination Seasonal' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
