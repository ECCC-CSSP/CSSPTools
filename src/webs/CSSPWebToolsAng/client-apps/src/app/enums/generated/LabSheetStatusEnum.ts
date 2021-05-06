/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum LabSheetStatusEnum {
    Created = 1,
    Transferred = 2,
    Accepted = 3,
    Rejected = 4,
}

export function GetLabSheetStatusEnum(): typeof LabSheetStatusEnum
{
  return LabSheetStatusEnum;
}

export function LabSheetStatusEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Created (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Transferred (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepté' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Created' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Transferred' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepted' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function LabSheetStatusEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let addressTypeEnunText: string;
    LabSheetStatusEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
