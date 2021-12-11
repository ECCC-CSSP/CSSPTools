/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net6.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/models/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum AnalysisCalculationTypeEnum {
    All = 1,
    Wet = 2,
    Dry = 3,
}

export function GetAnalysisCalculationTypeEnum(): typeof AnalysisCalculationTypeEnum
{
  return AnalysisCalculationTypeEnum;
}

export function AnalysisCalculationTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'All' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Wet' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Dry' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'All' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Wet' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Dry' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AnalysisCalculationTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let AnalysisCalculationTypeEnumText: string;
    AnalysisCalculationTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            AnalysisCalculationTypeEnumText = e.EnumText;
            return false;
        }
    });

    return AnalysisCalculationTypeEnumText;
}
