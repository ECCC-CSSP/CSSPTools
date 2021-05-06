/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum AnalysisReportExportCommandEnum {
    Report = 1,
    Excel = 2,
}

export function GetAnalysisReportExportCommandEnum(): typeof AnalysisReportExportCommandEnum
{
  return AnalysisReportExportCommandEnum;
}

export function AnalysisReportExportCommandEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Rapport' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Excel' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Report' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Excel' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AnalysisReportExportCommandEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let addressTypeEnunText: string;
    AnalysisReportExportCommandEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
