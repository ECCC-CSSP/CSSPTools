/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';

export enum PrimaryTreatmentTypeEnum {
    NotApplicable = 1,
    Sedimentation = 2,
    ChemicalCoagulation = 3,
    Filtration = 4,
    PrimaryClarification = 5,
}

export function PrimaryTreatmentTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not applicable (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Sedimentation (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Chemical coagulation (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Filtration (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Primary clarification (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not applicable' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Sedimentation' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Chemical coagulation' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Filtration' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Primary clarification' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function PrimaryTreatmentTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    PrimaryTreatmentTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
