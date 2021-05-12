/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum BeaufortScaleEnum {
    Calm = 0,
    LightAir = 1,
    LightBreeze = 2,
    GentleBreeze = 3,
    ModerateBreeze = 4,
    FreshBreeze = 5,
    StrongBreeze = 6,
    HighWind_ModerateGale_NearGale = 7,
    Gale_FreshGale = 8,
    Strong_SevereGale = 9,
    Storm_WholeGale = 10,
    ViolentStorm = 11,
    HurricaneForce = 12,
}

export function GetBeaufortScaleEnum(): typeof BeaufortScaleEnum
{
  return BeaufortScaleEnum;
}

export function BeaufortScaleEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 0, EnumText: 'Calm (fr)' });
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Light air (fr)' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Light breeze (fr)' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Gentle breeze (fr)' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Moderate breeze (fr)' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Fresh breeze (fr)' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Strong breeze (fr)' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'High wind, moderate gale, near gale (fr)' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Gale, fresh gale (fr)' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Strong, severe gale (fr)' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Storm, whole gale (fr)' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Violent storm (fr)' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Hurricane force (fr)' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 0, EnumText: 'Calm' });
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Light air' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Light breeze' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Gentle breeze' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Moderate breeze' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Fresh breeze' });
        enumTextOrderedList.push({ EnumID: 6, EnumText: 'Strong breeze' });
        enumTextOrderedList.push({ EnumID: 7, EnumText: 'High wind, moderate gale, near gale' });
        enumTextOrderedList.push({ EnumID: 8, EnumText: 'Gale, fresh gale' });
        enumTextOrderedList.push({ EnumID: 9, EnumText: 'Strong, severe gale' });
        enumTextOrderedList.push({ EnumID: 10, EnumText: 'Storm, whole gale' });
        enumTextOrderedList.push({ EnumID: 11, EnumText: 'Violent storm' });
        enumTextOrderedList.push({ EnumID: 12, EnumText: 'Hurricane force' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function BeaufortScaleEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let BeaufortScaleEnumText: string;
    BeaufortScaleEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            BeaufortScaleEnumText = e.EnumText;
            return false;
        }
    });

    return BeaufortScaleEnumText;
}
