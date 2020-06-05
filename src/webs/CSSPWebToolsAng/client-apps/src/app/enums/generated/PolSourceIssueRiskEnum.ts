/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum PolSourceIssueRiskEnum {
    LowRisk = 1,
    ModerateRisk = 2,
    HighRisk = 3,
}

export function PolSourceIssueRiskEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'LowRisk' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'ModerateRisk' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'HighRisk' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'LowRisk' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'ModerateRisk' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'HighRisk' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
