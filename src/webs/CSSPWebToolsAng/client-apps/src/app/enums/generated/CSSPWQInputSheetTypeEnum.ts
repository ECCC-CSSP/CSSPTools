/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum CSSPWQInputSheetTypeEnum {
    A1 = 1,
    LTB = 2,
    EC = 3,
}

export function GetCSSPWQInputSheetTypeEnum(): typeof CSSPWQInputSheetTypeEnum
{
  return CSSPWQInputSheetTypeEnum;
}

export function CSSPWQInputSheetTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'A1' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'LTB' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'EC' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'A1' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'LTB' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'EC' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function CSSPWQInputSheetTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let CSSPWQInputSheetTypeEnumText: string;
    CSSPWQInputSheetTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            CSSPWQInputSheetTypeEnumText = e.EnumText;
            return false;
        }
    });

    return CSSPWQInputSheetTypeEnumText;
}
