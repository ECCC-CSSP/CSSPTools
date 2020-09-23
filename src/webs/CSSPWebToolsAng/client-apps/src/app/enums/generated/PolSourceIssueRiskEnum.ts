/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';

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

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function PolSourceIssueRiskEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    PolSourceIssueRiskEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
