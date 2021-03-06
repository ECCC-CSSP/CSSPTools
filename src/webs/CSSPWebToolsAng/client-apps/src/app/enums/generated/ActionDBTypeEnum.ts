/*
 * Auto generated C:\CSSPTools\src\codegen\_package\net5.0\GenerateAngularEnums.exe
 *
 * Do not edit this file.
 *
 */

import { AppLanguageService } from 'src/app/services/app/app-language.service';
import { EnumIDAndText } from 'src/app/models/generated/helper/EnumIDAndText.model';
import { LanguageEnum } from 'src/app/enums/generated/LanguageEnum';

export enum ActionDBTypeEnum {
    Create = 1,
    Read = 2,
    Update = 3,
    Delete = 4,
}

export function GetActionDBTypeEnum(): typeof ActionDBTypeEnum
{
  return ActionDBTypeEnum;
}

export function ActionDBTypeEnum_GetOrderedText(appLanguageService: AppLanguageService): EnumIDAndText[] {
    let enumTextOrderedList: EnumIDAndText[] = [];
    if (appLanguageService.Language == LanguageEnum.fr) {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Créer' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Lire' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Mettre à jour' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Effacer' });
    }
    else {
        enumTextOrderedList.push({ EnumID: 1, EnumText: 'Create' });
        enumTextOrderedList.push({ EnumID: 2, EnumText: 'Read' });
        enumTextOrderedList.push({ EnumID: 3, EnumText: 'Update' });
        enumTextOrderedList.push({ EnumID: 4, EnumText: 'Delete' });
    }

    return enumTextOrderedList.sort((a, b) => a.EnumText.localeCompare(b.EnumText));
}

export function ActionDBTypeEnum_GetIDText(enumID: number, appLanguageService: AppLanguageService): string {
    let ActionDBTypeEnumText: string;
    ActionDBTypeEnum_GetOrderedText(appLanguageService).forEach(e => {
        if (e.EnumID == enumID) {
            ActionDBTypeEnumText = e.EnumText;
            return false;
        }
    });

    return ActionDBTypeEnumText;
}
