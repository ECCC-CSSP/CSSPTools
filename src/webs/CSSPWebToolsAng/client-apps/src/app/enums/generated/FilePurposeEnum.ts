/*
 * Auto generated C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from '../../models/enumidandtext.model';

export enum FilePurposeEnum {
    MikeInput = 1,
    MikeInputMDF = 2,
    MikeResultDFSU = 3,
    MikeResultKMZ = 4,
    Information = 5,
    Image = 6,
    Picture = 7,
    ReportGenerated = 8,
    TemplateGenerated = 9,
    GeneratedFCForm = 10,
    Template = 11,
    Map = 12,
    Analysis = 13,
    OpenData = 14,
}

export function FilePurposeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'MIKE Input (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'MIKE Input MDF (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'MIKE Result DFSU (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'MIKE Result KMZ (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Information (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Image (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Picture (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Report Generated (fr)' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Template Generated (fr)' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Generated FC Form(fr)' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Template (fr)' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Map (fr)' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'Analyses' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'Open Data (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'MIKE Input' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'MIKE Input MDF' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'MIKE Result DFSU' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'MIKE Result KMZ' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Information' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Image' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Picture' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Report Generated' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Template Generated' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Generated FC Form' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Template' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Map' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'Analysis' });
        enumTextOrderedList.push({ EnumID: 14, EnumText: 'Open Data' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function FilePurposeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    FilePurposeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
