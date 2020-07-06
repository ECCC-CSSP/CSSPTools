/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum AlarmSystemTypeEnum {
    SCADA = 1,
    None = 2,
    OnlyVisualLight = 3,
    SCADAAndLight = 4,
    PagerAndLight = 5,
}

export function AlarmSystemTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'SCADA (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Aucun' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Only Visual Light (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'SCADA And Light (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Pager And Light (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'SCADA' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'None' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Only Visual Light' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'SCADA And Light' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Pager And Light' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AlarmSystemTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    AlarmSystemTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
