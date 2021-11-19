/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum DrogueTypeEnum {
    SmallDrogue = 1,
    LargeDrogue = 2,
}

export function GetDrogueTypeEnum(): typeof DrogueTypeEnum
{
  return DrogueTypeEnum;
}

export function DrogueTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Small drogue (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Large drogue (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Small drogue' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Large drogue' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function DrogueTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let DrogueTypeEnumText: string;
    DrogueTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            DrogueTypeEnumText = e.EnumText;
            return false;
        }
    });

    return DrogueTypeEnumText;
}
