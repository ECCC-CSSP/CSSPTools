/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

export enum TertiaryTreatmentTypeEnum {
    NotApplicable = 1,
    Adsorption = 2,
    Flocculation = 3,
    MembraneFiltration = 4,
    IonExchange = 5,
    ReverseOsmosis = 6,
    BiologicalNutrientRemoval = 7,
}

export function TertiaryTreatmentTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not applicable (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Adsorption (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Flocculation (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Membrane filtration (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Ion exchange (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Reverse osmosis (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Biological Nutrient Removal (BNR) (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not applicable' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Adsorption' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Flocculation' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Membrane filtration' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Ion exchange' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Reverse osmosis' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Biological Nutrient Removal (BNR)' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function TertiaryTreatmentTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    TertiaryTreatmentTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}