/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum SecondaryTreatmentTypeEnum {
    NotApplicable = 1,
    RotatingBiologicalContactor = 2,
    TricklingFilters = 3,
    SequencingBatchReactor = 4,
    OxidationDitch = 5,
    ExtendedAeration = 6,
    ContactStabilization = 7,
    PhysicalChemicalProcesses = 8,
    MovingBedBioReactor = 10,
    BiologicalAearatedFilters = 11,
    AeratedSubmergedBioFilmReactor = 12,
    IntegratedFixedFilmActivatedSludge = 13,
    ActivatedSludge = 14,
    ExtendedActivatedSludge = 15,
}

export function SecondaryTreatmentTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not applicable (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Rotating Biological Contactor (RBC) (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Trickling filters (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Sequencing Batch Reactor (SBR) (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Oxidation Ditch (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Extended aeration (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Contact stabilization (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Physical chemical processes (fr)' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Moving bed bio reactor (fr)' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Biological aearated filters (fr)' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Aerated submerged bio film reactor (fr)' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'Integrated fixed film activated sludge (fr)' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'Activated sludge (fr)' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'Extended activated sludge (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not applicable' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Rotating Biological Contactor (RBC)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Trickling filters' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Sequencing Batch Reactor (SBR)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Oxidation Ditch' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Extended aeration' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Contact stabilization' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Physical chemical processes' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Moving bed bio reactor' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Biological aearated filters' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Aerated submerged bio film reactor' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'Integrated fixed film activated sludge' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'Activated sludge' });
        enumTextOrderedList.push({ EnumID: 15, EnumText: 'Extended activated sludge' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SecondaryTreatmentTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    SecondaryTreatmentTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
