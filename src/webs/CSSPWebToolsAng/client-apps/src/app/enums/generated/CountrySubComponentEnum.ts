/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum CountrySubComponentEnum {
    Provinces = 1,
    Files = 2,
    OpenDataNational = 3,
    EmailDistributionList = 4,
    RainExceedance = 5,
}

export function GetCountrySubComponentEnum(): typeof CountrySubComponentEnum
{
  return CountrySubComponentEnum;
}

export function CountrySubComponentEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Provinces (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Files (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Open Data National (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Email Distribution List (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Rain Exceedance (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Provinces' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Files' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Open Data National' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Email Distribution List' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Rain Exceedance' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function CountrySubComponentEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let CountrySubComponentEnumText: string;
    CountrySubComponentEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            CountrySubComponentEnumText = e.EnumText;
            return false;
        }
    });

    return CountrySubComponentEnumText;
}
