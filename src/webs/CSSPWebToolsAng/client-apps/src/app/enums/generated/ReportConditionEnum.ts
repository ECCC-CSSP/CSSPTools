/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net6.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/models/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ReportConditionEnum {
    ReportConditionTrue = 1,
    ReportConditionFalse = 2,
    ReportConditionContain = 3,
    ReportConditionStart = 4,
    ReportConditionEnd = 5,
    ReportConditionBigger = 6,
    ReportConditionSmaller = 7,
    ReportConditionEqual = 8,
}

export function GetReportConditionEnum(): typeof ReportConditionEnum
{
  return ReportConditionEnum;
}

export function ReportConditionEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'TRUE' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'FALSE' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'CONTAIN' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'START' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'END' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'BIGGER' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'SMALLER' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'EQUAL' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'TRUE' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'FALSE' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'CONTAIN' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'START' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'END' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'BIGGER' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'SMALLER' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'EQUAL' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ReportConditionEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let ReportConditionEnumText: string;
    ReportConditionEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            ReportConditionEnumText = e.EnumText;
            return false;
        }
    });

    return ReportConditionEnumText;
}
