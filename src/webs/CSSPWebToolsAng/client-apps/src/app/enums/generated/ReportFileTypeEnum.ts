/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ReportFileTypeEnum {
    CSV = 1,
    Word = 2,
    Excel = 3,
    KML = 4,
}

export function GetReportFileTypeEnum(): typeof ReportFileTypeEnum
{
  return ReportFileTypeEnum;
}

export function ReportFileTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Comma Seperated Values (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Word (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Excel (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Google Earth' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Comma Seperated Values' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Word' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Excel' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Google Earth' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ReportFileTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let ReportFileTypeEnumText: string;
    ReportFileTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            ReportFileTypeEnumText = e.EnumText;
            return false;
        }
    });

    return ReportFileTypeEnumText;
}
