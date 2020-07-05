/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum ScenarioStatusEnum {
    Normal = 1,
    Copying = 2,
    Copied = 3,
    Changing = 4,
    Changed = 5,
    AskToRun = 6,
    Running = 7,
    Completed = 8,
    Cancelled = 9,
}

export function ScenarioStatusEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Normal (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Copying (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Copied (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Changing (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Changed (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Ask To Run (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Running (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Completed (fr)' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Cancelled (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Normal' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Copying' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Copied' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Changing' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Changed' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Ask To Run' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Running' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Completed' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Cancelled' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ScenarioStatusEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    ScenarioStatusEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
