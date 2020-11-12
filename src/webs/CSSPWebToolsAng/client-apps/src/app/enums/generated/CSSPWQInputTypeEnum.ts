/*
 * Auto generated C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppStateService } from 'src/app/services/app-state.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum CSSPWQInputTypeEnum {
    Subsector = 1,
    Municipality = 2,
}

export function GetCSSPWQInputTypeEnum(): typeof CSSPWQInputTypeEnum
{
  return CSSPWQInputTypeEnum;
}

export function CSSPWQInputTypeEnum_GetOrderedText(appStateService: AppStateService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appStateService.AppState$?.getValue().Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsector (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Municipality (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsector' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Municipality' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function CSSPWQInputTypeEnum_GetIDText(enumID: number, appStateService: AppStateService): string {
    let addressTypeEnunText: string;
    CSSPWQInputTypeEnum_GetOrderedText(appStateService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
