/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net6.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/models/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum SiteTypeEnum {
    Climate = 1,
    Hydrometric = 2,
    Tide = 3,
}

export function GetSiteTypeEnum(): typeof SiteTypeEnum
{
  return SiteTypeEnum;
}

export function SiteTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Climate (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Hydrometric (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Tide (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Climate' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Hydrometric' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Tide' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SiteTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let SiteTypeEnumText: string;
    SiteTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            SiteTypeEnumText = e.EnumText;
            return false;
        }
    });

    return SiteTypeEnumText;
}
