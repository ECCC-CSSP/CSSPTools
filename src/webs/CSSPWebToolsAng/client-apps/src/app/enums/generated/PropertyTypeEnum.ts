/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.model';

export enum PropertyTypeEnum {
    Int = 1,
    Double = 2,
    String = 3,
    Boolean = 4,
    DateTime = 5,
    Enum = 6,
}

export function PropertyTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Int' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Double' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'String' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Boolean' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'DateTime' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Enum' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Int' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Double' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'String' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Boolean' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'DateTime' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Enum' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function PropertyTypeEnum_GetIDText(enumID: number): string {
    let addressTypeEnunText: string;
    PropertyTypeEnum_GetOrderedText().forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
