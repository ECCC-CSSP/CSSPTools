/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum StreetTypeEnum {
    Street = 1,
    Road = 2,
    Avenue = 3,
    Crescent = 4,
    Court = 5,
    Alley = 6,
    Drive = 7,
    Blvd = 8,
    Route = 9,
    Lane = 10,
}

export function GetStreetTypeEnum(): typeof StreetTypeEnum
{
  return StreetTypeEnum;
}

export function StreetTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Rue' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Chemin' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Avenue' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Croissant' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Ruelle' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Allée' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Promenade' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Boulevard' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Route (fr)' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Voie' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Street' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Road' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Avenue' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Crescent' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Court' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Alley' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Drive' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Boulevard' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Route' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Lane' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function StreetTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let StreetTypeEnumText: string;
    StreetTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            StreetTypeEnumText = e.EnumText;
            return false;
        }
    });

    return StreetTypeEnumText;
}
