/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ReportFormatingDateEnum {
    ReportFormatingDateYearOnly = 1,
    ReportFormatingDateMonthDecimalOnly = 2,
    ReportFormatingDateMonthShortTextOnly = 3,
    ReportFormatingDateMonthFullTextOnly = 4,
    ReportFormatingDateDayOnly = 5,
    ReportFormatingDateHourOnly = 6,
    ReportFormatingDateMinuteOnly = 7,
    ReportFormatingDateYearMonthDecimalDay = 8,
    ReportFormatingDateYearMonthShortTextDay = 9,
    ReportFormatingDateYearMonthFullTextDay = 10,
    ReportFormatingDateYearMonthDecimalDayHourMinute = 11,
    ReportFormatingDateYearMonthShortTextDayHourMinute = 12,
    ReportFormatingDateYearMonthFullTextDayHourMinute = 13,
}

export function GetReportFormatingDateEnum(): typeof ReportFormatingDateEnum
{
  return ReportFormatingDateEnum;
}

export function ReportFormatingDateEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'ReportFormatingDateYearOnly' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'ReportFormatingDateMonthDecimalOnly' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'ReportFormatingDateMonthShortTextOnly' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'ReportFormatingDateMonthFullTextOnly' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'ReportFormatingDateDayOnly' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'ReportFormatingDateHourOnly' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'ReportFormatingDateMinuteOnly' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'ReportFormatingDateYearMonthDecimalDay' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'ReportFormatingDateYearMonthShortTextDay' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'ReportFormatingDateYearMonthFullTextDay' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'ReportFormatingDateYearMonthDecimalDayHourMinute' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'ReportFormatingDateYearMonthShortTextDayHourMinute' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'ReportFormatingDateYearMonthFullTextDayHourMinute' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'ReportFormatingDateYearOnly' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'ReportFormatingDateMonthDecimalOnly' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'ReportFormatingDateMonthShortTextOnly' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'ReportFormatingDateMonthFullTextOnly' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'ReportFormatingDateDayOnly' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'ReportFormatingDateHourOnly' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'ReportFormatingDateMinuteOnly' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'ReportFormatingDateYearMonthDecimalDay' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'ReportFormatingDateYearMonthShortTextDay' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'ReportFormatingDateYearMonthFullTextDay' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'ReportFormatingDateYearMonthDecimalDayHourMinute' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'ReportFormatingDateYearMonthShortTextDayHourMinute' });
        enumTextOrderedList.push({ EnumID: 13, EnumText: 'ReportFormatingDateYearMonthFullTextDayHourMinute' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ReportFormatingDateEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let ReportFormatingDateEnumText: string;
    ReportFormatingDateEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            ReportFormatingDateEnumText = e.EnumText;
            return false;
        }
    });

    return ReportFormatingDateEnumText;
}
