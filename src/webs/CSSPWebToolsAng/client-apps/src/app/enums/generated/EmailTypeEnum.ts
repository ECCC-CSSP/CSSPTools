/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum EmailTypeEnum {
    Personal = 1,
    Work = 2,
    Personal2 = 3,
    Work2 = 4,
}

export function EmailTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Personnel' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Travail' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'Personnel-2' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'Travail-2' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Personal' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Work' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'Personal-2' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'Work-2' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
