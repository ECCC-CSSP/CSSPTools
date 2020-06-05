/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum TideTextEnum {
    LowTide = 1,
    LowTideFalling = 2,
    LowTideRising = 3,
    MidTide = 4,
    MidTideFalling = 5,
    MidTideRising = 6,
    HighTide = 7,
    HighTideFalling = 8,
    HighTideRising = 9,
}

export function TideTextEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Low Tide (fr)' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Low Tide Falling (fr)' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'Low Tide Rising (fr)' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'Mid Tide (fr)' });
       enumTextOrderedList.push({ EnumID: 5, EnumText: 'Mid Tide Falling (fr)' });
       enumTextOrderedList.push({ EnumID: 6, EnumText: 'Mid Tide Rising (fr)' });
       enumTextOrderedList.push({ EnumID: 7, EnumText: 'High Tide (fr)' });
       enumTextOrderedList.push({ EnumID: 8, EnumText: 'High Tide Falling (fr)' });
       enumTextOrderedList.push({ EnumID: 9, EnumText: 'High Tide Rising (fr)' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Low Tide' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Low Tide Falling' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'Low Tide Rising' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'Mid Tide' });
       enumTextOrderedList.push({ EnumID: 5, EnumText: 'Mid Tide Falling' });
       enumTextOrderedList.push({ EnumID: 6, EnumText: 'Mid Tide Rising' });
       enumTextOrderedList.push({ EnumID: 7, EnumText: 'High Tide' });
       enumTextOrderedList.push({ EnumID: 8, EnumText: 'High Tide Falling' });
       enumTextOrderedList.push({ EnumID: 9, EnumText: 'High Tide Rising' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
