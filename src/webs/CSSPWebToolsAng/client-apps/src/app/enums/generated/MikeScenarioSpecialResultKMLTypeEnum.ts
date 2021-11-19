/*
 * Auto generated C:\CSSPTools\src\codegen\GenerateAngularEnums\bin\Debug\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum MikeScenarioSpecialResultKMLTypeEnum {
    Mesh = 1,
    StudyArea = 2,
    BoundaryConditions = 3,
    PollutionLimit = 4,
    PollutionAnimation = 5,
}

export function GetMikeScenarioSpecialResultKMLTypeEnum(): typeof MikeScenarioSpecialResultKMLTypeEnum
{
  return MikeScenarioSpecialResultKMLTypeEnum;
}

export function MikeScenarioSpecialResultKMLTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Grillage' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Région d\'étude' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Conditions aux limits' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Limit de pollution' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Animation de pollution' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Mesh' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Study area' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Boundary conditions' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Pollution limit' });
        enumTextOrderedList.push({ EnumID: 5, EnumText: 'Pollution animation' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function MikeScenarioSpecialResultKMLTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let MikeScenarioSpecialResultKMLTypeEnumText: string;
    MikeScenarioSpecialResultKMLTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            MikeScenarioSpecialResultKMLTypeEnumText = e.EnumText;
            return false;
        }
    });

    return MikeScenarioSpecialResultKMLTypeEnumText;
}
