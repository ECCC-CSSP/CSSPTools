/*
 * Auto generated C:\CSSPTools\src\codegen\AngularEnumsGenerated\bin\Debug\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { EnumIDAndText } from 'src/app/models/enumidandtext.models';

export enum ReportTreeNodeSubTypeEnum {
    TableSelectable = 1,
    Field = 2,
    FieldsHolder = 3,
    TableNotSelectable = 4,
}

export function ReportTreeNodeSubTypeEnum_GetOrderedText(): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if ($localize.locale === 'fr-CA') {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'TableSelectable' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Field' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'FieldsHolder' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'TableNotSelectable' });
    }
    else {
       enumTextOrderedList.push({ EnumID: 1, EnumText: 'TableSelectable' });
       enumTextOrderedList.push({ EnumID: 2, EnumText: 'Field' });
       enumTextOrderedList.push({ EnumID: 3, EnumText: 'FieldsHolder' });
       enumTextOrderedList.push({ EnumID: 4, EnumText: 'TableNotSelectable' });
    }

    return enumTextOrderedList.sort((a,b) => a.EnumText.localeCompare(b.EnumText));

}
