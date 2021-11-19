/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum PreliminaryTreatmentTypeEnum {
    NotApplicable = 1,
    BarScreen = 2,
    Grinder = 3,
    MechanicalScreening = 4,
}

export function GetPreliminaryTreatmentTypeEnum(): typeof PreliminaryTreatmentTypeEnum
{
  return PreliminaryTreatmentTypeEnum;
}

export function PreliminaryTreatmentTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not applicable (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Bar screen (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Grinder (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Mechanical screening (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Not applicable' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Bar screen' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Grinder' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Mechanical screening' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function PreliminaryTreatmentTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let PreliminaryTreatmentTypeEnumText: string;
    PreliminaryTreatmentTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            PreliminaryTreatmentTypeEnumText = e.EnumText;
            return false;
        }
    });

    return PreliminaryTreatmentTypeEnumText;
}
