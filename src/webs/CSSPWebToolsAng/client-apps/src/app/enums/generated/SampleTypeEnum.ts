/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';

export enum SampleTypeEnum {
    DailyDuplicate = 101,
    Infrastructure = 102,
    IntertechDuplicate = 103,
    IntertechRead = 104,
    RainCMP = 105,
    RainRun = 106,
    ReopeningEmergencyRain = 107,
    ReopeningSpill = 108,
    Routine = 109,
    Sanitary = 110,
    Study = 111,
    Sediment = 112,
    Bivalve = 113,
}

export function SampleTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 101, EnumText: 'Daily duplicate (fr)' });
        enumTextOrderedList.push({ EnumID: 102, EnumText: 'Infrastructure (fr)' });
        enumTextOrderedList.push({ EnumID: 103, EnumText: 'Intertech duplicate (fr)' });
        enumTextOrderedList.push({ EnumID: 104, EnumText: 'Intertech read (fr)' });
        enumTextOrderedList.push({ EnumID: 105, EnumText: 'Rain CMP (fr)' });
        enumTextOrderedList.push({ EnumID: 106, EnumText: 'Rain run (fr)' });
        enumTextOrderedList.push({ EnumID: 107, EnumText: 'Reopening emergency rain (fr)' });
        enumTextOrderedList.push({ EnumID: 108, EnumText: 'Reopening spill (fr)' });
        enumTextOrderedList.push({ EnumID: 109, EnumText: 'Routine (fr)' });
        enumTextOrderedList.push({ EnumID: 110, EnumText: 'Sanitary (fr)' });
        enumTextOrderedList.push({ EnumID: 111, EnumText: 'Study (fr)' });
        enumTextOrderedList.push({ EnumID: 112, EnumText: 'Sediment (fr)' });
        enumTextOrderedList.push({ EnumID: 113, EnumText: 'Bivalve (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 101, EnumText: 'Daily duplicate' });
        enumTextOrderedList.push({ EnumID: 102, EnumText: 'Infrastructure' });
        enumTextOrderedList.push({ EnumID: 103, EnumText: 'Intertech duplicate' });
        enumTextOrderedList.push({ EnumID: 104, EnumText: 'Intertech read' });
        enumTextOrderedList.push({ EnumID: 105, EnumText: 'Rain CMP' });
        enumTextOrderedList.push({ EnumID: 106, EnumText: 'Rain run' });
        enumTextOrderedList.push({ EnumID: 107, EnumText: 'Reopening emergency rain' });
        enumTextOrderedList.push({ EnumID: 108, EnumText: 'Reopening spill' });
        enumTextOrderedList.push({ EnumID: 109, EnumText: 'Routine' });
        enumTextOrderedList.push({ EnumID: 110, EnumText: 'Sanitary' });
        enumTextOrderedList.push({ EnumID: 111, EnumText: 'Study' });
        enumTextOrderedList.push({ EnumID: 112, EnumText: 'Sediment' });
        enumTextOrderedList.push({ EnumID: 113, EnumText: 'Bivalve' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SampleTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    SampleTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
