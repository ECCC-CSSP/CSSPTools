/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ClassificationTypeEnum {
    Approved = 1,
    Restricted = 2,
    Prohibited = 3,
    ConditionallyApproved = 4,
    ConditionallyRestricted = 5,
}

export function GetClassificationTypeEnum(): typeof ClassificationTypeEnum
{
  return ClassificationTypeEnum;
}

export function ClassificationTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Agréé' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Restreint' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Interdit' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Agréé sous condition' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Restreint sous condition' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Approved' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Restricted' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Prohibited' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Conditionally Approved' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Conditionally Restricted' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ClassificationTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let ClassificationTypeEnumText: string;
    ClassificationTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            ClassificationTypeEnumText = e.EnumText;
            return false;
        }
    });

    return ClassificationTypeEnumText;
}
