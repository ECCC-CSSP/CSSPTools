/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum RunningOnEnum {
    Azure = 1,
    Local = 2,
}

export function GetRunningOnEnum(): typeof RunningOnEnum
{
  return RunningOnEnum;
}

export function RunningOnEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Azure (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Local (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Azure' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Local' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function RunningOnEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let RunningOnEnumText: string;
    RunningOnEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            RunningOnEnumText = e.EnumText;
            return false;
        }
    });

    return RunningOnEnumText;
}
