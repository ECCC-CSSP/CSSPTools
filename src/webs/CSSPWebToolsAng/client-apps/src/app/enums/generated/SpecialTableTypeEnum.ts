/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum SpecialTableTypeEnum {
    FCDensitiesTable = 1,
    SalinityTable = 2,
    TemperatureTable = 3,
    GeometricMeanTable = 4,
    MedianTable = 5,
    P90Table = 6,
    PercentOver43Table = 7,
    PercentOver260Table = 8,
}

export function GetSpecialTableTypeEnum(): typeof SpecialTableTypeEnum
{
  return SpecialTableTypeEnum;
}

export function SpecialTableTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'FCDensitiesTable' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'SalinityTable' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'TemperatureTable' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'GeometricMeanTable' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'MedianTable' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'P90Table' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'PercentOver43Table' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'PercentOver260Table' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'FCDensitiesTable' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'SalinityTable' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'TemperatureTable' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'GeometricMeanTable' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'MedianTable' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'P90Table' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'PercentOver43Table' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'PercentOver260Table' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SpecialTableTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let addressTypeEnunText: string;
    SpecialTableTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            addressTypeEnunText = e.EnumText;
            return false;
        }
    });

    return addressTypeEnunText;
}
