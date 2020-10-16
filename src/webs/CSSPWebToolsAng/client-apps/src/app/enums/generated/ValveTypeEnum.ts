/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\AngularEnumsGenerated.exe
 *
 * Do not edit this file.
 *
 */

import { AppService } from '../../app.service';
import { EnumIDAndText } from '../../models/generated/EnumIDAndText.model';
import { LanguageEnum } from './LanguageEnum';

export enum ValveTypeEnum {
    Manually = 1,
    Automatically = 2,
    None = 3,
}

export function ValveTypeEnum_GetOrderedText(appService: AppService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appService.AppVar$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Manually (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Automatically (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'None (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Manually' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Automatically' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'None' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ValveTypeEnum_GetIDText(enumID: number, appService: AppService): string {
    let addressTypeEnunText: string;
    ValveTypeEnum_GetOrderedText(appService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
