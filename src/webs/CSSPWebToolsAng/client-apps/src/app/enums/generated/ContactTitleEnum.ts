/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum ContactTitleEnum {
    DirectorGeneral = 1,
    DirectorPublicWorks = 2,
    Superintendent = 3,
    Engineer = 4,
    Foreman = 5,
    Operator = 6,
    FacilitiesManager = 7,
    Supervisor = 8,
    Technician = 9,
}

export function ContactTitleEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Director General (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Director Public Works (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Superintendent (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Engineer (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Foreman (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Operator (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Facilities Manager (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Supervisor (fr)' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Technician (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Director General' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Director Public Works' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Superintendent' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Engineer' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Foreman' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Operator' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Facilities Manager' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Supervisor' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Technician' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ContactTitleEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    ContactTitleEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
