/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum FileStatusEnum {
    Changed = 1,
    Sent = 2,
    Accepted = 3,
    Rejected = 4,
    Fail = 5,
}

export function GetFileStatusEnum(): typeof FileStatusEnum
{
  return FileStatusEnum;
}

export function FileStatusEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Changed (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Sent (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepté' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Fail (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Changed' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Sent' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Accepted' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Rejected' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Fail' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function FileStatusEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let FileStatusEnumText: string;
    FileStatusEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            FileStatusEnumText = e.EnumText;
            return false;
        }
    });

    return FileStatusEnumText;
}
