/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum DailyOrHourlyDataEnum {
    Daily = 1,
    Hourly = 2,
}

export function DailyOrHourlyDataEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Daily (fr)' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Hourly (fr)' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Daily' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Hourly' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
