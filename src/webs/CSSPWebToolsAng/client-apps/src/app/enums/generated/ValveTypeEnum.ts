/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ValveTypeEnum {
    Manually = 1,
    Automatically = 2,
    None = 3,
}

export function GetValveTypeEnum(): typeof ValveTypeEnum
{
  return ValveTypeEnum;
}

export function ValveTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
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

export function ValveTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let addressTypeEnunText: string;
    ValveTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
