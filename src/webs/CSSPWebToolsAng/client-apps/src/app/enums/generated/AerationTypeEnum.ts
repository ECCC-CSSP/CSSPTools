/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum AerationTypeEnum {
    MechanicalAirLines = 1,
    MechanicalSurfaceMixers = 2,
}

export function GetAerationTypeEnum(): typeof AerationTypeEnum
{
  return AerationTypeEnum;
}

export function AerationTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Ligne d\'air méchanique' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Mélangeurs de surface mécaniques' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Mechanical Air Lines' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Mechanical Surface Mixers' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function AerationTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let AerationTypeEnumText: string;
    AerationTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            AerationTypeEnumText = e.EnumText;
            return false;
        }
    });

    return AerationTypeEnumText;
}
