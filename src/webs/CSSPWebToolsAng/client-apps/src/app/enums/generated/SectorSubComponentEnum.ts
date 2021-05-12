/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum SectorSubComponentEnum {
    Subsectors = 1,
    Files = 2,
    MIKEScenarios = 3,
}

export function GetSectorSubComponentEnum(): typeof SectorSubComponentEnum
{
  return SectorSubComponentEnum;
}

export function SectorSubComponentEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Sous-secteurs' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Fichiers' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Scénarios MIKE' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Subsectors' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Files' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'MIKE Scenarios' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function SectorSubComponentEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let SectorSubComponentEnumText: string;
    SectorSubComponentEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            SectorSubComponentEnumText = e.EnumText;
            return false;
        }
    });

    return SectorSubComponentEnumText;
}
