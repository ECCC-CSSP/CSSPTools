/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';

export enum PolSourceObsInfoTypeEnum {
    Description = 1,
    Report = 2,
    Text = 3,
    Initial = 4,
}

export function PolSourceObsInfoTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Description (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Report (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Text (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Initial (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Description' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Report' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Text' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Initial' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function PolSourceObsInfoTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    PolSourceObsInfoTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
