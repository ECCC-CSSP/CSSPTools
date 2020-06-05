/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum PolSourceInactiveReasonEnum {
    Abandoned = 1,
    Closed = 2,
    Removed = 3,
}

export function PolSourceInactiveReasonEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Abandoned (fr)' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Closed (fr)' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'Removed (fr)' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'Abandoned' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Closed' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'Removed' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
