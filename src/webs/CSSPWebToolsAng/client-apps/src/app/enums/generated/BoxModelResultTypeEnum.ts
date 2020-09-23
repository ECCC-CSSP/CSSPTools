/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';

export enum BoxModelResultTypeEnum {
    Dilution = 1,
    NoDecayUntreated = 2,
    NoDecayPreDisinfection = 3,
    DecayUntreated = 4,
    DecayPreDisinfection = 5,
}

export function BoxModelResultTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Dilution' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'NoDecayUntreated (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'NoDecayPreDisinfection (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'DecayUntreated (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'DecayPreDisinfection (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Dilution' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'NoDecayUntreated' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'NoDecayPreDisinfection' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'DecayUntreated' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'DecayPreDisinfection' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function BoxModelResultTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    BoxModelResultTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
