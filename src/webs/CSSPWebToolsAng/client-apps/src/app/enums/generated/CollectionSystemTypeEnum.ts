/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum CollectionSystemTypeEnum {
    CompletelySeparated = 1,
    CompletelyCombined = 2,
    Combined90Separated10 = 3,
    Combined80Separated20 = 4,
    Combined70Separated30 = 5,
    Combined60Separated40 = 6,
    Combined50Separated50 = 7,
    Combined40Separated60 = 8,
    Combined30Separated70 = 9,
    Combined20Separated80 = 10,
    Combined10Separated90 = 11,
}

export function GetCollectionSystemTypeEnum(): typeof CollectionSystemTypeEnum
{
  return CollectionSystemTypeEnum;
}

export function CollectionSystemTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Completely Separated (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Completely Combined (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Combined 90% Separated 10% (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Combined 80% Separated 20% (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Combined 70% Separated 30% (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Combined 60% Separated 40% (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'Combined 50% Separated 50% (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Combined 40% Separated 60% (fr)' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Combined 30% Separated 70% (fr)' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Combined 20% Separated 80% (fr)' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Combined 10% Separated 90% (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Completely Separated' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Completely Combined' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Combined 90% Separated 10%' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Combined 80% Separated 20%' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Combined 70% Separated 30%' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Combined 60% Separated 40%' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: '' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Combined 40% Separated 60%' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Combined 30% Separated 70%' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Combined 20% Separated 80%' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Combined 10% Separated 90%' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function CollectionSystemTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let CollectionSystemTypeEnumText: string;
    CollectionSystemTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            CollectionSystemTypeEnumText = e.EnumText;
            return false;
        }
    });

    return CollectionSystemTypeEnumText;
}
