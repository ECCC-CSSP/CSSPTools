/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ContentSizeEnum {
    Size30 = 1,
    Size40 = 2,
    Size50 = 3,
    Size60 = 4,
    Size70 = 5,
}

export function GetContentSizeEnum(): typeof ContentSizeEnum
{
  return ContentSizeEnum;
}

export function ContentSizeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Size 30' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Size 40' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Size 50' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Size 60' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Size 70' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Size 30' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Size 40' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Size 50' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Size 60' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Size 70' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ContentSizeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let ContentSizeEnumText: string;
    ContentSizeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            ContentSizeEnumText = e.EnumText;
            return false;
        }
    });

    return ContentSizeEnumText;
}
