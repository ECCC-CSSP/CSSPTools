/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum TopComponentEnum {
    Home = 1,
    Shell = 2,
}

export function GetTopComponentEnum(): typeof TopComponentEnum
{
  return TopComponentEnum;
}

export function TopComponentEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Home (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Shell (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Home' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Shell' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function TopComponentEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let TopComponentEnumText: string;
    TopComponentEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            TopComponentEnumText = e.EnumText;
            return false;
        }
    });

    return TopComponentEnumText;
}
